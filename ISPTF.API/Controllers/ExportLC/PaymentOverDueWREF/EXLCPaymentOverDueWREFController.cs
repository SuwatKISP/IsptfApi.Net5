﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.ExportLC;
using ISPTF.Models.PEXPayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.ExportLC.PaymentOverDueWREF;
using System.Text.Json;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCPaymentOverDueWREFController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "20";
        private const string EVENT_TYPE = "Payment OverDue";
        public EXLCPaymentOverDueWREFController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCPaymentOverDueWREFListResponse>> List(string? ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        {
            EXLCPaymentOverDueWREFListResponse response = new EXLCPaymentOverDueWREFListResponse();

            // Validate
            if (string.IsNullOrEmpty(ListType) || 
                string.IsNullOrEmpty(CenterID) || 
                string.IsNullOrEmpty(Page) || 
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCPaymentOverDueWREFListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCPaymentOverDueWREFListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@ListType", @ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENName", BENName);
                param.Add("@USER_ID", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENName == null)
                {
                    param.Add("@BENName", "");
                }

                var results = await _db.LoadData<Q_EXLCPaymentOverDueWREFListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_PaymentOverDueWREFListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCPaymentOverDueWREFListPageRsp>)results;

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
                response.Data = new List<Q_EXLCPaymentOverDueWREFListPageRsp>();
            }
            return BadRequest(response);
        }

        //[HttpGet("query")]
        //public async Task<IEnumerable<Q_EXBCPurchasePaymentQueryPageRsp>> GetAllQuery( string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    //param.Add("@ListType", @ListType);
        //    param.Add("@CenterID", CenterID);
        //    param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
        //    param.Add("@BENName", BENName);
        //    param.Add("@USER_ID", USER_ID);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (EXPORT_BC_NO == null)
        //    {
        //        param.Add("@EXPORT_BC_NO", "");
        //    }
        //    if (BENName == null)
        //    {
        //        param.Add("@BENName", "");
        //    }

        //    var results = await _db.LoadData<Q_EXBCPurchasePaymentQueryPageRsp, dynamic>(
        //                storedProcedure: "usp_q_EXLC_PurchasePaymentQueryPage",
        //                param);
        //    return results;
        //}


        [HttpGet("select")]
        //        public async Task<IEnumerable<PEXBCPEXPaymentRsp>> GetAllSelect(string? EXPORT_BC_NO , string? EVENT_NO, string? LFROM)
        public async Task<ActionResult<EXLCPaymentOverDueWREFSelectResponse>> Select(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            EXLCPaymentOverDueWREFSelectResponse response = new EXLCPaymentOverDueWREFSelectResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || 
                EVENT_NO == null || 
                string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCPEXPaymentRsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@LFROM", LFROM);

                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPEXPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_PaymentOverDueWREF_Select",
                           param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PExLcRsp > 0 && !string.IsNullOrEmpty(pexlcpexpaymentrsp))
                {
                    PEXLCPEXPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPEXPaymentRsp>(pexlcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT L/C NO does not exit";
                    response.Data = new PEXLCPEXPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPEXPaymentRsp();
            }
            return Ok(response);
        }


        [HttpPost("save")]
        public async Task<ActionResult<PEXLCPPaymentPEXPaymentPPayDetailsSaveResponse>> Save([FromBody] PEXLCPPaymentPEXPaymentPPayDetailsSaveRequest data)
        {
            PEXLCPPaymentPEXPaymentPPayDetailsSaveResponse response = new();
            // Class validate

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {

                        // 0 - Select EXLC Master
                        var pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).FirstOrDefault();

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }

                        // 2 - Update Master
                        pExlcMaster.REC_STATUS = "P";
                        _context.SaveChanges();

                        var targetEventNo = pExlcMaster.EVENT_NO + 1;

                        // 2 - Insert EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow = data.PEXLC;


                        // 3 - Select Existing Event
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();


                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_NO = targetEventNo;
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = DateTime.Now; // With Time

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = DateTime.Today; // Without Time


                        if (eventRow.PAYMENT_INSTRU == "PAID")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;
                            // Call Save PaymentDetail
                        }
                        else
                        {
                            // UNPAID
                            eventRow.METHOD = "";

                            var existingPaymentRows = (from row in _context.pPayments
                                                       where row.RpReceiptNo == eventRow.RECEIVED_NO
                                                       select row).ToListAsync();
                            foreach (var row in await existingPaymentRows)
                            {
                                _context.pPayments.Remove(row);
                            }

                            var existingPPayDetailRows = (from row in _context.pPayDetails
                                                          where row.DpReceiptNo == eventRow.RECEIVED_NO
                                                          select row).ToListAsync();
                            foreach (var row in await existingPPayDetailRows)
                            {
                                _context.pPayDetails.Remove(row);
                            }

                        }

                        // Commit
                        if (pExlcEvent == null)
                        {
                            // Insert
                            _context.pExlcs.Add(eventRow);
                        }
                        else
                        {
                            // Update
                            _context.pExlcs.Update(eventRow);
                        }

                        await _context.SaveChangesAsync();


                        pExPayment exPaymentRow = data.PEXPAYMENT;
                        exPaymentRow.DOCNUMBER = data.PEXLC.EXPORT_LC_NO;
                        exPaymentRow.EVENT_NO = targetEventNo;
                        exPaymentRow.EVENT_TYPE = EVENT_TYPE;
                        exPaymentRow.REC_STATUS = "P";
                        exPaymentRow.CenterID = USER_CENTER_ID;

                        if (exPaymentRow.PAYMENT_INSTRU == "UNPAID")
                        {
                            exPaymentRow.Method = "";
                        }
                        // 3 - Select Existing Event
                        var pExPayment = (from row in _context.pExPayments
                                              where row.DOCNUMBER == data.PEXLC.EXPORT_LC_NO &&
                                                    (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                                    row.EVENT_TYPE == EVENT_TYPE &&
                                                    row.EVENT_NO == targetEventNo
                                              select row).AsNoTracking().FirstOrDefault();

                        // Commit
                        if (pExPayment == null)
                        {
                            // Insert
                            _context.pExPayments.Add(exPaymentRow);
                        }
                        else
                        {
                            // Update
                            _context.pExPayments.Update(exPaymentRow);
                        }

                        await _context.SaveChangesAsync();

                        // 4 - GL MOCK WAIT DLL

                        var glEvent = "CPAYMENT PURCHASE";
                        if(eventRow.WithOutFlag == "1")
                        {
                            if(eventRow.WithOutType == "U")
                            {
                                glEvent = "PAYMENT-ODU-UNISB";
                            }else if(eventRow.WithOutType == "A")
                            {
                                glEvent = "PAYMENT-ODU-UNAGB";
                            }
                        }

                        // CALL DLL
                        var glVouchId = "VOUCH ID FROM GL DLL" + " " + glEvent ;
                        eventRow.VOUCH_ID = glVouchId;
                        await _context.SaveChangesAsync();

                        transaction.Complete();

                        response.Code = Constants.RESPONSE_OK;

                        PEXLCPPaymentPEXPaymentPPayDetailDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PPAYMENT = data.PPAYMENT;
                        responseData.PEXPAYMENT = data.PEXPAYMENT;
                        responseData.PPAYDETAILS = data.PPAYDETAILS;

                        response.Data = responseData;
                        response.Message = "Export L/C Saved";
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException != null &&
                            e.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
                        {
                            // Key already exists
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC " + EVENT_TYPE + " Event Already exists / Wrong Event State";
                            return BadRequest(response);
                        }
                        else
                        {
                            // Rollback
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = e.ToString();
                            return BadRequest(response);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }

        }

        [HttpPost("delete")]
        public async Task<ActionResult<EXLCResultResponse>> Delete([FromBody] PEXLCDeleteRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();
            DynamicParameters param = new();

            // Validate
            if (string.IsNullOrEmpty(data.EXPORT_LC_NO) ||
                string.IsNullOrEmpty(data.EVENT_DATE)
                )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_DATE is required";
                return BadRequest(response);
            }


            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // 0 - Select EXLC MASTER
                        var pExlc = (from row in _context.pExlcs
                                     where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                           row.RECORD_TYPE == "MASTER"
                                     select row).FirstOrDefault();

                        if (pExlc == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export L/C does not exist";
                            return BadRequest(response);
                        }

                        // 1 - Cancel PPayment
                        var issueCollectExlc = (from row in _context.pExlcs
                                                where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                      row.RECORD_TYPE == "EVENT" &&
                                                      row.EVENT_TYPE == "Payment OverDue" &&
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
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'T' WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE = '{EVENT_TYPE}' AND REC_STATUS IN ('P','W')");


                        // 4 - Delete PExPayment
                        var targetEventNo = pExlc.EVENT_NO + 1;
                        var pExPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == "Payment OverDue" &&
                                                 row.EVENT_NO == targetEventNo
                                           select row).ToListAsync();

                        foreach (var row in await pExPayments)
                        {
                            _context.pExPayments.Remove(row);
                        }

                        // 5 - Update pExlc Master

                        // Commit
                        await _context.SaveChangesAsync();

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', EVENT_NO = {targetEventNo} WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE = 'MASTER'");

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
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }
        }
    }

}
