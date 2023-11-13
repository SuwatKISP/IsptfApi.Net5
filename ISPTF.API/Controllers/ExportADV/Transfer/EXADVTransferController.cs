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
using ISPTF.API.Controllers.ExportLC;

namespace ISPTF.API.Controllers.ExportADV
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXADVTransferController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
        public EXADVTransferController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<TransferLCListPageResponse>> List(string? TypeLC, string? ListType, string? CenterID, string? EXPORT_ADVICE_NO, string? LC_NO, string? BENEFICIARY_ID, string? BENEFICIARY_INFO, string? Page, string? PageSize)
        {
            TransferLCListPageResponse response = new TransferLCListPageResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(TypeLC) || string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "TypeLC, ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_TransferLCListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_TransferLCListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@TypeLC", TypeLC);
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

                var results = await _db.LoadData<Q_TransferLCListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXAD_TransferLCListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_TransferLCListPageRsp>)results;

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
                response.Data = new List<Q_TransferLCListPageRsp>();
            }
            return BadRequest(response);
        }

        //[HttpGet("listTransfer")]
        //public async Task<ActionResult<TransferLCListPageResponse>> ListTransfer(string? TypeLC, string? ListType, string? CenterID, string? EXPORT_ADVICE_NO, string? LC_NO, string? BENEFICIARY_ID, string? BENEFICIARY_INFO, string? Page, string? PageSize)
        //{
        //    TransferLCListPageResponse response = new TransferLCListPageResponse();
        //    var USER_ID = User.Identity.Name;
        //    //var USER_ID = "API";
        //    // Validate
        //    if (string.IsNullOrEmpty(TypeLC) || string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
        //    {
        //        response.Code = Constants.RESPONSE_FIELD_REQUIRED;
        //        response.Message = "TypeLC, ListType, CenterID, Page, PageSize is required";
        //        response.Data = new List<Q_TransferLCListPageRsp>();
        //        return BadRequest(response);
        //    }
        //    if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
        //    {
        //        response.Code = Constants.RESPONSE_FIELD_REQUIRED;
        //        response.Message = "USER_ID is required";
        //        response.Data = new List<Q_TransferLCListPageRsp>();
        //        return BadRequest(response);
        //    }

        //    // Call Store Procedure
        //    try
        //    {
        //        DynamicParameters param = new();
        //        param.Add("@TypeLC", TypeLC);
        //        param.Add("@ListType", ListType);
        //        param.Add("@CenterID", CenterID);
        //        param.Add("@EXPORT_ADVICE_NO", EXPORT_ADVICE_NO);
        //        param.Add("@LC_NO", LC_NO);
        //        param.Add("@BENEFICIARY_ID", BENEFICIARY_ID);
        //        param.Add("@BENEFICIARY_INFO", BENEFICIARY_INFO);
        //        param.Add("@UserCode", USER_ID);
        //        param.Add("@Page", Page);
        //        param.Add("@PageSize", PageSize);

        //        if (EXPORT_ADVICE_NO == null)
        //        {
        //            param.Add("@EXPORT_ADVICE_NO", "");
        //        }
        //        if (LC_NO == null)
        //        {
        //            param.Add("@LC_NO", "");
        //        }
        //        if (BENEFICIARY_ID == null)
        //        {
        //            param.Add("@BENEFICIARY_ID", "");
        //        }
        //        if (BENEFICIARY_INFO == null)
        //        {
        //            param.Add("@BENEFICIARY_INFO", "");
        //        }

        //        var results = await _db.LoadData<Q_TransferLCListPageRsp, dynamic>(
        //                    storedProcedure: "usp_q_EXAD_TransferLCListPage",
        //                    param);

        //        response.Code = Constants.RESPONSE_OK;
        //        response.Message = "Success";
        //        response.Data = (List<Q_TransferLCListPageRsp>)results;

        //        try
        //        {
        //            response.Page = int.Parse(Page);
        //            response.Total = response.Data[0].RCount;
        //            response.TotalPage = Convert.ToInt32(Math.Ceiling(response.Total / decimal.Parse(PageSize)));
        //        }
        //        catch (Exception)
        //        {
        //            response.Page = 0;
        //            response.Total = 0;
        //            response.TotalPage = 0;
        //        }
        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        response.Code = Constants.RESPONSE_ERROR;
        //        response.Message = e.ToString();
        //        response.Data = new List<Q_TransferLCListPageRsp>();
        //    }
        //    return BadRequest(response);
        //}
        [HttpGet("listtransfer")]
        public async Task<ActionResult<TransferLCListPageResp>> ListTransfer(string? EXPORT_ADVICE_NO, string? RECORD_TYPE,string REC_STATUS, int? EVENT_NO, string? Page, string? PageSize)
        {
            TransferLCListPageResp response = new TransferLCListPageResp();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO  ==null|| string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE,REC_STATUS, EVENT_NO, Page, PageSize is required";
                response.Data = new List<Q_TransferLCListPageResp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@EXPORT_ADVICE_NO", EXPORT_ADVICE_NO);
                param.Add("@RECORD_TYPE", RECORD_TYPE);
                param.Add("@REC_STATUS", REC_STATUS);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                var results = await _db.LoadData<Q_TransferLCListPageResp, dynamic>(
                            storedProcedure: "[usp_q_EXAD_TransferLCListUnder]",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_TransferLCListPageResp>)results;

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
                response.Data = new List<Q_TransferLCListPageResp>();
            }
            return BadRequest(response);
        }



        [HttpGet("select")]
        public async Task<ActionResult<PEXADPTransferResponse>> Select(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO, string ADVICE_TYPE)
        {
            PEXADPTransferResponse response = new();
            response.Data = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null || ADVICE_TYPE == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS,ADVICE_TYPE, EVENT_NO is required";
                return BadRequest(response);
            }

            try
            {
                // pExad
                var pExadMaster = (from row in _context.pExads
                                   where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                         row.RECORD_TYPE == "MASTER"
                                   select row).AsNoTracking().FirstOrDefault();
                pExad exad = new pExad();
                if (RECORD_TYPE=="MASTER")
                {
                     exad = await EXADVHelper.GetExad(_context, EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, pExadMaster.EVENT_NO);

                }
                else
                {
                    if (REC_STATUS=="P")
                    {
                         exad = await EXADVHelper.GetExad(_context, EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, pExadMaster.EVENT_NO + 1);

                    }
                    else
                    {
                         exad = await EXADVHelper.GetExad(_context, EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO + 1);

                    }
                }
                if (exad != null)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Data.PEXAD = exad;
                    response.Data.ADVICE_TYPE = ADVICE_TYPE;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export Advice L/C does not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            return BadRequest(response);
        }

        //[HttpGet("select")]
        //public async Task<ActionResult<PEXADPTransferResponse>> Select(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO, string ADVICE_TYPE)
        //{
        //    //PEXADPTransferResponse response = new();
        //    //response.Data = new();
        //    PEXADPTransferResponse response = new PEXADPTransferResponse();

        //    // Validate
        //    if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null || ADVICE_TYPE == null)
        //    {
        //        response.Code = Constants.RESPONSE_FIELD_REQUIRED;
        //        response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS,ADVICE_TYPE, EVENT_NO is required";
        //        return BadRequest(response);
        //    }

        //    // Call Store Procedure
        //    try
        //    {
        //        DynamicParameters param = new();

        //        param.Add("@EXPORT_ADVICE_NO", EXPORT_ADVICE_NO);
        //        param.Add("@EVENT_NO", EVENT_NO);
        //        param.Add("@ADVICE_TYPE", ADVICE_TYPE);

        //        param.Add("@TranRsp", dbType: DbType.Int32,
        //           direction: System.Data.ParameterDirection.Output,
        //           size: 12800);
        //        param.Add("@TranSONRsp", dbType: DbType.String,
        //           direction: System.Data.ParameterDirection.Output,
        //           size: 5215585);


        //        var results = await _db.LoadData<PEXADPTransferDataContainer, dynamic>(
        //                       storedProcedure: "usp_pExad_Transfer_Select",
        //                       param);  

        //        var TranRsp = param.Get<dynamic>("@TranRsp");
        //        var Tranjsonrsp = param.Get<dynamic>("@TranSONRsp");

        //        if (TranRsp > 0 && !string.IsNullOrEmpty(Tranjsonrsp))
        //        {
        //            PEXADPTransferDataContainer jsonResponse = JsonSerializer.Deserialize<PEXADPTransferDataContainer>(Tranjsonrsp);
        //            response.Code = Constants.RESPONSE_OK;
        //            response.Message = "Success";
        //            response.Data = jsonResponse;
        //            response.Data.ADVICE_TYPE = ADVICE_TYPE;
        //            return Ok(response);
        //        }
        //        else
        //        {

        //            response.Code = Constants.RESPONSE_ERROR;
        //            response.Message = "Error selecting Transfer";
        //            response.Data = new PEXADPTransferDataContainer();
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response.Code = Constants.RESPONSE_ERROR;
        //        response.Message = e.ToString();
        //        response.Data = new PEXADPTransferDataContainer();
        //    }
        //    return BadRequest(response);
        //}

        [HttpGet("selecttransfer")]
        public async Task<ActionResult<PEXADSelectPTransferResponse>> SelectTransfer(string? EXPORT_ADVICE_NO, int? SEQ_TRANSFER, int? EVENT_NO,string ADVICE_TYPE)
        {
            PEXADSelectPTransferResponse response = new();
            response.Data = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || SEQ_TRANSFER ==null || EVENT_NO == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, SEQ_TRANSFER, EVENT_NO is required";
                return BadRequest(response);
            }

            try
            {
                // pExad
                var exadtran = await EXADVHelper.SelectTransafer(_context, EXPORT_ADVICE_NO, SEQ_TRANSFER, EVENT_NO);
                if (exadtran != null)
                {
                    var pPaymentEvent = (from row in _context.pPayments
                                         where row.RpReceiptNo == exadtran.RECEIPT_NO
                                         select row).AsNoTracking().FirstOrDefault();

                    response.Code = Constants.RESPONSE_OK;
                    //response.Data.PEXAD = exad;
                    response.Data.PTRANSFER = exadtran;
                    response.Data.PPAYMENT = pPaymentEvent;
                    response.Data.ADVICE_Type = ADVICE_TYPE;
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

        [HttpPost("save")]
        public ActionResult<PEXADPPaymentTranResponse> Save([FromBody] PEXADPTransferPaymentRequest pexadppaymentrequest)
        {
            PEXADPPaymentTranResponse response = new();
            response.Data = new();
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            // Validate
            if (pexadppaymentrequest.pExad == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "pExad is required.";
                response.Data = new();
                return BadRequest(response);
            }

            // Get USER_ID, CenterID
            pexadppaymentrequest.pExad.USER_ID = User.Identity.Name;
            pexadppaymentrequest.pExad.CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();
            pexadppaymentrequest.pTransfer.USER_ID = User.Identity.Name;
            pexadppaymentrequest.pTransfer.CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // Get Requirement
                        int GetSeqNo = EXADVHelper.GetSeqNo(_context, pexadppaymentrequest.pExad.EXPORT_ADVICE_NO);
                        pTransfer pTransferEvent = new pTransfer();
                        pExad pExadEvent = new pExad();
                        if (pexadppaymentrequest.pExad.TRANSACTION_TYPE=="5")
                        {
                             pTransferEvent = Transfer_save(pexadppaymentrequest.pTransfer, pexadppaymentrequest.pPayment, GetSeqNo, "EVENT", "Transfer", "P", UpdateDateT, UpdateDateNT);
                            if (pTransferEvent == null)
                            {
                                transaction.Dispose();
                                response.Code = Constants.RESPONSE_ERROR;
                                response.Message = "Error for pTranser";
                                return BadRequest(response);
                            }
                            else
                            {
                                 pExadEvent = SaveUser(pexadppaymentrequest.pExad, pexadppaymentrequest.pPayment, GetSeqNo, "EVENT", "Transfer", "P", UpdateDateT, UpdateDateNT);
                                pExadEvent.RECEIPT_NO = pTransferEvent.RECEIPT_NO;
                                pExadEvent.VOUCH_ID = pTransferEvent.VOUCH_ID;
                            }
                        }
                        else if (pexadppaymentrequest.pExad.TRANSACTION_TYPE == "6")
                        {

                             pTransferEvent = Transfer_save(pexadppaymentrequest.pTransfer, pexadppaymentrequest.pPayment, GetSeqNo, "EVENT", "Amend Transfer", "P", UpdateDateT, UpdateDateNT);
                            if (pTransferEvent == null)
                            {
                                transaction.Dispose();
                                response.Code = Constants.RESPONSE_ERROR;
                                response.Message = "Error for pTranser";
                                return BadRequest(response);
                            }
                            else
                            {
                                 pExadEvent = SaveUser(pexadppaymentrequest.pExad, pexadppaymentrequest.pPayment, GetSeqNo, "EVENT", "Amend Transfer", "P", UpdateDateT, UpdateDateNT);
                            }
                        }

                        // Commit
                        _context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();

                        bool resGL;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = pTransferEvent.EVENT_TYPE;
                        eventDate = pTransferEvent.EVENT_DATE.Value.ToString("dd/MM/yyyy",engDateFormat);
                        if (pExadEvent.PAYMENT_INSTRU == "1")
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXAD(pTransferEvent.EXPORT_ADVICE_NO,
                                eventDate, GLEvent, pTransferEvent.EVENT_NO, "TRANSFER");
                        }
                        else
                        {
                            resVoucherID = "";
                        }
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            pTransferEvent.VOUCH_ID = resVoucherID;
                            pExadEvent.VOUCH_ID = resVoucherID;
                        }
                        else
                        {
                            resGL = false;
                        }
                        if (resGL == false)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Error for G/L";
                            response.Data = new();
                            return BadRequest(response);
                        }

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export Advice Saved";
                        response.Data.PEXAD = pExadEvent;
                        var pPaymentEvent = (from row in _context.pPayments
                                             where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                                             select row).AsNoTracking().FirstOrDefault();
                        response.Data.PPAYMENT = pPaymentEvent;
                        response.Data.PTRANSFER = pTransferEvent;
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }

                }
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            response.Data = new();
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

                        var pExadRelesed = (from row in _context.pExads
                                            where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                    row.EVENT_NO == seq &&
                                                    row.RECORD_TYPE == "R"
                                            select row).AsNoTracking().FirstOrDefault();
                        if (pExadRelesed == null)
                        {
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'T' WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE = 'EVENT' AND REC_STATUS IN ('P','W') AND EVENT_NO = {seq}");
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pTransfer Set REC_STATUS ='T' where EXPORT_ADVICE_NO= '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE = 'EVENT' AND REC_STATUS='P' AND EVENT_NO = {seq}");
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' AND EVENT_NO = {seq} WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE ='MASTER'");
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

        [HttpPost("deletetransfer")]
        public async Task<ActionResult<EXADVResultResponse>> DeleteTransfer(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO,int? SEQ_TRANSFER)
        {
            EXADVResultResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO==null  || SEQ_TRANSFER ==null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO,SEQ_TRANSFER is required";
                return BadRequest(response);
            }

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var pTranser = (from row in _context.pTransfers
                                          where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                row.RECORD_TYPE == RECORD_TYPE &&
                                                row.EVENT_NO == EVENT_NO &&
                                                row.REC_STATUS == "P" &&
                                                row.SEQ_TRANSFER== SEQ_TRANSFER
                                        select row).AsNoTracking().FirstOrDefault();

                        if (pTranser == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Transfer Advice no does not exist.";
                            return BadRequest(response);
                        }

                       await _context.Database.ExecuteSqlRawAsync($"Delete pTransfer  where EXPORT_ADVICE_NO= '{pTranser.EXPORT_ADVICE_NO}' AND RECORD_TYPE = '{RECORD_TYPE}' AND REC_STATUS='P' AND EVENT_NO = {EVENT_NO} and SEQ_TRANSFER ={SEQ_TRANSFER} ");


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

        [HttpPost("release")]
        public async Task<ActionResult<EXADVResultResponse>> Release(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
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
                        // Get Requirement
                        var pExadEvent_temp = (from row in _context.pExads
                                               where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                     row.RECORD_TYPE == "EVENT" &&
                                                     row.EVENT_NO == EVENT_NO
                                               select row).AsNoTracking().FirstOrDefault();

                        if (pExadEvent_temp == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export Advice no does not exist.";
                            return BadRequest(response);
                        }

                        // var seq = EVENT_NO;
                        var seq = EXADVHelper.GetSeqNo(_context, pExadEvent_temp.EXPORT_ADVICE_NO);

                        var pExadEvent = (from row in _context.pExads
                                          where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                              row.RECORD_TYPE == "EVENT" &&
                                              row.EVENT_NO == seq
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExadEvent != null)
                        {
                            pExadEvent.USER_ID = USER_ID;
                            pExadEvent.CenterID = CenterID;
                            pExadEvent = SaveSup(pExadEvent);
                            _context.pExads.Update(pExadEvent);
                        }

                        var pExadMaster = (from row in _context.pExads
                                           where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                   row.RECORD_TYPE == "MASTER" 
                                           select row).AsNoTracking().FirstOrDefault();
                        if (pExadMaster != null)
                        {
                            pExadMaster.USER_ID = USER_ID;
                            pExadMaster.CenterID = CenterID;
                            if (pExadEvent.TRANSACTION_TYPE == "5")
                            {
                                pExadMaster = SaveMaster(pExadMaster, pExadEvent, "Transfer");
                            }
                            else if (pExadEvent.TRANSACTION_TYPE == "6")
                            {
                                pExadMaster = SaveMaster(pExadMaster, pExadEvent, "Amend Transfer");
                            }
                            _context.pExads.Update(pExadMaster);
                        }

                        // Commit
                        await _context.SaveChangesAsync();

                        // Update REC_STATUS
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='EVENT' AND EVENT_NO = {seq}");
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER' AND EVENT_NO = {seq}");

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
                    response.Message = "Export Advice Released";
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

        private pExad SaveUser(pExad pExad, pPayment pPayment, int seqNo, string RECORD_TYPE, string EVENT_TYPE, string REC_STATUS, DateTime UpdateDateT, DateTime UpdateDateNT)
        {

            var pExadEvent = (from row in _context.pExads
                              where
                                    row.EXPORT_ADVICE_NO == pExad.EXPORT_ADVICE_NO &&
                                    row.RECORD_TYPE == RECORD_TYPE &&
                                    row.REC_STATUS == REC_STATUS &&
                                    row.EVENT_NO == seqNo
                              select row).AsNoTracking().FirstOrDefault();
            if (pExadEvent == null)
            {
                pExadEvent = pExad;
                pExadEvent.RECORD_TYPE = RECORD_TYPE;
                pExadEvent.EVENT_TYPE = EVENT_TYPE;
                pExadEvent.REC_STATUS = REC_STATUS;
                pExadEvent.EVENT_NO = seqNo;
                pExadEvent.EVENT_MODE = "E";
                pExadEvent.BUSINESS_TYPE = "6";
                pExadEvent.VOUCH_ID = "ADVICE LC";
                pExadEvent.AUTH_CODE = "";
                pExadEvent.UPDATE_DATE =UpdateDateT;
                _context.Add(pExadEvent);
                _context.SaveChanges();
            }
            else
            {
                pExadEvent = pExad;
                pExadEvent.EVENT_MODE = "E";
                pExadEvent.BUSINESS_TYPE = "6";
                pExadEvent.VOUCH_ID = "ADVICE LC";
                pExadEvent.AUTH_CODE = "";
                pExadEvent.UPDATE_DATE = UpdateDateT;
                _context.Update(pExadEvent);
                _context.SaveChanges();
            }

            return pExadEvent;
        }

        private pTransfer Transfer_save(pTransfer pTransfer, pPayment pPayment, int EVENT_NO, string RECORD_TYPE, string EVENT_TYPE, string REC_STATUS, DateTime UpdateDateT, DateTime UpdateDateNT)
        {
            int Seqno;
            var pTransferMax = (
                from row in _context.pTransfers
                where row.EXPORT_ADVICE_NO == pTransfer.EXPORT_ADVICE_NO
                orderby row.EVENT_NO descending
                select row).AsNoTracking().FirstOrDefault();
            if (pTransferMax != null)
            {
                Seqno =pTransferMax.SEQ_TRANSFER;
            }
            else
            {
                Seqno =0;
            }
            Seqno = Seqno + 1;

            var pTransferEvent = (from row in _context.pTransfers
                              where
                                    row.EXPORT_ADVICE_NO == pTransfer.EXPORT_ADVICE_NO &&
                                    row.SEQ_TRANSFER == Seqno &&
                                    row.EVENT_NO == EVENT_NO
                                  select row).AsNoTracking().FirstOrDefault();

                pTransferEvent = pTransfer;
                pTransferEvent.SEQ_TRANSFER = Seqno;
                pTransferEvent = pTransfer;
                pTransferEvent.EVENT_TYPE = EVENT_TYPE;
                pTransferEvent.EVENT_NO = EVENT_NO;
                if (pTransferEvent.EVENT_TYPE == "Transfer")
                {
                    pTransferEvent.TRANSFER_TYPE = "T";
                }
                else
                {
                    pTransferEvent.TRANSFER_TYPE = "A";
                }

                //eventType$ = pTransferEvent.event_type
                //EventTran = "TRANSFER"
                pTransferEvent.RECORD_TYPE = "EVENT";
                pTransferEvent.BUSINESS_TYPE = "6";
                pTransferEvent.REC_STATUS = "P";
                // ' ---------------------------------------------------------Tab Transfer/History


                pTransferEvent.VOUCH_ID = "ADVICE LC";
               // pTransferEvent.user_id = cUserCode;
                pTransferEvent.STATUS = "A";
                if (pTransferEvent.PAYMENT_INSTRU == "1")
                {
                    if (pTransferEvent.RECEIPT_NO == null)
                    {
                        pTransferEvent.RECEIPT_NO = ExportLCHelper.GenRefNo(_context, pTransferEvent.CenterID, pTransferEvent.USER_ID, "PAYD", UpdateDateT, UpdateDateNT);

                    }
                    PaymentSave(pTransferEvent, pPayment, UpdateDateT, UpdateDateNT);
                }
                else
                {
                    pTransferEvent.VOUCH_ID = "";
                    pTransferEvent.RECEIPT_NO = "";
                    // Delete pPayment
                    var pPaymentDel = (from row in _context.pPayments
                                       where row.RpReceiptNo == pTransferEvent.RECEIPT_NO
                                       select row).ToList();
                    foreach (var row in pPaymentDel)
                    {
                        _context.pPayments.Remove(row);
                    }
                    // Delete pPayDetail
                    var pPayDetailDel = (from row in _context.pPayDetails
                                         where row.DpReceiptNo == pTransferEvent.RECEIPT_NO
                                         select row).ToList();
                    foreach (var row in pPayDetailDel)
                    {
                        _context.pPayDetails.Remove(row);
                    }
                    // Delete pDailyGL
                    var pDailyGLDel = (from row in _context.pDailyGLs
                                       where row.VouchID == pTransferEvent.VOUCH_ID &&
                                             row.VouchDate == pTransferEvent.EVENT_DATE
                                       select row).ToList();
                    foreach (var row in pDailyGLDel)
                    {
                        _context.pDailyGLs.Remove(row);
                    }

                }

                //cRecpt = pTransferEvent.RECEIPT_NO

                pTransferEvent.UPDATE_DATE = UpdateDateT;
                // pTransferEvent.centerID = cBran
                pTransferEvent.GENACC_FLAG = "";
                pTransferEvent.GENACC_DATE =UpdateDateNT;
                pTransferEvent.IN_Use = "0";

            if (pTransferEvent == null)
            {
                _context.Add(pTransferEvent);
            }
            else
            {
                _context.Update(pTransferEvent);
            }
                return pTransferEvent;
        }
        private void PaymentSave(pTransfer exad, pPayment pPaymentReq, DateTime UpdateDateT, DateTime UpdateDateNT)
        {
 
            var pPaymentEvent = (from row in _context.pPayments
                                 where row.RpReceiptNo == exad.RECEIPT_NO
                                 select row).AsNoTracking().FirstOrDefault();
            pPaymentEvent = new();
            pPaymentEvent = pPaymentReq;
            pPaymentEvent.RpReceiptNo = exad.RECEIPT_NO;
            pPaymentReq.RpDocNo = exad.EXPORT_ADVICE_NO;
            pPaymentReq.RpRefer1 = exad.LC_NO;
            pPaymentReq.RpModule = "EXAD";
            pPaymentReq.RpEvent = "1";
            pPaymentReq.RpPayDate = exad.EVENT_DATE;
            pPaymentReq.RpPayBy = exad.METHOD;
            pPaymentReq.RpNote = "";
            pPaymentReq.RpStatus = "A";
            pPaymentReq.RpRecStatus = "P";
            pPaymentReq.UserCode = exad.USER_ID;
            pPaymentReq.UpdateDate = UpdateDateT;

            if (pPaymentEvent == null)
            {

                _context.pPayments.Add(pPaymentEvent);
            }
            else
            {
                _context.pPayments.Update(pPaymentReq);
            }

            // Delete pPayDetail
            var pPayDetailDel = (from row in _context.pPayDetails
                                 where row.DpReceiptNo == exad.RECEIPT_NO
                                 select row).ToList();
            foreach (var row in pPayDetailDel)
            {
                _context.pPayDetails.Remove(row);
            }

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
                paydetail.DpPayAmt = exad.AMENDTRN_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.TRANSFER_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "TRANSFER L/C COMM.";
                paydetail.DpPayAmt = exad.TRANSFER_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.AMENDTRN_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "AMEND TRANSFER L/C COMM.";
                paydetail.DpPayAmt = exad.AMENDTRN_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.CABLE_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "CABLE CHARGE";
                paydetail.DpPayAmt = exad.CABLE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.CONFIRM_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "CONFIRM L/C COMM";
                paydetail.DpPayAmt = exad.CONFIRM_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.OTHER_CHARGE != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "OTHER CHARGE";
                paydetail.DpPayAmt = exad.OTHER_CHARGE;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.PAY_REFUND == "Y")
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "REFUND TAX AMT.";
                paydetail.DpPayAmt = exad.REFUND_TAX * -1;
                _context.pPayDetails.Add(paydetail);
            }
        }

        private pExad SaveSup(pExad pExadEvent)
        {
            pExadEvent.AUTH_DATE = DateTime.Now;

            // Update pPayment
            var pPayment = (from row in _context.pPayments
                            where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                            select row).FirstOrDefault();
            if (pPayment != null)
            {
                pPayment.RpRecStatus = "R";
                pPayment.AuthDate = DateTime.Now;
                pPayment.AuthCode = pExadEvent.USER_ID;
            }

            var pTransfer = (from row in _context.pTransfers
                             where row.EXPORT_ADVICE_NO == pExadEvent.EXPORT_ADVICE_NO &&
                                   row.REC_STATUS == "P" &&
                                   row.RECORD_TYPE == "EVENT"
                             select row).FirstOrDefault();
            if (pTransfer!=null)
            {
                pTransfer.REC_STATUS = "R";
                pTransfer.AUTH_DATE = DateTime.Now;
                pTransfer.AUTH_CODE = pExadEvent.USER_ID;
            }

            // Update pDailyGL
            var pDailyGL = (from row in _context.pDailyGLs
                            where row.TranDocNo == pExadEvent.EXPORT_ADVICE_NO &&
                                  row.TranEvent == "TRANSFER" &&
                                  row.VouchDate == pExadEvent.EVENT_DATE
                            select row).ToList();
            foreach (var row in pDailyGL)
            {
                row.SendFlag = "R";
            }
            return pExadEvent;
        }

        private pExad SaveMaster(pExad pExadMaster, pExad pExadTemp, string EVENT_TYPE)
        {
            var vch = pExadTemp.VOUCH_ID; // ???????
            pExadMaster.EVENT_TYPE = EVENT_TYPE;
            pExadMaster.LC_TYPE = "1";
            pExadMaster.GENACC_FLAG = "Y";
            pExadMaster.GENACC_DATE = DateTime.Now;
            pExadMaster.FLAG_TRANSFER = "Y";
            pExadMaster.EVENT_MODE = "E";
            pExadMaster.VOUCH_ID = "";
            pExadMaster.BUSINESS_TYPE = "6";
            pExadMaster.AMEND_DATE = pExadTemp.AMEND_DATE;
            pExadMaster.AMEND_NO = pExadTemp.AMEND_NO;
            pExadMaster.INCREASE_AMT = pExadTemp.INCREASE_AMT;
            pExadMaster.DECREASE_AMT = pExadTemp.DECREASE_AMT;
            pExadMaster.LC_AMOUNT = pExadTemp.LC_AMOUNT;
            pExadMaster.ADVICE_COM = pExadTemp.ADVICE_COM;
            pExadMaster.AMEND_COM = pExadTemp.AMEND_COM;
            pExadMaster.TRANSFER_COM = pExadTemp.TRANSFER_COM;
            pExadMaster.CABLE_COM = pExadTemp.CABLE_COM;
            pExadMaster.CONFIRM_COM = pExadTemp.CONFIRM_COM;
            pExadMaster.OTHER_CHARGE = pExadTemp.OTHER_CHARGE;
            pExadMaster.TOTAL_AMOUNT = pExadTemp.TOTAL_AMOUNT;
            pExadMaster.TOTAL_CHARGE = pExadTemp.TOTAL_CHARGE;
            pExadMaster.REFUND_TAX = pExadTemp.REFUND_TAX;
            pExadMaster.PAY_REFUND = pExadTemp.PAY_REFUND;
            pExadMaster.ALLOCATION = pExadTemp.ALLOCATION;
            pExadMaster.METHOD = pExadTemp.METHOD;

            if (pExadTemp.PAYMENT_INSTRU == "1")
            {
                pExadMaster.RECEIPT_NO = pExadTemp.RECEIPT_NO;
                pExadMaster.PAYMENT_INSTRU = "1";
            }
            else
            {
                pExadMaster.RECEIPT_NO = "";
                pExadMaster.PAYMENT_INSTRU = "2";
                pExadTemp.UNADVICE_COM = pExadTemp.UNADVICE_COM + pExadTemp.ADVICE_COM;
                pExadTemp.UNAMEND_COM = pExadTemp.UNAMEND_COM + pExadTemp.AMEND_COM;
                pExadTemp.UNTRANSFER_COM = pExadTemp.UNTRANSFER_COM + pExadTemp.TRANSFER_COM;
                pExadTemp.UNCABLE_COM = pExadTemp.UNCABLE_COM + pExadTemp.CABLE_COM;
                pExadTemp.UNCONFIRM_COM = pExadTemp.UNCONFIRM_COM + pExadTemp.CONFIRM_COM;
                pExadTemp.UNOTHER_CHARGE = pExadTemp.UNOTHER_CHARGE + pExadTemp.OTHER_CHARGE;
            }

            return pExadMaster;
        }
    }
}