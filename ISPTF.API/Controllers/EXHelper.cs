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
                select row).AsNoTracking().FirstOrDefaultAsync();
            return pPayment;
        }

        public async static Task<pTransfer> GetPTransfer(ISPTFContext _context, string EXPORT_ADVICE_NO, string REC_STATUS)
        {
            var pTransfer = await (
                from row in _context.pTransfers
                where
                row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                row.REC_STATUS == REC_STATUS
                select row).AsNoTracking().FirstOrDefaultAsync();
            return pTransfer;
        }

        public async static Task<String> GetReceiptNo(ISPTFContext _context, String USER_ID, String CENTER_ID, String cType = null)
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
            var mControl = await (
                from row in _context.mControls
                where
                row.CTL_Type == "FUNCT" &&
                row.CTL_Code == "PAID" &&
                row.CTL_ID == refTran
                orderby row.CTL_ID
                select row).AsNoTracking().FirstOrDefaultAsync();
            if (mControl == null)
            {
                prefix = "DDR";
            }
            else
            {
                prefix = mControl.CTL_Note1;
            }
            var pReferenceNO = await (
                from row in _context.pReferenceNos
                where
                row.pRefTrans == refTran &&
                row.pRefBran == CENTER_ID &&
                row.pRefYear == DateTime.Now.Year.ToString() &&
                row.pRefPrefix == prefix
                select row).AsNoTracking().FirstOrDefaultAsync();
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
                _context.pReferenceNos.Update(pReferenceNO);
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

        
    }
}
