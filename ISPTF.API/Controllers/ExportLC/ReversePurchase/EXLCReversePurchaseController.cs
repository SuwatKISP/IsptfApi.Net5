﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.ExportLC;
using ISPTF.Models.PurchasePayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.ExportLC.ReverseCollection;
using System.Text.Json;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCReversePurchaseController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "10";
        private const string EVENT_TYPE = "Reverse";
        public EXLCReversePurchaseController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCAcceptTermDueListResponse>> List(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCAcceptTermDueListResponse response = new EXLCAcceptTermDueListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCAcceptTermDueListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCAcceptTermDueListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
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

                var results = await _db.LoadData<Q_EXLCAcceptTermDueListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_ReversePurchaseListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCAcceptTermDueListPageRsp>)results;

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
                response.Data = new List<Q_EXLCAcceptTermDueListPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("select")]
        public async Task<ActionResult<PEXLCPPaymentResponse>> Select(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXLCPPaymentResponse response = new PEXLCPPaymentResponse();
            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || string.IsNullOrEmpty(EVENT_NO) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCPPaymentRsp();
                return BadRequest(response);
            }

            DynamicParameters param = new();

            param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
            param.Add("@EVENT_NO", EVENT_NO);
            //param.Add("@RECORD_TYPE", RECORD_TYPE);
            //param.Add("@REC_STATUS", REC_STATUS);
            param.Add("@LFROM", LFROM);

            param.Add("@PExLcRsp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            param.Add("@PEXLCPPaymentRsp", dbType: DbType.String,
                       direction: System.Data.ParameterDirection.Output,
                       size: 5215585);
            try
            {
                var results = await _db.LoadData<PEXLCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_ReversePurchase_Select",
                           param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcppaymentrsp = param.Get<dynamic>("@PEXLCPPaymentRsp");

                if (PExLcRsp > 0 && !string.IsNullOrEmpty(pexlcppaymentrsp))
                {
                    PEXLCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPPaymentRsp>(pexlcppaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT L/C NO does not exit";
                    response.Data = new PEXLCPPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPPaymentRsp();
            }
            return BadRequest(response);
        }

        [HttpPost("save")]
        public async Task<ActionResult<PEXLCPPaymentPPayDetailsSaveResponse>> Save([FromBody] PEXLCPPaymentPPayDetailsSaveRequest data)
        {
            PEXLCPPaymentPPayDetailsSaveResponse response = new();
            // Class validate
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {

                        // 0 - Select EXLC Master
                        var pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == "Issue Purchase" &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).FirstOrDefault();

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Issue Purchase Master does not exists";
                            return BadRequest(response);
                        }


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
                                                (row.REC_STATUS == "P") &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();


                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_NO = targetEventNo;
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                      //  eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = UpdateDateT; // With Time
                        eventRow.IN_USE = 0;
                        eventRow.WithOutFlag = "N";
                        eventRow.WithOutType = null;
                        eventRow.Wref_Bank_ID = "";

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = UpdateDateNT; // Without Time

                        if (eventRow.PAYMENT_INSTRU == "PAID" || eventRow.PAYMENT_INSTRU == "BAHTNET")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;

                            if (eventRow.RECEIVED_NO == null || eventRow.RECEIVED_NO == "")
                            {
                                eventRow.RECEIVED_NO = ExportLCHelper.GenRefNo(_context, USER_CENTER_ID, USER_ID, "PAYD", UpdateDateT, UpdateDateNT);
                            }
                            // Call Save Payment
                            eventRow.RECEIVED_NO = ExportLCHelper.SavePayment(_context, USER_CENTER_ID, USER_ID, eventRow, data.PPAYMENT, UpdateDateT, UpdateDateNT);

                            // Call Save PaymentDetail

                            //if (eventRow.RECEIVED_NO != "ERROR") 
                            //{  

                            //   bool savePayDetailResult = ExportLCHelper.SavePaymentDetail(_context, eventRow, data.PPAYDETAILS);
                            //}
                        }
                        else
                        {
                            // UNPAID
                            eventRow.METHOD = "";
                            eventRow.RECEIVED_NO = "";
                            eventRow.VOUCH_ID = "";
                            var existingPaymentRows = (from row in _context.pPayments
                                                       where row.RpReceiptNo == eventRow.RECEIVED_NO
                                                       select row).ToList();
                            foreach (var row in existingPaymentRows)
                            {
                                _context.pPayments.Remove(row);
                            }

                            var existingPPayDetailRows = (from row in _context.pPayDetails
                                                          where row.DpReceiptNo == eventRow.RECEIVED_NO
                                                          select row).ToList();
                            foreach (var row in existingPPayDetailRows)
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


                        // GL MOCK WAIT DLL

                        transaction.Complete();
                        transaction.Dispose();

                        // Call PrintPostGL (Crystal Report)

                        response.Code = Constants.RESPONSE_OK;

                        PEXLCPPaymentPPayDetailDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PPAYMENT = data.PPAYMENT;
                        response.Data = responseData;
                        response.Message = "Export L/C Saved";

                        bool resGL;
                        bool resPayD;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = EVENT_TYPE;
                        eventDate = response.Data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        if (response.Data.PEXLC.PAYMENT_INSTRU == "PAID" || response.Data.PEXLC.PAYMENT_INSTRU == "BAHTNET")
                        {
                            if (data.PEXLC.WithOutFlag == "Y")
                            {
                                if (data.PEXLC.WithOutType == "F")
                                {
                                    GLEvent = EVENT_TYPE+ "-FUND";
                                }
                                if (data.PEXLC.WithOutType == "I")
                                {
                                    GLEvent = EVENT_TYPE + "-UNISB";
                                }
                                if (data.PEXLC.WithOutType == "A")
                                {
                                    GLEvent = EVENT_TYPE + "-UNAGB";
                                }
                            }

                            resVoucherID = ISPModule.GeneratrEXP.RevGLPayment(GLEvent, 1,
                            response.Data.PEXLC.EVENT_NO,responseData.PEXLC.EXPORT_LC_NO, eventDate);

                        }
                        else
                        {
                            resVoucherID = "";

                        }
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            response.Data.PEXLC.VOUCH_ID = resVoucherID;
                        }
                        else
                        {
                            resGL = false;
                        }

                        string resPayDetail;
                        if (response.Data.PPAYMENT != null)
                        {
                            resPayDetail = ISPModule.PayDetailEXLC.PayDetail_IssPurchase(response.Data.PEXLC.EXPORT_LC_NO, response.Data.PEXLC.EVENT_NO, response.Data.PEXLC.RECEIVED_NO);
                            if (resPayDetail != "ERROR")
                            {
                                resPayD = true;
                            }
                            else
                            {
                                resPayD = false;
                            }
                        }
                        else
                        {
                            resPayD = true;
                        }

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

        [HttpPost("release")]
        public async Task<ActionResult<EXLCResultResponse>> Release([FromBody] PEXLCSaveRequest data)
        {
            EXLCResultResponse response = new();
            // Class validate
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
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

                        // 1 - Check if Master+EVENT Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }

                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                row.REC_STATUS == "P" &&
                                                row.BUSINESS_TYPE == BUSINESS_TYPE &&
                                                row.EVENT_NO == data.PEXLC.EVENT_NO
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExlcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }
                        // 2 - Update Master
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlcMaster.AUTH_CODE = USER_ID;
                        pExlcMaster.AUTH_DATE = UpdateDateT; // With Time
                        pExlcMaster.UPDATE_DATE = UpdateDateT; // With Time
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.EVENT_MODE = "E";
                        pExlcMaster.GENACC_FLAG = "Y";
                        pExlcMaster.GENACC_DATE = UpdateDateNT;

                        await _context.SaveChangesAsync();

                        // 3 - Update Master/Event PK to Release
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'C',EVENT_NO ='{data.PEXLC.EVENT_NO}',EVENT_TYPE ='{EVENT_TYPE}'  WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");

                        // 3 - Update Master/Event PK to Release
                        pExlcEvent.AUTH_CODE = USER_ID;
                        pExlcEvent.AUTH_DATE = UpdateDateT; // With Time
                        await _context.SaveChangesAsync();
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R'  WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE='{EVENT_TYPE}' and  EVENT_NO = '{data.PEXLC.EVENT_NO}'");

                        // 4 - Update PPayment
                        var pPayments = (from row in _context.pPayments
                                         where row.RpReceiptNo == data.PEXLC.RECEIVED_NO
                                         select row).ToListAsync();

                        foreach (var row in await pPayments)
                        {
                            row.RpRecStatus = "R";
                        }
                        await _context.SaveChangesAsync();

                        // 5 - Update GL Flag
                        var gls = (from row in _context.pDailyGLs
                                   where row.VouchID == data.PEXLC.VOUCH_ID &&
                                            row.VouchDate == data.PEXLC.EVENT_DATE.GetValueOrDefault().Date
                                   select row).ToListAsync();

                        foreach (var row in await gls)
                        {
                            row.SendFlag = "R";
                        }
                        await _context.SaveChangesAsync();


                        transaction.Complete();
                        transaction.Dispose();

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Released";

                        string resCustLiab;
                        string eventDate;
                        string WithOut="";
                       
                        eventDate = data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        if (data.PEXLC.Wref_Bank_ID != null) WithOut = data.PEXLC.Wref_Bank_ID;
                        resCustLiab = ISPModule.CustLiabEXLC.EXLC_ReverseIssuePur(eventDate, "ISSUE", "SAVE", data.PEXLC.EXPORT_LC_NO, data.PEXLC.BENE_ID, 
                            data.PEXLC.CLAIM_TYPE.ToString(), "", data.PEXLC.DRAFT_CCY, data.PEXLC.DRAFT_AMT.ToString(), data.PEXLC.TOT_NEGO_AMT.ToString(), WithOut);

                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
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


                        // 1 - Delete Daily GL
                        var dailyGL = (from row in _context.pDailyGLs
                                       where row.VouchID == data.VOUCH_ID &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 2 - Update pExlc EVENT
                        var pExlcs = (from row in _context.pExlcs
                                      where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                            row.EVENT_TYPE == EVENT_TYPE &&
                                            row.REC_STATUS == "P" &&
                                            row.RECORD_TYPE == "EVENT"
                                      select row).ToListAsync();

                        foreach (var row in await pExlcs)
                        {
                            _context.pExlcs.Remove(row);
                        }


                        // 3 - Delete PExPayment
                        var targetEventNo = pExlc.EVENT_NO + 1;
                        var pExPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == EVENT_TYPE &&
                                                 row.EVENT_NO == targetEventNo
                                           select row).ToListAsync();

                        foreach (var row in await pExPayments)
                        {
                            _context.pExPayments.Remove(row);
                        }

                        // 4 - Update pExlc Master

                        // Commit
                        await _context.SaveChangesAsync();

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R',IN_USE =0 WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE = 'MASTER'");

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
