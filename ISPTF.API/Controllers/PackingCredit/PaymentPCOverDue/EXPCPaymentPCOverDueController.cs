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
    public class EXPCPaymentPCOverDueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        private const string BUSINESS_TYPE = "2";
        private const string EVENT_TYPE = "Payment";

        public EXPCPaymentPCOverDueController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<PaymentPCOverDueListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            PaymentPCOverDueListPageResponse response = new PaymentPCOverDueListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_PaymentPCOverDueListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_PaymentPCOverDueListPageRsp>();
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

                var results = await _db.LoadData<Q_PaymentPCOverDueListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_PaymentOverDueListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_PaymentPCOverDueListPageRsp>)results;

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
                response.Data = new List<Q_PaymentPCOverDueListPageRsp>();
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
                                                row.record_type == "EVENT"
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

                        pExpcEvent.OveSeqno = pExpc.OveSeqno;
                        pExpcEvent.event_date = pExpc.event_date;
                        pExpcEvent.LastIntDate = pExpc.LastIntDate;
                        pExpcEvent.OBASEDAY = pExpc.OBASEDAY;
                        pExpcEvent.OINTCODE = pExpc.OINTCODE;
                        pExpcEvent.OINTRATE = pExpc.OINTRATE;
                        pExpcEvent.OINTSPDRATE = pExpc.OINTSPDRATE;
                        pExpcEvent.OINTCURRATE = pExpc.OINTCURRATE;
                        pExpcEvent.AutoOverdue = pExpc.AutoOverdue;
                        pExpcEvent.PCOverdue = pExpc.PCOverdue;
                        pExpcEvent.total_bal_thb = pExpc.total_bal_thb;
                        pExpcEvent.interest_thb1 = pExpc.interest_thb1;
                        pExpcEvent.principle_amt_thb1 = pExpc.principle_amt_thb1;
                        pExpcEvent.principle_amt_thb3 = pExpc.principle_amt_thb3;
                        pExpcEvent.principle_amt_thb2 = pExpc.principle_amt_thb2;
                        pExpcEvent.interest_thb2 = pExpc.interest_thb2;
                        pExpcEvent.PaymentType = pExpc.PaymentType;
                        pExpcEvent.PaymentType = pExpc.PaymentType;
                        pExpcEvent.LastPayDate = pExpc.LastPayDate;
                        pExpcEvent.ValueDate = pExpc.ValueDate;

                        pExpcEvent.pay_instruc = pExpc.pay_instruc;
                        pExpcEvent.received_no = pExpc.received_no;

                        if (pExpcEvent.pay_instruc == "1")
                        {
                            pExpcEvent.method = pExpc.method;
                            pExpcEvent.received_no = EXHelper.GetReceivedNo(_context, pExpcEvent.PACKING_NO, pExpcEvent.event_no.ToString());
                            if (pExpcEvent.received_no == "")
                            {
                                pExpcEvent.received_no = EXHelper.GenRefNo(_context,"PAYD",user_id,CenterID);
                            }
                        }
                        else if (pExpcEvent.pay_instruc == "2")
                        {
                            pExpcEvent.method = "";
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayment WHERE RpReceiptNo = '{pExpcEvent.received_no}'");
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE DpReceiptNo = '{pExpcEvent.received_no}'");
                            pExpcEvent.received_no = "";
                        }
                        pExpcEvent.TaxRefund = "Y";
                        pExpcEvent.refund_tax_amt = pExpc.refund_tax_amt;
                        pExpcEvent.total_amount = pExpc.total_amount;
                        pExpcEvent.duty_stamp = pExpc.duty_stamp;
                        pExpcEvent.Com_Lieu = pExpc.Com_Lieu;
                        pExpcEvent.comm_other = pExpc.comm_other;
                        pExpcEvent.total_charge = pExpc.total_charge;
                        pExpcEvent.total_credit_ac = pExpc.total_credit_ac;
                        pExpcEvent.remark = pExpc.remark;
                        pExpcEvent.ALLOCATION = pExpc.ALLOCATION;

                        pExpcEvent.DateToStop = pExpcMaster.DateToStop;
                        pExpcEvent.DateStartAccru = pExpcMaster.DateStartAccru;
                        pExpcEvent.DateLastAccru = pExpcMaster.DateLastAccru;
                        pExpcEvent.AccruCcy = pExpcMaster.AccruCcy;
                        pExpcEvent.AccruAmt = pExpcMaster.AccruAmt;
                        pExpcEvent.DAccruAmt = pExpcMaster.DAccruAmt;
                        pExpcEvent.PAccruAmt = pExpcMaster.PAccruAmt;
                        pExpcEvent.AccruPending = pExpcMaster.AccruPending;
                        pExpcEvent.RevAccru = pExpcMaster.RevAccru;
                        pExpcEvent.RevAccruTax = pExpcMaster.RevAccruTax;
                        pExpcEvent.PastDueDate = pExpcMaster.PastDueDate;
                        pExpcEvent.LastAccruCcy = 0;
                        pExpcEvent.LastAccruAmt = 0;
                        pExpcEvent.PCPastDue = "O";

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
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET rec_status = 'R', event_no = {pExpcEvent.event_no+1} WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND rec_status = 'P' AND record_type = 'MASTER'");
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
