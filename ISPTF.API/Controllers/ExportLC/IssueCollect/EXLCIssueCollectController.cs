using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportLC;
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

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCIssueCollectController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "1";
        private const string EVENT_TYPE = "Issue Collect";

        public EXLCIssueCollectController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("newlist")]
        public async Task<ActionResult<EXLCIssueCollectNewPageResponse>> GetAllNew(string? CenterID, string? RegDocNo, string? BENName, string? Page, string? PageSize)
        {
            EXLCIssueCollectNewPageResponse response = new EXLCIssueCollectNewPageResponse();

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(Page) ||
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueNewPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@CenterID", CenterID);
                param.Add("@RegDocNo", RegDocNo);
                param.Add("@BENName", BENName);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (RegDocNo == null)
                {
                    param.Add("@RegDocNo", "");
                }
                if (BENName == null)
                {
                    param.Add("@BENName", "");
                }

                var results = await _db.LoadData<Q_EXLCIssueNewPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_IssueCollNewPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueNewPageRsp>)results;

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
                response.Data = new List<Q_EXLCIssueNewPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("editlist")]
        public async Task<ActionResult<EXLCIssueCollectEditPageResponse>> GetAllEdit(string? CenterID, string? EXPORT_LC_NO, string? BENNAME, string? Page, string? PageSize)
        {
            EXLCIssueCollectEditPageResponse response = new EXLCIssueCollectEditPageResponse();

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(Page) ||
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENNAME", BENNAME);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENNAME == null)
                {
                    param.Add("@BENNAME", "");
                }

                var results = await _db.LoadData<Q_EXLCIssueEditPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_IssueCollEditPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueEditPageRsp>)results;

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
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("releaselist")]
        public async Task<ActionResult<EXLCIssueCollectReleasePageResponse>> GetAllRelease(string? CenterID, string? EXPORT_LC_NO, string? BENNAME, string? Page, string? PageSize)
        {
            EXLCIssueCollectReleasePageResponse response = new EXLCIssueCollectReleasePageResponse();
             var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(USER_ID) ||
                string.IsNullOrEmpty(Page) ||
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, USER_ID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@CenterID", CenterID);
                param.Add("@USER_ID", USER_ID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENNAME", BENNAME);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENNAME == null)
                {
                    param.Add("@BENNAME", "");
                }

                var results = await _db.LoadData<Q_EXLCIssueEditPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_IssueCollReleasePage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueEditPageRsp>)results;

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
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
            }
            return BadRequest(response);
        }
        // Select from pDocRegister
        [HttpGet("newselect")]
        public async Task<ActionResult<EXLCIssueCollectResponse>> GetNewSelect(string? RegDocNo)
        {

            EXLCIssueCollectResponse response = new EXLCIssueCollectResponse();

            // Validate
            if (string.IsNullOrEmpty(RegDocNo))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "RegDocNo is required";
                response.Data = new List<PDocRegisterCustomer>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@RegDocNo", RegDocNo);

                var results = await _db.LoadData<PDocRegisterCustomer, dynamic>(
                            storedProcedure: "usp_pDocRegisterCustomerSelect",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<PDocRegisterCustomer>)results;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<PDocRegisterCustomer>();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult<EXLCIssueCollectSelectResponse>> GetAllSelect(string? EXPORT_LC_NO, string? RECORD_TYPE, string? REC_STATUS, string? EVENT_NO)
        {
            EXLCIssueCollectSelectResponse response = new EXLCIssueCollectSelectResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || string.IsNullOrEmpty(EVENT_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                response.Data = new PEXLCPPaymentRsp();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new();

                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@RECORD_TYPE", RECORD_TYPE);
                param.Add("@REC_STATUS", REC_STATUS);
                param.Add("@EVENT_NO", EVENT_NO);

                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_IssueCollect_Select",
                           param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PExLcRsp > 0 && !string.IsNullOrEmpty(pexlcpexpaymentrsp))
                {
                    PEXLCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPPaymentRsp>(pexlcpexpaymentrsp);
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
                return BadRequest(response);
            }
        }

        [HttpPost("save")]
        public async Task<ActionResult<EXLCIssueCollectSaveResponse>> Save([FromBody] PEXLCPPaymentRsp pexlcppaymentreq)
        {
            PEXLCPPaymentSaveResponse response = new();
            // Class validate

            try
            {
                DynamicParameters param = new DynamicParameters();
                var USER_ID = User.Identity.Name;
                var claimsPrincipal = HttpContext.User;
                var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                //PEXLC
                param.Add("@EVENT_MODE", pexlcppaymentreq.PEXLC.EVENT_MODE);
                param.Add("@RECORD_TYPE", pexlcppaymentreq.PEXLC.RECORD_TYPE);
                param.Add("@REC_STATUS", pexlcppaymentreq.PEXLC.REC_STATUS);
                param.Add("@EVENT_NO", pexlcppaymentreq.PEXLC.EVENT_NO);
                param.Add("@BUSINESS_TYPE", pexlcppaymentreq.PEXLC.BUSINESS_TYPE);
                param.Add("@EXPORT_LC_NO", pexlcppaymentreq.PEXLC.EXPORT_LC_NO);
                param.Add("@EVENT_TYPE", pexlcppaymentreq.PEXLC.EVENT_TYPE);
                param.Add("@EVENT_DATE", pexlcppaymentreq.PEXLC.EVENT_DATE);
                param.Add("@TENOR_OF_COLL", pexlcppaymentreq.PEXLC.TENOR_OF_COLL);
                param.Add("@TENOR_TYPE", pexlcppaymentreq.PEXLC.TENOR_TYPE);
                param.Add("@INVOICE", pexlcppaymentreq.PEXLC.INVOICE);
                param.Add("@LC_REF_NO", pexlcppaymentreq.PEXLC.LC_REF_NO);
                param.Add("@REFER_LC_NO", pexlcppaymentreq.PEXLC.REFER_LC_NO);
                param.Add("@RELETE_PACK", pexlcppaymentreq.PEXLC.RELETE_PACK);
                param.Add("@DRAFT_CCY", pexlcppaymentreq.PEXLC.DRAFT_CCY);
                param.Add("@DRAFT_AMT", pexlcppaymentreq.PEXLC.DRAFT_AMT);
                param.Add("@SIGHT_AMT", pexlcppaymentreq.PEXLC.SIGHT_AMT);
                param.Add("@TERM_AMT", pexlcppaymentreq.PEXLC.TERM_AMT);
                param.Add("@GOOD_CODE", pexlcppaymentreq.PEXLC.GOOD_CODE);
                param.Add("@REL_CODE", pexlcppaymentreq.PEXLC.REL_CODE);
                param.Add("@CLAIM_TYPE", pexlcppaymentreq.PEXLC.CLAIM_TYPE);
                param.Add("@SIGHT_START_DATE", pexlcppaymentreq.PEXLC.SIGHT_START_DATE);
                param.Add("@SIGHT_DUE_DATE", pexlcppaymentreq.PEXLC.SIGHT_DUE_DATE);
                param.Add("@TENOR_DAY", pexlcppaymentreq.PEXLC.TENOR_DAY);
                param.Add("@TENOR_DAY_DESC", pexlcppaymentreq.PEXLC.TENOR_DAY_DESC);
                param.Add("@TERM_START_DATE", pexlcppaymentreq.PEXLC.TERM_START_DATE);
                param.Add("@TERM_DUE_DATE", pexlcppaymentreq.PEXLC.TERM_DUE_DATE);
                param.Add("@PURCH_DISC_DATE", pexlcppaymentreq.PEXLC.PURCH_DISC_DATE);
                param.Add("@APPLICANT_NAME", pexlcppaymentreq.PEXLC.APPLICANT_NAME);
                param.Add("@CNTY_CODE", pexlcppaymentreq.PEXLC.CNTY_CODE);
                param.Add("@Cust_AO", pexlcppaymentreq.PEXLC.Cust_AO);
                param.Add("@Cust_LO", pexlcppaymentreq.PEXLC.Cust_LO);
                param.Add("@BENE_ID", pexlcppaymentreq.PEXLC.BENE_ID);
                param.Add("@BENE_INFO", pexlcppaymentreq.PEXLC.BENE_INFO);
                param.Add("@ISSUE_BANK_ID", pexlcppaymentreq.PEXLC.ISSUE_BANK_ID);
                param.Add("@ISSUE_BANK_INFO", pexlcppaymentreq.PEXLC.ISSUE_BANK_INFO);
                param.Add("@COLLECT_AGENT", pexlcppaymentreq.PEXLC.COLLECT_AGENT);
                param.Add("@AGENT_BANK_ID", pexlcppaymentreq.PEXLC.AGENT_BANK_ID);
                param.Add("@AGENT_BANK_INFO", pexlcppaymentreq.PEXLC.AGENT_BANK_INFO);
                param.Add("@AGENT_BANK_REF", pexlcppaymentreq.PEXLC.AGENT_BANK_REF);
                param.Add("@AGENT_BANK_NOSTRO", pexlcppaymentreq.PEXLC.AGENT_BANK_NOSTRO);
                param.Add("@RESTRICT", pexlcppaymentreq.PEXLC.RESTRICT);
                param.Add("@RESTRICT_TO_BK_NAME", pexlcppaymentreq.PEXLC.RESTRICT_TO_BK_NAME);
                param.Add("@RESTRICT_TO_BK_ADDR1", pexlcppaymentreq.PEXLC.RESTRICT_TO_BK_ADDR1);
                param.Add("@RESTRICT_TO_BK_ADDR2", pexlcppaymentreq.PEXLC.RESTRICT_TO_BK_ADDR2);
                param.Add("@RESTRICT_TO_BK_ADDR3", pexlcppaymentreq.PEXLC.RESTRICT_TO_BK_ADDR3);
                param.Add("@RESTRICT_REFER", pexlcppaymentreq.PEXLC.RESTRICT_REFER);
                param.Add("@RESTRICT_FR_BK_NAME", pexlcppaymentreq.PEXLC.RESTRICT_FR_BK_NAME);
                param.Add("@RESTRICT_FR_BK_ADDR1", pexlcppaymentreq.PEXLC.RESTRICT_FR_BK_ADDR1);
                param.Add("@RESTRICT_FR_BK_ADDR2", pexlcppaymentreq.PEXLC.RESTRICT_FR_BK_ADDR2);
                param.Add("@RESTRICT_FR_BK_ADDR3", pexlcppaymentreq.PEXLC.RESTRICT_FR_BK_ADDR3);
                param.Add("@PARTIAL_FULL_RATE", pexlcppaymentreq.PEXLC.PARTIAL_FULL_RATE);
                param.Add("@INT_RATE_METHOD", pexlcppaymentreq.PEXLC.INT_RATE_METHOD);
                param.Add("@TYPE_OF_ACCOUNT", pexlcppaymentreq.PEXLC.TYPE_OF_ACCOUNT);
                param.Add("@CREDIT_CURRENCY", pexlcppaymentreq.PEXLC.CREDIT_CURRENCY);
                param.Add("@DISCOUNT_DAY", pexlcppaymentreq.PEXLC.DISCOUNT_DAY);
                param.Add("@GRACE_PERIOD", pexlcppaymentreq.PEXLC.GRACE_PERIOD);
                param.Add("@DISC_BASE_DAY", pexlcppaymentreq.PEXLC.DISC_BASE_DAY);
                param.Add("@BASE_DAY", pexlcppaymentreq.PEXLC.BASE_DAY);
                param.Add("@DISCOUNT_RATE", pexlcppaymentreq.PEXLC.DISCOUNT_RATE);
                param.Add("@INT_BASE_RATE", pexlcppaymentreq.PEXLC.INT_BASE_RATE);
                param.Add("@INT_SPREAD_RATE", pexlcppaymentreq.PEXLC.INT_SPREAD_RATE);
                param.Add("@CURRENT_DIS_RATE", pexlcppaymentreq.PEXLC.CURRENT_DIS_RATE);
                param.Add("@CURRENT_INT_RATE", pexlcppaymentreq.PEXLC.CURRENT_INT_RATE);
                param.Add("@PAY_BY", pexlcppaymentreq.PEXLC.PAY_BY);
                param.Add("@NEGO_AMT", pexlcppaymentreq.PEXLC.NEGO_AMT);
                param.Add("@LESS_AGENT", pexlcppaymentreq.PEXLC.LESS_AGENT);
                param.Add("@PURCHASE_AMT", pexlcppaymentreq.PEXLC.PURCHASE_AMT);
                param.Add("@PURCHASE_RATE", pexlcppaymentreq.PEXLC.PURCHASE_RATE);
                param.Add("@TOTAL_NEGO_BALANCE", pexlcppaymentreq.PEXLC.TOTAL_NEGO_BALANCE);
                param.Add("@TOTAL_NEGO_BAL_THB", pexlcppaymentreq.PEXLC.TOTAL_NEGO_BAL_THB);
                param.Add("@TOT_NEGO_AMT", pexlcppaymentreq.PEXLC.TOT_NEGO_AMT);
                param.Add("@TOT_NEGO_AMOUNT", pexlcppaymentreq.PEXLC.TOT_NEGO_AMOUNT);
                param.Add("@BANK_CHARGE_AMT", pexlcppaymentreq.PEXLC.BANK_CHARGE_AMT);
                param.Add("@NET_PROCEED_CLAIM", pexlcppaymentreq.PEXLC.NET_PROCEED_CLAIM);
                param.Add("@CLAIM_PAY_BY", pexlcppaymentreq.PEXLC.CLAIM_PAY_BY);
                param.Add("@ParTnor_Type1", pexlcppaymentreq.PEXLC.ParTnor_Type1);
                param.Add("@ParTnor_Type2", pexlcppaymentreq.PEXLC.ParTnor_Type2);
                param.Add("@ParTnor_Type3", pexlcppaymentreq.PEXLC.ParTnor_Type3);
                param.Add("@ParTnor_Type4", pexlcppaymentreq.PEXLC.ParTnor_Type4);
                param.Add("@ParTnor_Type5", pexlcppaymentreq.PEXLC.ParTnor_Type5);
                param.Add("@ParTnor_Type6", pexlcppaymentreq.PEXLC.ParTnor_Type6);
                param.Add("@PARTIAL_AMT1", pexlcppaymentreq.PEXLC.PARTIAL_AMT1);
                param.Add("@PARTIAL_AMT2", pexlcppaymentreq.PEXLC.PARTIAL_AMT2);
                param.Add("@PARTIAL_AMT3", pexlcppaymentreq.PEXLC.PARTIAL_AMT3);
                param.Add("@PARTIAL_AMT4", pexlcppaymentreq.PEXLC.PARTIAL_AMT4);
                param.Add("@PARTIAL_AMT5", pexlcppaymentreq.PEXLC.PARTIAL_AMT5);
                param.Add("@PARTIAL_AMT6", pexlcppaymentreq.PEXLC.PARTIAL_AMT6);
                param.Add("@PARTIAL_RATE1", pexlcppaymentreq.PEXLC.PARTIAL_RATE1);
                param.Add("@PARTIAL_RATE2", pexlcppaymentreq.PEXLC.PARTIAL_RATE2);
                param.Add("@PARTIAL_RATE3", pexlcppaymentreq.PEXLC.PARTIAL_RATE3);
                param.Add("@PARTIAL_RATE4", pexlcppaymentreq.PEXLC.PARTIAL_RATE4);
                param.Add("@PARTIAL_RATE5", pexlcppaymentreq.PEXLC.PARTIAL_RATE5);
                param.Add("@PARTIAL_RATE6", pexlcppaymentreq.PEXLC.PARTIAL_RATE6);
                param.Add("@PARTIAL_AMT1_THB", pexlcppaymentreq.PEXLC.PARTIAL_AMT1_THB);
                param.Add("@PARTIAL_AMT2_THB", pexlcppaymentreq.PEXLC.PARTIAL_AMT2_THB);
                param.Add("@PARTIAL_AMT3_THB", pexlcppaymentreq.PEXLC.PARTIAL_AMT3_THB);
                param.Add("@PARTIAL_AMT4_THB", pexlcppaymentreq.PEXLC.PARTIAL_AMT4_THB);
                param.Add("@PARTIAL_AMT5_THB", pexlcppaymentreq.PEXLC.PARTIAL_AMT5_THB);
                param.Add("@PARTIAL_AMT6_THB", pexlcppaymentreq.PEXLC.PARTIAL_AMT6_THB);
                param.Add("@FORWARD_CONRACT_NO", pexlcppaymentreq.PEXLC.FORWARD_CONRACT_NO);
                param.Add("@FORWARD_CONRACT_NO1", pexlcppaymentreq.PEXLC.FORWARD_CONRACT_NO1);
                param.Add("@FORWARD_CONRACT_NO2", pexlcppaymentreq.PEXLC.FORWARD_CONRACT_NO2);
                param.Add("@FORWARD_CONRACT_NO3", pexlcppaymentreq.PEXLC.FORWARD_CONRACT_NO3);
                param.Add("@FORWARD_CONRACT_NO4", pexlcppaymentreq.PEXLC.FORWARD_CONRACT_NO4);
                param.Add("@FORWARD_CONRACT_NO5", pexlcppaymentreq.PEXLC.FORWARD_CONRACT_NO5);
                param.Add("@FORWARD_CONRACT_NO6", pexlcppaymentreq.PEXLC.FORWARD_CONRACT_NO6);
                param.Add("@NEGO_COMM", pexlcppaymentreq.PEXLC.NEGO_COMM);
                param.Add("@TELEX_SWIFT", pexlcppaymentreq.PEXLC.TELEX_SWIFT);
                param.Add("@COURIER_POSTAGE", pexlcppaymentreq.PEXLC.COURIER_POSTAGE);
                param.Add("@STAMP_FEE", pexlcppaymentreq.PEXLC.STAMP_FEE);
                param.Add("@BE_STAMP", pexlcppaymentreq.PEXLC.BE_STAMP);
                param.Add("@COMM_OTHER", pexlcppaymentreq.PEXLC.COMM_OTHER);
                param.Add("@HANDING_FEE", pexlcppaymentreq.PEXLC.HANDING_FEE);
                param.Add("@DRAFTCOMM", pexlcppaymentreq.PEXLC.DRAFTCOMM);
                param.Add("@INT_AMT_CCY", pexlcppaymentreq.PEXLC.INT_AMT_CCY);
                param.Add("@INT_AMT_RATE", pexlcppaymentreq.PEXLC.INT_AMT_RATE);
                param.Add("@INT_AMT_THB", pexlcppaymentreq.PEXLC.INT_AMT_THB);
                param.Add("@COMMONTT", pexlcppaymentreq.PEXLC.COMMONTT);
                param.Add("@TOTAL_CHARGE", pexlcppaymentreq.PEXLC.TOTAL_CHARGE);
                param.Add("@REFUND_TAX_YN", pexlcppaymentreq.PEXLC.REFUND_TAX_YN);
                param.Add("@REFUND_TAX_AMT", pexlcppaymentreq.PEXLC.REFUND_TAX_AMT);
                param.Add("@DISCOUNT_CCY", pexlcppaymentreq.PEXLC.DISCOUNT_CCY);
                param.Add("@DISCRATE", pexlcppaymentreq.PEXLC.DISCRATE);
                param.Add("@DISCOUNT_AMT", pexlcppaymentreq.PEXLC.DISCOUNT_AMT);
                param.Add("@TOTAL_AMOUNT", pexlcppaymentreq.PEXLC.TOTAL_AMOUNT);
                param.Add("@PAYMENT_INSTRU", pexlcppaymentreq.PEXLC.PAYMENT_INSTRU);
                param.Add("@METHOD", pexlcppaymentreq.PEXLC.METHOD);
                param.Add("@ACBAHTNET", pexlcppaymentreq.PEXLC.ACBAHTNET);
                param.Add("@BAHTNET", pexlcppaymentreq.PEXLC.BAHTNET);
                param.Add("@RECEIVED_NO", pexlcppaymentreq.PEXLC.RECEIVED_NO);
                param.Add("@ALLOCATION", pexlcppaymentreq.PEXLC.ALLOCATION);
                param.Add("@NARRATIVE", pexlcppaymentreq.PEXLC.NARRATIVE);
                param.Add("@SEQ_ACCEPT_DUE", pexlcppaymentreq.PEXLC.SEQ_ACCEPT_DUE);
                param.Add("@COMFIRM_DUE", pexlcppaymentreq.PEXLC.COMFIRM_DUE);
                param.Add("@PLUS_MINUS_DISC", pexlcppaymentreq.PEXLC.PLUS_MINUS_DISC);
                param.Add("@DISC_DAYS_PLUS_MINUS", pexlcppaymentreq.PEXLC.DISC_DAYS_PLUS_MINUS);
                param.Add("@RECEIVE_PAY_AMT", pexlcppaymentreq.PEXLC.RECEIVE_PAY_AMT);
                param.Add("@EXCHANGE_RATE", pexlcppaymentreq.PEXLC.EXCHANGE_RATE);
                param.Add("@REFUND_DISC_RECEIVE", pexlcppaymentreq.PEXLC.REFUND_DISC_RECEIVE);
                param.Add("@DISC_RECEIVE", pexlcppaymentreq.PEXLC.DISC_RECEIVE);
                param.Add("@LC_DATE", pexlcppaymentreq.PEXLC.LC_DATE);
                param.Add("@COVERING_DATE", pexlcppaymentreq.PEXLC.COVERING_DATE);
                param.Add("@COVERING_FOR", pexlcppaymentreq.PEXLC.COVERING_FOR);
                param.Add("@ADVICE_ISSUE_BANK", pexlcppaymentreq.PEXLC.ADVICE_ISSUE_BANK);
                param.Add("@ADVICE_FORMAT", pexlcppaymentreq.PEXLC.ADVICE_FORMAT);
                param.Add("@REMIT_CLAIM_TYPE", pexlcppaymentreq.PEXLC.REMIT_CLAIM_TYPE);
                param.Add("@REIMBURSE_BANK_ID", pexlcppaymentreq.PEXLC.REIMBURSE_BANK_ID);
                param.Add("@REIMBURSE_BANK_INFO", pexlcppaymentreq.PEXLC.REIMBURSE_BANK_INFO);
                param.Add("@SWIFT_BANK", pexlcppaymentreq.PEXLC.SWIFT_BANK);
                param.Add("@SWIFT_MAIL", pexlcppaymentreq.PEXLC.SWIFT_MAIL);
                param.Add("@CLAIM_FORMAT", pexlcppaymentreq.PEXLC.CLAIM_FORMAT);
                param.Add("@VALUE_DATE", pexlcppaymentreq.PEXLC.VALUE_DATE);
                param.Add("@THIRD_BANK_ID", pexlcppaymentreq.PEXLC.THIRD_BANK_ID);
                param.Add("@THIRD_BANK_INFO", pexlcppaymentreq.PEXLC.THIRD_BANK_INFO);
                param.Add("@DISCREPANCY_TYPE", pexlcppaymentreq.PEXLC.DISCREPANCY_TYPE);
                param.Add("@SWIFT_DISC", pexlcppaymentreq.PEXLC.SWIFT_DISC);
                param.Add("@DOCUMENT_COPY", pexlcppaymentreq.PEXLC.DOCUMENT_COPY);

                // Convert bool to string => DB BIT (0/1)
                string SIGHT_BASIS = "0";
                if (pexlcppaymentreq.PEXLC.SIGHT_BASIS == true)
                {
                    SIGHT_BASIS = "1";
                }
                string ART44A = "0";
                if (pexlcppaymentreq.PEXLC.ART44A == true)
                {
                    ART44A = "1";
                }
                string ENDORSED = "0";
                if (pexlcppaymentreq.PEXLC.ENDORSED == true)
                {
                    ENDORSED = "1";
                }
                string MT750 = "0";
                if (pexlcppaymentreq.PEXLC.MT750 == true)
                {
                    MT750 = "1";
                }
                param.Add("@SIGHT_BASIS", SIGHT_BASIS);
                param.Add("@ART44A", ART44A);
                param.Add("@ENDORSED", ENDORSED);
                param.Add("@MT750", MT750);


                param.Add("@ADJ_TOT_NEGO_AMOUNT", pexlcppaymentreq.PEXLC.ADJ_TOT_NEGO_AMOUNT);
                param.Add("@ADJ_LESS_CHARGE_AMT", pexlcppaymentreq.PEXLC.ADJ_LESS_CHARGE_AMT);
                param.Add("@ADJUST_COVERING_AMT", pexlcppaymentreq.PEXLC.ADJUST_COVERING_AMT);
                param.Add("@ADJUST_TENOR", pexlcppaymentreq.PEXLC.ADJUST_TENOR);
                param.Add("@ADJUST_LC_REF", pexlcppaymentreq.PEXLC.ADJUST_LC_REF);
                param.Add("@PAYMENT_INSTRC", pexlcppaymentreq.PEXLC.PAYMENT_INSTRC);
                param.Add("@TXTDOCUMENT", pexlcppaymentreq.PEXLC.TXTDOCUMENT);
                param.Add("@CHARGE_ACC", pexlcppaymentreq.PEXLC.CHARGE_ACC);
                param.Add("@DRAFT", pexlcppaymentreq.PEXLC.DRAFT);
                param.Add("@MT202", pexlcppaymentreq.PEXLC.MT202);
                param.Add("@FB_CURRENCY", pexlcppaymentreq.PEXLC.FB_CURRENCY);
                param.Add("@FB_AMT", pexlcppaymentreq.PEXLC.FB_AMT);
                param.Add("@FB_RATE", pexlcppaymentreq.PEXLC.FB_RATE);
                param.Add("@FB_AMT_THB", pexlcppaymentreq.PEXLC.FB_AMT_THB);
                param.Add("@COLLECT_REFUND", pexlcppaymentreq.PEXLC.COLLECT_REFUND);
                param.Add("@USER_ID", USER_ID);
                param.Add("@IN_USE", pexlcppaymentreq.PEXLC.IN_USE);
                //param.Add("@UPDATE_DATE", pexlcppaymentreq.PEXLC.UPDATE_DATE);
                param.Add("@AUTH_CODE", pexlcppaymentreq.PEXLC.AUTH_CODE);
                //param.Add("@AUTH_DATE", pexlcppaymentreq.PEXLC.AUTH_DATE);
                //param.Add("@GENACC_DATE", pexlcppaymentreq.PEXLC.GENACC_DATE);
                param.Add("@GENACC_FLAG", pexlcppaymentreq.PEXLC.GENACC_FLAG);
                param.Add("@VOUCH_ID", pexlcppaymentreq.PEXLC.VOUCH_ID);
                param.Add("@APPVNO", pexlcppaymentreq.PEXLC.APPVNO);
                param.Add("@FACNO", pexlcppaymentreq.PEXLC.FACNO);
                param.Add("@AUTOOVERDUE", pexlcppaymentreq.PEXLC.AUTOOVERDUE);
                param.Add("@LCOVERDUE", pexlcppaymentreq.PEXLC.LCOVERDUE);
                param.Add("@OVESEQNO", pexlcppaymentreq.PEXLC.OVESEQNO);
                param.Add("@INTFLAG", pexlcppaymentreq.PEXLC.INTFLAG);
                param.Add("@IntRateCode", pexlcppaymentreq.PEXLC.IntRateCode);
                param.Add("@CFRRate", pexlcppaymentreq.PEXLC.CFRRate);
                param.Add("@INTCODE", pexlcppaymentreq.PEXLC.INTCODE);
                param.Add("@OINTRATE", pexlcppaymentreq.PEXLC.OINTRATE);
                param.Add("@OINTSPDRATE", pexlcppaymentreq.PEXLC.OINTSPDRATE);
                param.Add("@OINTCURRATE", pexlcppaymentreq.PEXLC.OINTCURRATE);
                param.Add("@OINTDAY", pexlcppaymentreq.PEXLC.OINTDAY);
                param.Add("@OBASEDAY", pexlcppaymentreq.PEXLC.OBASEDAY);
                param.Add("@BFINTAMT", pexlcppaymentreq.PEXLC.BFINTAMT);
                param.Add("@SELLING_RATE", pexlcppaymentreq.PEXLC.SELLING_RATE);
                param.Add("@BFINTTHB", pexlcppaymentreq.PEXLC.BFINTTHB);
                param.Add("@INTBALANCE", pexlcppaymentreq.PEXLC.INTBALANCE);
                param.Add("@PRNBALANCE", pexlcppaymentreq.PEXLC.PRNBALANCE);
                param.Add("@LASTINTAMT", pexlcppaymentreq.PEXLC.LASTINTAMT);
                param.Add("@DMS", pexlcppaymentreq.PEXLC.DMS);
                param.Add("@LASTINTDATE", pexlcppaymentreq.PEXLC.LASTINTDATE);
                param.Add("@PAYMENTTYPE", pexlcppaymentreq.PEXLC.PAYMENTTYPE);
                param.Add("@CONFIRM_DATE", pexlcppaymentreq.PEXLC.CONFIRM_DATE);
                param.Add("@TOTALACCRUAMT", pexlcppaymentreq.PEXLC.TOTALACCRUAMT);
                param.Add("@TOTALACCRUBHT", pexlcppaymentreq.PEXLC.TOTALACCRUBHT);
                param.Add("@ACCRUAMT", pexlcppaymentreq.PEXLC.ACCRUAMT);
                param.Add("@ACCRUBHT", pexlcppaymentreq.PEXLC.ACCRUBHT);
                param.Add("@DATELASTACCRU", pexlcppaymentreq.PEXLC.DATELASTACCRU);
                param.Add("@PASTDUEDATE", pexlcppaymentreq.PEXLC.PASTDUEDATE);
                param.Add("@PASTDUEFLAG", pexlcppaymentreq.PEXLC.PASTDUEFLAG);
                param.Add("@TOTALSUSPAMT", pexlcppaymentreq.PEXLC.TOTALSUSPAMT);
                param.Add("@TOTALSUSPBHT", pexlcppaymentreq.PEXLC.TOTALSUSPBHT);
                param.Add("@SUSPAMT", pexlcppaymentreq.PEXLC.SUSPAMT);
                param.Add("@SUSPBHT", pexlcppaymentreq.PEXLC.SUSPBHT);
                param.Add("@CenterID", USER_CENTER_ID);
                param.Add("@LCPastDue", pexlcppaymentreq.PEXLC.LCPastDue);
                param.Add("@DateStartAccru", pexlcppaymentreq.PEXLC.DateStartAccru);
                param.Add("@DateToStop", pexlcppaymentreq.PEXLC.DateToStop);
                param.Add("@ValueDate", pexlcppaymentreq.PEXLC.ValueDate);
                param.Add("@FlagBack", pexlcppaymentreq.PEXLC.FlagBack);
                param.Add("@NewAccruCcy", pexlcppaymentreq.PEXLC.NewAccruCcy);
                param.Add("@NewAccruAmt", pexlcppaymentreq.PEXLC.NewAccruAmt);
                param.Add("@AccruPending", pexlcppaymentreq.PEXLC.AccruPending);
                param.Add("@LastAccruCcy", pexlcppaymentreq.PEXLC.LastAccruCcy);
                param.Add("@LastAccruAmt", pexlcppaymentreq.PEXLC.LastAccruAmt);
                param.Add("@DAccruAmt", pexlcppaymentreq.PEXLC.DAccruAmt);
                param.Add("@CCS_ACCT", pexlcppaymentreq.PEXLC.CCS_ACCT);
                param.Add("@CCS_LmType", pexlcppaymentreq.PEXLC.CCS_LmType);
                param.Add("@CCS_CNUM", pexlcppaymentreq.PEXLC.CCS_CNUM);
                param.Add("@CCS_CIFRef", pexlcppaymentreq.PEXLC.CCS_CIFRef);
                param.Add("@WithOut", pexlcppaymentreq.PEXLC.WithOut);
                param.Add("@WOFUND", pexlcppaymentreq.PEXLC.WOFUND);
                param.Add("@INT_PAID_AMT", pexlcppaymentreq.PEXLC.INT_PAID_AMT);
                param.Add("@INT_PAID_RATE", pexlcppaymentreq.PEXLC.INT_PAID_RATE);
                param.Add("@INT_PAID_THB", pexlcppaymentreq.PEXLC.INT_PAID_THB);
                param.Add("@WithOutFlag", pexlcppaymentreq.PEXLC.WithOutFlag);
                param.Add("@WithOutType", pexlcppaymentreq.PEXLC.WithOutType);
                param.Add("@Wref_Bank_ID", pexlcppaymentreq.PEXLC.Wref_Bank_ID);
                param.Add("@AcceptFlag", pexlcppaymentreq.PEXLC.AcceptFlag);
                param.Add("@AcceptDate", pexlcppaymentreq.PEXLC.AcceptDate);
                param.Add("@RevAccru", pexlcppaymentreq.PEXLC.RevAccru);
                param.Add("@ObjectType", pexlcppaymentreq.PEXLC.ObjectType);
                param.Add("@UnderlyName", pexlcppaymentreq.PEXLC.UnderlyName);
                param.Add("@applicant_info", pexlcppaymentreq.PEXLC.APPLICANT_INFO);
                param.Add("@BPOFlag", pexlcppaymentreq.PEXLC.BPOFlag);
                param.Add("@Campaign_Code", pexlcppaymentreq.PEXLC.Campaign_Code);
                param.Add("@Campaign_EffDate", pexlcppaymentreq.PEXLC.Campaign_EffDate);
                param.Add("@Pending_Payable", pexlcppaymentreq.PEXLC.Pending_Payable);
                param.Add("@PurposeCode", pexlcppaymentreq.PEXLC.PurposeCode);
                param.Add("@RELETE_CONFIRM", pexlcppaymentreq.PEXLC.RELETE_CONFIRM);
                param.Add("@ConfirmFlag", pexlcppaymentreq.PEXLC.ConfirmFlag);
                param.Add("@Com_Lieu", pexlcppaymentreq.PEXLC.Com_Lieu);
                param.Add("@ComLieuRate", pexlcppaymentreq.PEXLC.ComLieuRate);
                //PPayment
                param.Add("@RpPayDate", pexlcppaymentreq.PPAYMENT.RpPayDate);
                param.Add("@RpNote", pexlcppaymentreq.PPAYMENT.RpNote);
                param.Add("@RpCashAmt", pexlcppaymentreq.PPAYMENT.RpCashAmt);
                param.Add("@RpChqAmt", pexlcppaymentreq.PPAYMENT.RpChqAmt);
                param.Add("@RpChqNo", pexlcppaymentreq.PPAYMENT.RpChqNo);
                param.Add("@RpChqBank", pexlcppaymentreq.PPAYMENT.RpChqBank);
                param.Add("@RpChqBranch", pexlcppaymentreq.PPAYMENT.RpChqBranch);
                param.Add("@RpCustAc1", pexlcppaymentreq.PPAYMENT.RpCustAc1);
                param.Add("@RpCustAmt1", pexlcppaymentreq.PPAYMENT.RpCustAmt1);
                param.Add("@RpCustAc2", pexlcppaymentreq.PPAYMENT.RpCustAc2);
                param.Add("@RpCustAmt2", pexlcppaymentreq.PPAYMENT.RpCustAmt2);
                param.Add("@RpCustAc3", pexlcppaymentreq.PPAYMENT.RpCustAc3);
                param.Add("@RpCustAmt3", pexlcppaymentreq.PPAYMENT.RpCustAmt3);
                param.Add("@RpStatus", pexlcppaymentreq.PPAYMENT.RpStatus);

                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                //param.Add("@Resp", dbType: DbType.Int32,
                param.Add("@Resp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);

                var results = await _db.LoadData<PEXLCPPaymentRsp, dynamic>(
                    storedProcedure: "usp_pEXLC_IssueCollect_Save",
                    param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexLcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                var resp = param.Get<int>("@PExLcRsp");
                if (PExLcRsp == 1)
                {
                    PEXLCPPaymentDataContainer jsonResponse = JsonSerializer.Deserialize<PEXLCPPaymentDataContainer>(pexLcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    //return Ok(response);


                    bool resGL;
                    bool resPayD;
                    string eventDate;
                    string resVoucherID;
                    string resEventType;
                    int resSeqNo;
                    resEventType = response.Data.PEXLC.EVENT_TYPE;
                    resSeqNo = response.Data.PEXLC.EVENT_NO;

                    eventDate = pexlcppaymentreq.PEXLC.EVENT_DATE.ToString("dd/MM/yyyy");
                    if (pexlcppaymentreq.PEXLC.PAYMENT_INSTRU == "PAID")
                    {
                        resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(pexlcppaymentreq.PEXLC.EXPORT_LC_NO,
                            eventDate,
                            resEventType,
                            resSeqNo,
                            "Issue Collect");

                    }
                    else
                    {
                        resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(pexlcppaymentreq.PEXLC.EXPORT_LC_NO,
                            eventDate,
                           resEventType,
                            resSeqNo,
                            "Issue Collect",
                            false,
                            "U");

                    }
                    if (resVoucherID != "ERROR")
                    {
                        resGL = true;
                    }
                    else
                    {
                        resGL = false;
                    }

                    string resPayDetail;
                    string resReceiptNo;
                    resReceiptNo = response.Data.PEXLC.RECEIVED_NO;
                    if (pexlcppaymentreq.PPAYMENT != null)
                    {
                        resPayDetail = ISPModule.PayDetailEXBC.PayDetail_IssCollect(pexlcppaymentreq.PEXLC.EXPORT_LC_NO, resSeqNo, resReceiptNo);
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
                  //  resPayD = true;
                    if (resGL == true && resPayD == true)
                    {
                        response.Data.PEXLC.VOUCH_ID = resVoucherID;
                        return Ok(response);
                    }
                    else
                    {
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = "EXPORT_LC_NO Update G/L or Payment Error";
                        response.Data = new PEXLCPPaymentDataContainer();
                        return BadRequest(response);
                    }













                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_LC_NO Insert Error";
                    response.Data = new PEXLCPPaymentDataContainer();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPPaymentDataContainer();
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<EXLCResultResponse>> Release([FromBody] PEXLCSaveRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();
            // 0 - Select EXLC Master
            var pExlcMaster = (from row in _context.pExlcs
                               where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                     row.RECORD_TYPE == "MASTER"
                               select row).FirstOrDefault();

            if (pExlcMaster == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "PEXLC " + EVENT_TYPE + " Master does not exists";
                return BadRequest(response);
            }

            DateTime VOUCH_DATE = ExportLCHelper.GetSysDate(_context);

            // 1 - Check if GL is Balance
            if (await ExportLCHelper.GLBalance(_context, VOUCH_DATE, data.PEXLC.VOUCH_ID) == true)
            {
                try
                {
                    using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        try
                        {
                            // 2 - Update GL Flag
                            var gls = (from row in _context.pDailyGLs
                                       where row.VouchID == data.PEXLC.VOUCH_ID &&
                                                row.VouchDate == data.PEXLC.EVENT_DATE.GetValueOrDefault().Date
                                       select row).ToListAsync();

                            foreach (var row in await gls)
                            {
                                row.SendFlag = "R";
                            }

                            // 3 - Update Master
                            var USER_ID = User.Identity.Name;
                            var claimsPrincipal = HttpContext.User;
                            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = GETDATE() WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");


                            // 4 - Update Event
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = GETDATE() WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT'");


                            // 5 - Update PPayment
                            var pPayments = (from row in _context.pPayments
                                             where row.RpReceiptNo == data.PEXLC.RECEIVED_NO
                                             select row).ToListAsync();

                            foreach (var row in await pPayments)
                            {
                                row.RpRecStatus = "R";
                            }

                            // Commit
                            await _context.SaveChangesAsync();
                            transaction.Complete();

                            response.Code = Constants.RESPONSE_OK;
                            response.Message = "Export L/C Release Complete";
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
            else
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "GL Transaction not balance please check.";
                return BadRequest(response);
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult<EXLCResultResponse>> Delete([FromBody] PEXLCDeleteRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();

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
                        var pExlcEvents = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "EVENT" &&
                                                 row.EVENT_TYPE == EVENT_TYPE &&
                                                 row.REC_STATUS == "P" &&
                                                 (row.RECEIVED_NO != null && row.RECEIVED_NO != "")
                                           select row).ToListAsync();

                        foreach (var row in await pExlcEvents)
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
                                       where row.TranDocNo == data.EXPORT_LC_NO &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 3 - Update PDOCRegister
                        var pDocRegister = (from row in _context.pDocRegisters
                                            where row.Reg_Docno == data.EXPORT_LC_NO &&
                                                  row.Reg_Login == "EXLC"
                                            select row).ToListAsync();

                        foreach (var row in await pDocRegister)
                        {
                            row.Reg_Status = "A";
                            row.Remark = "N";
                        }


                        // 4 - Delete all pExlc
                        var pExlcs = (from row in _context.pExlcs
                                      where row.EXPORT_LC_NO == data.EXPORT_LC_NO
                                      select row).ToListAsync();

                        foreach (var row in await pExlcs)
                        {
                            _context.pExlcs.Remove(row);
                        }


                        // 5 - Delete pSWExport
                        var pSWExports = (from row in _context.pSWExports
                                          where row.DocNo == data.EXPORT_LC_NO
                                          select row).ToListAsync();

                        foreach (var row in await pSWExports)
                        {
                            _context.pSWExports.Remove(row);
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
                }
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Export L/C Deleted";
                return Ok(response);

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
