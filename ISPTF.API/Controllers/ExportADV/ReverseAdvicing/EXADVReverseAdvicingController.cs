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
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXADVReverseAdvicingController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public EXADVReverseAdvicingController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }


        [HttpGet("list")]
        public async Task<ActionResult<ReverseAdvicingLCListPageResponse>> List(string? ListType, string? CenterID, string? EXPORT_ADVICE_NO, string? LC_NO, string? BENEFICIARY_ID, string? BENEFICIARY_INFO, string? Page, string? PageSize)
        {
            ReverseAdvicingLCListPageResponse response = new ReverseAdvicingLCListPageResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_ReverseAdvicingLCListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_ReverseAdvicingLCListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_ADVICE_NO", EXPORT_ADVICE_NO);
                param.Add("@LC_NO", LC_NO);
                param.Add("@BENEFICIARY_ID", BENEFICIARY_ID);
                param.Add("@BENEFICIARY_INFO", BENEFICIARY_INFO);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_ADVICE_NO == null)
                {
                    param.Add("@EXPORT_ADVICE_NO", "");
                }
                if (LC_NO == null)
                {
                    param.Add("@LC_NO", "");
                }
                if (BENEFICIARY_ID == null)
                {
                    param.Add("@BENEFICIARY_ID", "");
                }
                if (BENEFICIARY_INFO == null)
                {
                    param.Add("@BENEFICIARY_INFO", "");
                }

                var results = await _db.LoadData<Q_ReverseAdvicingLCListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXAD_ReverseAdvisingListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_ReverseAdvicingLCListPageRsp>)results;

                try
                {
                    response.Page = int.Parse(Page);
                    response.Total = response.Data[0].RCount;
                    response.TotalPage = Convert.ToInt32(Math.Ceiling(response.Total / decimal.Parse(PageSize)));
                }
                catch (Exception)
                {
                    response.Page = 0;
                    response.Total = 0;
                    response.TotalPage = 0;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_ReverseAdvicingLCListPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("select")]
        public async Task<ActionResult<PEXADPPaymentResponse>> Select(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
        {
            PEXADPPaymentResponse response = new();
            response.Data = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                return BadRequest(response);
            }

            try
            {
                // pExad
                var exad = await EXADVHelper.GetExad(_context, EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO);

                if (exad != null)
                {
                    // pPayment
                    if (exad.PAYMENT_INSTRU=="1")
                    {
                        response.Data.PPAYMENT = await EXHelper.GetPPayment(_context, exad.RECEIPT_NO);
                    }
                    response.Code = Constants.RESPONSE_OK;
                    response.Data.PEXAD = exad;
                    return Ok(response);
                }
                response.Message = "Export Advice L/C does not exist";
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            return BadRequest(response);
        }

        [HttpPost("delete")]
        public async Task<ActionResult<EXADVResultResponse>> Delete(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
        {
            EXADVResultResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                return BadRequest(response);
            }

            // Get USER_ID, CenterID
            var USER_ID = User.Identity.Name;
            var CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var pExadEvent = (from row in _context.pExads
                                          where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                row.RECORD_TYPE == RECORD_TYPE &&
                                                row.EVENT_NO == EVENT_NO &&
                                                row.REC_STATUS == REC_STATUS
                                          select row).AsNoTracking().FirstOrDefault();

                        if (pExadEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export Advice no does not exist.";
                            return BadRequest(response);
                        }

                        var seq = EVENT_NO;
                        // 1 - Update pPayment
                        if (pExadEvent.RECEIPT_NO != "")
                        {
                            var pPayment = (from row in _context.pPayments
                                            where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                                            select row).FirstOrDefault();
                            pPayment.RpStatus = "C";
                        }
                        // 2 - Delete pDailyGL
                        var pDailyGL = (from row in _context.pDailyGLs
                                        where row.VouchID == pExadEvent.VOUCH_ID &&
                                              row.VouchDate == pExadEvent.EVENT_DATE
                                        select row).ToList();
                        foreach (var row in pDailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        var pExadRelesed = (from row in _context.pExads
                                            where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                    row.EVENT_NO == seq &&
                                                    row.RECORD_TYPE == "R"
                                            select row).AsNoTracking().FirstOrDefault();
                        if (pExadRelesed == null)
                        {
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'T' WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND and RECORD_TYPE ='EVENT' and REC_STATUS in('P','W') AND EVENT_NO = {seq}");
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' AND EVENT_NO = {seq} WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND and RECORD_TYPE ='MASTER'");
                        }
                        else
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Can not delete MASTER of EVENT record is rec_status = R";
                            return BadRequest(response);
                        }

                        // Commit
                        await _context.SaveChangesAsync();
                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export Advice Deleted";
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            return BadRequest(response);
        }
    }
}