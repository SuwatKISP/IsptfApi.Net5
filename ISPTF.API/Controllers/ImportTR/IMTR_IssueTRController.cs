using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.Inquiry;
using ISPTF.Models.ImportTR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using ISPTF.Models.ExportLC;
namespace ISPTF.API.Controllers.ImportTR
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IMTR_IssueTRController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IMTR_IssueTRController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("newpage")]
        public async Task<ActionResult<Q_IMTR_Issue_NewPage_Response>> NewPage(string CustCode, string? CustName, string? Reg_DocNo, string? CenterID, string? Page, string? PageSize)
        {
            Q_IMTR_Issue_NewPage_Response response = new Q_IMTR_Issue_NewPage_Response();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_IMTR_Issue_NewPage_rsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", "NEW");
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@Reg_DocNo", Reg_DocNo);
                param.Add("@UserCode", USER_ID);
                param.Add("@CenterID", CenterID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }
                if (Reg_DocNo == null)
                {
                    param.Add("@Reg_DocNo", "");
                }


                var results = await _db.LoadData<Q_IMTR_Issue_NewPage_rsp, dynamic>(
                            storedProcedure: "usp_q_IMTR_IssueTRNewPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMTR_Issue_NewPage_rsp>)results;

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
                response.Data = new List<Q_IMTR_Issue_NewPage_rsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("listpage")]
        public async Task<ActionResult<Q_IMTR_Issue_ListPage_Response>> ListPage(string? ListType, string? TRNumber, string CustCode, string? CustName, string? CenterID, string? Page, string? PageSize)
        {
            Q_IMTR_Issue_ListPage_Response response = new Q_IMTR_Issue_ListPage_Response();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_IMTR_Issue_ListPage_rsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IMTR_Issue_ListPage_rsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@TRNumber", TRNumber);
                param.Add("@CenterID", CenterID);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }
                if (TRNumber == null)
                {
                    param.Add("@TRNumber", "");
                }


                var results = await _db.LoadData<Q_IMTR_Issue_ListPage_rsp, dynamic>(
                            storedProcedure: "usp_q_IMTR_IssueTRListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMTR_Issue_ListPage_rsp>)results;

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
                response.Data = new List<Q_IMTR_Issue_ListPage_rsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("newSelect")]
        public async Task<ActionResult<Q_IMTR_Issue_NewSelect_Response>> NewSelect(string? Reg_Docno, string? Reg_CustCode, string? Reg_RefNo, string? Reg_RefType, string? Reg_AppvNo)
        {
            Q_IMTR_Issue_NewSelect_Response response = new Q_IMTR_Issue_NewSelect_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(Reg_Docno) || string.IsNullOrEmpty(Reg_CustCode))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "Reg_Docno, Reg_CustCode is required";
                response.Data = new Q_IMTR_IssueNewSelect_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@RegDocno", Reg_Docno);
                param.Add("@RegCustCode", Reg_CustCode);
                param.Add("@RegRefNo", Reg_RefNo);
                param.Add("@RegRefType", Reg_RefType);
                param.Add("@RegAppvNo", Reg_AppvNo);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@IssueNewResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_IMTR_IssueNewSelect_JSON_rsp, dynamic>(
                            storedProcedure: "usp_Q_IMTR_IssueTRNewSelect",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var IssueNewResp = param.Get<dynamic>("@IssueNewResp");

                if (Resp == 1)
                {
                    Q_IMTR_IssueNewSelect_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_IMTR_IssueNewSelect_JSON_rsp>(IssueNewResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_IMTR_IssueNewSelect_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_IMTR_IssueNewSelect_JSON_rsp();
                return BadRequest(response);
            }
        }

        [HttpGet("listSelect")]
        public async Task<ActionResult<Q_IMTR_Issue_ListSelect_Response>> Select(string? CustCode, string? RefNumber, string? TRSeqno, string? RecType, string? Event)
        {
            Q_IMTR_Issue_ListSelect_Response response = new Q_IMTR_Issue_ListSelect_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(CustCode) || string.IsNullOrEmpty(RefNumber) || string.IsNullOrEmpty(TRSeqno) ||
                string.IsNullOrEmpty(RecType) || string.IsNullOrEmpty(Event))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CustCode, RefNumber, TRSeqno, RecType, Event are required";
                response.Data = new Q_IMTR_IssueListSelect_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@CustCode", CustCode);
                param.Add("@RefNumber", RefNumber);
                param.Add("@TRSeqno", TRSeqno);
                param.Add("@RecType", RecType);
                param.Add("@Event", Event);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@IssueTRResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_IMTR_IssueListSelect_JSON_rsp, dynamic>(
                            storedProcedure: "usp_Q_IMTR_IssueTRListSelect",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var IssueTRResp = param.Get<dynamic>("@IssueTRResp");

                if (Resp == 1)
                {
                    Q_IMTR_IssueListSelect_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_IMTR_IssueListSelect_JSON_rsp>(IssueTRResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_IMTR_IssueListSelect_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_IMTR_IssueListSelect_JSON_rsp();
                return BadRequest(response);
            }
        }

        [HttpPost("save")]
        public async Task<ActionResult<IMTR_SaveIssue_Response>> Save([FromBody] IMTR_SaveIssue_JSON_req saveissue)
        {
            IMTR_SaveIssue_Response response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            if (saveissue.ListType.ListType != "NEW" && saveissue.ListType.ListType != "EDIT")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be NEW or EDIT";
                response.Data = new IMTR_SaveIssue_JSON_rsp();
                return BadRequest(response);
            }
            try
            {
                DynamicParameters param = new DynamicParameters();
                //ListType
                param.Add("@ListType", saveissue.ListType.ListType);
                param.Add("@cutLineTextF50K", saveissue.ListType.cutLineTextF50K);
                param.Add("@cutLineTextF59", saveissue.ListType.cutLineTextF59);
                //pIMTR
                param.Add("@CenterID", saveissue.pIMTR.CenterID);
                param.Add("@TRNumber", saveissue.pIMTR.TRNumber);
                param.Add("@RefNumber", saveissue.pIMTR.RefNumber);
                param.Add("@RecType", saveissue.pIMTR.RecType);
                param.Add("@TRSeqno", saveissue.pIMTR.TRSeqno);
                param.Add("@TRStatus", saveissue.pIMTR.TRStatus);
                param.Add("@RecStatus", saveissue.pIMTR.RecStatus);
                param.Add("@EventMode", saveissue.pIMTR.EventMode);
                param.Add("@Event", saveissue.pIMTR.Event);
                param.Add("@EventDate", saveissue.pIMTR.EventDate);
                param.Add("@LOCode", saveissue.pIMTR.LOCode);
                param.Add("@AOCode", saveissue.pIMTR.AOCode);
                param.Add("@ValueDate", saveissue.pIMTR.ValueDate);
                param.Add("@EventFlag", saveissue.pIMTR.EventFlag);
                param.Add("@AutoOverDue", saveissue.pIMTR.AutoOverDue);
                param.Add("@TRDueStatus", saveissue.pIMTR.TRDueStatus);
                param.Add("@OverdueDate", saveissue.pIMTR.OverdueDate);
                param.Add("@PastDueDate", saveissue.pIMTR.PastDueDate);
                param.Add("@TRCCyFlag", saveissue.pIMTR.TRCCyFlag);
                param.Add("@TRRate", saveissue.pIMTR.TRRate);
                param.Add("@LCNumber", saveissue.pIMTR.LCNumber);
                param.Add("@BLNumber", saveissue.pIMTR.BLNumber);
                param.Add("@BLAdvice", saveissue.pIMTR.BLAdvice);
                param.Add("@CustCode", saveissue.pIMTR.CustCode);
                param.Add("@CustAddr", saveissue.pIMTR.CustAddr);
                param.Add("@DocCCy", saveissue.pIMTR.DocCCy);
                param.Add("@BLBalance", saveissue.pIMTR.BLBalance);
                param.Add("@BLDay", saveissue.pIMTR.BLDay);
                param.Add("@TRTermDay", saveissue.pIMTR.TRTermDay);
                param.Add("@BLIntStartDate", saveissue.pIMTR.BLIntStartDate);
                param.Add("@BLIntCode", saveissue.pIMTR.BLIntCode);
                param.Add("@BLIntRate", saveissue.pIMTR.BLIntRate);
                param.Add("@BLBase", saveissue.pIMTR.BLBase);
                param.Add("@BLInterest", saveissue.pIMTR.BLInterest);
                param.Add("@BLExch", saveissue.pIMTR.BLExch);
                param.Add("@BLFwd", saveissue.pIMTR.BLFwd);
                param.Add("@BLIntAmt", saveissue.pIMTR.BLIntAmt);
                param.Add("@BenName", saveissue.pIMTR.BenName);
                param.Add("@BenInfo", saveissue.pIMTR.BenInfo);
                param.Add("@BenCnty", saveissue.pIMTR.BenCnty);
                param.Add("@TenorType", saveissue.pIMTR.TenorType);
                param.Add("@NegoBank", saveissue.pIMTR.NegoBank);
                param.Add("@NegoCnty", saveissue.pIMTR.NegoCnty);
                param.Add("@NegoRefno", saveissue.pIMTR.NegoRefno);
                param.Add("@ChipNego", saveissue.pIMTR.ChipNego);
                param.Add("@TRCcy", saveissue.pIMTR.TRCcy);
                param.Add("@TRAmount", saveissue.pIMTR.TRAmount);
                param.Add("@TRBalance", saveissue.pIMTR.TRBalance);
                param.Add("@TRProfit", saveissue.pIMTR.TRProfit);
                param.Add("@MidRate", saveissue.pIMTR.MidRate);
                param.Add("@TRDay", saveissue.pIMTR.TRDay);
                param.Add("@StartDate", saveissue.pIMTR.StartDate);
                param.Add("@DueDate", saveissue.pIMTR.DueDate);
                param.Add("@PrevDueDate", saveissue.pIMTR.PrevDueDate);
                param.Add("@FBCcy", saveissue.pIMTR.FBCcy);
                param.Add("@FBCharge", saveissue.pIMTR.FBCharge);
                param.Add("@FBInterest", saveissue.pIMTR.FBInterest);
                param.Add("@FBEngage", saveissue.pIMTR.FBEngage);
                param.Add("@PrevFBChrg", saveissue.pIMTR.PrevFBChrg);
                param.Add("@PrevFBInt", saveissue.pIMTR.PrevFBInt);
                param.Add("@PrevFBEng", saveissue.pIMTR.PrevFBEng);
                param.Add("@Invoice", saveissue.pIMTR.Invoice);
                param.Add("@Goods", saveissue.pIMTR.Goods);
                param.Add("@Relation", saveissue.pIMTR.Relation);
                param.Add("@DeductSwift", saveissue.pIMTR.DeductSwift);
                param.Add("@DeductComm", saveissue.pIMTR.DeductComm);
                param.Add("@DeductOther", saveissue.pIMTR.DeductOther);
                param.Add("@SettleFlag", saveissue.pIMTR.SettleFlag);
                param.Add("@SettleDate", saveissue.pIMTR.SettleDate);
                param.Add("@MTNego", saveissue.pIMTR.MTNego);
                param.Add("@MTType", saveissue.pIMTR.MTType);
                param.Add("@ReimBank", saveissue.pIMTR.ReimBank);
                param.Add("@SGNumber", saveissue.pIMTR.SGNumber);
                param.Add("@SGNumber1", saveissue.pIMTR.SGNumber1);
                param.Add("@SGAmount", saveissue.pIMTR.SGAmount);
                param.Add("@DOAmount", saveissue.pIMTR.DOAmount);
                param.Add("@IntermBank", saveissue.pIMTR.IntermBank);
                param.Add("@ChipInterm", saveissue.pIMTR.ChipInterm);
                param.Add("@IntermAddr", saveissue.pIMTR.IntermAddr);
                param.Add("@AcBank", saveissue.pIMTR.AcBank);
                param.Add("@ChipAcBank", saveissue.pIMTR.ChipAcBank);
                param.Add("@AcAddr", saveissue.pIMTR.AcAddr);
                param.Add("@IntBefore", saveissue.pIMTR.IntBefore);
                param.Add("@ExchBefore", saveissue.pIMTR.ExchBefore);
                param.Add("@IntPayType", saveissue.pIMTR.IntPayType);
                param.Add("@IntFixDate", saveissue.pIMTR.IntFixDate);
                param.Add("@IntRateCode", saveissue.pIMTR.IntRateCode);
                param.Add("@IntRate", saveissue.pIMTR.IntRate);
                param.Add("@IntSpread", saveissue.pIMTR.IntSpread);
                param.Add("@IntFlag", saveissue.pIMTR.IntFlag);
                param.Add("@IntBaseDay", saveissue.pIMTR.IntBaseDay);
                param.Add("@CFRRate", saveissue.pIMTR.CFRRate);
                param.Add("@IntStartDate", saveissue.pIMTR.IntStartDate);
                param.Add("@LastIntDate", saveissue.pIMTR.LastIntDate);
                param.Add("@LastIntAmt", saveissue.pIMTR.LastIntAmt);
                param.Add("@IntBalance", saveissue.pIMTR.IntBalance);
                param.Add("@OverDrawComm", saveissue.pIMTR.OverDrawComm);
                param.Add("@ExchRate", saveissue.pIMTR.ExchRate);
                param.Add("@EngageRate", saveissue.pIMTR.EngageRate);
                param.Add("@EngageComm", saveissue.pIMTR.EngageComm);
                param.Add("@CommFCD", saveissue.pIMTR.CommFCD);
                param.Add("@OpenAmt", saveissue.pIMTR.OpenAmt);
                param.Add("@CableAmt", saveissue.pIMTR.CableAmt);
                param.Add("@PostageAmt", saveissue.pIMTR.PostageAmt);
                param.Add("@DutyAmt", saveissue.pIMTR.DutyAmt);
                param.Add("@PayableAmt", saveissue.pIMTR.PayableAmt);
                param.Add("@IBCRate", saveissue.pIMTR.IBCRate);
                param.Add("@IBCComm", saveissue.pIMTR.IBCComm);
                param.Add("@CommLieu", saveissue.pIMTR.CommLieu);
                param.Add("@CommTran", saveissue.pIMTR.CommTran);
                param.Add("@CommExch", saveissue.pIMTR.CommExch);
                param.Add("@CommCertify", saveissue.pIMTR.CommCertify);
                param.Add("@DiscFee", saveissue.pIMTR.DiscFee);
                param.Add("@CommOther", saveissue.pIMTR.CommOther);
                param.Add("@TaxRefund", saveissue.pIMTR.TaxRefund);
                param.Add("@TaxAmt", saveissue.pIMTR.TaxAmt);
                param.Add("@CommDesc", saveissue.pIMTR.CommDesc);
                param.Add("@PayFlag", saveissue.pIMTR.PayFlag);
                param.Add("@PayMethod", saveissue.pIMTR.PayMethod);
                param.Add("@Allocation", saveissue.pIMTR.Allocation);
                param.Add("@DateLastPaid", saveissue.pIMTR.DateLastPaid);
                param.Add("@LastReceiptNo", saveissue.pIMTR.LastReceiptNo);
                param.Add("@AppvNo", saveissue.pIMTR.AppvNo);
                param.Add("@FacNo", saveissue.pIMTR.FacNo);
                param.Add("@FCyPayFlag", saveissue.pIMTR.FCyPayFlag);
                param.Add("@FCyAcNo", saveissue.pIMTR.FCyAcNo);
                param.Add("@FCyReceiptNo", saveissue.pIMTR.FCyReceiptNo);
                param.Add("@PayType", saveissue.pIMTR.PayType);
                param.Add("@PayAmount", saveissue.pIMTR.PayAmount);
                param.Add("@PayInterest", saveissue.pIMTR.PayInterest);
                //param.Add("@UpdateDate", saveissue.pIMTR.UpdateDate);
                param.Add("@UserCode", USER_ID);
                //param.Add("@AuthDate", saveissue.pIMTR.AuthDate);
                //param.Add("@AuthCode", saveissue.pIMTR.AuthCode);
                param.Add("@GenAccFlag", saveissue.pIMTR.GenAccFlag);
                param.Add("@VoucherID", saveissue.pIMTR.VoucherID);
                param.Add("@DateToStop", saveissue.pIMTR.DateToStop);
                param.Add("@DateStartAccru", saveissue.pIMTR.DateStartAccru);
                param.Add("@DateLastAccru", saveissue.pIMTR.DateLastAccru);
                param.Add("@LastAccruCcy", saveissue.pIMTR.LastAccruCcy);
                param.Add("@LastAccruAmt", saveissue.pIMTR.LastAccruAmt);
                param.Add("@NewAccruCcy", saveissue.pIMTR.NewAccruCcy);
                param.Add("@NewAccruAmt", saveissue.pIMTR.NewAccruAmt);
                param.Add("@AccruCCy", saveissue.pIMTR.AccruCCy);
                param.Add("@AccruAmt", saveissue.pIMTR.AccruAmt);
                param.Add("@DAccruAmt", saveissue.pIMTR.DAccruAmt);
                param.Add("@PAccruAmt", saveissue.pIMTR.PAccruAmt);
                param.Add("@AccruPending", saveissue.pIMTR.AccruPending);
                param.Add("@RevAccru", saveissue.pIMTR.RevAccru);
                param.Add("@RevAccruTax", saveissue.pIMTR.RevAccruTax);
                param.Add("@DMS", saveissue.pIMTR.DMS);
                param.Add("@Tx72", saveissue.pIMTR.Tx72);
                param.Add("@Tx23E", saveissue.pIMTR.Tx23E);
                param.Add("@Tx71A", saveissue.pIMTR.Tx71A);
                param.Add("@Tx26", saveissue.pIMTR.Tx26);
                param.Add("@Tx59A", saveissue.pIMTR.Tx59A);
                param.Add("@Tx59D", saveissue.pIMTR.Tx59D);
                param.Add("@Tx59Cnty", saveissue.pIMTR.Tx59Cnty);
                param.Add("@TRCcy1", saveissue.pIMTR.TRCcy1);
                param.Add("@TRExch1", saveissue.pIMTR.TRExch1);
                param.Add("@TRAmt1", saveissue.pIMTR.TRAmt1);
                param.Add("@TRCont1", saveissue.pIMTR.TRCont1);
                param.Add("@TRCcy2", saveissue.pIMTR.TRCcy2);
                param.Add("@TRExch2", saveissue.pIMTR.TRExch2);
                param.Add("@TRAmt2", saveissue.pIMTR.TRAmt2);
                param.Add("@TRCont2", saveissue.pIMTR.TRCont2);
                param.Add("@TRCcy3", saveissue.pIMTR.TRCcy3);
                param.Add("@TRExch3", saveissue.pIMTR.TRExch3);
                param.Add("@TRAmt3", saveissue.pIMTR.TRAmt3);
                param.Add("@TRCont3", saveissue.pIMTR.TRCont3);
                param.Add("@TRCcy4", saveissue.pIMTR.TRCcy4);
                param.Add("@TRExch4", saveissue.pIMTR.TRExch4);
                param.Add("@TRAmt4", saveissue.pIMTR.TRAmt4);
                param.Add("@TRCont4", saveissue.pIMTR.TRCont4);
                param.Add("@TRCcy5", saveissue.pIMTR.TRCcy5);
                param.Add("@TRExch5", saveissue.pIMTR.TRExch5);
                param.Add("@TRAmt5", saveissue.pIMTR.TRAmt5);
                param.Add("@TRCont5", saveissue.pIMTR.TRCont5);
                param.Add("@NostACInfo", saveissue.pIMTR.NostACInfo);
                param.Add("@Nego799", saveissue.pIMTR.Nego799);
                param.Add("@Nego999", saveissue.pIMTR.Nego999);
                param.Add("@NegoTelex", saveissue.pIMTR.NegoTelex);
                param.Add("@CCS_ACCT", saveissue.pIMTR.CCS_ACCT);
                param.Add("@CCS_LmType", saveissue.pIMTR.CCS_LmType);
                param.Add("@CCS_CNUM", saveissue.pIMTR.CCS_CNUM);
                param.Add("@CCS_CIFRef", saveissue.pIMTR.CCS_CIFRef);
                param.Add("@TRFLAG", saveissue.pIMTR.TRFLAG);
                param.Add("@InUse", saveissue.pIMTR.InUse);
                param.Add("@ObjectType", saveissue.pIMTR.ObjectType);
                param.Add("@UnderlyName", saveissue.pIMTR.UnderlyName);
                param.Add("@BPOFlag", saveissue.pIMTR.BPOFlag);
                param.Add("@Campaign_Code", saveissue.pIMTR.Campaign_Code);
                param.Add("@Campaign_EffDate", saveissue.pIMTR.Campaign_EffDate);
                param.Add("@PurposeCode", saveissue.pIMTR.PurposeCode);

                //pPayment
                param.Add("@RpReceiptNo", saveissue.pPayment.RpReceiptNo);
                param.Add("@RpModule", saveissue.pPayment.RpModule);
                param.Add("@RpEvent", saveissue.pPayment.RpEvent);
                param.Add("@RpDocNo", saveissue.pPayment.RpDocNo);
                param.Add("@RpCustCode", saveissue.pPayment.RpCustCode);
                param.Add("@RpPayDate", saveissue.pPayment.RpPayDate);
                param.Add("@RpPayBy", saveissue.pPayment.RpPayBy);
                param.Add("@RpNote", saveissue.pPayment.RpNote);
                param.Add("@RpCashAmt", saveissue.pPayment.RpCashAmt);
                param.Add("@RpChqAmt", saveissue.pPayment.RpChqAmt);
                param.Add("@RpChqNo", saveissue.pPayment.RpChqNo);
                param.Add("@RpChqBank", saveissue.pPayment.RpChqBank);
                param.Add("@RpChqBranch", saveissue.pPayment.RpChqBranch);
                param.Add("@RpCustAc1", saveissue.pPayment.RpCustAc1);
                param.Add("@RpCustAmt1", saveissue.pPayment.RpCustAmt1);
                param.Add("@RpCustAc2", saveissue.pPayment.RpCustAc2);
                param.Add("@RpCustAmt2", saveissue.pPayment.RpCustAmt2);
                param.Add("@RpCustAc3", saveissue.pPayment.RpCustAc3);
                param.Add("@RpCustAmt3", saveissue.pPayment.RpCustAmt3);
                param.Add("@RpRefer1", saveissue.pPayment.RpRefer1);
                param.Add("@RpRefer2", saveissue.pPayment.RpRefer2);
                param.Add("@RpApplicant", saveissue.pPayment.RpApplicant);
                param.Add("@RpIssBank", saveissue.pPayment.RpIssBank);
                param.Add("@RpStatus", saveissue.pPayment.RpStatus);
                param.Add("@RpRecStatus", saveissue.pPayment.RpRecStatus);
                param.Add("@RpPrint", saveissue.pPayment.RpPrint);
                //param.Add("@UserCode", saveissue.pPayment.UserCode);
                //param.Add("@UpdateDate", saveissue.pPayment.UpdateDate);
                //param.Add("@AuthCode", saveissue.pPayment.AuthCode);
                //param.Add("@AuthDate", saveissue.pPayment.AuthDate);

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@IssueTRSaveResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<IMTR_SaveIssue_Response, dynamic>(
                    storedProcedure: "usp_pIMTR_IssueTR_Save",
                    param);

                var Resp = param.Get<int>("@Resp");
                var IssueTRSaveResp = param.Get<dynamic>("@IssueTRSaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    IMTR_SaveIssue_JSON_rsp jsonResponse = JsonSerializer.Deserialize<IMTR_SaveIssue_JSON_rsp>(IssueTRSaveResp);

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    //return Ok(response);
                    bool resGL;
                    bool resPayD;
                    string eventDate;
                    string resVoucherID;
                    string TRLogin;
                    eventDate = response.Data.pIMTR.EventDate.Value.ToString("dd/MM/yyyy");
                    if (response.Data.pIMTR.EventMode=="L")
                    {
                        TRLogin = "IMBL";
                    }
                    else if (response.Data.pIMTR.EventMode == "B")
                    {
                        TRLogin = "IMBC";
                    }
                    else if (response.Data.pIMTR.EventMode == "D")
                    {
                        TRLogin = "DMLC";
                    }
                    else if (response.Data.pIMTR.EventMode == "S")
                    {
                        TRLogin = "TRS";
                    }
                    else 
                    {
                        TRLogin = "PN";
                    }

                    resVoucherID = ISPModuleIMP.GenerateGL.StartPIMTR(response.Data.pIMTR.TRNumber,
                        eventDate,
                        response.Data.pIMTR.TRSeqno.ToString("#0"),
                        response.Data.pIMTR.Event,TRLogin);


                    if (resVoucherID != "ERROR")
                    {
                        resGL = true;
                        response.Data.pIMTR.VoucherID = resVoucherID;
                    }
                    else
                    {
                        resGL = false;
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = "Error for  Gen.G/L  ";
                        response.Data = jsonResponse;
                        return BadRequest(response);
                    }
                    string resQuote = "";
                    if (response.Data.pIMTR.RecStatus == "N" )
                    {
                        resQuote = ISPModule.RequestQuoteRate.GenQuoteRate("IMTR", response.Data.pIMTR.TRNumber,
                             response.Data.pIMTR.TRSeqno, response.Data.pIMTR.Event, "", response.Data.pIMTR.UserCode);
                    }
                    if (resQuote == "ERROR")
                    {
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = "Error for Quote Rate";
                        return BadRequest(response);
                    }
                    return Ok(response);
                    //string resPayDetail;

                    //resPayDetail = ISPModule.PayDetailEXBC.PayDetail_IssPurchase(response.Data.pIMTR.EXPORT_BC_NO, response.Data.pIMTR.EVENT_NO, resReceiptNo);
                    //if (resPayDetail != "ERROR")
                    //{
                    //    resPayD = true;
                    //}
                    //else
                    //{
                    //    resPayD = false;
                    //}

                    //string resQuote = "";
                    //if (response.Data.pIMTR.REC_STATUS == "N")
                    //{
                    //    resQuote = ISPModule.RequestQuoteRate.GenQuoteRate("EXBC", response.Data.pIMTR.EXPORT_BC_NO,
                    //         response.Data.pIMTR.EVENT_NO, response.Data.pIMTR.EVENT_TYPE, "NEW", response.Data.pIMTR.USER_ID);
                    //}
                    //if (resQuote == "ERROR" || resPayD == false || resGL == false)
                    //{
                    //    response.Code = Constants.RESPONSE_ERROR;
                    //    response.Message = "Error for  Gen.G/L or Paymemnt Detail or Quote Rate ";
                    //    response.Data = new IMTR_SaveIssue_JSON_rsp();
                    //    return BadRequest(response);
                    //}
                    //else
                    //{
                    //    return Ok(response);
                    //}

                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Issue T/R Insert Error";
                    response.Data = new IMTR_SaveIssue_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new IMTR_SaveIssue_JSON_rsp();
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<IMTRResultResponse>> Release([FromBody] IMTR_ReleaseIssue_pIMTR_req releaseissue)
        {
            IMTRResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            //if (saveissue.pIMTR.ListType != "NEW" && saveissue.pIMTR.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMTR_SaveIssue_JSON_rsp();
            //    return BadRequest(response);
            //}

            DynamicParameters param = new DynamicParameters();

            param.Add("@CustCode", releaseissue.CustCode);
            param.Add("@RefNumber", releaseissue.RefNumber);
            param.Add("@TRNumber", releaseissue.TRNumber);
            param.Add("@RecType", releaseissue.RecType);
            param.Add("@TRSeqno", releaseissue.TRSeqno);
            param.Add("@PayFlag", releaseissue.PayFlag);
            param.Add("@BLInterest", releaseissue.BLInterest);
            param.Add("@BLIntAmt", releaseissue.BLIntAmt); ;
            param.Add("@IntBalance", releaseissue.IntBalance);
            param.Add("@AccruPending", releaseissue.AccruPending);
            param.Add("@FBCharge", releaseissue.FBCharge);
            param.Add("@PayMethod", releaseissue.PayMethod);
            param.Add("@FBInterest", releaseissue.FBInterest);
            param.Add("@EventMode", releaseissue.EventMode);
            param.Add("@SGNumber", releaseissue.SGNumber);
            param.Add("@LCNumber", releaseissue.LCNumber);
            param.Add("@DocCcy", releaseissue.DocCcy);
            param.Add("@CenterID", releaseissue.CenterID);
            param.Add("@UserCode", USER_ID);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                    storedProcedure: "usp_pIMTR_IssueTR_Release", param);

                var Resp = param.Get<int>("@Resp");

                if (Resp > 0)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "ISSUE T/R Release Complete";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    try
                    {
                        response.Message = Resp.ToString();
                    }
                    catch (Exception)
                    {
                        response.Message = "ISSUE T/R Release Error";
                    }
                    return BadRequest(response);
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
        public async Task<ActionResult<IMTRResultResponse>> Delete([FromBody] IMTR_DeleteIssue_pIMTR_req deleteissue)
        {
            IMTRResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            //if (saveissue.pIMTR.ListType != "NEW" && saveissue.pIMTR.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMTR_SaveIssue_JSON_rsp();
            //    return BadRequest(response);
            //}

            DynamicParameters param = new DynamicParameters();

            param.Add("@RefNumber", deleteissue.RefNumber);
            param.Add("@TRNumber", deleteissue.TRNumber);
            param.Add("@TRSeqno", deleteissue.TRSeqno);
            param.Add("@EventMode", deleteissue.EventMode);
            param.Add("@UserCode", USER_ID);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                    storedProcedure: "usp_pIMTR_IssueTR_Delete", param);

                var Resp = param.Get<int>("@Resp");

                if (Resp > 0)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Delete Pending Data Complete";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    try
                    {
                        response.Message = "Delete Pending Data Does not Exists";
                    }
                    catch (Exception)
                    {
                        response.Message = Resp.ToString();
                    }
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }
        }

        [HttpGet("cmbACType")]
        public async Task<IEnumerable<MControl>> cmbACType()
        {
            DynamicParameters param = new DynamicParameters();

            var results = await _db.LoadData<MControl, dynamic>(
                storedProcedure: "usp_pIMTR_IssueTR_mControlSelect",
                param);
            return results;
        }

        [HttpPost("saveSWIFT")]
        public async Task<ActionResult<IMTR_SaveSWIFT_Response>> SaveSWIFT([FromBody] IMTR_SaveSWIFT_JSON_req saveSWIFT)
        {
            IMTR_SaveSWIFT_Response response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            //if (saveissue.ListType.ListType != "NEW" && saveissue.ListType.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMTR_SaveIssue_JSON_rsp();
            //    return BadRequest(response);
            //}
            try
            {
                DynamicParameters param = new DynamicParameters();
                //ListType
                //param.Add("@ListType", saveissue.ListType.ListType);
                param.Add("@cutLineTextF50K", saveSWIFT.SWIFTCutLine.cutLineTextF50K);
                param.Add("@cutLineTextF59", saveSWIFT.SWIFTCutLine.cutLineTextF59);
                //pIMTR
                param.Add("@CenterID", saveSWIFT.pIMTR.CenterID);
                param.Add("@TRNumber", saveSWIFT.pIMTR.TRNumber);
                param.Add("@RefNumber", saveSWIFT.pIMTR.RefNumber);
                param.Add("@RecType", saveSWIFT.pIMTR.RecType);
                param.Add("@TRSeqno", saveSWIFT.pIMTR.TRSeqno);
                param.Add("@EventMode", saveSWIFT.pIMTR.EventMode);
                param.Add("@EventDate", saveSWIFT.pIMTR.EventDate);
                param.Add("@ValueDate", saveSWIFT.pIMTR.ValueDate);
                param.Add("@EventFlag", saveSWIFT.pIMTR.EventFlag);
                param.Add("@LCNumber", saveSWIFT.pIMTR.LCNumber);
                param.Add("@DocCCy", saveSWIFT.pIMTR.DocCCy);
                param.Add("@BLBalance", saveSWIFT.pIMTR.BLBalance);
                param.Add("@BLDay", saveSWIFT.pIMTR.BLDay);
                param.Add("@NegoBank", saveSWIFT.pIMTR.NegoBank);
                param.Add("@NegoRefno", saveSWIFT.pIMTR.NegoRefno);
                param.Add("@ChipNego", saveSWIFT.pIMTR.ChipNego);
                param.Add("@TRCcy", saveSWIFT.pIMTR.TRCcy);
                param.Add("@TRAmount", saveSWIFT.pIMTR.TRAmount);
                param.Add("@FBCharge", saveSWIFT.pIMTR.FBCharge);
                param.Add("@FBInterest", saveSWIFT.pIMTR.FBInterest);
                param.Add("@DeductSwift", saveSWIFT.pIMTR.DeductSwift);
                param.Add("@DeductComm", saveSWIFT.pIMTR.DeductComm);
                param.Add("@DeductOther", saveSWIFT.pIMTR.DeductOther);
                param.Add("@MTNego", saveSWIFT.pIMTR.MTNego);
                param.Add("@ReimBank", saveSWIFT.pIMTR.ReimBank);
                param.Add("@UserCode", USER_ID);

                //pSWImport
                param.Add("@Login", saveSWIFT.pSWImport.Login);
                param.Add("@DocNumber", saveSWIFT.pSWImport.DocNumber);
                param.Add("@Seqno", saveSWIFT.pSWImport.Seqno);
                //param.Add("@RefNumber", saveSWIFT.pSWImport.RefNumber);
                param.Add("@RemitCcy", saveSWIFT.pSWImport.RemitCcy);
                param.Add("@RemitAmt", saveSWIFT.pSWImport.RemitAmt);
                param.Add("@DeductAmt", saveSWIFT.pSWImport.DeductAmt);
                param.Add("@ChargeAmt", saveSWIFT.pSWImport.ChargeAmt);
                param.Add("@Amt71", saveSWIFT.pSWImport.Amt71);
                //param.Add("@ValueDate", saveSWIFT.pSWImport.ValueDate);
                param.Add("@SwiftFile", saveSWIFT.pSWImport.SwiftFile);
                param.Add("@MT103", saveSWIFT.pSWImport.MT103);
                param.Add("@MT202", saveSWIFT.pSWImport.MT202);
                param.Add("@MT734", saveSWIFT.pSWImport.MT734);
                param.Add("@MT752", saveSWIFT.pSWImport.MT752);
                param.Add("@MT754", saveSWIFT.pSWImport.MT754);
                param.Add("@MT756", saveSWIFT.pSWImport.MT756);
                param.Add("@MT799", saveSWIFT.pSWImport.MT799);
                param.Add("@MT999", saveSWIFT.pSWImport.MT999);
                param.Add("@MT412", saveSWIFT.pSWImport.MT412);
                param.Add("@MT499", saveSWIFT.pSWImport.MT499);
                param.Add("@MT202Cov", saveSWIFT.pSWImport.MT202Cov);
                param.Add("@MT400", saveSWIFT.pSWImport.MT400);
                param.Add("@BNet", saveSWIFT.pSWImport.BNet);
                param.Add("@ToNego", saveSWIFT.pSWImport.ToNego);
                param.Add("@ToName", saveSWIFT.pSWImport.ToName);
                param.Add("@ToRefer", saveSWIFT.pSWImport.ToRefer);
                param.Add("@ToBank", saveSWIFT.pSWImport.ToBank);
                param.Add("@ToWhom", saveSWIFT.pSWImport.ToWhom);
                param.Add("@F20", saveSWIFT.pSWImport.F20);
                param.Add("@F20_X", saveSWIFT.pSWImport.F20_X);
                param.Add("@F21", saveSWIFT.pSWImport.F21);
                param.Add("@F21_X", saveSWIFT.pSWImport.F21_X);
                param.Add("@F23", saveSWIFT.pSWImport.F23);
                param.Add("@F23_X", saveSWIFT.pSWImport.F23_X);
                param.Add("@F26", saveSWIFT.pSWImport.F26);
                param.Add("@F30", saveSWIFT.pSWImport.F30);
                param.Add("@F32A", saveSWIFT.pSWImport.F32A);
                param.Add("@F32B", saveSWIFT.pSWImport.F32B);
                param.Add("@F33A", saveSWIFT.pSWImport.F33A);
                param.Add("@F33B", saveSWIFT.pSWImport.F33B);
                param.Add("@F34A", saveSWIFT.pSWImport.F34A);
                param.Add("@F50K", saveSWIFT.pSWImport.F50K);
                param.Add("@F59", saveSWIFT.pSWImport.F59);
                param.Add("@F70", saveSWIFT.pSWImport.F70);
                param.Add("@F71A", saveSWIFT.pSWImport.F71A);
                param.Add("@F71F", saveSWIFT.pSWImport.F71F);
                param.Add("@F52A", saveSWIFT.pSWImport.F52A);
                param.Add("@F52D", saveSWIFT.pSWImport.F52D);
                param.Add("@F53A", saveSWIFT.pSWImport.F53A);
                param.Add("@F53B", saveSWIFT.pSWImport.F53B);
                param.Add("@F53D", saveSWIFT.pSWImport.F53D);
                param.Add("@F53UID", saveSWIFT.pSWImport.F53UID);
                param.Add("@F54A", saveSWIFT.pSWImport.F54A);
                param.Add("@F54D", saveSWIFT.pSWImport.F54D);
                param.Add("@F54UID", saveSWIFT.pSWImport.F54UID);
                param.Add("@F56A", saveSWIFT.pSWImport.F56A);
                param.Add("@F56D", saveSWIFT.pSWImport.F56D);
                param.Add("@F56UID", saveSWIFT.pSWImport.F56UID);
                param.Add("@F57A", saveSWIFT.pSWImport.F57A);
                param.Add("@F57D", saveSWIFT.pSWImport.F57D);
                param.Add("@F57UID", saveSWIFT.pSWImport.F57UID);
                param.Add("@F58A", saveSWIFT.pSWImport.F58A);
                param.Add("@F58D", saveSWIFT.pSWImport.F58D);
                param.Add("@F58UID", saveSWIFT.pSWImport.F58UID);
                param.Add("@F71B", saveSWIFT.pSWImport.F71B);
                param.Add("@F72", saveSWIFT.pSWImport.F72);
                param.Add("@F72_X", saveSWIFT.pSWImport.F72_X);
                param.Add("@F73", saveSWIFT.pSWImport.F73);
                param.Add("@F79", saveSWIFT.pSWImport.F79);
                param.Add("@F79_X", saveSWIFT.pSWImport.F79_X);
                param.Add("@F77A", saveSWIFT.pSWImport.F77A);
                param.Add("@F77B", saveSWIFT.pSWImport.F77B);
                param.Add("@F77J", saveSWIFT.pSWImport.F77J);
                param.Add("@F53A_X", saveSWIFT.pSWImport.F53A_X);
                param.Add("@F53B_X", saveSWIFT.pSWImport.F53B_X);
                param.Add("@F53D_X", saveSWIFT.pSWImport.F53D_X);
                param.Add("@F53UID_X", saveSWIFT.pSWImport.F53UID_X);
                param.Add("@F54A_X", saveSWIFT.pSWImport.F54A_X);
                param.Add("@F54D_X", saveSWIFT.pSWImport.F54D_X);
                param.Add("@F54UID_X", saveSWIFT.pSWImport.F54UID_X);
                param.Add("@F72103", saveSWIFT.pSWImport.F72103);
                param.Add("@Flag32", saveSWIFT.pSWImport.Flag32);
                param.Add("@Detail32", saveSWIFT.pSWImport.Detail32);
                param.Add("@F21_B", saveSWIFT.pSWImport.F21_B);
                param.Add("@F21_C", saveSWIFT.pSWImport.F21_C);
                param.Add("@MT199", saveSWIFT.pSWImport.MT199);
                param.Add("@CF50", saveSWIFT.pSWImport.CF50);
                param.Add("@CF59", saveSWIFT.pSWImport.CF59);
                param.Add("@F79_Z", saveSWIFT.pSWImport.F79_Z);
                param.Add("@SWUuid", saveSWIFT.pSWImport.SWUuid);

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@SaveSWIFTResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<IMTR_SaveSWIFT_Response, dynamic>(
                    storedProcedure: "usp_pIMTR_IssueTR_SaveSWIFT",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveSWIFTResp = param.Get<dynamic>("@SaveSWIFTResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    IMTR_SaveSWIFT_JSON_rsp jsonResponse = JsonSerializer.Deserialize<IMTR_SaveSWIFT_JSON_rsp>(SaveSWIFTResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_LC_NO Insert Error";
                    response.Data = new IMTR_SaveSWIFT_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new IMTR_SaveSWIFT_JSON_rsp();
                return BadRequest(response);
            }

        }



















    }
}