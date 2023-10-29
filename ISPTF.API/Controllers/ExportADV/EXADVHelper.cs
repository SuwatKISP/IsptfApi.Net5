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
                    ).FirstOrDefaultAsync();
        }

        public async static Task<pExad> GetExadAmend(ISPTFContext _context, string EXPORT_ADVICE_NO)
        {
            int AmdSeq;
            AmdSeq = GetSeqNoAmend(_context,EXPORT_ADVICE_NO);
            return await (
                    from row in _context.pExads
                    where
                    row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                    row.RECORD_TYPE == "EVENT" &&
                    row.EVENT_NO == AmdSeq
                    select row
                    ).FirstOrDefaultAsync();
        }

        public async static Task<int> TestUpdate(ISPTFContext _context, string EXPORT_ADVICE_NO, string RECORD_TYPE, string REC_STATUS, int? EVENT_NO)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var pExad = await (
                    from row in _context.pExads
                    where
                    row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                    row.RECORD_TYPE == RECORD_TYPE &&
                    row.REC_STATUS == REC_STATUS &&
                    row.EVENT_NO == EVENT_NO
                    select row
                    ).FirstOrDefaultAsync();
                    pExad.EVENT_MODE = "X";
                    _context.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception e)
                {

                }
            }
            return 0;
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

        public static int GetSeqNo(ISPTFContext _context, string EXPORT_ADVICE_NO)
        {
            var exad = (
                from row in _context.pExads
                where
                row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                row.RECORD_TYPE == "MASTER"
                orderby row.EVENT_NO descending
                select row).AsNoTracking().FirstOrDefault();
            if(exad != null)
            {
                return exad.EVENT_NO + 1;
            }
            else
            {
                return 1;
            }
        }

        public static int GetSeqNoAmend(ISPTFContext _context, string EXPORT_ADVICE_NO)
        {
            var exad = (
                from row in _context.pExads
                where
                row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                row.RECORD_TYPE == "EVENT" &&  row.EVENT_TYPE == "Amend"
                orderby row.EVENT_NO descending
                select row).AsNoTracking().FirstOrDefault();
            if (exad != null)
            {
                return exad.EVENT_NO ;
            }
            else
            {
                return 0;
            }
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

        
    }
}
