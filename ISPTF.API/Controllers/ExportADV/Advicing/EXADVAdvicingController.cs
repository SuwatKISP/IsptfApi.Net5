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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXADVAdvicingController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public EXADVAdvicingController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("select")]
        public async Task<ActionResult<PEXADResponse>> Select(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
        {
            PEXADResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                response.Data = new();
                return BadRequest(response);
            }

            try
            {
                // Select pExad
                var pExad = await (
                    from row in _context.pExads
                    where
                    row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                    row.RECORD_TYPE == RECORD_TYPE &&
                    row.REC_STATUS == REC_STATUS &&
                    row.EVENT_NO == EVENT_NO
                    select row
                    ).FirstOrDefaultAsync();

                if (pExad != null)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Data = pExad;
                    return Ok(response);
                }
                response.Message = "Export Advice L/C does not exist";
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            response.Data = new();
            return BadRequest(response);
        }

        /*[HttpPost("save")]
        public async Task<ActionResult<PEXADResponse>> Save([FromBody] PEXADRequest pexadreq)
        {
            PEXADResponse response = new();

            // Validate
            if (pexadreq == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "p is required.";
                response.Data = new();
                return BadRequest(response);
            }

            // Get USER_ID, CenterID
            pexadreq.USER_ID = User.Identity.Name;
            pexadreq.CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // 0 - Select existence pExad or Create new one #2861
                        var pExad = (
                            from row in _context.pExads
                            where row.EXPORT_ADVICE_NO == pexadreq.EXPORT_ADVICE_NO &&
                                  row.RECORD_TYPE == pexadreq.RECORD_TYPE &&
                                  row.EVENT_NO == pexadreq.EVENT_NO
                            select row).FirstOrDefault();
                        if (pExad == null)
                        {
                            _context.pExads.Add(pExad);
                        }


                        // 0 - Delete pExad MASTER
                        var pExad = (from row in _context.pExads
                                     where row.EXPORT_ADVICE_NO == pexadreq.EXPORT_ADVICE_NO &&
                                           row.RECORD_TYPE == "MASTER"
                                     select row).FirstOrDefault();

                        if (pExad == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export Advice no. does not exist";
                            return BadRequest(response);
                        }

                        // 1 - Cancel PPayment
                        var issueCollectExlc = (from row in _context.pExlcs
                                                where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                      row.RECORD_TYPE == "EVENT" &&
                                                      row.EVENT_TYPE == "Accept Due" &&
                                                      row.REC_STATUS == "P" &&
                                                      (row.RECEIVED_NO != null && row.RECEIVED_NO != "")
                                                select row).ToListAsync();

                        foreach (var row in await issueCollectExlc)
                        {
                            var pPayment = (from row2 in _context.pPayments
                                            where row2.RpReceiptNo == row.RECEIVED_NO
                                            select row2).ToListAsync();
                            foreach (var rowPayment in await pPayment)
                            {
                                rowPayment.RpStatus = "C";
                            }
                        }


                        // 2 - Delete Daily GL
                        var dailyGL = (from row in _context.pDailyGLs
                                       where row.VouchID == data.VOUCH_ID &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 3 - Update pExlc EVENT

                        var pExlcs = (from row in _context.pExlcs
                                      where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                            row.EVENT_TYPE == "Accept Due" &&
                                            (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                            row.RECORD_TYPE == "EVENT"
                                      select row).ToListAsync();

                        foreach (var row in await pExlcs)
                        {
                            row.REC_STATUS = "T";
                        }

                        // 4 - Update pExlc Master
                        var targetEventNo = pExlc.EVENT_NO + 1;
                        /* 
                        var pExlcMasters = (from row in _context.pExlcs
                                         where  row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "MASTER"
                                         select row).ToListAsync();

                        foreach (var row in await pExlcMasters)
                        {
                            row.REC_STATUS = "R";
                            //row.EVENT_NO = targetEventNo;
                        }

                        // Commit
                        await _context.SaveChangesAsync();
                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export L/C Deleted";
                    return Ok(response);
                }
            }
            catch(Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            response.Data = new();
            return BadRequest(response);
        }*/
    }
}
