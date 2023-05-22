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
using System.Reflection;

namespace ISPTF.API.Controllers.ExportADV
{
    public static class EXADVHelper
    {
        public async static Task<pExad> GetExad(ISPTFContext _context, string EXPORT_ADVICE_NO, string RECORD_TYPE, string REC_STATUS, int? EVENT_NO)
        {
            return await (
                    from row in _context.pExads
                    where
                    row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                    row.RECORD_TYPE == RECORD_TYPE &&
                    row.REC_STATUS == REC_STATUS &&
                    row.EVENT_NO == EVENT_NO
                    select row
                    ).AsNoTracking().FirstOrDefaultAsync();
        }

        public async static Task<pExad> InsertExad(ISPTFContext _context, pExad exad)
        {
            var tempExad = await GetExad(_context, exad.EXPORT_ADVICE_NO, exad.RECORD_TYPE, exad.REC_STATUS, exad.EVENT_NO);
            if(tempExad == null)
            {
                _context.pExads.Add(exad);
            }
            return exad;
        }

        public async static Task<int> UpdateExad(ISPTFContext _context, pExad exad)
        {
            var targetExad = await GetExad(_context, exad.EXPORT_ADVICE_NO, exad.RECORD_TYPE, exad.REC_STATUS, exad.EVENT_NO);
            if (targetExad != null)
            {
                _context.pExads.Update(targetExad);
            }
            return 0;
        }

        public async static Task<int> DeleteExad(ISPTFContext _context, pExad exad)
        {
            await (
                from row in _context.pExads
                where row.EXPORT_ADVICE_NO == exad.EXPORT_ADVICE_NO &&
                        row.RECORD_TYPE == exad.RECORD_TYPE &&
                        row.REC_STATUS == exad.REC_STATUS &&
                        row.EVENT_NO == exad.EVENT_NO
                select row).AsNoTracking().FirstOrDefaultAsync();
            _context.pExads.Remove(exad);
            return 0;
        }

        public async static Task<int> GetSeqNo(ISPTFContext _context, string EXPORT_ADVICE_NO)
        {
            var exad = await (
                from row in _context.pExads
                where
                row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                row.RECORD_TYPE == "MASTER"
                orderby row.EVENT_NO descending
                select row).FirstOrDefaultAsync();
            return exad.EVENT_NO + 1;
        }

        public async static Task<int> SaveDBM(ISPTFContext _context, pExad exad)
        {
            // Delete Master Exad
            var exads = await (
                from row in _context.pExads
                where
                row.EXPORT_ADVICE_NO == exad.EXPORT_ADVICE_NO &&
                row.RECORD_TYPE == "MASTER"
                select row).AsNoTracking().ToListAsync();
            foreach (var row in exads)
            {
                _context.pExads.Remove(row);
            }

            // Select EVENT Exad
            var event_exad = await (
                from row in _context.pExads
                where
                row.EXPORT_ADVICE_NO == exad.EXPORT_ADVICE_NO &&
                row.RECORD_TYPE == "EVENT"
                select row).AsNoTracking().FirstOrDefaultAsync();

            // Insert MASTER Exad
            if (event_exad!= null)
            {
                exad.RECORD_TYPE = "MASTER";
                _context.pExads.Add(exad);
            }
            return 0;
        }

        public static int InsertPPayDetails(ISPTFContext _context, pExad exad)
        {
            pPayDetail paydetail;
            var dpSeq = 1;
            if (exad.ADVICE_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "ADVICE L/C COMM.";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.AMEND_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "AMENDMENT L/C COMM.";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.TRANSFER_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "TRANSFER L/C COMM.";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.AMENDTRN_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "AMEND TRANSFER L/C COMM.";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.CABLE_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "CABLE CHARGE";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.CONFIRM_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "CONFIRM L/C COMM";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.OTHER_CHARGE != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "OTHER CHARGE";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.PAY_REFUND == "Y")
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "REFUND TAX AMT.";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
            }
            return 0;
        }
    }
}
