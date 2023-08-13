using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportADV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace ISPTF.API.Controllers
{
    public static class EXHelper
    {
        public async static Task<pPayment> GetPPayment(ISPTFContext _context, string RECEIPT_NO)
        {
            var pPayment = await (
                from row in _context.pPayments
                where
                row.RpReceiptNo == RECEIPT_NO
                select row).FirstOrDefaultAsync();
            return pPayment;
        }

        public async static Task<pTransfer> GetPTransfer(ISPTFContext _context, string EXPORT_ADVICE_NO, string REC_STATUS)
        {
            var pTransfer = await (
                from row in _context.pTransfers
                where
                row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                row.REC_STATUS == REC_STATUS
                select row).FirstOrDefaultAsync();
            return pTransfer;
        }

        public static String GetReceiptNo(ISPTFContext _context, String USER_ID, String CENTER_ID, String cType = null)
        {
            String refTran;
            String prefix;
            if (cType == "C")
            {
                refTran = "PAYC";
            }
            else
            {
                refTran = "PAYD";
            }
            var mControl = (
                from row in _context.mControls
                where
                row.CTL_Type == "FUNCT" &&
                row.CTL_Code == "PAID" &&
                row.CTL_ID == refTran
                orderby row.CTL_ID
                select row).FirstOrDefault();
            if (mControl == null)
            {
                prefix = "DDR";
            }
            else
            {
                prefix = mControl.CTL_Note1;
            }
            var pReferenceNO =  (
                from row in _context.pReferenceNos
                where
                row.pRefTrans == refTran &&
                row.pRefBran == CENTER_ID &&
                row.pRefYear == DateTime.Now.Year.ToString() &&
                row.pRefPrefix == prefix
                select row).FirstOrDefault();
            if (pReferenceNO == null)
            {
                pReferenceNO = new();
                pReferenceNO.pRefTrans = refTran;
                pReferenceNO.pRefBran = CENTER_ID;
                pReferenceNO.pRefYear = DateTime.Now.Year.ToString();
                pReferenceNO.pRefPrefix = prefix;
                pReferenceNO.pRefSeq = 1;
                pReferenceNO.InUse = false;
                pReferenceNO.LastUpdate = DateTime.Now;
                pReferenceNO.UserCode = USER_ID;
                _context.pReferenceNos.Add(pReferenceNO);
            }
            else
            {
                pReferenceNO.pRefSeq = pReferenceNO.pRefSeq + 1;
                pReferenceNO.InUse = false;
                pReferenceNO.LastUpdate = DateTime.Now;
                pReferenceNO.UserCode = USER_ID;
            }
            int seq = pReferenceNO.pRefSeq.Value;
            return CENTER_ID + prefix + DateTime.Now.ToString("yy") + seq.ToString("000000");
        }

        public async static Task<pExadSWIn> UpdateExadSWIn(ISPTFContext _context, string SwifInID, string REC_STATUS)
        {
            var exadswin = await (
                from row in _context.pExadSWIns
                where row.SwifInID == SwifInID
                select row).AsNoTracking().FirstOrDefaultAsync();
            exadswin.RecStatus = REC_STATUS;
            _context.pExadSWIns.Update(exadswin);
            return exadswin;
        }

        public async static Task<int> DeletePPayment(ISPTFContext _context, string RECEIPT_NO)
        {
            var payments = (
                           from row in _context.pPayments
                           where row.RpReceiptNo == RECEIPT_NO
                           select row).AsNoTracking().ToListAsync();
            foreach (var row in await payments)
            {
                _context.pPayments.Remove(row);
            }
            return 0;
        }

        public async static Task<int> DeletePPayDetail(ISPTFContext _context, string RECEIPT_NO)
        {
            var payDetails = (
                           from row in _context.pPayDetails
                           where row.DpReceiptNo == RECEIPT_NO
                           select row).AsNoTracking().ToListAsync();
            foreach (var row in await payDetails)
            {
                _context.pPayDetails.Remove(row);
            }
            return 0;
        }

        public async static Task<int> DeletePDailyGL(ISPTFContext _context, string VOUCH_ID, DateTime? EVENT_DATE)
        {
            var dailyGLs = (
                           from row in _context.pDailyGLs
                           where
                           row.VouchID == VOUCH_ID &&
                           row.VouchDate == EVENT_DATE
                           select row).AsNoTracking().ToListAsync();
            foreach (var row in await dailyGLs)
            {
                _context.pDailyGLs.Remove(row);
            }
            return 0;
        }

        public static string GenSWNo(ISPTFContext _context)
        {
            var year = DateTime.Now.ToString("yy");
            var max = _context.pSWExports.Max(x => x.AutoNum);
            if(max == null)
            {
                return year + "00000001";
            }
            else
            {
                if (max.Substring(0, 2) == year)
                {
                    return year + (int.Parse(max.Substring(2, 8).TrimStart('0')) + 1).ToString("00000000.##");
                }
                else
                {
                    return year + "00000001";
                }
            }
        }

        public static double GetRateExChange(ISPTFContext _context, string ccy, int cType=0)
        {
            string time;
            DateTime date;

            var latestExch = (from row in _context.pExchanges
                                     where row.Exch_Date == DateTime.Today &&
                                           row.Exch_Ccy == ccy
                                     orderby row.Exch_Time descending
                                     select row).FirstOrDefault();

            if (latestExch == null)
            {
                latestExch = (from row in _context.pExchanges
                              where row.Exch_Ccy == ccy
                              orderby row.Exch_Date descending
                              orderby row.Exch_Time descending
                              select row).FirstOrDefault();
            }

            if (latestExch != null)
            {
                if(cType == 1)
                {
                    return latestExch.Exch_TRate1.Value;
                }
                else if(cType == 2)
                {
                    return latestExch.Exch_TRate2.Value;
                }
                else
                {
                    return latestExch.Exch_TRate3.Value;
                }
            }

            return 0.00;
        }

        public static double CompDiscRate(ISPTFContext _context, string cust, string mod, string exp, string ccy)
        {
            var custRate="";
            DateTime maxDate = DateTime.Today;
            bool isHasMaxDate = false;

            var mCustRate = (from row in _context.mCustRates
                             where row.Def_Cust == cust &&
                                   row.Def_Mod == mod &&
                                   row.Def_Exp == exp
                             select row).AsNoTracking().FirstOrDefault();
            if (mCustRate != null)
            {
                return mCustRate.Def_Rate.Value;
            }

            var mCustomer = (from row in _context.mCustomers
                             where row.Cust_Code == cust
                             select row).AsNoTracking().FirstOrDefault();
            if (mCustomer != null)
            {
                if (ccy == "THB")
                    custRate = mCustomer.IRateTHB;
                else
                    custRate = mCustomer.IRateCcy;
            }
            if (custRate != "")
                return 0.00;

            var pIntRate = (from row in _context.pIntRates
                            where row.IRate_Code == custRate
                            orderby row.IRate_EffDate descending
                            select row).AsNoTracking().FirstOrDefault();
            if (pIntRate!=null)
            {
                maxDate = pIntRate.IRate_EffDate;
                isHasMaxDate = true;
            }
            if(isHasMaxDate)
            {
                pIntRate = (from row in _context.pIntRates
                            where row.IRate_Code == custRate &&
                                  row.IRate_EffDate == maxDate
                            orderby row.IRate_EffTime descending
                            select row).AsNoTracking().FirstOrDefault();
                if (pIntRate != null)
                {
                    return pIntRate.IRate_Rate.Value;
                }
            }
            return 0.00;
        }

        public static double CompSpreadRate(ISPTFContext _context, string cust, string mod, string exp)
        {
            var mCustRate = (from row in _context.mCustRates
                             where row.Def_Cust == cust &&
                                   row.Def_Mod == mod &&
                                   row.Def_Exp == exp
                             select row).AsNoTracking().FirstOrDefault();
            if(mCustRate != null)
            {
                return mCustRate.Def_Rate.Value;
            }
            return 0.00;
        }

        public static string GenRefNo(ISPTFContext _context, string docTyp, string UserId, string CenterID, string cusNo="")
        {
            var refNo = "";
            var year = DateTime.Today.ToString("yy");
            var pRefNo = (from row in _context.pReferenceNos
                          where row.pRefTrans == docTyp.ToUpper() &&
                                row.pRefYear == year &&
                                row.pRefBran == CenterID
                          select row).AsNoTracking().FirstOrDefault();
            if(pRefNo!=null)
            {
                var xRun = pRefNo.pRefSeq + 1;
                refNo = CenterID + pRefNo.pRefPrefix + DateTime.Today.ToString("yy") + xRun.Value.ToString("000000");
            }
            return refNo;
        }

        public static string GetReceivedNo(ISPTFContext _context, string RpDocNo, string RpEvent)
        {
            var pPayment = (from row in _context.pPayments
                            where row.RpDocNo == RpDocNo &&
                                  row.RpEvent == RpEvent
                            select row).AsNoTracking().FirstOrDefault();
            if (pPayment != null)
                return pPayment.RpReceiptNo;
            else
                return "";
        }
    }
}
