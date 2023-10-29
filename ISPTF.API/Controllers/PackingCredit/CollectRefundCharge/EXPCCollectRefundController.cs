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
    public class EXPCCollectRefundController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "6";
        private const string EVENT_TYPE = "Collect/Refund";
        public IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
        public EXPCCollectRefundController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<CollectRefundChargeListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            CollectRefundChargeListPageResponse response = new CollectRefundChargeListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_CollectRefundChargeListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_CollectRefundChargeListPageRsp>();
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

                var results = await _db.LoadData<Q_CollectRefundChargeListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_CollectRefundChargesListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_CollectRefundChargeListPageRsp>)results;

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
                response.Data = new List<Q_CollectRefundChargeListPageRsp>();
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

                      //  pExpc pExpcEvent = pexpcppaymentrequest.pExpc;

                        if (pExpcEvent == null)
                        {
                            //   pExpcEvent = new pExpc();
                            pExpc.PACKING_NO = pExpcMaster.PACKING_NO;
                            pExpc.record_type = "EVENT";
                            pExpc.event_no = event_no;
                            _context.pExpcs.Add(pExpc);
                            _context.SaveChanges();

                        }
                        // start Default
                        pExpc.PACKING_NO = pExpcMaster.PACKING_NO;
                        pExpc.record_type = "EVENT";
                        pExpc.event_no = event_no;
                        pExpc.event_mode = pExpcMaster.event_mode;
                        pExpc.rec_status = "P";
                        pExpc.event_type = EVENT_TYPE;
                        pExpc.event_date = pExpc.event_date;
                        pExpc.business_type = BUSINESS_TYPE;
                        pExpc.cust_id = pExpcMaster.cust_id;
                        pExpc.cust_info = pExpcMaster.cust_info;
                        pExpc.cnty_code = pExpcMaster.cnty_code;
                        pExpc.applicant_name = pExpcMaster.applicant_name;
                        pExpc.good_code = pExpcMaster.good_code;
                        pExpc.Rel_code = pExpcMaster.Rel_code;
                        pExpc.shipmentFr = pExpcMaster.shipmentFr;
                        pExpc.shipmentTo = pExpcMaster.shipmentTo;
                        pExpc.principle_amt_thb5 = pExpcMaster.principle_amt_thb5;
                        pExpc.good_desc = pExpcMaster.good_desc;
                        pExpc.packing_for = pExpcMaster.packing_for;
                        pExpc.pack_under = pExpcMaster.pack_under;
                        pExpc.refer_lcno = pExpcMaster.refer_lcno;
                        pExpc.doc_ccy = pExpcMaster.doc_ccy;
                        pExpc.doc_amount = pExpcMaster.doc_amount;
                        pExpc.rate = pExpcMaster.rate;
                        pExpc.pack_ccy = pExpcMaster.pack_ccy;
                        pExpc.pack_thb = pExpcMaster.pack_thb;
                        pExpc.pn_no = pExpcMaster.pn_no;
                        pExpc.new_pn_no = pExpcMaster.new_pn_no;
                        pExpc.PackNote = pExpcMaster.PackNote;
                        pExpc.doc_expiry_date = pExpcMaster.doc_expiry_date;
                        pExpc.pc_start_date = pExpcMaster.pc_start_date;
                        pExpc.current_pc_due = pExpcMaster.current_pc_due;
                        pExpc.tot_pc_day = pExpcMaster.tot_pc_day;
                        pExpc.current_60_daydue = pExpcMaster.current_60_daydue;
                        pExpc.IntRateCode = pExpcMaster.IntRateCode;
                        pExpc.IntBaseDay = pExpcMaster.IntBaseDay;
                        pExpc.pc_int_rate = pExpcMaster.pc_int_rate;
                        pExpc.spread_rate = pExpcMaster.spread_rate;
                        pExpc.current_intrate = pExpcMaster.current_intrate;
                        pExpc.CFRRate = pExpcMaster.CFRRate;
                        pExpc.PcIntType = pExpcMaster.PcIntType;
                        pExpc.FixDate = pExpcMaster.FixDate;
                        pExpc.Due_no = pExpcMaster.Due_no;
                        pExpc.PayNo = pExpcMaster.PayNo;
                        pExpc.total_date = pExpcMaster.total_date;
                        pExpc.ValueDate = pExpcMaster.ValueDate;
                        pExpc.prev_contra_bal = pExpcMaster.prev_contra_bal;
                        pExpc.contra_bal = pExpcMaster.contra_bal;
                        pExpc.principle_amt_thb1 = pExpcMaster.principle_amt_thb1;
                        pExpc.principle_amt_ccy1 = pExpcMaster.principle_amt_ccy1;
                        pExpc.PurposeCode = pExpcMaster.PurposeCode;
                        // End Default
                        pExpc.CenterID = CenterID;
                        pExpc.user_id = user_id;
                        pExpc.update_date = UpdateDateT;
                        pExpc.genacc_flag = "Y";
                        pExpc.in_Use = "0";

                        if (pExpc.pay_instruc == "1")
                        {
                            if (pExpc.received_no!="" && pExpc.received_no!=null)
                            {
                                if (pExpc.pay_method == "C")
                                {
                                    if (!pExpc.received_no.Contains("DCR"))
                                    {
                                        pExpc.received_no = "";
                                    }
                                }
                                else
                                {
                                    if (!pExpc.received_no.Contains("DDR"))
                                    {
                                        pExpc.received_no = "";
                                    }
                                }
                            }
                            if (pExpc.received_no == "" || pExpc.received_no == null)
                            {
                                if (pExpc.pay_method == "D")
                                {
                                    pExpc.received_no = ExportLCHelper.GenRefNo(_context, CenterID, user_id, "PAYD", UpdateDateT, UpdateDateNT);

                                }
                                else
                                {
                                    pExpc.received_no = ExportLCHelper.GenRefNo(_context, CenterID, user_id, "PAYC", UpdateDateT, UpdateDateNT);
                                }
                            }
                           
                            SavePayment(pExpc, pexpcppaymentrequest.pPayment, UpdateDateT);
                        }
                        else
                        {
                            pExpc.method = "";
                            pExpc.vouch_id = "";
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayment WHERE RpReceiptNo = '{pExpc.received_no}'");
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE DpReceiptNo = '{pExpc.received_no}'");
                            pExpc.received_no = "";
                        }
                        _context.pExpcs.Update(pExpc);

                        // Commit
                        _context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Packing Credit Saved";
                        response.Data = new();
                        response.Data.PEXPC = pExpc;//pexpcppaymentrequest.pExpc;
                        var pPaymentEvent = (from row in _context.pPayments
                                             where row.RpReceiptNo == pExpc.received_no
                                             select row).AsNoTracking().FirstOrDefault();

                        response.Data.PPAYMENT = pPaymentEvent;// pexpcppaymentrequest.pPayment;


                        bool resGL=false;
                        bool resPayD;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = response.Data.PEXPC.event_type;
                        eventDate = response.Data.PEXPC.event_date.Value.ToString("dd/MM/yyyy", engDateFormat);
                        if (pExpc.pay_instruc == "1")
                        {
                            if (pExpc.pay_method == "D")
                            {
                                resVoucherID = ISPModule.GeneratrEXP.StartPEXPC(response.Data.PEXPC.PACKING_NO,
                                eventDate, GLEvent, response.Data.PEXPC.event_no, "COLLECT");
                            }
                            else
                            {
                                resVoucherID = ISPModule.GeneratrEXP.StartPEXPC(response.Data.PEXPC.PACKING_NO,
                                eventDate, GLEvent, response.Data.PEXPC.event_no, "REFUND");
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
                        }
  

                        string resPayDetail;
                        if (response.Data.PPAYMENT != null)
                        {
                            resPayDetail = ISPModule.PayDetailEXPC.PayDetail_OtherCharge(response.Data.PEXPC.PACKING_NO, response.Data.PEXPC.event_no, response.Data.PEXPC.received_no);
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
                                                row.event_no == event_no
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExpcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PACKING_NO does not exist.";
                            return BadRequest(response);
                        }
                        //UPDATE MASTER
                        pExpcMaster.rec_status = "R";
                        pExpcMaster.user_id = USER_ID;
                        pExpcMaster.event_type = EVENT_TYPE;
                        pExpcMaster.business_type =BUSINESS_TYPE;
                        pExpcMaster.event_mode = "E";
                        pExpcMaster.update_date = UpdateDateT;
                        pExpcMaster.auth_code = USER_ID;
                        pExpcMaster.auth_date = UpdateDateT;
                        pExpcMaster.vouch_id = pExpcEvent.vouch_id;
                        pExpcMaster.genacc_flag = "Y";
                        pExpcMaster.genacc_date = UpdateDateT;
                        pExpcMaster.method = pExpcEvent.method;
                        pExpcMaster.pay_instruc = pExpcEvent.pay_instruc;
                        pExpcMaster.TaxRefund = pExpcEvent.TaxRefund;
                        pExpcMaster.Com_Lieu = pExpcEvent.Com_Lieu;
                        pExpcMaster.duty_stamp = pExpcEvent.duty_stamp;
                        pExpcMaster.comm_OnTT = pExpcEvent.comm_OnTT;
                        pExpcMaster.comm_other = pExpcEvent.comm_other;
                        pExpcMaster.Comm_Certi = pExpcEvent.Comm_Certi;
                        pExpcMaster.IntReceived = pExpcEvent.IntReceived;
                        pExpcMaster.FrontFee = pExpcEvent.FrontFee;
                        pExpcMaster.total_charge = pExpcEvent.total_charge;
                        pExpcMaster.total_credit_ac = pExpcEvent.total_credit_ac;
                        pExpcMaster.refund_tax_amt = pExpcEvent.refund_tax_amt;
                        pExpcMaster.total_amount = pExpcEvent.total_amount;
                        pExpcMaster.received_no = pExpcEvent.received_no;
                        pExpcMaster.remark = pExpcEvent.remark;

                        _context.SaveChanges();
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET  rec_status= 'R', event_type = '{EVENT_TYPE}', auth_code = '{USER_ID}', auth_date = '{UpdateDateT}',event_no ={pExpcEvent.event_no} WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='MASTER'");
                        //Update EVENT
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


                        // Commit
                        transaction.Complete();
                        transaction.Dispose();
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
            else if (pPaymentReq.RpChqAmt > 0) // 'cheque
            {
                pPayment.RpPayBy = "3";
            }
            else
            {
                pPayment.RpPayBy = "1";
            }
            if (pExpc.BahtNet > 0)//baht
            {
                pPayment.RpPayBy = "4";
            }
            if (pExpc.FcdAmt > 0)//fcd
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

        }







    }
}
