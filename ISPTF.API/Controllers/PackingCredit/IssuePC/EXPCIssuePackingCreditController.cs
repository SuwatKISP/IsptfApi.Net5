using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportLC;
using ISPTF.Models.PackingCredit;
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
using System.Reflection;

namespace ISPTF.API.Controllers.PackingCredit
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXPCIssuePackingCreditController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        private const string BUSINESS_TYPE = "1";
        private const string EVENT_TYPE = "ISSUE";

        public EXPCIssuePackingCreditController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("newlist")]
        public async Task<ActionResult<IssuePCNewListPageResponse>> NewList(string? CenterID, string? RegDocNo,string? CustCode , string? @CustName, string? Page, string? PageSize)
        {
            IssuePCNewListPageResponse response = new IssuePCNewListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_IssuePCNewListPageRsp>();
                return BadRequest(response);
            }
            //if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "USER_ID is required";
            //    response.Data = new List<Q_IssuePCNewListPageRsp>();
            //    return BadRequest(response);
            //}

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                //param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@RegDocNo", RegDocNo);
                param.Add("@CustName", @CustName);
                param.Add("@CustCode", @CustCode);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (RegDocNo == null)
                {
                    param.Add("@RegDocNo", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_IssuePCNewListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_IssuePackingNewListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IssuePCNewListPageRsp>)results;

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
                response.Data = new List<Q_IssuePCNewListPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("list")]
        public async Task<ActionResult<IssuePCListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            IssuePCListPageResponse response = new IssuePCListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_IssuePCListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IssuePCListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@PackingNo", PackingNo);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (PackingNo == null)
                {
                    param.Add("@PackingNo", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_IssuePCListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_IssuePackingListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IssuePCListPageRsp>)results;

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
                response.Data = new List<Q_IssuePCListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("newselect")]
        public ActionResult<PEXPCPPaymentResponse> GetNewSelect(string? RegDocNo)
        {
            PEXPCPPaymentResponse response = new();
            // Validate
            if (string.IsNullOrEmpty(RegDocNo))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "RegDocNo is required";
                response.Data = new();
                return BadRequest(response);
            }

            try
            {
                var pDocReg = (from row in _context.pDocRegisters
                               where row.Reg_Docno == RegDocNo
                               select row).AsNoTracking().FirstOrDefault();
                pExpc pExpc = new();
                pExpc.PACKING_NO = pDocReg.Reg_Docno;
                pExpc.cust_id = pDocReg.Reg_CustCode;
                var mCustomer = (from row in _context.mCustomers
                                 where row.Cust_Code == pDocReg.Reg_CustCode
                                 select row).AsNoTracking().FirstOrDefault();
                if (mCustomer!=null)
                {
                    string cus_info = "";
                    if (mCustomer.Cust_Add1_Line1 != null)
                        cus_info = mCustomer.Cust_Add1_Line1;
                    if (mCustomer.Cust_Add1_Line2 != null)
                        cus_info = cus_info + System.Environment.NewLine + mCustomer.Cust_Add1_Line2;
                    if (mCustomer.Cust_Add1_Line3 != null)
                        cus_info = cus_info + System.Environment.NewLine + mCustomer.Cust_Add1_Line3;
                    if (mCustomer.Cust_Add1_Line4 != null)
                        cus_info = cus_info + System.Environment.NewLine + mCustomer.Cust_Add1_Line4;
                    pExpc.cust_info = cus_info;
                }
                pExpc.refer_lcno = pDocReg.Reg_RefNo;
                pExpc.packing_for = pDocReg.Reg_DocType;
                pExpc.doc_amount = pDocReg.Reg_CcyAmt;
                pExpc.pack_ccy = pDocReg.Reg_CcyBal;
                pExpc.rate = pDocReg.Reg_Plus;
                pExpc.exch_rate = pDocReg.Reg_ExchRate;
                pExpc.pack_thb = pDocReg.Reg_BhtAmt;
                pExpc.pn_no = pDocReg.Reg_RefNo2;
                pExpc.total_credit_ac = pDocReg.Reg_BhtAmt;

                var exp = "CCY";
                var ccy = "THB";
                if(pDocReg.Reg_DocType == "O")
                {
                    exp = "INT CCY";
                    ccy = "CCY";
                }
                pExpc.pc_int_rate = EXHelper.CompDiscRate(_context, pDocReg.Reg_CustCode, "EXPC", exp, ccy);

                exp = "SPPCTHB";
                if (pDocReg.Reg_DocType == "O")
                {
                    exp = "SPPCCCY";
                }
                pExpc.spread_rate = EXHelper.CompSpreadRate(_context, pDocReg.Reg_CustCode, "EXPC", exp);
                pExpc.current_intrate = pExpc.pc_int_rate + pExpc.spread_rate;
                response.Code = Constants.RESPONSE_OK;
                response.Data = new();
                response.Data.PEXPC = pExpc;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        public ActionResult<PEXPCPPaymentResponse> Select(string? PACKING_NO)
        {
            PEXPCPPaymentResponse response = new();
            // Validate
            if (string.IsNullOrEmpty(PACKING_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "PACKING_NO is required";
                response.Data = new();
                return BadRequest(response);
            }

            try
            {
                response.Data = new();
                var pExpc = (from row in _context.pExpcs
                             where row.PACKING_NO == PACKING_NO &&
                                   row.event_type == EVENT_TYPE &&
                                   row.record_type == "EVENT"
                             select row).AsNoTracking().FirstOrDefault();
                if( pExpc == null)
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "record not Found !";
                    response.Data = new();
                }
                var pPayment = (from row in _context.pPayments
                                where row.RpReceiptNo == pExpc.received_no &&
                                      row.RpDocNo == pExpc.PACKING_NO
                                select row).AsNoTracking().FirstOrDefault();
                if (pPayment != null)
                {
                    response.Data.PPAYMENT = pPayment;
                }
                response.Code = Constants.RESPONSE_OK;
                response.Data.PEXPC = pExpc;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new();
            }
            return BadRequest(response);
        }

        [HttpPost("save")]
        public ActionResult<PEXPCPPaymentResponse> Save([FromBody] PEXPCPPaymentRequest pexpcppaymentrequest)
        {
            PEXPCPPaymentResponse response = new();
            // Validate
            var pExpc = pexpcppaymentrequest.pExpc;
            if (string.IsNullOrEmpty(pExpc.PACKING_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "PACKING_NO is required";
                response.Data = new();
                return BadRequest(response);
            }

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var user_id = User.Identity.Name;
                        var CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();
                        bool isNew = false;
                        // 1 - Get ApprvNo, ApprvFac
                        var appvNo = "";
                        var appvFac = "";
                        var genPay = "";
                        var pDocRegister = (from row in _context.pDocRegisters
                                            where row.Reg_Docno == pExpc.PACKING_NO
                                            select row).AsNoTracking().FirstOrDefault();
                        if(pDocRegister != null)
                        {
                            appvNo = pDocRegister.Reg_AppvNo;
                        }
                        var pCustAppv = (from row in _context.pCustAppvs
                                         where row.Appv_No == appvNo
                                         select row).AsNoTracking().FirstOrDefault();
                        if(pCustAppv != null)
                        {
                            appvFac = pCustAppv.Facility_No;
                        }

                        // 2 - Save Master
                        var pExpcMaster = (from row in _context.pExpcs
                                           where row.PACKING_NO == pExpc.PACKING_NO &&
                                                 row.record_type == "MASTER"
                                           select row).AsNoTracking().FirstOrDefault();
                        if(pExpcMaster == null)
                        {
                            isNew = true;
                            pExpcMaster = new pExpc();
                            pExpcMaster.PACKING_NO = pExpc.PACKING_NO;
                            pExpcMaster.record_type = "MASTER";
                            pExpcMaster.event_no = 1;
                            pExpcMaster.rec_status = "P";
                            pExpcMaster.event_mode = "E";
                            pExpcMaster.event_type = EVENT_TYPE;
                            pExpcMaster.business_type = BUSINESS_TYPE;
                            pExpcMaster.vouch_id = "ISSUE-PACK";
                            _context.pExpcs.Add(pExpcMaster);
                            _context.SaveChanges();
                        }
                        pExpcMaster.PurposeCode = pExpc.PurposeCode;
                        pExpcMaster.ObjectType = pExpc.ObjectType;
                        pExpcMaster.UnderlyName = pExpc.UnderlyName;
                        pExpcMaster.CenterID = CenterID;
                        pExpcMaster.user_id = user_id;
                        pExpcMaster.update_date = DateTime.Now;
                        pExpcMaster.LastIntDate = pExpc.LastIntDate;
                        pExpcMaster.event_date = pExpc.event_date;
                        pExpcMaster.cust_id = pExpc.cust_id;
                        pExpcMaster.cust_info = pExpc.cust_info;
                        pExpcMaster.cnty_code = pExpc.cnty_code;
                        pExpcMaster.applicant_name = pExpc.applicant_name;
                        pExpcMaster.good_code = pExpc.good_code;
                        pExpcMaster.Rel_code = pExpc.Rel_code;
                        pExpcMaster.good_desc = pExpc.good_desc;
                        pExpcMaster.shipmentFr = pExpc.shipmentFr;
                        pExpcMaster.shipmentTo = pExpc.shipmentTo;
                        pExpcMaster.packing_for = pExpc.packing_for;
                        pExpcMaster.pack_under = pExpc.pack_under;
                        pExpcMaster.refer_lcno = pExpc.refer_lcno;
                        pExpcMaster.doc_ccy = pExpc.doc_ccy;
                        pExpcMaster.doc_amount = pExpc.doc_amount;
                        pExpcMaster.exch_rate = pExpc.exch_rate;
                        pExpcMaster.rate = pExpc.rate;
                        pExpcMaster.pack_ccy = pExpc.pack_ccy;
                        pExpcMaster.pack_thb = pExpc.pack_thb;
                        pExpcMaster.pn_no = pExpc.pn_no;
                        pExpcMaster.principle_amt_ccy1 = pExpc.principle_amt_ccy1;
                        pExpcMaster.principle_amt_thb1 = pExpc.principle_amt_thb1;
                        pExpcMaster.prev_contra_bal = pExpc.prev_contra_bal;
                        pExpcMaster.PackNote = pExpc.PackNote;
                        pExpcMaster.doc_expiry_date = pExpc.doc_expiry_date;
                        pExpcMaster.pc_start_date = pExpc.pc_start_date;
                        pExpcMaster.current_pc_due = pExpc.current_pc_due;
                        pExpcMaster.tot_pc_day = pExpc.tot_pc_day;
                        pExpcMaster.current_60_daydue = pExpc.current_60_daydue;
                        pExpcMaster.prev_start_date = pExpc.prev_start_date;
                        pExpcMaster.IntRateCode = pExpc.IntRateCode;
                        pExpcMaster.pc_int_rate = pExpc.pc_int_rate;
                        pExpcMaster.spread_rate = pExpc.spread_rate;
                        pExpcMaster.current_intrate = pExpc.current_intrate;
                        pExpcMaster.IntBaseDay = pExpc.IntBaseDay;
                        pExpcMaster.CFRRate = pExpc.CFRRate;
                        pExpcMaster.IntFlag = pExpc.IntFlag;
                        pExpcMaster.FixDate = pExpc.FixDate;
                        pExpcMaster.partial_amt_ccy1 = pExpc.partial_amt_ccy1;
                        pExpcMaster.exch_rate1 = pExpc.exch_rate1;
                        pExpcMaster.partial_amt_thb1 = pExpc.partial_amt_thb1;
                        pExpcMaster.forward_contract1 = pExpc.forward_contract1;
                        pExpcMaster.partial_amt_ccy2 = pExpc.partial_amt_ccy2;
                        pExpcMaster.exch_rate2 = pExpc.exch_rate2;
                        pExpcMaster.partial_amt_thb2 = pExpc.partial_amt_thb2;
                        pExpcMaster.forward_contract2 = pExpc.forward_contract2;
                        pExpcMaster.partial_amt_ccy3 = pExpc.partial_amt_ccy3;
                        pExpcMaster.exch_rate3 = pExpc.exch_rate3;
                        pExpcMaster.partial_amt_thb3 = pExpc.partial_amt_thb3;
                        pExpcMaster.forward_contract3 = pExpc.forward_contract3;
                        pExpcMaster.partial_amt_ccy4 = pExpc.partial_amt_ccy4;
                        pExpcMaster.exch_rate4 = pExpc.exch_rate4;
                        pExpcMaster.partial_amt_thb4 = pExpc.partial_amt_thb4;
                        pExpcMaster.forward_contract4 = pExpc.forward_contract4;
                        pExpcMaster.partial_amt_ccy5 = pExpc.partial_amt_ccy5;
                        pExpcMaster.exch_rate5 = pExpc.exch_rate5;
                        pExpcMaster.partial_amt_thb5 = pExpc.partial_amt_thb5;
                        pExpcMaster.forward_contract5 = pExpc.forward_contract5;
                        pExpcMaster.partial_amt_ccy6 = pExpc.partial_amt_ccy6;
                        pExpcMaster.exch_rate6 = pExpc.exch_rate6;
                        pExpcMaster.partial_amt_thb6 = pExpc.partial_amt_thb6;
                        pExpcMaster.forward_contract6 = pExpc.forward_contract6;
                        pExpcMaster.total_bal_ccy = pExpc.total_bal_ccy;
                        pExpcMaster.total_bal_thb = pExpc.total_bal_thb;
                        pExpcMaster.partial_full_rate = pExpc.partial_full_rate;
                        pExpcMaster.duty_stamp = pExpc.duty_stamp;
                        pExpcMaster.Comm_Certi = pExpc.Comm_Certi;
                        pExpcMaster.comm_other = pExpc.comm_other;
                        pExpcMaster.comm_OnTT = pExpc.comm_OnTT;
                        pExpcMaster.total_charge = pExpc.total_charge;
                        pExpcMaster.total_credit_ac = pExpc.total_credit_ac;
                        pExpcMaster.remark = pExpc.remark;
                        pExpcMaster.ALLOCATION = pExpc.ALLOCATION;
                        pExpcMaster.BahtNet = pExpc.BahtNet;

                        pExpcMaster.pay_instruc = pExpc.pay_instruc;
                        pExpcMaster.received_no = pExpc.received_no;
                        if (pExpcMaster.pay_instruc == "1")
                        {
                            pExpcMaster.method = pExpc.method;
                            if(pExpcMaster.received_no == "" || isNew)
                            {
                                pExpcMaster.received_no = EXHelper.GenRefNo(_context, "PAYC", user_id, CenterID);
                                genPay = pExpcMaster.received_no;
                                SavePayment(pExpcMaster,pexpcppaymentrequest.pPayment);
                            }
                        }
                        else if (pExpcMaster.pay_instruc == "2")
                        {
                            pExpcMaster.method = "";
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayment WHERE rpReceiptNo = '{pExpcMaster.received_no}'");
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE dpReceiptNo = '{pExpcMaster.received_no}'");
                        }
                        else if (pExpcMaster.pay_instruc == "3")
                        {
                            if (pExpcMaster.received_no == "" || isNew)
                            {
                                pExpcMaster.received_no = EXHelper.GenRefNo(_context, "PAYC", user_id, CenterID);
                                genPay = pExpcMaster.received_no;
                                pExpcMaster.AcBahtnet = pExpc.AcBahtnet;
                                pExpcMaster.BahtNet = pExpc.BahtNet;
                            }
                        }

                        pExpcMaster.total_amount = pExpc.total_amount;
                        pExpcMaster.AutoOverdue = "N";
                        pExpcMaster.genacc_flag = "Y";
                        pExpcMaster.genacc_date = DateTime.Today;
                        pExpcMaster.LastPayDate = pExpc.LastPayDate;
                        pExpcMaster.CalIntDate = pExpc.CalIntDate;
                        pExpcMaster.AppvNo = appvNo;
                        pExpcMaster.FACNO = appvFac;
                        pExpcMaster.DateStartAccru = pExpc.DateStartAccru;
                        _context.pExpcs.Update(pExpcMaster);
                        _context.SaveChanges();

                        // 3 - Save Event
                        var pExpcEvent = (from row in _context.pExpcs
                                           where row.PACKING_NO == pExpc.PACKING_NO &&
                                                 row.record_type == "EVENT"
                                           select row).AsNoTracking().FirstOrDefault();
                        if (pExpcEvent == null)
                        {
                            isNew = true;
                            pExpcEvent = new pExpc();
                            pExpcEvent.PACKING_NO = pExpc.PACKING_NO;
                            pExpcEvent.record_type = "EVENT";
                            pExpcEvent.event_no = 1;
                            pExpcEvent.rec_status = "P";
                            pExpcEvent.event_mode = "E";
                            pExpcEvent.event_type = EVENT_TYPE;
                            pExpcEvent.business_type = BUSINESS_TYPE;
                            pExpcEvent.vouch_id = "ISSUE-PACK";
                            _context.pExpcs.Add(pExpcEvent);
                            _context.SaveChanges();
                        }
                        pExpcEvent.PurposeCode = pExpc.PurposeCode;
                        pExpcEvent.ObjectType = pExpc.ObjectType;
                        pExpcEvent.UnderlyName = pExpc.UnderlyName;
                        pExpcEvent.CenterID = CenterID;
                        pExpcEvent.user_id = user_id;
                        pExpcEvent.update_date = DateTime.Now;
                        pExpcEvent.LastIntDate = pExpc.LastIntDate;
                        pExpcEvent.event_date = pExpc.event_date;
                        pExpcEvent.cust_id = pExpc.cust_id;
                        pExpcEvent.cust_info = pExpc.cust_info;
                        pExpcEvent.cnty_code = pExpc.cnty_code;
                        pExpcEvent.applicant_name = pExpc.applicant_name;
                        pExpcEvent.good_code = pExpc.good_code;
                        pExpcEvent.Rel_code = pExpc.Rel_code;
                        pExpcEvent.good_desc = pExpc.good_desc;
                        pExpcEvent.shipmentFr = pExpc.shipmentFr;
                        pExpcEvent.shipmentTo = pExpc.shipmentTo;
                        pExpcEvent.packing_for = pExpc.packing_for;
                        pExpcEvent.pack_under = pExpc.pack_under;
                        pExpcEvent.refer_lcno = pExpc.refer_lcno;
                        pExpcEvent.doc_ccy = pExpc.doc_ccy;
                        pExpcEvent.doc_amount = pExpc.doc_amount;
                        pExpcEvent.exch_rate = pExpc.exch_rate;
                        pExpcEvent.rate = pExpc.rate;
                        pExpcEvent.pack_ccy = pExpc.pack_ccy;
                        pExpcEvent.pack_thb = pExpc.pack_thb;
                        pExpcEvent.pn_no = pExpc.pn_no;
                        pExpcEvent.principle_amt_ccy1 = pExpc.principle_amt_ccy1;
                        pExpcEvent.principle_amt_thb1 = pExpc.principle_amt_thb1;
                        pExpcEvent.prev_contra_bal = pExpc.prev_contra_bal;
                        pExpcEvent.PackNote = pExpc.PackNote;
                        pExpcEvent.doc_expiry_date = pExpc.doc_expiry_date;
                        pExpcEvent.pc_start_date = pExpc.pc_start_date;
                        pExpcEvent.current_pc_due = pExpc.current_pc_due;
                        pExpcEvent.tot_pc_day = pExpc.tot_pc_day;
                        pExpcEvent.current_60_daydue = pExpc.current_60_daydue;
                        pExpcEvent.prev_start_date = pExpc.prev_start_date;
                        pExpcEvent.IntRateCode = pExpc.IntRateCode;
                        pExpcEvent.pc_int_rate = pExpc.pc_int_rate;
                        pExpcEvent.spread_rate = pExpc.spread_rate;
                        pExpcEvent.current_intrate = pExpc.current_intrate;
                        pExpcEvent.IntBaseDay = pExpc.IntBaseDay;
                        pExpcEvent.CFRRate = pExpc.CFRRate;
                        pExpcEvent.IntFlag = pExpc.IntFlag;
                        pExpcEvent.FixDate = pExpc.FixDate;
                        pExpcEvent.partial_amt_ccy1 = pExpc.partial_amt_ccy1;
                        pExpcEvent.exch_rate1 = pExpc.exch_rate1;
                        pExpcEvent.partial_amt_thb1 = pExpc.partial_amt_thb1;
                        pExpcEvent.forward_contract1 = pExpc.forward_contract1;
                        pExpcEvent.partial_amt_ccy2 = pExpc.partial_amt_ccy2;
                        pExpcEvent.exch_rate2 = pExpc.exch_rate2;
                        pExpcEvent.partial_amt_thb2 = pExpc.partial_amt_thb2;
                        pExpcEvent.forward_contract2 = pExpc.forward_contract2;
                        pExpcEvent.partial_amt_ccy3 = pExpc.partial_amt_ccy3;
                        pExpcEvent.exch_rate3 = pExpc.exch_rate3;
                        pExpcEvent.partial_amt_thb3 = pExpc.partial_amt_thb3;
                        pExpcEvent.forward_contract3 = pExpc.forward_contract3;
                        pExpcEvent.partial_amt_ccy4 = pExpc.partial_amt_ccy4;
                        pExpcEvent.exch_rate4 = pExpc.exch_rate4;
                        pExpcEvent.partial_amt_thb4 = pExpc.partial_amt_thb4;
                        pExpcEvent.forward_contract4 = pExpc.forward_contract4;
                        pExpcEvent.partial_amt_ccy5 = pExpc.partial_amt_ccy5;
                        pExpcEvent.exch_rate5 = pExpc.exch_rate5;
                        pExpcEvent.partial_amt_thb5 = pExpc.partial_amt_thb5;
                        pExpcEvent.forward_contract5 = pExpc.forward_contract5;
                        pExpcEvent.partial_amt_ccy6 = pExpc.partial_amt_ccy6;
                        pExpcEvent.exch_rate6 = pExpc.exch_rate6;
                        pExpcEvent.partial_amt_thb6 = pExpc.partial_amt_thb6;
                        pExpcEvent.forward_contract6 = pExpc.forward_contract6;
                        pExpcEvent.total_bal_ccy = pExpc.total_bal_ccy;
                        pExpcEvent.total_bal_thb = pExpc.total_bal_thb;
                        pExpcEvent.partial_full_rate = pExpc.partial_full_rate;
                        pExpcEvent.duty_stamp = pExpc.duty_stamp;
                        pExpcEvent.Comm_Certi = pExpc.Comm_Certi;
                        pExpcEvent.comm_other = pExpc.comm_other;
                        pExpcEvent.comm_OnTT = pExpc.comm_OnTT;
                        pExpcEvent.total_charge = pExpc.total_charge;
                        pExpcEvent.total_credit_ac = pExpc.total_credit_ac;
                        pExpcEvent.remark = pExpc.remark;
                        pExpcEvent.ALLOCATION = pExpc.ALLOCATION;
                        pExpcEvent.BahtNet = pExpc.BahtNet;

                        pExpcEvent.pay_instruc = pExpc.pay_instruc;
                        pExpcEvent.received_no = pExpc.received_no;
                        if (pExpcEvent.pay_instruc == "1")
                        {
                            pExpcEvent.method = pExpc.method;
                            if (pExpcEvent.received_no == "" || isNew)
                            {
                                pExpcEvent.received_no = genPay;
                            }
                        }
                        else if (pExpcEvent.pay_instruc == "2")
                        {
                            pExpcEvent.method = "";
                            pExpcEvent.received_no = "";
                        }
                        else if (pExpcEvent.pay_instruc == "3")
                        {
                            if (pExpcEvent.received_no == "" || isNew)
                            {
                                pExpcEvent.received_no = EXHelper.GenRefNo(_context, "PAYC", user_id, CenterID);
                                genPay = pExpcMaster.received_no;
                                pExpcEvent.AcBahtnet = pExpc.AcBahtnet;
                                pExpcEvent.BahtNet = pExpc.BahtNet;
                            }
                        }

                        pExpcEvent.total_amount = pExpc.total_amount;
                        pExpcEvent.AutoOverdue = "N";
                        pExpcEvent.genacc_flag = "Y";
                        pExpcEvent.genacc_date = DateTime.Today;
                        pExpcEvent.LastPayDate = pExpc.LastPayDate;
                        pExpcEvent.CalIntDate = pExpc.CalIntDate;
                        pExpcEvent.AppvNo = appvNo;
                        pExpcEvent.FACNO = appvFac;
                        pExpcEvent.DateStartAccru = pExpc.DateStartAccru;
                        _context.pExpcs.Update(pExpcEvent);
                        _context.SaveChanges();

                        // 3 - Update pDocRegister
                        _context.Database.ExecuteSqlRaw($"UPDATE pDocRegister SET Reg_Status = 'I' WHERE Reg_Login = 'EXPC' AND Reg_Appv = 'Y' and Reg_Status = 'A' AND Reg_RecStat = 'R' AND Reg_CustCode = '{pExpcMaster.cust_id}' AND Reg_Docno = '{pExpcMaster.PACKING_NO}'");

                        // Commit
                        _context.SaveChanges();
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
                    response.Message = "Packing Credit Saved";
                    response.Data = new();
                    response.Data.PEXPC = pexpcppaymentrequest.pExpc;
                    response.Data.PPAYMENT = pexpcppaymentrequest.pPayment;
                    return Ok(response);
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
        public ActionResult<EXPCResultResponse> Delete(string? PACKING_NO)
        {
            EXPCResultResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(PACKING_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "PACKING_NO is required";
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
                        var pExpcEvent = (from row in _context.pExpcs
                                          where row.PACKING_NO == PACKING_NO &&
                                                row.event_type == EVENT_TYPE &&
                                                row.business_type == BUSINESS_TYPE
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExpcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PACKING_NO does not exist.";
                            return BadRequest(response);
                        }

                        if(pExpcEvent.received_no != "")
                        {
                            _context.Database.ExecuteSqlRaw($"UPDATE pPayment SET RpStatus = 'C' WHERE RpReceiptNo = '{pExpcEvent.received_no}'");
                        }
                        _context.Database.ExecuteSqlRaw($"DELETE pPayDetail WHERE DpReceiptNo = '{pExpcEvent.received_no}'");
                        _context.Database.ExecuteSqlRaw($"DELETE pDailyGL WHERE TranDocNo = '{pExpcEvent.PACKING_NO}' AND VouchDate = '{pExpcEvent.LastIntDate}'");
                        _context.Database.ExecuteSqlRaw($"UPDATE pDocRegister SET Reg_Status = 'A' WHERE Reg_Login = 'EXPC' AND Reg_Appv = 'Y' and Reg_Status = 'I' AND Reg_RecStat = 'R' AND Reg_CustCode = '{pExpcEvent.cust_id}' AND Reg_Docno = '{pExpcEvent.PACKING_NO}'");
                        _context.Database.ExecuteSqlRaw($"DELETE pExpc WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}'");

                        // Commit
                        _context.SaveChanges();
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
                    response.Message = "Packing Credit Deleted";
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
        public ActionResult<EXPCResultResponse> Release(string? PACKING_NO)
        {
            EXPCResultResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(PACKING_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "PACKING_NO is required";
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
                        var pExpcEvent = (from row in _context.pExpcs
                                          where row.PACKING_NO == PACKING_NO &&
                                                row.event_type == EVENT_TYPE &&
                                                row.business_type == BUSINESS_TYPE
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExpcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PACKING_NO does not exist.";
                            return BadRequest(response);
                        }

                       if(UpdateCustLiab(pExpcEvent))
                       {
                            var tmp = "pack_thb = 0";
                            if (pExpcEvent.packing_for == "T")
                                tmp = "pack_ccy = 0";
                            _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET {tmp}, rec_status= 'R', event_type = '{EVENT_TYPE}', auth_code = '{USER_ID}', auth_date = '{DateTime.Now}' WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='MASTER'");
                            _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET {tmp} , rec_status= 'R' , event_type = '{EVENT_TYPE}' , auth_code = '{USER_ID}' , auth_date = '{DateTime.Now}' WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='EVENT'");
                            _context.Database.ExecuteSqlRaw($"UPDATE pDailyGL SET SendFlag= 'R' WHERE VouchID = '{pExpcEvent.vouch_id}' AND VouchDate = '{pExpcEvent.LastIntDate}'");
                       }

                        // Commit
                        _context.SaveChanges();
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
                    response.Message = "Packing Credit Released";
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

        private void SavePayment(pExpc pExpcMaster, pPayment pPaymentReq)
        {
            var pPayment = (from row in _context.pPayments
                            where row.RpReceiptNo == pExpcMaster.received_no
                            select row).AsNoTracking().FirstOrDefault();
            if(pPayment == null)
            {
                pPayment = new();
                pPayment.RpReceiptNo = pExpcMaster.received_no;
                pPayment.RpDocNo = pExpcMaster.PACKING_NO;
                pPayment.RpEvent = pExpcMaster.event_no.ToString();
                _context.pPayments.Add(pPayment);
            }
            pPayment.RpEvent = "1";
            pPayment.RpModule = "EXPC";
            pPayment.RpPayDate = pExpcMaster.event_date;
            if (pExpcMaster.method == "CASH")
                pPayment.RpPayBy = "2";
            else if (pExpcMaster.method == "CREDIT")
                pPayment.RpPayBy = "1";
            else
                pPayment.RpPayBy = "3";
            if (pExpcMaster.pay_instruc == "3")
                pPayment.RpPayBy = "4";
            pPayment.RpNote = "";
            pPayment.RpCustCode = pExpcMaster.cust_id;
            pPayment.RpCustAmt1 = pPaymentReq.RpCustAmt1;
            pPayment.RpCustAmt2 = pPaymentReq.RpCustAmt2;
            pPayment.RpCustAmt3 = pPaymentReq.RpCustAmt3;
            pPayment.RpCustAc1 = pPaymentReq.RpCustAc1;
            pPayment.RpCustAc2 = pPaymentReq.RpCustAc2;
            pPayment.RpCustAc3 = pPaymentReq.RpCustAc3;
            pPayment.RpCashAmt = pPaymentReq.RpCashAmt;
            pPayment.RpChqAmt = pPaymentReq.RpChqAmt;
            pPayment.RpChqNo = pPaymentReq.RpChqNo;
            pPayment.RpChqBank = pPaymentReq.RpChqBank;
            pPayment.RpChqBranch = pPaymentReq.RpChqBranch;
            pPayment.RpRefer1 = "";
            pPayment.RpRefer2 = "";
            pPayment.RpApplicant = "";
            pPayment.RpIssBank = "";
            pPayment.RpStatus = "A";
            pPayment.RpRecStatus = pExpcMaster.rec_status;
            pPayment.UserCode = pExpcMaster.user_id;
            pPayment.UpdateDate = DateTime.Now;

            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE dpReceiptNo = '{pExpcMaster.received_no}'");

            int li_seq = 0;
            if(pExpcMaster.partial_full_rate == "0")
            {
                li_seq++;
                if(pExpcMaster.packing_for == "T")
                {
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpcMaster.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpcMaster.pack_thb;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB";
                    _context.pPayDetails.Add(payDetail);
                }
                else
                {
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpcMaster.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpcMaster.pack_thb;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB";
                    payDetail.DpExchRate = pExpcMaster.exch_rate;
                    _context.pPayDetails.Add(payDetail);
                }
            }
            else
            {
                if(pExpcMaster.partial_amt_thb1 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpcMaster.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpcMaster.partial_amt_thb1;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpcMaster.partial_amt_ccy1;
                    payDetail.DpExchRate = pExpcMaster.exch_rate1;
                    payDetail.DpContract = pExpcMaster.forward_contract1;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpcMaster.partial_amt_thb2 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpcMaster.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpcMaster.partial_amt_thb2;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpcMaster.partial_amt_ccy2;
                    payDetail.DpExchRate = pExpcMaster.exch_rate2;
                    payDetail.DpContract = pExpcMaster.forward_contract2;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpcMaster.partial_amt_thb3 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpcMaster.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpcMaster.partial_amt_thb3;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpcMaster.partial_amt_ccy3;
                    payDetail.DpExchRate = pExpcMaster.exch_rate3;
                    payDetail.DpContract = pExpcMaster.forward_contract3;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpcMaster.partial_amt_thb4 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpcMaster.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpcMaster.partial_amt_thb4;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpcMaster.partial_amt_ccy4;
                    payDetail.DpExchRate = pExpcMaster.exch_rate4;
                    payDetail.DpContract = pExpcMaster.forward_contract4;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpcMaster.partial_amt_thb5 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpcMaster.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpcMaster.partial_amt_thb5;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpcMaster.partial_amt_ccy5;
                    payDetail.DpExchRate = pExpcMaster.exch_rate5;
                    payDetail.DpContract = pExpcMaster.forward_contract5;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpcMaster.partial_amt_thb6 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpcMaster.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpcMaster.partial_amt_thb6;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpcMaster.partial_amt_ccy6;
                    payDetail.DpExchRate = pExpcMaster.exch_rate6;
                    payDetail.DpContract = pExpcMaster.forward_contract6;
                    _context.pPayDetails.Add(payDetail);
                }
            }
            if (pExpcMaster.duty_stamp > 0 || pExpcMaster.Comm_Certi > 0 || pExpcMaster.comm_other > 0 || pExpcMaster.comm_OnTT > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpcMaster.received_no;
                payDetail.DpPayName = "";
                payDetail.DpPayAmt = 0;
                payDetail.DpSeq = li_seq;
                payDetail.DpRemark = "LESS";
                _context.pPayDetails.Add(payDetail);
            }
            if (pExpcMaster.duty_stamp > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpcMaster.received_no;
                payDetail.DpPayName = "  DUTY STAMP";
                payDetail.DpPayAmt = pExpcMaster.duty_stamp;
                payDetail.DpSeq = li_seq;
                _context.pPayDetails.Add(payDetail);
            }
            if (pExpcMaster.Comm_Certi > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpcMaster.received_no;
                payDetail.DpPayName = "  COMM. CERTIFY CHEQUE";
                payDetail.DpPayAmt = pExpcMaster.Comm_Certi;
                payDetail.DpSeq = li_seq;
                _context.pPayDetails.Add(payDetail);
            }
            if (pExpcMaster.comm_other > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpcMaster.received_no;
                payDetail.DpPayName = "  COMM. OTHER";
                payDetail.DpPayAmt = pExpcMaster.comm_other;
                payDetail.DpSeq = li_seq;
                _context.pPayDetails.Add(payDetail);
            }
            if (pExpcMaster.comm_OnTT > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpcMaster.received_no;
                payDetail.DpPayName = "COMM. ON T/T DOMESTIC";
                payDetail.DpPayAmt = pExpcMaster.comm_OnTT;
                payDetail.DpSeq = li_seq;
                _context.pPayDetails.Add(payDetail);
            }
        }

        private bool UpdateCustLiab(pExpc pExpcEvent)
        {
            double CCyAmt = 0;
            double BhtAmt = 0;
            double exchrate = 0;
            string AppvFac = "";
            string cCcy = "";
            string AppvNo = "";

            try
            {
                var pDocReg = (from row in _context.pDocRegisters
                               where row.Reg_Docno == pExpcEvent.PACKING_NO
                               select row).AsNoTracking().FirstOrDefault();
                if (pDocReg != null)
                    AppvNo = pDocReg.Reg_AppvNo;

                var pCustAppv = (from row in _context.pCustAppvs
                                 where row.Appv_No == AppvNo
                                 select row).AsNoTracking().FirstOrDefault();
                if (pCustAppv != null)
                {
                    AppvFac = pCustAppv.Facility_No;
                }

                var pExpcMaster = (from row in _context.pExpcs
                                   where row.PACKING_NO == pExpcEvent.PACKING_NO &&
                                         row.record_type == "MASTER"
                                   select row).AsNoTracking().FirstOrDefault();
                if (pExpcMaster != null)
                {
                    AppvFac = pExpcMaster.FACNO;
                }

                if (pExpcEvent.packing_for == "T")
                {
                    CCyAmt = pExpcEvent.pack_thb.Value;
                    BhtAmt = pExpcEvent.pack_thb.Value;
                    cCcy = "THB";
                }
                else
                {
                    cCcy = pExpcEvent.doc_ccy;
                    exchrate = EXHelper.GetRateExChange(_context, cCcy, 3);
                    CCyAmt = pExpcEvent.pack_ccy.Value;
                    BhtAmt = exchrate * CCyAmt;
                }

                var pCustLiab = (from row in _context.pCustLiabs
                                 where row.Cust_Code == pExpcEvent.cust_id &&
                                       row.Facility_No == AppvFac &&
                                       row.Currency == cCcy
                                 select row).FirstOrDefault();
                if(pCustLiab != null)
                {
                    pCustLiab.EXPC_Book = pCustLiab.EXPC_Book - CCyAmt;
                    pCustLiab.EXPC_Amt = pCustLiab.EXPC_Amt + CCyAmt;
                    pCustLiab.UpdateDate = DateTime.Now;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
