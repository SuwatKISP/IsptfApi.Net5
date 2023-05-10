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
                var exad = await (
                    from row in _context.pExads
                    where
                    row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                    row.RECORD_TYPE == RECORD_TYPE &&
                    row.REC_STATUS == REC_STATUS &&
                    row.EVENT_NO == EVENT_NO
                    select row
                    ).FirstOrDefaultAsync();

                if (exad != null)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Data = exad;
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

        [HttpPost("save")]
        public async Task<ActionResult<PEXADResponse>> Save([FromBody] PEXADRequest pexadreq, [FromBody] pPayment ppaymentreq)
        {
            PEXADResponse response = new();

            // Validate
            if (pexadreq == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "pExad is required.";
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
                        // -1 - Get Requirement
                        //pexadreq.RECEIPT_NO = ?
                        
                        // 0 - Insert exad if not exist #2861
                        var exad = (
                            from row in _context.pExads
                            where row.EXPORT_ADVICE_NO == pexadreq.EXPORT_ADVICE_NO &&
                                  row.RECORD_TYPE == pexadreq.RECORD_TYPE &&
                                  row.EVENT_NO == pexadreq.EVENT_NO
                            select row).FirstOrDefault();
                        if (exad == null)
                        {
                            _context.pExads.Add(exad);
                        }

                        // 1 - Delete pPayment, pPayDetail, pDailyGL if *UNPAID* #2980
                        if (exad.PAYMENT_INSTRU == "2")
                        {
                            var payments = (
                                from row in _context.pPayments
                                where row.RpReceiptNo == pexadreq.RECEIPT_NO
                                select row).ToListAsync();
                            foreach (var row in await payments)
                            {
                                _context.pPayments.Remove(row);
                            }

                            var payDetails = (
                                from row in _context.pPayDetails
                                where row.DpReceiptNo == pexadreq.RECEIPT_NO
                                select row).ToListAsync();
                            foreach (var row in await payDetails)
                            {
                                _context.pPayDetails.Remove(row);
                            }

                            var dailyGLs = (
                                from row in _context.pDailyGLs
                                where row.VouchID == pexadreq.VOUCH_ID &&
                                      row.VouchDate == pexadreq.EVENT_DATE
                                select row).ToListAsync();
                            foreach (var row in await dailyGLs)
                            {
                                _context.pDailyGLs.Remove(row);
                            }
                        }

                        // 2 - Insert pPayment if not exist #2989 #334
                        var payment = (
                            from row in _context.pPayments
                            where row.RpReceiptNo == pexadreq.EXPORT_ADVICE_NO
                            select row).FirstOrDefault();
                        if (payment == null)
                        {
                            _context.pPayments.Add(ppaymentreq);
                        }

                        // 3 - Delete pPayDetail and insert new #2989 #369
                        var paydetails = (from row in _context.pPayDetails
                                       where row.DpReceiptNo == pexadreq.RECEIPT_NO
                                       select row).ToListAsync();
                        foreach (var row in await paydetails)
                        {
                            _context.pPayDetails.Remove(row);
                        }

                        var dpSeq = 1;

                        pPayDetail paydetail;
                        if (pexadreq.ADVICE_COM != null)
                        {
                            paydetail = (
                                from row in _context.pPayDetails
                                where row.DpReceiptNo == pexadreq.RECEIPT_NO &&
                                      row.DpPayName == "Advice Comm."
                                select row).FirstOrDefault();
                            if (paydetail == null)
                            {
                                paydetail = new();
                                paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                                paydetail.DpSeq = dpSeq;
                                _context.pPayDetails.Add(paydetail);
                            }
                            paydetail.DpPayName = "ADVICE L/C COMM.";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Update(paydetail);
                            dpSeq++;
                        }
                        if (pexadreq.AMEND_COM != null)
                        {

                        }
                        if (pexadreq.TRANSFER_COM != null)
                        {

                        }
                        if (pexadreq.AMENDTRN_COM != null)
                        {

                        }
                        if (pexadreq.CABLE_COM != null)
                        {

                        }
                        if (pexadreq.CONFIRM_COM != null)
                        {

                        }
                        if (pexadreq.OTHER_CHARGE != null)
                        {

                        }
                        if (pexadreq.PAY_REFUND == "Y")
                        {

                        }
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
        }
    }
}
