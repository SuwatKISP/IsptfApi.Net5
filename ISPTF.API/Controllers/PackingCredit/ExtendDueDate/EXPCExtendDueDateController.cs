using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
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
    public class EXPCExtendDueDateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "3";
        private const string EVENT_TYPE = "ExtendDue";

        public EXPCExtendDueDateController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ExtendDueDateListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            ExtendDueDateListPageResponse response = new ExtendDueDateListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_ExtendDueDateListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_ExtendDueDateListPageRsp>();
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

                var results = await _db.LoadData<Q_ExtendDueDateListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_ExtenDueDateListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_ExtendDueDateListPageRsp>)results;

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
                response.Data = new List<Q_ExtendDueDateListPageRsp>();
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
                var event_no = 0;
                var pExpcMaster = (from row in _context.pExpcs
                                   where row.PACKING_NO == PACKING_NO &&
                                           row.record_type == "MASTER"
                                   select row).AsNoTracking().FirstOrDefault();
                if (pExpcMaster != null)
                {
                    event_no = pExpcMaster.event_no + 1;
                }
                var pExpc = (from row in _context.pExpcs
                             where row.PACKING_NO == PACKING_NO &&
                                 row.event_type == EVENT_TYPE &&
                                 row.event_no == event_no &&
                                 (row.rec_status == "P" || row.rec_status == "W")
                             select row).AsNoTracking().FirstOrDefault();
                if (pExpc != null)
                {
                    pExpc = (from row in _context.pExpcs
                             where row.PACKING_NO == PACKING_NO &&
                                 row.event_type == EVENT_TYPE &&
                                 row.record_type == "EVENT" &&
                                 (row.rec_status == "P" || row.rec_status == "W")
                             select row).AsNoTracking().FirstOrDefault();
                }
                else
                {
                    pExpc = pExpcMaster;
                }

                if (pExpc == null)
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "record not Found !";
                    response.Data = new();
                }
                if (pExpc.pay_instruc == "1")
                {
                    var pPayment = (from row in _context.pPayments
                                    where row.RpReceiptNo == pExpc.received_no &&
                                          row.RpDocNo == pExpc.PACKING_NO
                                    select row).AsNoTracking().FirstOrDefault();
                    if (pPayment != null)
                    {
                        response.Data.PPAYMENT = pPayment;
                    }
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

                        // 1 - Update Master
                        var pExpcMaster = (from row in _context.pExpcs
                                           where row.PACKING_NO == pExpc.PACKING_NO &&
                                                 row.record_type == "MASTER"
                                           select row).AsNoTracking().FirstOrDefault();
                        var event_no = pExpcMaster.event_no + 1;
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET event_no = {event_no}, rec_status = 'P' WHERE PACKING_NO = '{pExpcMaster.PACKING_NO}' AND record_type = 'MASTER'");
                        _context.SaveChanges();

                        // 2 - Save Event
                        var pExpcEvent = (from row in _context.pExpcs
                                          where row.PACKING_NO == pExpc.PACKING_NO &&
                                                row.record_type == "EVENT" &&
                                                row.event_no == event_no
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExpcEvent == null)
                        {
                            pExpcEvent = new pExpc();
                            pExpcEvent.PACKING_NO = pExpc.PACKING_NO;
                            pExpcEvent.record_type = "EVENT";
                            pExpcEvent.event_no = event_no;
                            pExpcEvent.rec_status = "P";
                            _context.pExpcs.Add(pExpcEvent);
                            _context.SaveChanges();
                        }
                        pExpcEvent.event_mode = "E";
                        pExpcEvent.event_type = EVENT_TYPE;
                        pExpcEvent.business_type = BUSINESS_TYPE;
                        pExpcEvent.CenterID = CenterID;
                        pExpcEvent.user_id = user_id;
                        pExpcEvent.update_date = DateTime.Now;

                        pExpcEvent.PayNo = pExpc.PayNo;
                        pExpcEvent.event_date = pExpc.event_date;
                        pExpcEvent.LastIntDate = pExpc.LastIntDate;
                        pExpcEvent.cust_id = pExpc.cust_id;
                        pExpcEvent.cust_info = pExpc.cust_info;
                        pExpcEvent.applicant_name = pExpc.applicant_name;
                        pExpcEvent.good_code = pExpc.good_code;
                        pExpcEvent.cnty_code = pExpc.cnty_code;
                        pExpcEvent.Rel_code = pExpc.Rel_code;
                        pExpcEvent.shipmentFr = pExpc.shipmentFr;
                        pExpcEvent.shipmentTo = pExpc.shipmentTo;
                        pExpcEvent.good_desc = pExpc.good_desc;
                        pExpcEvent.CalIntDate = pExpc.CalIntDate;
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
                        pExpcEvent.new_pn_no = pExpc.new_pn_no;
                        pExpcEvent.PcIntType = pExpc.PcIntType;
                        pExpcEvent.FixDate = pExpc.FixDate;
                        pExpcEvent.doc_expiry_date = pExpc.doc_expiry_date;
                        pExpcEvent.pc_start_date = pExpc.pc_start_date;
                        pExpcEvent.current_pc_due = pExpc.current_pc_due;
                        pExpcEvent.prev_start_date = pExpc.prev_start_date;
                        pExpcEvent.tot_pc_day = pExpc.tot_pc_day;
                        pExpcEvent.current_60_daydue = pExpc.current_60_daydue;
                        pExpcEvent.pc_int_rate = pExpc.pc_int_rate;
                        pExpcEvent.spread_rate = pExpc.spread_rate;
                        pExpcEvent.current_intrate = pExpc.current_intrate;
                        pExpcEvent.Due_no = pExpc.Due_no;
                        pExpcEvent.LastPayDate = pExpc.LastPayDate;
                        pExpcEvent.CFRRate = pExpc.CFRRate;
                        pExpcEvent.IntFlag = pExpc.IntFlag;
                        pExpcEvent.IntRateCode = pExpc.IntRateCode;
                        pExpcEvent.IntBaseDay = pExpc.IntBaseDay;
                        pExpcEvent.exch_rate1 = pExpc.exch_rate1;
                        pExpcEvent.principle_amt_ccy1 = pExpc.principle_amt_ccy1;
                        pExpcEvent.principle_amt_thb1 = pExpc.principle_amt_thb1;
                        pExpcEvent.interest_ccy1 = pExpc.interest_ccy1;
                        pExpcEvent.interest_thb1 = pExpc.interest_thb1;
                        pExpcEvent.principle_amt_ccy4 = pExpc.principle_amt_ccy4;
                        pExpcEvent.principle_amt_thb4 = pExpc.principle_amt_thb4;
                        pExpcEvent.exch_rate2 = pExpc.exch_rate2;
                        pExpcEvent.principle_amt_ccy2 = pExpc.principle_amt_ccy2;
                        pExpcEvent.principle_amt_thb2 = pExpc.principle_amt_thb2;
                        pExpcEvent.interest_ccy2 = pExpc.interest_ccy2;
                        pExpcEvent.interest_thb2 = pExpc.interest_thb2;
                        pExpcEvent.exch_rate3 = pExpc.exch_rate3;
                        pExpcEvent.interest_ccy2 = pExpc.interest_ccy2;
                        pExpcEvent.interest_thb2 = pExpc.interest_thb2;
                        pExpcEvent.total_date = pExpc.total_date;
                        pExpcEvent.remark = pExpc.remark;
                        pExpcEvent.exch_rate6 = pExpc.exch_rate6;

                        pExpcEvent.pay_instruc = pExpc.pay_instruc;
                        pExpcEvent.received_no = pExpc.received_no;
                        if (pExpcEvent.pay_instruc == "1")
                        {
                            pExpcEvent.method = pExpc.method;
                            pExpcEvent.received_no = EXHelper.GetReceivedNo(_context, pExpcEvent.PACKING_NO, pExpcEvent.event_no.ToString());
                            if (pExpcEvent.received_no == "")
                            {
                                pExpcEvent.received_no = EXHelper.GenRefNo(_context, "PAYD", user_id, CenterID);
                            }
                            SavePayment(pExpcEvent,pexpcppaymentrequest.pPayment);
                        }
                        else if (pExpcEvent.pay_instruc == "2")
                        {
                            pExpcEvent.method = "";
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayment WHERE RpReceiptNo = '{pExpcEvent.received_no}'");
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE DpReceiptNo = '{pExpcEvent.received_no}'");
                            pExpcEvent.received_no = "";
                        }
                        else if (pExpcEvent.pay_instruc == "3")
                        {
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayment WHERE RpReceiptNo = '{pExpcEvent.received_no}'");
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE DpReceiptNo = '{pExpcEvent.received_no}'");
                            pExpcEvent.received_no = "";
                        }

                        pExpcEvent.total_charge = pExpc.total_charge;
                        pExpcEvent.total_credit_ac = pExpc.total_credit_ac;
                        pExpcEvent.total_amount = pExpc.total_amount;
                        pExpcEvent.TaxRefund = pExpc.TaxRefund;
                        pExpcEvent.refund_tax_amt = pExpc.refund_tax_amt;
                        pExpcEvent.ALLOCATION = pExpc.ALLOCATION;
                        pExpcEvent.MidRate = pExpc.MidRate;
                        _context.pExpcs.Update(pExpcEvent);

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

                        if (pExpcEvent.received_no != "")
                        {
                            _context.Database.ExecuteSqlRaw($"UPDATE pPayment SET RpStatus = 'C' WHERE RpReceiptNo = '{pExpcEvent.received_no}'");
                        }
                        _context.Database.ExecuteSqlRaw($"DELETE pPayDetail WHERE DpReceiptNo = '{pExpcEvent.received_no}'");
                        _context.Database.ExecuteSqlRaw($"DELETE pDailyGL WHERE VouchID = '{pExpcEvent.vouch_id}' AND VouchDate = '{pExpcEvent.LastIntDate}'");
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET rec_status = 'R', event_no = {pExpcEvent.event_no + 1} WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND rec_status = 'P' AND record_type = 'MASTER'");
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET rec_status = 'T' WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND rec_status IN ('P','W') AND record_type = 'EVENT' AND event_type = '{EVENT_TYPE}' AND business_type = '{BUSINESS_TYPE}'");
                        var pexpc = new pExpc();

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

                        if (UpdateCustLiab(pExpcEvent))
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

        private void SavePayment(pExpc pExpc, pPayment pPaymentReq)
        {
            var pPayment = (from row in _context.pPayments
                            where row.RpReceiptNo == pExpc.received_no
                            select row).AsNoTracking().FirstOrDefault();
            if (pPayment == null)
            {
                pPayment = new();
                pPayment.RpReceiptNo = pExpc.received_no;
                pPayment.RpDocNo = pExpc.PACKING_NO;
                pPayment.RpEvent = pExpc.event_no.ToString();
                _context.pPayments.Add(pPayment);
            }
            pPayment.RpModule = "EXPC";
            pPayment.RpPayDate = pExpc.event_date;
            pPayment.RpPayBy = pPayment.RpPayBy;
            pPayment.RpNote = "";
            pPayment.RpCustCode = pExpc.cust_id;
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
            pPayment.RpRecStatus = pExpc.rec_status;
            pPayment.UserCode = pExpc.user_id;
            pPayment.UpdateDate = DateTime.Now;

            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE dpReceiptNo = '{pExpc.received_no}'");

            int li_seq = 0;
            if (pExpc.partial_full_rate == "0")
            {
                li_seq++;
                if (pExpc.packing_for == "T")
                {
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpc.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpc.pack_thb;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB";
                    _context.pPayDetails.Add(payDetail);
                }
                else
                {
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpc.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpc.pack_thb;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB";
                    payDetail.DpExchRate = pExpc.exch_rate;
                    _context.pPayDetails.Add(payDetail);
                }
            }
            else
            {
                if (pExpc.partial_amt_thb1 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpc.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpc.partial_amt_thb1;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy1;
                    payDetail.DpExchRate = pExpc.exch_rate1;
                    payDetail.DpContract = pExpc.forward_contract1;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpc.partial_amt_thb2 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpc.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpc.partial_amt_thb2;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy2;
                    payDetail.DpExchRate = pExpc.exch_rate2;
                    payDetail.DpContract = pExpc.forward_contract2;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpc.partial_amt_thb3 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpc.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpc.partial_amt_thb3;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy3;
                    payDetail.DpExchRate = pExpc.exch_rate3;
                    payDetail.DpContract = pExpc.forward_contract3;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpc.partial_amt_thb4 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpc.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpc.partial_amt_thb4;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy4;
                    payDetail.DpExchRate = pExpc.exch_rate4;
                    payDetail.DpContract = pExpc.forward_contract4;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpc.partial_amt_thb5 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpc.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpc.partial_amt_thb5;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy5;
                    payDetail.DpExchRate = pExpc.exch_rate5;
                    payDetail.DpContract = pExpc.forward_contract5;
                    _context.pPayDetails.Add(payDetail);
                }
                if (pExpc.partial_amt_thb6 > 0)
                {
                    li_seq++;
                    var payDetail = new pPayDetail();
                    payDetail.DpReceiptNo = pExpc.received_no;
                    payDetail.DpPayName = "";
                    payDetail.DpPayAmt = pExpc.partial_amt_thb6;
                    payDetail.DpSeq = li_seq;
                    payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy6;
                    payDetail.DpExchRate = pExpc.exch_rate6;
                    payDetail.DpContract = pExpc.forward_contract6;
                    _context.pPayDetails.Add(payDetail);
                }
            }
            if (pExpc.duty_stamp > 0 || pExpc.Comm_Certi > 0 || pExpc.comm_other > 0 || pExpc.comm_OnTT > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpc.received_no;
                payDetail.DpPayName = "";
                payDetail.DpPayAmt = 0;
                payDetail.DpSeq = li_seq;
                payDetail.DpRemark = "LESS";
                _context.pPayDetails.Add(payDetail);
            }
            if (pExpc.duty_stamp > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpc.received_no;
                payDetail.DpPayName = "  DUTY STAMP";
                payDetail.DpPayAmt = pExpc.duty_stamp;
                payDetail.DpSeq = li_seq;
                _context.pPayDetails.Add(payDetail);
            }
            if (pExpc.Comm_Certi > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpc.received_no;
                payDetail.DpPayName = "  COMM. CERTIFY CHEQUE";
                payDetail.DpPayAmt = pExpc.Comm_Certi;
                payDetail.DpSeq = li_seq;
                _context.pPayDetails.Add(payDetail);
            }
            if (pExpc.comm_other > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpc.received_no;
                payDetail.DpPayName = "  COMM. OTHER";
                payDetail.DpPayAmt = pExpc.comm_other;
                payDetail.DpSeq = li_seq;
                _context.pPayDetails.Add(payDetail);
            }
            if (pExpc.comm_OnTT > 0)
            {
                li_seq++;
                var payDetail = new pPayDetail();
                payDetail.DpReceiptNo = pExpc.received_no;
                payDetail.DpPayName = "COMM. ON T/T DOMESTIC";
                payDetail.DpPayAmt = pExpc.comm_OnTT;
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
                if (pCustLiab != null)
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
