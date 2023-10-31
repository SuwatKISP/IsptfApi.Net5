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
using ISPTF.API.Controllers.ExportLC;

namespace ISPTF.API.Controllers.PackingCredit
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXPCPaymentPackingCreditController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "2";
        private const string EVENT_TYPE = "Payment";

        public IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;

        public EXPCPaymentPackingCreditController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<PaymentPCListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            PaymentPCListPageResponse response = new PaymentPCListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_PaymentPCListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_PaymentPCListPageRsp>();
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

                var results = await _db.LoadData<Q_PaymentPCListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_PaymentPackingListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_PaymentPCListPageRsp>)results;

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
                response.Data = new List<Q_PaymentPCListPageRsp>();
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
                }
                else
                {
                    pExpc = pExpcMaster;
                    response.Data.PPAYMENT = null;
                }

                if (pExpc == null)
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "record not Found !";
                    response.Data = new();
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
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
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
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET rec_status = 'P' WHERE PACKING_NO = '{pExpcMaster.PACKING_NO}' AND record_type = 'MASTER'");
                        _context.SaveChanges();

                        // 2 - Save Event
                        var pExpcEvent = (from row in _context.pExpcs
                                          where row.PACKING_NO == pExpc.PACKING_NO &&
                                                row.record_type == "EVENT" &&
                                                row.event_no == event_no
                                          select row).AsNoTracking().FirstOrDefault();

                       //pExpc pExpcEvent = pexpcppaymentrequest.pExpc;

                        if (pExpcEvent == null)
                        {
                         //   pExpcEvent = new pExpc();
                            pExpc.PACKING_NO = pExpc.PACKING_NO;
                            pExpc.record_type = "EVENT";
                            pExpc.event_no = event_no;
                            pExpc.rec_status = "P";
                            _context.pExpcs.Add(pExpc);
                            _context.SaveChanges();

                        }
                        pExpc.PACKING_NO = pExpc.PACKING_NO;
                        pExpc.record_type = "EVENT";
                        pExpc.event_no = event_no;
                        pExpc.rec_status = "P";
                        pExpc.event_mode = "E";
                        pExpc.event_type = EVENT_TYPE;
                        pExpc.business_type = BUSINESS_TYPE;
                        pExpc.PurposeCode = pExpc.PurposeCode;
                        pExpc.CenterID = CenterID;
                        pExpc.user_id = user_id;
                        pExpc.update_date = UpdateDateT;
                        pExpc.event_date = pExpc.event_date;
                        pExpc.cnty_code = pExpc.cnty_code;
                        pExpc.cust_id = pExpc.cust_id;
                        pExpc.cust_info = pExpc.cust_info;
                        pExpc.applicant_name = pExpc.applicant_name;
                        pExpc.good_code = pExpc.good_code;
                        pExpc.Rel_code = pExpc.Rel_code;
                        pExpc.good_desc = pExpc.good_desc;
                        pExpc.PayNo = pExpc.PayNo;
                        pExpc.packing_for = pExpc.packing_for;
                        pExpc.pack_under = pExpc.pack_under;
                        pExpc.shipmentFr = pExpc.shipmentFr;
                        pExpc.shipmentTo = pExpc.shipmentTo;
                        pExpc.refer_lcno = pExpc.refer_lcno;
                        pExpc.doc_ccy = pExpc.doc_ccy;
                        pExpc.doc_amount = pExpc.doc_amount;
                        pExpc.rate = pExpc.rate;
                        pExpc.pack_ccy = pExpc.pack_ccy;
                        pExpc.pack_thb = pExpc.pack_thb;
                        pExpc.pn_no = pExpc.pn_no;
                        pExpc.FlagBack = pExpc.FlagBack;
                        pExpc.doc_expiry_date = pExpc.doc_expiry_date;
                        pExpc.pc_start_date = pExpc.pc_start_date;
                        pExpc.current_pc_due = pExpc.current_pc_due;
                        pExpc.tot_pc_day = pExpc.tot_pc_day;
                        pExpc.current_60_daydue = pExpc.current_60_daydue;
                        pExpc.pc_int_rate = pExpc.pc_int_rate;
                        pExpc.spread_rate = pExpc.spread_rate;
                        pExpc.current_intrate = pExpc.current_intrate;
                        pExpc.total_date = pExpc.total_date;
                        pExpc.PcIntType = pExpc.PcIntType;
                        pExpc.FixDate = pExpc.FixDate;
                        pExpc.ValueDate = pExpc.ValueDate;
                        pExpc.exch_rate1 = pExpc.exch_rate1;
                        pExpc.principle_amt_ccy1 = pExpc.principle_amt_ccy1;
                        pExpc.principle_amt_thb1 = pExpc.principle_amt_thb1;
                        pExpc.interest_ccy1 = pExpc.interest_ccy1;
                        pExpc.interest_thb1 = pExpc.interest_thb1;
                        pExpc.exch_rate = pExpc.exch_rate;
                        pExpc.principle_amt_ccy4 = pExpc.principle_amt_ccy4;
                        pExpc.principle_amt_thb4 = pExpc.principle_amt_thb4;
                        pExpc.RevAccru = pExpc.RevAccru;
                        pExpc.exch_rate2 = pExpc.exch_rate2;
                        pExpc.principle_amt_ccy2 = pExpc.principle_amt_ccy2;
                        pExpc.principle_amt_thb2 = pExpc.principle_amt_thb2;
                        pExpc.exch_rate3 = pExpc.exch_rate3;
                        pExpc.interest_ccy2 = pExpc.interest_ccy2;
                        pExpc.interest_thb2 = pExpc.interest_thb2;
                        pExpc.exch_rate5 = pExpc.exch_rate5;
                        pExpc.Com_Lieu = pExpc.Com_Lieu;
                        pExpc.partial_amt_thb5 = pExpc.partial_amt_thb5;
                        pExpc.PCProfit = pExpc.PCProfit;
                        pExpc.MidRate = pExpc.MidRate;
                        pExpc.prev_contra_bal = pExpc.prev_contra_bal;
                        pExpc.contra_bal = pExpc.contra_bal;
                        pExpc.deduct_export_thb = pExpc.deduct_export_thb;
                        pExpc.contra_date = pExpc.contra_date;
                        pExpc.remark = pExpc.remark;
                        pExpc.FcdAcc = pExpc.FcdAcc;
                        pExpc.BahtNet = pExpc.BahtNet;
                        pExpc.CalIntDate = pExpcMaster.CalIntDate;
                        pExpc.in_Use = "0";
                        pExpc.pay_instruc = pExpc.pay_instruc;
                        pExpc.received_no = pExpc.received_no;

                        if (pExpc.pay_instruc == "1")
                        {
                            pExpc.method = pExpc.method;
                            //pExpc.received_no = EXHelper.GetReceivedNo(_context, pExpc.PACKING_NO, pExpc.event_no.ToString());
                            //if (pExpc.received_no == "")
                            //{
                            //    pExpc.received_no = EXHelper.GenRefNo(_context, "PAYD", user_id, CenterID);
                            //}

                            if (pExpc.received_no == "" || pExpc.received_no == null)
                            {
                                pExpc.received_no = ExportLCHelper.GenRefNo(_context, CenterID, user_id, "PAYD", UpdateDateT, UpdateDateNT);
                            }

                            SavePayment(pExpc, pexpcppaymentrequest.pPayment,UpdateDateT);
                        }
                        else if (pExpc.pay_instruc == "2")
                        {
                            pExpc.method = "";
                            pExpc.vouch_id = "";
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayment WHERE RpReceiptNo = '{pExpc.received_no}'");
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE DpReceiptNo = '{pExpc.received_no}'");
                            pExpc.received_no = "";
                        }
                        else if (pExpc.pay_instruc == "3")
                        {
                            //pExpc.received_no = EXHelper.GetReceivedNo(_context, pExpc.PACKING_NO, pExpc.event_no.ToString());
                            //if (pExpc.received_no == "")
                            //{
                            //    pExpc.received_no = EXHelper.GenRefNo(_context, "PAYD", user_id, CenterID);
                            //}
                            if (pExpc.received_no == "" || pExpc.received_no == null)
                            {
                                pExpc.received_no = ExportLCHelper.GenRefNo(_context, CenterID, user_id, "PAYD", UpdateDateT, UpdateDateNT);
                            }

                            pExpc.BahtNet = pExpc.BahtNet;
                            SavePayment(pExpc, pexpcppaymentrequest.pPayment,UpdateDateT);
                        }
                        else if (pExpc.pay_instruc == "4")
                        {
                            pExpc.method = "";
                            //pExpc.received_no = EXHelper.GetReceivedNo(_context, pExpc.PACKING_NO, pExpc.event_no.ToString());
                            //if (pExpc.received_no == "")
                            //{
                            //    pExpc.received_no = EXHelper.GenRefNo(_context, "PAYD", user_id, CenterID);
                            //}
                            if (pExpc.received_no == "" || pExpc.received_no == null)
                            {
                                pExpc.received_no = ExportLCHelper.GenRefNo(_context, CenterID, user_id, "PAYD", UpdateDateT, UpdateDateNT);
                            }

                            pExpc.FcdAcc = pExpc.FcdAcc;
                            pExpc.FcdAmt = pExpc.FcdAmt;
                            SavePayment(pExpc, pexpcppaymentrequest.pPayment,UpdateDateT);
                        }
                        pExpc.total_charge = pExpc.total_charge;
                        pExpc.total_credit_ac = pExpc.total_credit_ac;
                        pExpc.total_amount = pExpc.total_amount;
                        pExpc.TaxRefund = pExpc.TaxRefund;
                        pExpc.refund_tax_amt = pExpc.refund_tax_amt;
                        pExpc.LastPayDate = pExpc.LastPayDate;
                        pExpc.ALLOCATION = pExpc.ALLOCATION;
                        _context.pExpcs.Update(pExpc);

                        // Commit
                        _context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Packing Credit Saved";
                        response.Data = new();
                        response.Data.PEXPC = pExpc;// pexpcppaymentrequest.pExpc;
                        var pPaymentEvent = (from row in _context.pPayments
                                             where row.RpReceiptNo == pExpc.received_no
                                             select row).AsNoTracking().FirstOrDefault();
                        response.Data.PPAYMENT = pPaymentEvent;// pexpcppaymentrequest.pPayment;
     

                        bool resGL;
                        bool resPayD;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = response.Data.PEXPC.event_type;
                        eventDate = response.Data.PEXPC.event_date.Value.ToString("dd/MM/yyyy",engDateFormat);
                        if (pExpc.pay_instruc == "4")
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXPC(response.Data.PEXPC.PACKING_NO,
                            eventDate, GLEvent, response.Data.PEXPC.event_no, "PAYMENT-FCD");
                        }
                        else
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXPC(response.Data.PEXPC.PACKING_NO,
                            eventDate, GLEvent, response.Data.PEXPC.event_no, GLEvent);
                        }

                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            response.Data.PEXPC.vouch_id = resVoucherID;
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
                        string resPayDetail;
                        if (response.Data.PPAYMENT != null)
                        {
                            resPayDetail = ISPModule.PayDetailEXPC.PayDetail_Payment(response.Data.PEXPC.PACKING_NO, response.Data.PEXPC.event_no, response.Data.PEXPC.received_no);
                            if (resPayDetail != "ERROR")
                            {
                                resPayD = true;
                            }
                            else
                            {
                                response.Code = Constants.RESPONSE_ERROR;
                                response.Message = "Error for PayDetail";
                                return BadRequest(response);
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
        public ActionResult<EXPCResultResponse> Delete([FromBody] PEXPCRelaseReq data)
        {
            EXPCResultResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(data.PACKING_NO))
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
                                          where row.PACKING_NO == data.PACKING_NO &&
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
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET rec_status = 'R', event_no = {pExpcEvent.event_no} WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND rec_status = 'P' AND record_type = 'MASTER'");
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
        public ActionResult<EXPCResultResponse> Release([FromBody] PEXPCRelaseReq data)
        {
            EXPCResultResponse response = new();
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            // Validate
            if (string.IsNullOrEmpty(data.PACKING_NO))
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
                        var pExpcMaster = (from row in _context.pExpcs
                                           where row.PACKING_NO == data.PACKING_NO &&
                                                 row.record_type == "MASTER"
                                           select row).FirstOrDefault();
                        var event_no = pExpcMaster.event_no + 1;
                        // 1 - Check if Master Exists
                        if (pExpcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXPC Master does not exists";
                            return BadRequest(response);
                        }
                        var pExpcEvent = (from row in _context.pExpcs
                                          where row.PACKING_NO == data.PACKING_NO &&
                                                row.event_type == EVENT_TYPE &&
                                                row.business_type == BUSINESS_TYPE &&
                                                row.event_no ==event_no
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExpcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PACKING_NO does not exist.";
                            return BadRequest(response);
                        }
                        //                    pExpcMaster.event_no = cEventNo
                        pExpcMaster.rec_status = "R";
                        pExpcMaster.user_id = USER_ID;
                        pExpcMaster.event_type = "Payment";
                        pExpcMaster.business_type = "2";
                        pExpcMaster.event_mode = "E";
                        pExpcMaster.update_date = UpdateDateT;
                        pExpcMaster.auth_code = USER_ID;
                        pExpcMaster.auth_date = UpdateDateT;
                        pExpcMaster.vouch_id = pExpcEvent.vouch_id;
                        pExpcMaster.genacc_flag = "Y";
                        pExpcMaster.genacc_date = UpdateDateT;
                        pExpcMaster.total_date = pExpcEvent.total_date;
                        pExpcMaster.exch_rate1 = pExpcEvent.exch_rate1;
                        pExpcMaster.PayNo = pExpcEvent.PayNo;
                        pExpcMaster.PurposeCode = pExpcEvent.PurposeCode;
                        string packing_for = pExpcEvent.packing_for;


                        if (packing_for == "O")
                        {
                            pExpcMaster.principle_amt_ccy1 =Convert.ToDouble( Math.Round(Convert.ToDecimal( pExpcEvent.principle_amt_ccy1 - pExpcEvent.principle_amt_ccy2),2));
                            pExpcMaster.principle_amt_thb1 = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcMaster.principle_amt_ccy1 * pExpcMaster.exch_rate), 2));
                            if (pExpcEvent.interest_ccy2>0)
                            {
                                pExpcMaster.interest_ccy1 = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcEvent.principle_amt_ccy4 - pExpcEvent.interest_ccy2), 2));
                            }
                            if (pExpcMaster.principle_amt_ccy1 < 0 ) pExpcMaster.principle_amt_ccy1 = 0;
                            if (pExpcMaster.interest_ccy1 < 0 ) pExpcMaster.interest_ccy1 = 0;
                        }
                        else
                        {
                            pExpcMaster.principle_amt_thb1 = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcEvent.principle_amt_thb1 - pExpcEvent.principle_amt_thb2), 2));
                            if (pExpcEvent.interest_thb2 > 0)
                            {
                                pExpcMaster.interest_thb1 = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcEvent.principle_amt_thb4 - pExpcEvent.interest_thb2), 2));
                            }
                            if (pExpcMaster.principle_amt_thb1 < 0) pExpcMaster.principle_amt_thb1 = 0;
                            if (pExpcMaster.interest_thb1 < 0) pExpcMaster.interest_thb1 = 0;
                        }

                        pExpcMaster.exch_rate2 = 0;
                        pExpcMaster.principle_amt_ccy2 = 0;
                        pExpcMaster.principle_amt_thb2 = 0;
                        pExpcMaster.interest_ccy2 = 0;
                        pExpcMaster.interest_thb2 = 0;
                        pExpcMaster.principle_amt_thb3 = 0;
                        pExpcMaster.principle_amt_thb3 = 0;
                        pExpcMaster.principle_amt_thb4 = 0;
                        pExpcMaster.principle_amt_thb4 = 0;
                        pExpcMaster.prev_contra_bal = pExpcEvent.contra_bal;
                        pExpcMaster.contra_bal = 0;
                        pExpcMaster.deduct_export_thb = 0;
                        pExpcMaster.contra_date = pExpcEvent.contra_date;
                        pExpcMaster.remark = pExpcEvent.remark;
                        pExpcMaster.method = pExpcEvent.method;
                        pExpcMaster.BahtNet = pExpcEvent.BahtNet;
                        pExpcMaster.FcdAcc = pExpcEvent.FcdAcc;
                        pExpcMaster.FcdAmt = pExpcEvent.FcdAmt;
                        pExpcMaster.total_amount = pExpcEvent.total_amount;
                        //com inlieu
                        pExpcMaster.exch_rate5 = pExpcEvent.exch_rate5;
                        pExpcMaster.Com_Lieu = pExpcEvent.Com_Lieu;
                        pExpcMaster.partial_amt_thb5 = pExpcEvent.partial_amt_thb5;
                        pExpcMaster.LastPayDate = pExpcEvent.ValueDate;


                        //----------------------- Cal Interest Date ---------------------------
                        if (pExpcEvent.PcIntType=="1")
                        {
                            pExpcMaster.exch_rate9 = 0;
                            if (pExpcEvent.principle_amt_thb4 == pExpcEvent.interest_thb2)
                            {
                                pExpcMaster.CalIntDate = pExpcEvent.ValueDate;
                                pExpcMaster.interest_thb1 = 0;
                            }
                            else if (pExpcEvent.principle_amt_thb2 > 0)
                                pExpcMaster.CalIntDate = pExpcEvent.CalIntDate;
                            else if (pExpcEvent.principle_amt_thb2 == 0 && pExpcEvent.interest_thb2 > 0)
                            {
                                pExpcMaster.CalIntDate = pExpcEvent.ValueDate;
                                if (packing_for == "O")
                                {
                                    pExpcMaster.exch_rate9 = pExpcMaster.interest_ccy1;
                                }
                                else
                                {
                                    pExpcMaster.exch_rate9 = pExpcMaster.interest_thb1;
                                }
                            }
                            else
                            {
                                pExpcMaster.CalIntDate = pExpcEvent.CalIntDate;
                            }

                        }
                        if (pExpcEvent.total_amount > 0)
                        {
                            pExpcMaster.received_no = pExpcEvent.received_no;

                        }
                        else
                        {
                            pExpcMaster.received_no = "";
                         }

                        if (packing_for == "O")
                        {
                            if (pExpcMaster.principle_amt_ccy1 == 0 && pExpcMaster.interest_ccy1 == 0 && pExpcMaster.prev_contra_bal == 0)
                            {
                                pExpcMaster.PaymentType = "F";
                            }
                            else if (pExpcMaster.principle_amt_ccy1 == 0 && pExpcMaster.interest_ccy1 == 0 && pExpcMaster.prev_contra_bal != 0)
                            {
                                if (pExpcMaster.FlagSettle == "Y")
                                {
                                    pExpcMaster.PaymentType = "F";
                                }
                                else
                                {
                                    pExpcMaster.PaymentType = "C";
                                }
                            }
                            else
                             {
                                    pExpcMaster.PaymentType = "P";
                             }
                            }
                            else
                            {
                                if (pExpcMaster.principle_amt_thb1 == 0 && pExpcMaster.interest_thb1 == 0 && pExpcMaster.prev_contra_bal == 0)
                                {
                                    pExpcMaster.PaymentType = "F";
                                }
                                else if (pExpcMaster.principle_amt_thb1 == 0 && pExpcMaster.interest_thb1 == 0 && pExpcMaster.prev_contra_bal != 0)
                                {
                                    if (pExpcMaster.FlagSettle == "Y")
                                    {
                                        pExpcMaster.PaymentType = "F";
                                    }
                                    else
                                    {
                                        pExpcMaster.PaymentType = "C";
                                    }
                                }
                                else
                                {
                                    pExpcMaster.PaymentType = "P";
                                }
                             }
                             if (pExpcEvent.contra_bal == 0)  pExpcMaster.FlagSettle = "Y";

                        //'------------------- ACCRU ----------------------------------------------------------------------
                        double PreAmt=0;
                        double LastPending=0;
                        pMonAccrued pMonAccrueds = new pMonAccrued();
                        if (pExpcEvent.ValueDate == pExpcEvent.event_date)
                        {
                            pMonAccrueds = (from row in _context.pMonAccrueds
                                               where row.DocNumber == data.PACKING_NO &&
                                                     row.Login == "EXPC"
                                               select row).FirstOrDefault();
                            if (pMonAccrueds != null)
                            {
                                PreAmt =  pMonAccrueds.PrevIntCcy.Value;
                            }
                        }
                        else
                        {
                            //  order by seqno desc 
                            var maxSeqRow = (from row in _context.pMonAccrueds
                                             where row.DocNumber == data.PACKING_NO &&
                                                       row.Login == "EXPC" &&
                                                       row.CalDate < pExpcEvent.ValueDate
                                             select row).ToList().OrderByDescending(x => x.Seqno);
                            foreach (var row in maxSeqRow)
                            {
                                PreAmt = row.PrevIntCcy.Value;
                                break;
                            }
                        }

                        if (packing_for == "O")
                        {
                            pExpcMaster.AccruCcy = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcMaster.AccruCcy - pExpcEvent.interest_ccy2), 2));// Val(Format(pExpcMaster.AccruCcy - Val(Format(txPackAmt(26).Text, "##0.00")), "#0.00"))
                            if (pExpcMaster.interest_ccy1 == 0)
                            {
                                pExpcMaster.AccruCcy = 0;
                            }
                            pExpcMaster.AccruAmt = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcMaster.AccruCcy * pExpcEvent.MidRate), 2));// Val(Format(pExpcMaster.AccruCcy * Val(Format(LbMidRate.Caption, "#0.000000")), "#0.00"))
                            if (pExpcEvent.interest_ccy2 > 0) 
                           {
                                LastPending = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcEvent.principle_amt_ccy4 - pExpcEvent.interest_ccy2), 2));// Val(Format(Val(Format(txPackAmt(22).Text, "##0.00")) - Val(Format(txPackAmt(26).Text, "##0.00")), "#0.00"))
                                pExpcMaster.AccruPending = LastPending;
                            }
                        }
                    else
                     {
                        pExpcMaster.AccruCcy = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcMaster.AccruCcy - pExpcEvent.interest_thb2), 2)); //Val(Format(pExpcMaster.AccruCcy - Val(Format(txPackAmt(27).Text, "##0.00")), "#0.00"))
                        if (pExpcMaster.interest_thb1 == 0) pExpcMaster.AccruCcy = 0;

                        pExpcMaster.AccruAmt = pExpcMaster.AccruCcy;
                        if (pExpcEvent.interest_thb2 > 0)
                        {
                            LastPending = Convert.ToDouble(Math.Round(Convert.ToDecimal(pExpcEvent.principle_amt_thb4 - pExpcEvent.interest_thb2), 2));// Val(Format(Val(Format(txPackAmt(23).Text, "##0.00")) - Val(Format(txPackAmt(27).Text, "##0.00")), "#0.00"))
                            pExpcMaster.AccruPending = LastPending;
                        }
                     }
                        pExpcMaster.DateStartAccru = pExpcEvent.ValueDate;
                        pExpcMaster.RevAccru = 0;
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET  rec_status= 'R', event_type = '{EVENT_TYPE}', auth_code = '{USER_ID}', auth_date = '{UpdateDateT}',event_no ={pExpcEvent.event_no} WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='MASTER'");
                        //Update Event
                        pExpcEvent.auth_code = USER_ID;
                        pExpcEvent.auth_date = UpdateDateT;
                        pExpcEvent.genacc_flag = "Y";
                        pExpcEvent.genacc_date = UpdateDateNT;
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET rec_status= 'R'  WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='EVENT' and Event_no ={pExpcEvent.event_no} ");

                        var pPayments = (from row in _context.pPayments
                                         where row.RpReceiptNo == pExpcEvent.received_no
                                         select row).ToList();
                        foreach (var row in pPayments)
                        {
                            row.RpRecStatus = "R";
                        }
                        _context.SaveChanges();
                        // 3 - Update GL Flag
                        var gls = (from row in _context.pDailyGLs
                                   where row.VouchID == pExpcEvent.vouch_id &&
                                         row.VouchDate == pExpcEvent.event_date.GetValueOrDefault().Date
                                   select row).ToList();

                        foreach (var row in gls)
                        {
                            row.SendFlag = "R";
                        }
                        _context.SaveChanges();

                        if (packing_for == "T")
                        {
                            if (pExpcEvent.interest_thb2 >0)
                            {
                                var HistoryInt = ExportLCHelper.HistInterestPC(_context, CenterID, USER_ID, pExpcEvent);
                            }    
                        }
                        else
                        {
                            if (pExpcEvent.interest_ccy2 > 0)
                            {
                                var HistoryInt = ExportLCHelper.HistInterestPC(_context, CenterID, USER_ID, pExpcEvent);
                            }
                        }

                        //if (UpdateCustLiab(pExpcEvent))
                        //{
                        //    var tmp = "pack_thb = 0";
                        //    if (pExpcEvent.packing_for == "T")
                        //        tmp = "pack_ccy = 0";
                        //    _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET {tmp}, rec_status= 'R', event_type = '{EVENT_TYPE}', auth_code = '{USER_ID}', auth_date = '{DateTime.Now}' WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='MASTER'");
                        //    _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET {tmp} , rec_status= 'R' , event_type = '{EVENT_TYPE}' , auth_code = '{USER_ID}' , auth_date = '{DateTime.Now}' WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='EVENT'");
                        //    _context.Database.ExecuteSqlRaw($"UPDATE pDailyGL SET SendFlag= 'R' WHERE VouchID = '{pExpcEvent.vouch_id}' AND VouchDate = '{pExpcEvent.LastIntDate}'");
                        //}

                        // Commit
                        transaction.Complete();
                        transaction.Dispose();

                        string eventDate;
                        string resCustLiab;
                        eventDate = pExpcEvent.event_date.Value.ToString("dd/MM/yyyy",engDateFormat);
                        resCustLiab = ISPModule.CustLiabEXPC.EXPC_Payment(eventDate, "ISSUE", pExpcEvent.PACKING_NO, pExpcEvent.cust_id,
                        pExpcEvent.doc_ccy, pExpcEvent.principle_amt_ccy2.ToString(), pExpcEvent.principle_amt_thb2.ToString(), pExpcEvent.packing_for);
                        if (resCustLiab == "ERROR")
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Error for Update Liability";
                            return BadRequest(response);
                        }
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

        private void SavePayment(pExpc pExpc, pPayment pPaymentReq, DateTime UpdateDateT)
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
           
            if (pPaymentReq.RpCashAmt > 0) // 'cash
           {
                pPayment.RpPayBy = "2";
            }
            else if(pPaymentReq.RpChqAmt > 0) // 'cheque
           {
                pPayment.RpPayBy = "3";
            }
            else
            {
                pPayment.RpPayBy = "1";
            }
            if (pExpc.BahtNet >0)//baht
            {
                pPayment.RpPayBy = "4";
            }
            if(pExpc.FcdAmt > 0)//fcd
            {
                pPayment.RpPayBy = "5";
            }
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
            pPayment.UpdateDate = UpdateDateT;

            //_context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE dpReceiptNo = '{pExpc.received_no}'");

            //int li_seq = 0;
            //if (pExpc.partial_full_rate == "0")
            //{
            //    li_seq++;
            //    if (pExpc.packing_for == "T")
            //    {
            //        var payDetail = new pPayDetail();
            //        payDetail.DpReceiptNo = pExpc.received_no;
            //        payDetail.DpPayName = "";
            //        payDetail.DpPayAmt = pExpc.pack_thb;
            //        payDetail.DpSeq = li_seq;
            //        payDetail.DpRemark = "P/C AMOUNT THB";
            //        _context.pPayDetails.Add(payDetail);
            //    }
            //    else
            //    {
            //        var payDetail = new pPayDetail();
            //        payDetail.DpReceiptNo = pExpc.received_no;
            //        payDetail.DpPayName = "";
            //        payDetail.DpPayAmt = pExpc.pack_thb;
            //        payDetail.DpSeq = li_seq;
            //        payDetail.DpRemark = "P/C AMOUNT THB";
            //        payDetail.DpExchRate = pExpc.exch_rate;
            //        _context.pPayDetails.Add(payDetail);
            //    }
            //}
            //else
            //{
            //    if (pExpc.principle_amt_thb2 > 0)
            //    {
            //        li_seq++;
            //        var payDetail = new pPayDetail();
            //        payDetail.DpReceiptNo = pExpc.received_no;
            //        payDetail.DpPayName = "";
            //        payDetail.DpPayAmt = pExpc.partial_amt_thb1;
            //        payDetail.DpSeq = li_seq;
            //        payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy1;
            //        payDetail.DpExchRate = pExpc.exch_rate1;
            //        payDetail.DpContract = pExpc.forward_contract1;
            //        _context.pPayDetails.Add(payDetail);
            //    }
            //    if (pExpc.partial_amt_thb2 > 0)
            //    {
            //        li_seq++;
            //        var payDetail = new pPayDetail();
            //        payDetail.DpReceiptNo = pExpc.received_no;
            //        payDetail.DpPayName = "";
            //        payDetail.DpPayAmt = pExpc.partial_amt_thb2;
            //        payDetail.DpSeq = li_seq;
            //        payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy2;
            //        payDetail.DpExchRate = pExpc.exch_rate2;
            //        payDetail.DpContract = pExpc.forward_contract2;
            //        _context.pPayDetails.Add(payDetail);
            //    }
            //    if (pExpc.partial_amt_thb3 > 0)
            //    {
            //        li_seq++;
            //        var payDetail = new pPayDetail();
            //        payDetail.DpReceiptNo = pExpc.received_no;
            //        payDetail.DpPayName = "";
            //        payDetail.DpPayAmt = pExpc.partial_amt_thb3;
            //        payDetail.DpSeq = li_seq;
            //        payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy3;
            //        payDetail.DpExchRate = pExpc.exch_rate3;
            //        payDetail.DpContract = pExpc.forward_contract3;
            //        _context.pPayDetails.Add(payDetail);
            //    }
            //    if (pExpc.partial_amt_thb4 > 0)
            //    {
            //        li_seq++;
            //        var payDetail = new pPayDetail();
            //        payDetail.DpReceiptNo = pExpc.received_no;
            //        payDetail.DpPayName = "";
            //        payDetail.DpPayAmt = pExpc.partial_amt_thb4;
            //        payDetail.DpSeq = li_seq;
            //        payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy4;
            //        payDetail.DpExchRate = pExpc.exch_rate4;
            //        payDetail.DpContract = pExpc.forward_contract4;
            //        _context.pPayDetails.Add(payDetail);
            //    }
            //    if (pExpc.partial_amt_thb5 > 0)
            //    {
            //        li_seq++;
            //        var payDetail = new pPayDetail();
            //        payDetail.DpReceiptNo = pExpc.received_no;
            //        payDetail.DpPayName = "";
            //        payDetail.DpPayAmt = pExpc.partial_amt_thb5;
            //        payDetail.DpSeq = li_seq;
            //        payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy5;
            //        payDetail.DpExchRate = pExpc.exch_rate5;
            //        payDetail.DpContract = pExpc.forward_contract5;
            //        _context.pPayDetails.Add(payDetail);
            //    }
            //    if (pExpc.partial_amt_thb6 > 0)
            //    {
            //        li_seq++;
            //        var payDetail = new pPayDetail();
            //        payDetail.DpReceiptNo = pExpc.received_no;
            //        payDetail.DpPayName = "";
            //        payDetail.DpPayAmt = pExpc.partial_amt_thb6;
            //        payDetail.DpSeq = li_seq;
            //        payDetail.DpRemark = "P/C AMOUNT THB " + pExpc.partial_amt_ccy6;
            //        payDetail.DpExchRate = pExpc.exch_rate6;
            //        payDetail.DpContract = pExpc.forward_contract6;
            //        _context.pPayDetails.Add(payDetail);
            //    }
            //}
            //if (pExpc.duty_stamp > 0 || pExpc.Comm_Certi > 0 || pExpc.comm_other > 0 || pExpc.comm_OnTT > 0)
            //{
            //    li_seq++;
            //    var payDetail = new pPayDetail();
            //    payDetail.DpReceiptNo = pExpc.received_no;
            //    payDetail.DpPayName = "";
            //    payDetail.DpPayAmt = 0;
            //    payDetail.DpSeq = li_seq;
            //    payDetail.DpRemark = "LESS";
            //    _context.pPayDetails.Add(payDetail);
            //}
            //if (pExpc.duty_stamp > 0)
            //{
            //    li_seq++;
            //    var payDetail = new pPayDetail();
            //    payDetail.DpReceiptNo = pExpc.received_no;
            //    payDetail.DpPayName = "  DUTY STAMP";
            //    payDetail.DpPayAmt = pExpc.duty_stamp;
            //    payDetail.DpSeq = li_seq;
            //    _context.pPayDetails.Add(payDetail);
            //}
            //if (pExpc.Comm_Certi > 0)
            //{
            //    li_seq++;
            //    var payDetail = new pPayDetail();
            //    payDetail.DpReceiptNo = pExpc.received_no;
            //    payDetail.DpPayName = "  COMM. CERTIFY CHEQUE";
            //    payDetail.DpPayAmt = pExpc.Comm_Certi;
            //    payDetail.DpSeq = li_seq;
            //    _context.pPayDetails.Add(payDetail);
            //}
            //if (pExpc.comm_other > 0)
            //{
            //    li_seq++;
            //    var payDetail = new pPayDetail();
            //    payDetail.DpReceiptNo = pExpc.received_no;
            //    payDetail.DpPayName = "  COMM. OTHER";
            //    payDetail.DpPayAmt = pExpc.comm_other;
            //    payDetail.DpSeq = li_seq;
            //    _context.pPayDetails.Add(payDetail);
            //}
            //if (pExpc.comm_OnTT > 0)
            //{
            //    li_seq++;
            //    var payDetail = new pPayDetail();
            //    payDetail.DpReceiptNo = pExpc.received_no;
            //    payDetail.DpPayName = "COMM. ON T/T DOMESTIC";
            //    payDetail.DpPayAmt = pExpc.comm_OnTT;
            //    payDetail.DpSeq = li_seq;
            //    _context.pPayDetails.Add(payDetail);
            //}
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
