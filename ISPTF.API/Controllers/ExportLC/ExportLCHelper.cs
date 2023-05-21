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
    }
}
