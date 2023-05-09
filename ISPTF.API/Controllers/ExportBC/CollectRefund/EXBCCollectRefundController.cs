using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.PurchasePayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ISPTF.API.Controllers.ExportBC
{
    [ApiController]
    [Route("api/[controller]")]
    public class EXBCCollectRefundController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public EXBCCollectRefundController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXBCCollectRefundListPageResponse>> GetAllList(string? @ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCCollectRefundListPageResponse response = new EXBCCollectRefundListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(@ListType) || string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCCollectRefundListPageRsp>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@ListType", @ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@BENName", BENName);
            param.Add("@USER_ID", USER_ID);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_BC_NO == null)
            {
                param.Add("@EXPORT_BC_NO", "");
            }
            if (BENName == null)
            {
                param.Add("@BENName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_EXBCCollectRefundListPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_CollectRefundListPage",
                        param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCCollectRefundListPageRsp>)results;
                try
                {
                    response.Page = (int)Page;
                    response.Total = (int)response.Data[0].RCount;
                    response.TotalPage = (int)((response.Total + PageSize - 1) / PageSize);
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
                response.Data = new List<Q_EXBCCollectRefundListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("query")]
        public async Task<ActionResult<EXBCCollectRefundQueryPageResponse>> GetAllQuery(string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCCollectRefundQueryPageResponse response = new EXBCCollectRefundQueryPageResponse();
            var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCCollectRefundQueryPageRsp>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            //param.Add("@ListType", @ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@BENName", BENName);
            param.Add("@USER_ID", USER_ID);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_BC_NO == null)
            {
                param.Add("@EXPORT_BC_NO", "");
            }
            if (BENName == null)
            {
                param.Add("@BENName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_EXBCAcceptTermDueQueryPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXBC_CollectRefundQueryPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCCollectRefundQueryPageRsp>)results;
                try
                {
                    response.Page = (int)Page;
                    response.Total = (int)response.Data[0].RCount;
                    response.TotalPage = (int)((response.Total + PageSize - 1) / PageSize);
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
                response.Data = new List<Q_EXBCCollectRefundQueryPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("select")]
        public async Task<ActionResult<PEXBCPPaymentResponse>> GetAllSelect(string? EXPORT_BC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXBCPPaymentResponse response = new PEXBCPPaymentResponse();
            var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(EXPORT_BC_NO) || string.IsNullOrEmpty(EVENT_NO) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXBCPPaymentRsp();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@EVENT_NO", EVENT_NO);
            param.Add("@LFROM", LFROM);
            param.Add("@PExBcRsp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);
            param.Add("@PEXBCPPaymentRsp", dbType: DbType.String,
                       direction: System.Data.ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<PEXBCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXBC_CollectRefund_Select",
                           param);

                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");
                var pexbcppaymentrsp = param.Get<dynamic>("@PEXBCPPaymentRsp");

                if (PExBcRsp > 0 && !string.IsNullOrEmpty(pexbcppaymentrsp))
                {
                    PEXBCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXBCPPaymentRsp>(pexbcppaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT B/C NO does not exit";
                    response.Data = new PEXBCPPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXBCPPaymentRsp();
            }
            return BadRequest(response);
        }


        [HttpPost("save")]
        public async Task<ActionResult<PEXBCPPaymentResponse>> Insert([FromBody] PEXBCPPaymentRsp pexbcppaymentreq)
        {
            PEXBCPPaymentResponse response = new PEXBCPPaymentResponse();
            var USER_ID = User.Identity.Name;

            DynamicParameters param = new DynamicParameters();
            //PEXBC
            param.Add("@RECORD_TYPE", pexbcppaymentreq.PEXBC.RECORD_TYPE);
            param.Add("@REC_STATUS", pexbcppaymentreq.PEXBC.REC_STATUS);
            param.Add("@EVENT_NO", pexbcppaymentreq.PEXBC.EVENT_NO);
            param.Add("@EXPORT_BC_NO", pexbcppaymentreq.PEXBC.EXPORT_BC_NO);
            param.Add("@EVENT_MODE", pexbcppaymentreq.PEXBC.EVENT_MODE);
            param.Add("@BUSINESS_TYPE", pexbcppaymentreq.PEXBC.BUSINESS_TYPE);
            param.Add("@EVENT_TYPE", pexbcppaymentreq.PEXBC.EVENT_TYPE);
            param.Add("@EVENT_DATE", pexbcppaymentreq.PEXBC.EVENT_DATE);
            param.Add("@TENOR_OF_COLL", pexbcppaymentreq.PEXBC.TENOR_OF_COLL);
            param.Add("@TENOR_TYPE", pexbcppaymentreq.PEXBC.TENOR_TYPE);
            param.Add("@INVOICE", pexbcppaymentreq.PEXBC.INVOICE);
            param.Add("@REFER_BC_NO", pexbcppaymentreq.PEXBC.REFER_BC_NO);
            param.Add("@RELETE_PACK", pexbcppaymentreq.PEXBC.RELETE_PACK);
            param.Add("@DRAFT_CCY", pexbcppaymentreq.PEXBC.DRAFT_CCY);
            param.Add("@DRAFT_AMT", pexbcppaymentreq.PEXBC.DRAFT_AMT);
            param.Add("@SIGHT_AMT", pexbcppaymentreq.PEXBC.SIGHT_AMT);
            param.Add("@TERM_AMT", pexbcppaymentreq.PEXBC.TERM_AMT);
            param.Add("@GOOD_CODE", pexbcppaymentreq.PEXBC.GOOD_CODE);
            param.Add("@REL_CODE", pexbcppaymentreq.PEXBC.REL_CODE);
            param.Add("@CLAIM_TYPE", pexbcppaymentreq.PEXBC.CLAIM_TYPE);
            param.Add("@SIGHT_START_DATE", pexbcppaymentreq.PEXBC.SIGHT_START_DATE);
            param.Add("@SIGHT_DUE_DATE", pexbcppaymentreq.PEXBC.SIGHT_DUE_DATE);
            param.Add("@TENOR_DAY", pexbcppaymentreq.PEXBC.TENOR_DAY);
            param.Add("@TENOR_DAY_DESC", pexbcppaymentreq.PEXBC.TENOR_DAY_DESC);
            param.Add("@TERM_START_DATE", pexbcppaymentreq.PEXBC.TERM_START_DATE);
            param.Add("@TERM_DUE_DATE", pexbcppaymentreq.PEXBC.TERM_DUE_DATE);
            param.Add("@PURCH_DISC_DATE", pexbcppaymentreq.PEXBC.PURCH_DISC_DATE);
            param.Add("@DRAWEE_INFO", pexbcppaymentreq.PEXBC.DRAWEE_INFO);
            param.Add("@CNTY_CODE", pexbcppaymentreq.PEXBC.CNTY_CODE);
            param.Add("@Cust_AO", pexbcppaymentreq.PEXBC.Cust_AO);
            param.Add("@Cust_LO", pexbcppaymentreq.PEXBC.Cust_LO);
            param.Add("@BENE_ID", pexbcppaymentreq.PEXBC.BENE_ID);
            param.Add("@BENE_INFO", pexbcppaymentreq.PEXBC.BENE_INFO);
            param.Add("@ISSUE_BANK_ID", pexbcppaymentreq.PEXBC.ISSUE_BANK_ID);
            param.Add("@ISSUE_BANK_INFO", pexbcppaymentreq.PEXBC.ISSUE_BANK_INFO);
            param.Add("@COLLECT_AGENT", pexbcppaymentreq.PEXBC.COLLECT_AGENT);
            param.Add("@AGENT_BANK_ID", pexbcppaymentreq.PEXBC.AGENT_BANK_ID);
            param.Add("@AGENT_BANK_INFO", pexbcppaymentreq.PEXBC.AGENT_BANK_INFO);
            param.Add("@AGENT_BANK_REF", pexbcppaymentreq.PEXBC.AGENT_BANK_REF);
            param.Add("@AGENT_BANK_NOSTRO", pexbcppaymentreq.PEXBC.AGENT_BANK_NOSTRO);
            param.Add("@RESTRICT", pexbcppaymentreq.PEXBC.RESTRICT);
            param.Add("@RESTRICT_TO_BK_NAME", pexbcppaymentreq.PEXBC.RESTRICT_TO_BK_NAME);
            param.Add("@RESTRICT_TO_BK_ADDR1", pexbcppaymentreq.PEXBC.RESTRICT_TO_BK_ADDR1);
            param.Add("@RESTRICT_TO_BK_ADDR2", pexbcppaymentreq.PEXBC.RESTRICT_TO_BK_ADDR2);
            param.Add("@RESTRICT_TO_BK_ADDR3", pexbcppaymentreq.PEXBC.RESTRICT_TO_BK_ADDR3);
            param.Add("@RESTRICT_REFER", pexbcppaymentreq.PEXBC.RESTRICT_REFER);
            param.Add("@RESTRICT_FR_BK_NAME", pexbcppaymentreq.PEXBC.RESTRICT_FR_BK_NAME);
            param.Add("@RESTRICT_FR_BK_ADDR1", pexbcppaymentreq.PEXBC.RESTRICT_FR_BK_ADDR1);
            param.Add("@RESTRICT_FR_BK_ADDR2", pexbcppaymentreq.PEXBC.RESTRICT_FR_BK_ADDR2);
            param.Add("@RESTRICT_FR_BK_ADDR3", pexbcppaymentreq.PEXBC.RESTRICT_FR_BK_ADDR3);
            param.Add("@PARTIAL_FULL_RATE", pexbcppaymentreq.PEXBC.PARTIAL_FULL_RATE);
            param.Add("@INT_RATE_METHOD", pexbcppaymentreq.PEXBC.INT_RATE_METHOD);
            param.Add("@TYPE_OF_ACCOUNT", pexbcppaymentreq.PEXBC.TYPE_OF_ACCOUNT);
            param.Add("@CREDIT_CURRENCY", pexbcppaymentreq.PEXBC.CREDIT_CURRENCY);
            param.Add("@DISCOUNT_DAY", pexbcppaymentreq.PEXBC.DISCOUNT_DAY);
            param.Add("@GRACE_PERIOD", pexbcppaymentreq.PEXBC.GRACE_PERIOD);
            param.Add("@DISC_BASE_DAY", pexbcppaymentreq.PEXBC.DISC_BASE_DAY);
            param.Add("@BASE_DAY", pexbcppaymentreq.PEXBC.BASE_DAY);
            param.Add("@DISCOUNT_RATE", pexbcppaymentreq.PEXBC.DISCOUNT_RATE);
            param.Add("@INT_BASE_RATE", pexbcppaymentreq.PEXBC.INT_BASE_RATE);
            param.Add("@INT_SPREAD_RATE", pexbcppaymentreq.PEXBC.INT_SPREAD_RATE);
            param.Add("@CURRENT_DIS_RATE", pexbcppaymentreq.PEXBC.CURRENT_DIS_RATE);
            param.Add("@CURRENT_INT_RATE", pexbcppaymentreq.PEXBC.CURRENT_INT_RATE);
            param.Add("@PAY_BY", pexbcppaymentreq.PEXBC.PAY_BY);
            param.Add("@NEGO_AMT", pexbcppaymentreq.PEXBC.NEGO_AMT);
            param.Add("@LESS_AGENT", pexbcppaymentreq.PEXBC.LESS_AGENT);
            param.Add("@PURCHASE_AMT", pexbcppaymentreq.PEXBC.PURCHASE_AMT);
            param.Add("@PURCHASE_RATE", pexbcppaymentreq.PEXBC.PURCHASE_RATE);
            param.Add("@TOTAL_NEGO_BALANCE", pexbcppaymentreq.PEXBC.TOTAL_NEGO_BALANCE);
            param.Add("@TOTAL_NEGO_BAL_THB", pexbcppaymentreq.PEXBC.TOTAL_NEGO_BAL_THB);
            param.Add("@TOT_NEGO_AMT", pexbcppaymentreq.PEXBC.TOT_NEGO_AMT);
            param.Add("@TOT_NEGO_AMOUNT", pexbcppaymentreq.PEXBC.TOT_NEGO_AMOUNT);
            param.Add("@BANK_CHARGE_AMT", pexbcppaymentreq.PEXBC.BANK_CHARGE_AMT);
            param.Add("@NET_PROCEED_CLAIM", pexbcppaymentreq.PEXBC.NET_PROCEED_CLAIM);
            param.Add("@CLAIM_PAY_BY", pexbcppaymentreq.PEXBC.CLAIM_PAY_BY);
            param.Add("@ParTnor_Type1", pexbcppaymentreq.PEXBC.ParTnor_Type1);
            param.Add("@ParTnor_Type2", pexbcppaymentreq.PEXBC.ParTnor_Type2);
            param.Add("@ParTnor_Type3", pexbcppaymentreq.PEXBC.ParTnor_Type3);
            param.Add("@ParTnor_Type4", pexbcppaymentreq.PEXBC.ParTnor_Type4);
            param.Add("@ParTnor_Type5", pexbcppaymentreq.PEXBC.ParTnor_Type5);
            param.Add("@ParTnor_Type6", pexbcppaymentreq.PEXBC.ParTnor_Type6);
            param.Add("@PARTIAL_AMT1", pexbcppaymentreq.PEXBC.PARTIAL_AMT1);
            param.Add("@PARTIAL_AMT2", pexbcppaymentreq.PEXBC.PARTIAL_AMT2);
            param.Add("@PARTIAL_AMT3", pexbcppaymentreq.PEXBC.PARTIAL_AMT3);
            param.Add("@PARTIAL_AMT4", pexbcppaymentreq.PEXBC.PARTIAL_AMT4);
            param.Add("@PARTIAL_AMT5", pexbcppaymentreq.PEXBC.PARTIAL_AMT5);
            param.Add("@PARTIAL_AMT6", pexbcppaymentreq.PEXBC.PARTIAL_AMT6);
            param.Add("@PARTIAL_RATE1", pexbcppaymentreq.PEXBC.PARTIAL_RATE1);
            param.Add("@PARTIAL_RATE2", pexbcppaymentreq.PEXBC.PARTIAL_RATE2);
            param.Add("@PARTIAL_RATE3", pexbcppaymentreq.PEXBC.PARTIAL_RATE3);
            param.Add("@PARTIAL_RATE4", pexbcppaymentreq.PEXBC.PARTIAL_RATE4);
            param.Add("@PARTIAL_RATE5", pexbcppaymentreq.PEXBC.PARTIAL_RATE5);
            param.Add("@PARTIAL_RATE6", pexbcppaymentreq.PEXBC.PARTIAL_RATE6);
            param.Add("@PARTIAL_AMT1_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT1_THB);
            param.Add("@PARTIAL_AMT2_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT2_THB);
            param.Add("@PARTIAL_AMT3_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT3_THB);
            param.Add("@PARTIAL_AMT4_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT4_THB);
            param.Add("@PARTIAL_AMT5_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT5_THB);
            param.Add("@PARTIAL_AMT6_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT6_THB);
            param.Add("@FORWARD_CONRACT_NO", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO);
            param.Add("@FORWARD_CONRACT_NO1", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO1);
            param.Add("@FORWARD_CONRACT_NO2", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO2);
            param.Add("@FORWARD_CONRACT_NO3", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO3);
            param.Add("@FORWARD_CONRACT_NO4", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO4);
            param.Add("@FORWARD_CONRACT_NO5", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO5);
            param.Add("@FORWARD_CONRACT_NO6", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO6);
            param.Add("@NEGO_COMM", pexbcppaymentreq.PEXBC.NEGO_COMM);
            param.Add("@TELEX_SWIFT", pexbcppaymentreq.PEXBC.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", pexbcppaymentreq.PEXBC.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", pexbcppaymentreq.PEXBC.STAMP_FEE);
            param.Add("@BE_STAMP", pexbcppaymentreq.PEXBC.BE_STAMP);
            param.Add("@COMM_OTHER", pexbcppaymentreq.PEXBC.COMM_OTHER);
            param.Add("@HANDING_FEE", pexbcppaymentreq.PEXBC.HANDING_FEE);
            param.Add("@DRAFTCOMM", pexbcppaymentreq.PEXBC.DRAFTCOMM);
            param.Add("@INT_AMT_THB", pexbcppaymentreq.PEXBC.INT_AMT_THB);
            param.Add("@COMMONTT", pexbcppaymentreq.PEXBC.COMMONTT);
            param.Add("@TOTAL_CHARGE", pexbcppaymentreq.PEXBC.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", pexbcppaymentreq.PEXBC.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", pexbcppaymentreq.PEXBC.REFUND_TAX_AMT);
            param.Add("@DISCOUNT_CCY", pexbcppaymentreq.PEXBC.DISCOUNT_CCY);
            param.Add("@DISCRATE", pexbcppaymentreq.PEXBC.DISCRATE);
            param.Add("@DISCOUNT_AMT", pexbcppaymentreq.PEXBC.DISCOUNT_AMT);
            param.Add("@TOTAL_AMOUNT", pexbcppaymentreq.PEXBC.TOTAL_AMOUNT);
            param.Add("@PAYMENT_INSTRU", pexbcppaymentreq.PEXBC.PAYMENT_INSTRU);
            param.Add("@METHOD", pexbcppaymentreq.PEXBC.METHOD);
            param.Add("@ACBAHTNET", pexbcppaymentreq.PEXBC.ACBAHTNET);
            param.Add("@BAHTNET", pexbcppaymentreq.PEXBC.BAHTNET);
            param.Add("@RECEIVED_NO", pexbcppaymentreq.PEXBC.RECEIVED_NO);
            param.Add("@ALLOCATION", pexbcppaymentreq.PEXBC.ALLOCATION);
            param.Add("@NARRATIVE", pexbcppaymentreq.PEXBC.NARRATIVE);
            param.Add("@SEQ_ACCEPT_DUE", pexbcppaymentreq.PEXBC.SEQ_ACCEPT_DUE);
            param.Add("@COMFIRM_DUE", pexbcppaymentreq.PEXBC.COMFIRM_DUE);
            param.Add("@PLUS_MINUS_DISC", pexbcppaymentreq.PEXBC.PLUS_MINUS_DISC);
            param.Add("@DISC_DAYS_PLUS_MINUS", pexbcppaymentreq.PEXBC.DISC_DAYS_PLUS_MINUS);
            param.Add("@RECEIVE_PAY_AMT", pexbcppaymentreq.PEXBC.RECEIVE_PAY_AMT);
            param.Add("@EXCHANGE_RATE", pexbcppaymentreq.PEXBC.EXCHANGE_RATE);
            param.Add("@REFUND_DISC_RECEIVE", pexbcppaymentreq.PEXBC.REFUND_DISC_RECEIVE);
            param.Add("@DISC_RECEIVE", pexbcppaymentreq.PEXBC.DISC_RECEIVE);
            param.Add("@LC_DATE", pexbcppaymentreq.PEXBC.LC_DATE);
            param.Add("@COVERING_DATE", pexbcppaymentreq.PEXBC.COVERING_DATE);
            param.Add("@COVERING_FOR", pexbcppaymentreq.PEXBC.COVERING_FOR);
            param.Add("@ADVICE_ISSUE_BANK", pexbcppaymentreq.PEXBC.ADVICE_ISSUE_BANK);
            param.Add("@ADVICE_FORMAT", pexbcppaymentreq.PEXBC.ADVICE_FORMAT);
            param.Add("@REMIT_CLAIM_TYPE", pexbcppaymentreq.PEXBC.REMIT_CLAIM_TYPE);
            param.Add("@REIMBURSE_BANK_ID", pexbcppaymentreq.PEXBC.REIMBURSE_BANK_ID);
            param.Add("@REIMBURSE_BANK_INFO", pexbcppaymentreq.PEXBC.REIMBURSE_BANK_INFO);
            param.Add("@SWIFT_BANK", pexbcppaymentreq.PEXBC.SWIFT_BANK);
            param.Add("@SWIFT_MAIL", pexbcppaymentreq.PEXBC.SWIFT_MAIL);
            param.Add("@CLAIM_FORMAT", pexbcppaymentreq.PEXBC.CLAIM_FORMAT);
            param.Add("@VALUE_DATE", pexbcppaymentreq.PEXBC.VALUE_DATE);
            param.Add("@THIRD_BANK_ID", pexbcppaymentreq.PEXBC.THIRD_BANK_ID);
            param.Add("@THIRD_BANK_INFO", pexbcppaymentreq.PEXBC.THIRD_BANK_INFO);
            param.Add("@DISCREPANCY_TYPE", pexbcppaymentreq.PEXBC.DISCREPANCY_TYPE);
            param.Add("@SWIFT_DISC", pexbcppaymentreq.PEXBC.SWIFT_DISC);
            param.Add("@DOCUMENT_COPY", pexbcppaymentreq.PEXBC.DOCUMENT_COPY);
            // Convert bool to string => DB BIT (0/1)
            string SIGHT_BASIS = "0";
            if (pexbcppaymentreq.PEXBC.SIGHT_BASIS == true)
            {
                SIGHT_BASIS = "1";
            }
            string ART44A = "0";
            if (pexbcppaymentreq.PEXBC.ART44A == true)
            {
                ART44A = "1";
            }
            string ENDORSED = "0";
            if (pexbcppaymentreq.PEXBC.ENDORSED == true)
            {
                ENDORSED = "1";
            }
            string MT750 = "0";
            if (pexbcppaymentreq.PEXBC.MT750 == true)
            {
                MT750 = "1";
            }
            param.Add("@SIGHT_BASIS", SIGHT_BASIS);
            param.Add("@ART44A", ART44A);
            param.Add("@ENDORSED", ENDORSED);
            param.Add("@MT750", MT750);
            param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbcppaymentreq.PEXBC.ADJ_TOT_NEGO_AMOUNT);
            param.Add("@ADJ_LESS_CHARGE_AMT", pexbcppaymentreq.PEXBC.ADJ_LESS_CHARGE_AMT);
            param.Add("@ADJUST_COVERING_AMT", pexbcppaymentreq.PEXBC.ADJUST_COVERING_AMT);
            param.Add("@ADJUST_TENOR", pexbcppaymentreq.PEXBC.ADJUST_TENOR);
            param.Add("@ADJUST_LC_REF", pexbcppaymentreq.PEXBC.ADJUST_LC_REF);
            param.Add("@PAYMENT_INSTRC", pexbcppaymentreq.PEXBC.PAYMENT_INSTRC);
            param.Add("@TXTDOCUMENT", pexbcppaymentreq.PEXBC.TXTDOCUMENT);
            param.Add("@CHARGE_ACC", pexbcppaymentreq.PEXBC.CHARGE_ACC);
            param.Add("@DRAFT", pexbcppaymentreq.PEXBC.DRAFT);
            param.Add("@MT202", pexbcppaymentreq.PEXBC.MT202);
            param.Add("@FB_CURRENCY", pexbcppaymentreq.PEXBC.FB_CURRENCY);
            param.Add("@FB_AMT", pexbcppaymentreq.PEXBC.FB_AMT);
            param.Add("@FB_RATE", pexbcppaymentreq.PEXBC.FB_RATE);
            param.Add("@FB_AMT_THB", pexbcppaymentreq.PEXBC.FB_AMT_THB);
            param.Add("@COLLECT_REFUND", pexbcppaymentreq.PEXBC.COLLECT_REFUND);
            param.Add("@USER_ID", pexbcppaymentreq.PEXBC.USER_ID);
            param.Add("@IN_USE", pexbcppaymentreq.PEXBC.IN_USE);
            param.Add("@AUTH_CODE", pexbcppaymentreq.PEXBC.AUTH_CODE);
            param.Add("@GENACC_FLAG", pexbcppaymentreq.PEXBC.GENACC_FLAG);
            param.Add("@VOUCH_ID", pexbcppaymentreq.PEXBC.VOUCH_ID);
            param.Add("@APPVNO", pexbcppaymentreq.PEXBC.APPVNO);
            param.Add("@FACNO", pexbcppaymentreq.PEXBC.FACNO);
            param.Add("@AUTOOVERDUE", pexbcppaymentreq.PEXBC.AUTOOVERDUE);
            param.Add("@LCOVERDUE", pexbcppaymentreq.PEXBC.LCOVERDUE);
            param.Add("@OVESEQNO", pexbcppaymentreq.PEXBC.OVESEQNO);
            param.Add("@INTFLAG", pexbcppaymentreq.PEXBC.INTFLAG);
            param.Add("@IntRateCode", pexbcppaymentreq.PEXBC.IntRateCode);
            param.Add("@CFRRate", pexbcppaymentreq.PEXBC.CFRRate);
            param.Add("@INTCODE", pexbcppaymentreq.PEXBC.INTCODE);
            param.Add("@OINTRATE", pexbcppaymentreq.PEXBC.OINTRATE);
            param.Add("@OINTSPDRATE", pexbcppaymentreq.PEXBC.OINTSPDRATE);
            param.Add("@OINTCURRATE", pexbcppaymentreq.PEXBC.OINTCURRATE);
            param.Add("@OINTDAY", pexbcppaymentreq.PEXBC.OINTDAY);
            param.Add("@OBASEDAY", pexbcppaymentreq.PEXBC.OBASEDAY);
            param.Add("@BFINTAMT", pexbcppaymentreq.PEXBC.BFINTAMT);
            param.Add("@SELLING_RATE", pexbcppaymentreq.PEXBC.SELLING_RATE);
            param.Add("@BFINTTHB", pexbcppaymentreq.PEXBC.BFINTTHB);
            param.Add("@INTBALANCE", pexbcppaymentreq.PEXBC.INTBALANCE);
            param.Add("@PRNBALANCE", pexbcppaymentreq.PEXBC.PRNBALANCE);
            param.Add("@LASTINTAMT", pexbcppaymentreq.PEXBC.LASTINTAMT);
            param.Add("@DMS", pexbcppaymentreq.PEXBC.DMS);
            param.Add("@LASTINTDATE", pexbcppaymentreq.PEXBC.LASTINTDATE);
            param.Add("@PAYMENTTYPE", pexbcppaymentreq.PEXBC.PAYMENTTYPE);
            param.Add("@CONFIRM_DATE", pexbcppaymentreq.PEXBC.CONFIRM_DATE);
            param.Add("@TOTALACCRUAMT", pexbcppaymentreq.PEXBC.TOTALACCRUAMT);
            param.Add("@TOTALACCRUBHT", pexbcppaymentreq.PEXBC.TOTALACCRUBHT);
            param.Add("@ACCRUAMT", pexbcppaymentreq.PEXBC.ACCRUAMT);
            param.Add("@ACCRUBHT", pexbcppaymentreq.PEXBC.ACCRUBHT);
            param.Add("@DATELASTACCRU", pexbcppaymentreq.PEXBC.DATELASTACCRU);
            param.Add("@PASTDUEDATE", pexbcppaymentreq.PEXBC.PASTDUEDATE);
            param.Add("@PASTDUEFLAG", pexbcppaymentreq.PEXBC.PASTDUEFLAG);
            param.Add("@TOTALSUSPAMT", pexbcppaymentreq.PEXBC.TOTALSUSPAMT);
            param.Add("@TOTALSUSPBHT", pexbcppaymentreq.PEXBC.TOTALSUSPBHT);
            param.Add("@SUSPAMT", pexbcppaymentreq.PEXBC.SUSPAMT);
            param.Add("@SUSPBHT", pexbcppaymentreq.PEXBC.SUSPBHT);
            param.Add("@CenterID", pexbcppaymentreq.PEXBC.CenterID);
            param.Add("@BCPastDue", pexbcppaymentreq.PEXBC.BCPastDue);
            param.Add("@DateStartAccru", pexbcppaymentreq.PEXBC.DateStartAccru);
            param.Add("@DateToStop", pexbcppaymentreq.PEXBC.DateToStop);
            param.Add("@ValueDate", pexbcppaymentreq.PEXBC.ValueDate);
            param.Add("@FlagBack", pexbcppaymentreq.PEXBC.FlagBack);
            param.Add("@NewAccruCcy", pexbcppaymentreq.PEXBC.NewAccruCcy);
            param.Add("@NewAccruAmt", pexbcppaymentreq.PEXBC.NewAccruAmt);
            param.Add("@AccruPending", pexbcppaymentreq.PEXBC.AccruPending);
            param.Add("@LastAccruCcy", pexbcppaymentreq.PEXBC.LastAccruCcy);
            param.Add("@LastAccruAmt", pexbcppaymentreq.PEXBC.LastAccruAmt);
            param.Add("@DAccruAmt", pexbcppaymentreq.PEXBC.DAccruAmt);
            param.Add("@CCS_ACCT", pexbcppaymentreq.PEXBC.CCS_ACCT);
            param.Add("@CCS_LmType", pexbcppaymentreq.PEXBC.CCS_LmType);
            param.Add("@CCS_CNUM", pexbcppaymentreq.PEXBC.CCS_CNUM);
            param.Add("@CCS_CIFRef", pexbcppaymentreq.PEXBC.CCS_CIFRef);
            param.Add("@ObjectType", pexbcppaymentreq.PEXBC.ObjectType);
            param.Add("@UnderlyName", pexbcppaymentreq.PEXBC.UnderlyName);
            param.Add("@BPOFlag", pexbcppaymentreq.PEXBC.BPOFlag);
            param.Add("@Campaign_Code", pexbcppaymentreq.PEXBC.Campaign_Code);
            param.Add("@Campaign_EffDate", pexbcppaymentreq.PEXBC.Campaign_EffDate);
            param.Add("@PurposeCode", pexbcppaymentreq.PEXBC.PurposeCode);
            //PPayment
            param.Add("@RpPayDate", pexbcppaymentreq.PPayment.RpPayDate);
            param.Add("@RpNote", pexbcppaymentreq.PPayment.RpNote);
            param.Add("@RpCashAmt", pexbcppaymentreq.PPayment.RpCashAmt);
            param.Add("@RpChqAmt", pexbcppaymentreq.PPayment.RpChqAmt);
            param.Add("@RpChqNo", pexbcppaymentreq.PPayment.RpChqNo);
            param.Add("@RpChqBank", pexbcppaymentreq.PPayment.RpChqBank);
            param.Add("@RpChqBranch", pexbcppaymentreq.PPayment.RpChqBranch);
            param.Add("@RpCustAc1", pexbcppaymentreq.PPayment.RpCustAc1);
            param.Add("@RpCustAmt1", pexbcppaymentreq.PPayment.RpCustAmt1);
            param.Add("@RpCustAc2", pexbcppaymentreq.PPayment.RpCustAc2);
            param.Add("@RpCustAmt2", pexbcppaymentreq.PPayment.RpCustAmt2);
            param.Add("@RpCustAc3", pexbcppaymentreq.PPayment.RpCustAc3);
            param.Add("@RpCustAmt3", pexbcppaymentreq.PPayment.RpCustAmt3);
            param.Add("@RpStatus", pexbcppaymentreq.PPayment.RpStatus);
            param.Add("@PExBcRsp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);
            param.Add("@PEXBCPPaymentRsp", dbType: DbType.String,
                       direction: System.Data.ParameterDirection.Output,
                       size: 5215585);
            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            try
            {
                var results = await _db.LoadData<PEXBCPPaymentRsp, dynamic>(
                     storedProcedure: "usp_pEXBC_CollectRefund_Save",
                     param);
                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");
                var pexbcppaymentrsp = param.Get<dynamic>("@PEXBCPPaymentRsp");
                var resp = param.Get<int>("@PExBcRsp");

                if (PExBcRsp == 1)
                {
                    PEXBCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXBCPPaymentRsp>(pexbcppaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_BC_NO Save Error";
                    response.Data = new PEXBCPPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXBCPPaymentRsp();
            }
            return BadRequest(response);
        }

        [HttpPost("delete")]
        public async Task<ActionResult<EXBCResultResponse>> EXBCCollectRefundDelete([FromBody] PEXBCCollectRefundDelete pExBcCollectRefundDelete)
        {
            EXBCResultResponse response = new EXBCResultResponse();
            if (string.IsNullOrEmpty(pExBcCollectRefundDelete.EXPORT_BC_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", pExBcCollectRefundDelete.EXPORT_BC_NO);
            param.Add("@VOUCH_ID", pExBcCollectRefundDelete.VOUCH_ID);


            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_CollectRefund_Delete", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (Int16.Parse(resp) > 0)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C Number Deleted";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export B/C NO Not Exist";
                    //response.Message = resp.ToString();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        /*
                [HttpPost("delete")]
                public async Task<ActionResult<EXBCResultResponse>> Delete([FromBody] EXBCCollectRefundDeleteRequest data)
                {

                    EXBCResultResponse response = new EXBCResultResponse();

                    // Validate
                    if (string.IsNullOrEmpty(data.EXPORT_BC_NO) ||
                        string.IsNullOrEmpty(data.VOUCH_ID) ||
                        string.IsNullOrEmpty(data.EVENT_DATE)
                        )
                    {
                        response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                        response.Message = "EXPORT_BC_NO, VOUCH_ID, EVENT_DATE is required";
                        return BadRequest(response);
                    }


                    try
                    {
                        // Delete Daily GL
                        var dailyGL = (from row in _context.pDailyGLs
                                       where row.VouchID == data.VOUCH_ID &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }

                        // Select EXBC MASTER
                        var pExbc = (from row in _context.pExbcs
                                     where row.EXPORT_BC_NO == data.EXPORT_BC_NO &&
                                           row.RECORD_TYPE == "MASTER"
                                     select row).FirstOrDefault();

                        if (pExbc == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export B/C does not exist";
                            //response.Message = resp.ToString();
                            return BadRequest(response);
                        }
                        var eventNo = pExbc.EVENT_NO;
                        eventNo++;

                        // Delete OverDue
                        var overDueRows = (from row in _context.pExbcs
                                           where row.EXPORT_BC_NO == data.EXPORT_BC_NO &&
                                                 row.EVENT_NO == eventNo &&
                                                 row.EVENT_TYPE == "OverDue" &&
                                                 row.REC_STATUS == "P"
                                           select row).ToListAsync();

                        foreach (var row in await overDueRows)
                        {
                            _context.pExbcs.Remove(row);
                        }

                        // Delete Interest
                        var interestRows = (from row in _context.pEXInterests
                                            where row.Login == "PEXBC" &&
                                            row.Event == "OverDue" &&
                                            row.EventNo == eventNo
                                            select row).ToListAsync();

                        foreach (var row in await interestRows)
                        {
                            _context.pEXInterests.Remove(row);
                        }

                        await _context.SaveChangesAsync();


                        // Update PEXBC set REC_STATUS = R
                        // Use Raw Query b/c REC_STATUS is part of PK
                        // If remove from PK
                        //
                        // pExbc.REC_STATUS = 'R';
                        // await _context.SaveChangesAsync();

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExbc SET REC_STATUS = 'R' WHERE EXPORT_BC_NO = '{data.EXPORT_BC_NO}' AND RECORD_TYPE = 'MASTER'");


                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export B/C Number Deleted";
                        return Ok(response);

                    }
                    catch (Exception e)
                    {
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }
                  
    }
          */

        [HttpPost("release")]
        public async Task<ActionResult<EXBCResultResponse>> PEXBCCollectRefundReleaseReq([FromBody] PEXBCCollectRefundReleaseReq pExBcCollectRefundRelease)
        {
            EXBCResultResponse response = new EXBCResultResponse();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

            // Validate
            if (string.IsNullOrEmpty(pExBcCollectRefundRelease.EXPORT_BC_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", pExBcCollectRefundRelease.EXPORT_BC_NO);
            param.Add("@BENE_ID", pExBcCollectRefundRelease.BENE_ID);
            //param.Add("@USER_ID", pExBcCollectRefundRelease.USER_ID);
            //param.Add("@CenterID", pExBcCollectRefundRelease.CenterID);
            param.Add("@CenterID", USER_CENTER_ID);
            param.Add("@USER_ID", USER_ID);
            param.Add("@EVENT_DATE", pExBcCollectRefundRelease.EVENT_DATE);
            param.Add("@VOUCH_ID", pExBcCollectRefundRelease.VOUCH_ID);
            param.Add("@PAYMENT_INSTRU", pExBcCollectRefundRelease.PAYMENT_INSTRU);
            param.Add("@CHARGE_ACC", pExBcCollectRefundRelease.CHARGE_ACC);
            param.Add("@DRAFT", pExBcCollectRefundRelease.DRAFT);
            param.Add("@MT202", pExBcCollectRefundRelease.MT202);
            param.Add("@FB_CURRENCY", pExBcCollectRefundRelease.FB_CURRENCY);
            param.Add("@FB_AMT", pExBcCollectRefundRelease.FB_AMT);
            param.Add("@FB_RATE", pExBcCollectRefundRelease.FB_RATE);
            param.Add("@FB_AMT_THB", pExBcCollectRefundRelease.FB_AMT_THB);
            param.Add("@NEGO_COMM", pExBcCollectRefundRelease.NEGO_COMM);
            param.Add("@TELEX_SWIFT", pExBcCollectRefundRelease.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", pExBcCollectRefundRelease.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", pExBcCollectRefundRelease.STAMP_FEE);
            param.Add("@COMMONTT", pExBcCollectRefundRelease.COMMONTT);
            param.Add("@COMM_OTHER", pExBcCollectRefundRelease.COMM_OTHER);
            param.Add("@HANDING_FEE", pExBcCollectRefundRelease.HANDING_FEE);
            param.Add("@INT_AMT_THB", pExBcCollectRefundRelease.INT_AMT_THB);
            param.Add("@TOTAL_CHARGE", pExBcCollectRefundRelease.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", pExBcCollectRefundRelease.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", pExBcCollectRefundRelease.REFUND_TAX_AMT);
            param.Add("@TOTAL_AMOUNT", pExBcCollectRefundRelease.TOTAL_AMOUNT);
            param.Add("@COLLECT_REFUND", pExBcCollectRefundRelease.COLLECT_REFUND);
            param.Add("@METHOD", pExBcCollectRefundRelease.METHOD);
            param.Add("@NARRATIVE", pExBcCollectRefundRelease.NARRATIVE);

            param.Add("@PExBcRsp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_CollectRefund_Release", param);
                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");  // For what?
                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C NO Release Complete";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export B/C do not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }
    }
}
