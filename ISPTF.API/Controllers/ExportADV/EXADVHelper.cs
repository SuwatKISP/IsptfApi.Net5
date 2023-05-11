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
using ISPTF.Models.LoginRegis;
using System.Transactions;
using Microsoft.AspNetCore.Http;

namespace ISPTF.API.Controllers.ExportADV
{
    public static class EXADVHelper
    {
        public async static Task<pExad> InsertIfNotExistExad(DbSet<pExad> pExads, pExad pexad)
        {
            var exad = await (
                       from row in pExads
                       where row.EXPORT_ADVICE_NO == pexad.EXPORT_ADVICE_NO &&
                             row.RECORD_TYPE == pexad.RECORD_TYPE &&
                             row.EVENT_NO == pexad.EVENT_NO
                       select row).FirstOrDefaultAsync();
            if (exad == null)
            {
                pExads.Add(pexad);
            }
            return pexad;
        }

        public async static Task<int> DeletePPayment(DbSet<pPayment> pPayments, string RECEIPT_NO)
        {
            var payments = (
                           from row in pPayments
                           where row.RpReceiptNo == RECEIPT_NO
                           select row).ToListAsync();
            foreach (var row in await payments)
            {
                pPayments.Remove(row);
            }
            return 1;
        }

        public async static Task<int> DeletePPayDetail(DbSet<pPayDetail> pPayDetails, string RECEIPT_NO)
        {
            var payDetails = (
                           from row in pPayDetails
                           where row.DpReceiptNo == RECEIPT_NO
                           select row).ToListAsync();
            foreach (var row in await payDetails)
            {
                pPayDetails.Remove(row);
            }
            return 1;
        }

        public async static Task<int> DeletePDailyGL(DbSet<pDailyGL> pDailyGLs, string VouchID, DateTime? EVENT_DATE)
        {
            var dailyGLs = (
                           from row in pDailyGLs
                           where
                           row.VouchID == VouchID &&
                           row.VouchDate == EVENT_DATE
                           select row).ToListAsync();
            foreach (var row in await dailyGLs)
            {
                pDailyGLs.Remove(row);
            }
            return 1;
        }

        public async static Task<pExad> GetExad(DbSet<pExad> pExads, string EXPORT_ADVICE_NO, string RECORD_TYPE, string REC_STATUS, int? EVENT_NO)
        {
            return await (
                    from row in pExads
                    where
                    row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                    row.RECORD_TYPE == RECORD_TYPE &&
                    row.REC_STATUS == REC_STATUS &&
                    row.EVENT_NO == EVENT_NO
                    select row
                    ).FirstOrDefaultAsync();
        }

        public async static Task<int> GetSeqNo(DbSet<pExad> pExads, string EXPORT_ADVICE_NO)
        {
            var exad = await (
                from row in pExads
                where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                        row.RECORD_TYPE == "MASTER"
                orderby row.EVENT_NO descending
                select row).FirstOrDefaultAsync();
            return exad.EVENT_NO + 1;
        }

        public async static Task<pExadSWIn> UpdateExadSWIn(DbSet<pExadSWIn> pExadSWIns, string sWiftInID, string RecStatus)
        {
            var exadswin = await (
                from row in pExadSWIns
                where row.SwifInID == sWiftInID
                select row).FirstOrDefaultAsync();
            exadswin.RecStatus = RecStatus;
            pExadSWIns.Update(exadswin);
            return exadswin;
        }
    }
}
