using ISPTF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Transactions;

namespace ISPTF.API.Controllers.ExportLC
{
    public class ExportLCHelper
    {
        public static string GenerateRandomReceiptNo(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }

        public static async Task<bool> GLBalance(ISPTFContext context, DateTime VOUCH_DATE, string VOUCH_ID)
        {
            var dailyGLTranD = await (from row in context.pDailyGLs
                                      where row.VouchDate.Date == VOUCH_DATE.Date &&
                                      row.VouchID == VOUCH_ID &&
                                      row.TranNature == "D"
                                      select row).ToListAsync();

            var dailyGLTranC = await (from row in context.pDailyGLs
                                      where row.VouchDate.Date == VOUCH_DATE.Date &&
                                      row.VouchID == VOUCH_ID &&
                                      row.TranNature == "C"
                                      select row).ToListAsync();

            decimal sumAmtDRN = (decimal)dailyGLTranD.Sum(row => row.TranAmount);
            decimal sumAmtCRN = (decimal)dailyGLTranC.Sum(row => row.TranAmount);

            if (sumAmtDRN == sumAmtCRN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DateTime GetSysDate(ISPTFContext context)
        {
            string connectionString = context.Database.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT GETDATE()", connection))
                {
                    DateTime currentDate = (DateTime)command.ExecuteScalar();
                    return currentDate;
                }
            }
        }
        public static double GetExchangeRate(ISPTFContext context, string CCY, int? cType = null)
        {

            return 0;
        }

        public async static Task<bool> UpdateCustomerLiability(ISPTFContext _context, pExlc data)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // 0 - Select EXLC Master
                    var pExlcMaster = (from row in _context.pExlcs
                                       where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                             row.RECORD_TYPE == "MASTER"
                                       select row).FirstOrDefault();

                    // 1 - Check if Master Exists
                    if (pExlcMaster == null)
                    {
                        return false;
                    }

                    var approveFacility = pExlcMaster.FACNO;
                    if (string.IsNullOrEmpty(approveFacility))
                    {
                        approveFacility = "TFL9999";
                    }

                    // 2 - Update PCustLiability ODU
                    var cCCY = "ODU";
                    var exchangeRate = 1;
                    var CCYAmt = data.PRNBALANCE;
                    var BHTAmt = CCYAmt * exchangeRate;

                    var pCustLiabODU = await (from row in _context.pCustLiabs
                                              where row.Cust_Code == data.BENE_ID &&
                                                    row.Facility_No == approveFacility &&
                                                    row.Currency == cCCY
                                              select row).FirstOrDefaultAsync();

                    if (pCustLiabODU != null)
                    {
                        if (pCustLiabODU.XLCP_Amt == null)
                        {
                            pCustLiabODU.XLCP_Amt = 0;
                        }
                        pCustLiabODU.XLCP_Amt = pCustLiabODU.XLCP_Amt - CCYAmt;
                        pCustLiabODU.UpdateDate = DateTime.Now; // With Time
                    }


                    // 3 - Update PCustLiability THB
                    cCCY = "THB";
                    var pCustLiabTHB = await (from row in _context.pCustLiabs
                                              where row.Cust_Code == data.BENE_ID &&
                                                    row.Facility_No == approveFacility &&
                                                    row.Currency == cCCY
                                              select row).FirstOrDefaultAsync();
                    if (pCustLiabTHB == null)
                    {
                        pCustLiab row = new();
                        row.Cust_Code = data.BENE_ID;
                        row.Facility_No = approveFacility;
                        row.Currency = cCCY;
                        row.UpdateDate = DateTime.Now;
                        row.XLCP_Amt = CCYAmt;
                        _context.pCustLiabs.Add(row);
                    }
                    else if (pCustLiabTHB != null)
                    {
                        if (pCustLiabTHB.XLCP_Amt == null)
                        {
                            pCustLiabTHB.XLCP_Amt = 0;
                        }
                        pCustLiabTHB.XLCP_Amt = pCustLiabTHB.XLCP_Amt + CCYAmt;
                        pCustLiabTHB.UpdateDate = DateTime.Now; // With Time
                    }

                    await _context.SaveChangesAsync();


                    if (approveFacility.Contains("MX"))
                    {
                        await UpdateGroupWork(data.BENE_ID, approveFacility, true, _context);
                    }
                    else
                    {
                        await UpdateGroupWork(data.BENE_ID, approveFacility, false, _context);
                    }


                    transaction.Complete();
                    return true;
                }
                catch (Exception e)
                {
                    // Rollback
                    return false;
                }
            }
        }

        public async static Task<bool> UpdateGroupWork(string customerCode, string facilityNo, bool isGroup, ISPTFContext _context)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    double liabilityAmount = 0;
                    double shareUse = 0;
                    string shareType = "";
                    string shareFlag = "";
                    double partialAvailableAmount = 0;
                    double groupAmount = 0;
                    string parentCode = "";
                    string parentFacility = "";
                    string childCode = "";
                    string CCY = "";
                    double amount = 0;
                    double cAmountTHB = 0;

                    // 1 - Select Parent Code, Facility
                    if (isGroup == true)
                    {
                        var custLimit = await (from row in _context.pCustLimits
                                               where row.Cust_Code == customerCode &&
                                                     row.Facility_No == facilityNo
                                               select row).FirstOrDefaultAsync();
                        if (custLimit != null)
                        {
                            parentCode = custLimit.Cust_Code;
                            parentFacility = custLimit.Facility_No;
                        }
                    }
                    else if (isGroup == false)
                    {
                        parentCode = customerCode;
                        parentFacility = facilityNo;
                    }

                    // 2 - Select Share Type / Flag
                    var custLimitChild = await (from row in _context.pCustLimits
                                                where row.Cust_Code == parentCode &&
                                                      row.Facility_No == parentFacility
                                                select row).FirstOrDefaultAsync();

                    if (custLimitChild != null)
                    {
                        shareType = custLimitChild.Share_Type;
                        shareFlag = custLimitChild.Share_Flag;
                    }
                    else
                    {
                        shareFlag = "N";
                    }

                    if (shareFlag == "N")
                    {
                        return true;
                    }

                    // Call RevalueLiab(ParentCode)

                    // 3 - Update Credit_Amount,Origin_Amount (child)
                    var custShareChilds = await (from row in _context.pCustShares
                                                 where row.Cust_Code == parentCode &&
                                                       row.Facility_No == parentFacility
                                                 select row).ToListAsync();

                    foreach (var row in custShareChilds)
                    {
                        var custLimitChilds = await (from row2 in _context.pCustLimits
                                                     where row2.Cust_Code == row.Share_Cust &&
                                                           row2.Refer_Cust == row.Cust_Code &&
                                                           row2.Facility_No == row.Facility_No
                                                     select row2).ToListAsync();
                        foreach (var row2 in custLimitChilds)
                        {
                            row2.Ear_Amount = 0;
                            row2.Credit_Amount = row.Share_Credit;
                            row2.Origin_Amount = row.Share_Credit;
                        }
                    }

                    await _context.SaveChangesAsync();

                    // 4 - UPDATE Share_Amount =0 ,Share_Used =0 (parent)
                    var custLimitParents = await (from row in _context.pCustLimits
                                                  where row.Refer_Cust == parentCode &&
                                                        row.Refer_Facility == parentFacility &&
                                                        !string.IsNullOrEmpty(row.Refer_Cust) &&
                                                        !string.IsNullOrEmpty(row.Refer_Facility)
                                                  select row).Distinct().ToListAsync();
                    foreach (var row3 in custLimitParents)
                    {
                        var subCustLimits = await (from row in _context.pCustLimits
                                                   where row.Cust_Code == row3.Refer_Cust &&
                                                         row.Facility_No == row3.Refer_Facility
                                                   select row).ToListAsync();

                        foreach (var row in subCustLimits)
                        {
                            row.Share_Amount = 0;
                        }

                        var subCustShares = await (from row in _context.pCustShares
                                                   where row.Cust_Code == row3.Refer_Cust &&
                                                         row.Facility_No == row3.Refer_Facility
                                                   select row).ToListAsync();

                        foreach (var row in subCustShares)
                        {
                            row.Share_Used = 0;
                        }
                    }

                    await _context.SaveChangesAsync();

                    // 5 - Revaluate Liability
                    var custLimits = await (from row in _context.pCustLimits
                                            where row.Facility_No.Substring(0, 2) == "MX" &&
                                                  (row.Status == "A" || row.Status == "U") &&
                                                    row.Refer_Cust == parentCode &&
                                                    row.Refer_Facility == parentFacility
                                            select row).ToListAsync();

                    // Call RevalueLiab(rs!cust_code)
                    foreach (var row in custLimits)
                    {
                        var result = (from c in _context.pCustLSums
                                      where c.Cust_Code == row.Cust_Code && c.Facility_No == row.Facility_No
                                      select new
                                      {
                                          LiabAmt = (
                                              (c.IMLC_Amt ?? 0) + (c.DBE_Amt ?? 0) + (c.DLC_Amt ?? 0) + (c.IBLS_Amt ?? 0) +
                                              (c.IBLT_Amt ?? 0) + (c.IMTR_Amt ?? 0) + ((c.SGBC_Amt ?? 0) - (c.SGBC_Issued ?? 0)) +
                                              (c.EXPC_Amt ?? 0) + (c.XLCP_Amt ?? 0) + (c.XBCP_Amt ?? 0) + (c.IMLC_Book ?? 0) +
                                              (c.IMTR_Book ?? 0) + (c.DLC_Book ?? 0) + (c.SGBC_Book ?? 0) + (c.EXPC_Book ?? 0) +
                                              (c.XLCP_Book ?? 0) + (c.SBLC_Book ?? 0) + (c.LG_Book ?? 0) + (c.SBLC_Amt ?? 0) +
                                              (c.LG_Amt ?? 0) + (c.XBCP_Book ?? 0) + (c.IMBL_Over ?? 0) + (c.NCTR_Book ?? 0)
                                          )
                                      }).FirstOrDefault()?.LiabAmt ?? 0;

                        liabilityAmount = result;

                        row.Susp_Amount = liabilityAmount;

                        // 6 - Update selected Facility No. mother
                        var custLimitMothers = await (from rowMother in _context.pCustLimits
                                                      where rowMother.Refer_Cust == parentCode &&
                                                            rowMother.Refer_Facility == parentFacility
                                                      select rowMother).ToListAsync();
                        foreach(var row2 in custLimitMothers)
                        {
                            if(row2.Share_Amount == null)
                            {
                                row2.Share_Amount = 0;
                            }
                            row2.Share_Amount = (double)row2.Share_Amount + liabilityAmount;
                            shareUse = (double)row2.Share_Amount;

                            if(row2.Share_Type == null)
                            {
                                row2.Share_Type = "";
                            }
                            shareType = row2.Share_Type;

                            if(row2.Facility_Type == "T" && row2.Revol_Flag == "N")
                            {
                                row2.Credit_Amount = row2.Credit_Amount - liabilityAmount;
                            }
                        }

                        // 7 - CustShares
                        var custShares = await (from row3 in _context.pCustShares
                                                where row3.Cust_Code == row.Refer_Cust &&
                                                      row3.Share_Cust == row.Cust_Code &&
                                                      row3.Facility_No == row.Facility_No
                                                select row3).ToListAsync();

                        foreach(var row3 in custShares)
                        {
                            if(row3.Share_Used == null)
                            {
                                row3.Share_Used = 0;
                            }
                            row3.Share_Used = row3.Share_Used + liabilityAmount;
                        }

                        

                    }

                    await _context.SaveChangesAsync();

                    // 8 - For none fix
                    var custLimitNones = await (from row in _context.pCustLimits
                                            where row.Share_Flag == "Y" &&
                                                  row.Share_Type == "N" &&
                                                  row.Status != "D" &&
                                                  row.Cust_Code == parentCode &&
                                                  row.Facility_No == parentFacility
                                            select row).ToListAsync();

                    // No Use as of
                    //'        ParentCode = rsTmp!Cust_Code
                    //'        ParentFac = rsTmp!facility_no


                    // 9 - Update Share Group Child (Liability Child)

                    var viewCustLiabilities = await (from row in _context.ViewCustLiabs
                                               where row.Facility_No.StartsWith("MX") &&
                                                     row.Refer_Cust == parentCode &&
                                                     row.Refer_Facility == parentFacility
                                               select row).ToListAsync();

                    foreach(var row in viewCustLiabilities)
                    {
                        childCode = row.Cust_Code;
                        facilityNo = row.Facility_No;
                        CCY = row.Currency;
                        amount = row.Liability;

                        if (CCY == "ODU" || 
                            CCY == "PDU" || 
                            CCY == "THB")
                        {
                            cAmountTHB = Math.Truncate(amount * 100) / 100;
                        }
                        else
                        {
                            /** GetRateExChange(CCY)*/
                            cAmountTHB = Math.Truncate(amount * 100) / 100;
                        }
                    }

                    
                    var custLimitChilds2 = await (from row in _context.pCustLimits
                                                where row.Refer_Cust == parentCode &&
                                                      row.Status != "I" &&
                                                      row.Cust_Code != childCode &&
                                                      row.Facility_No == parentFacility
                                                select row).ToListAsync();

                    foreach(var row in custLimitChilds2)
                    {
                        if(row.Ear_Amount == null)
                        {
                            row.Ear_Amount = 0;
                        }
                        row.Ear_Amount = row.Ear_Amount + cAmountTHB;
                        if(row.Ear_Amount < 0)
                        {
                            row.Ear_Amount = 0;
                        }
                        row.Share_Amount = 0;
                    }


                    // 10 - Update Share Group Parent

                    var viewCustLiabilityParents = await (from row in _context.ViewCustLiabs
                                                     where row.Cust_Code == parentCode &&
                                                           row.Facility_No == parentFacility
                                                     select row).ToListAsync();
                    foreach (var row in viewCustLiabilityParents)
                    {
                        childCode = row.Cust_Code;
                        facilityNo = row.Facility_No;
                        CCY = row.Currency;
                        amount = row.Liability;

                        if (CCY == "ODU" ||
                            CCY == "PDU" ||
                            CCY == "THB")
                        {
                            cAmountTHB = Math.Truncate(amount * 100) / 100;
                        }
                        else
                        {
                            /** GetRateExChange(CCY)*/
                            cAmountTHB = Math.Truncate(amount * 100) / 100;
                        }
                    }

                    var custLimitParents2 = await (from row in _context.pCustLimits
                                                 where row.Refer_Cust == parentCode &&
                                                       row.Status != "I" &&
                                                       row.Cust_Code != childCode &&
                                                       row.Facility_No == parentFacility
                                                 select row).ToListAsync();

                    foreach (var row in custLimitParents2)
                    {
                        if (row.Ear_Amount == null)
                        {
                            row.Ear_Amount = 0;
                        }
                        row.Ear_Amount = row.Ear_Amount + cAmountTHB;
                        if (row.Ear_Amount < 0)
                        {
                            row.Ear_Amount = 0;
                        }
                        row.Share_Amount = 0;
                    }

                    await _context.SaveChangesAsync();

                    // 11 - Update Group Amount

                    var groupCustLimits = await (from row in _context.pCustLimits
                                                     where !row.Facility_No.StartsWith("MX") &&
                                                           row.Share_Flag == "Y" &&
                                                           row.Share_Type == "F" &&
                                                           row.Cust_Code != childCode &&
                                                           row.Facility_No == parentFacility
                                                      select row).ToListAsync();

                    foreach(var row in groupCustLimits)
                    {
                        var result = (from c in _context.ViewCreditLimits
                                      where c.Cust_Code == parentCode && 
                                            c.Facility_No == parentFacility
                                      select new
                                      {
                                          Credit_Share = c.Credit_Share ?? 0,
                                          Available_Amt = c.Available_Amt
                                      }).FirstOrDefault();

                        partialAvailableAmount = result.Available_Amt;
                    }

                    var groupCustLimitPartials = await (from row in _context.pCustLimits
                                                        where row.Status != "I" &&
                                                              row.Refer_Cust != parentCode &&
                                                              row.Refer_Facility == parentFacility
                                                        select row).ToListAsync();

                    foreach(var row in groupCustLimitPartials)
                    {
                        groupAmount = (double)(row.Credit_Amount - row.Susp_Amount - partialAvailableAmount);
                        if (groupAmount < 0)
                        {
                            groupAmount = 0;
                        }
                        row.Ear_Amount = groupAmount;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    // Rollback
                    return false;
                }
            }
        }
    }
}
