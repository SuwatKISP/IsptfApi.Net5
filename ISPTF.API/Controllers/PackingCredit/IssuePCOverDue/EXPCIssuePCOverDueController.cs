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
    public class EXPCIssuePCOverDueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "8";
        private const string EVENT_TYPE = "Overdue";
        public IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;

        public EXPCIssuePCOverDueController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IssuePCOverDueListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            IssuePCOverDueListPageResponse response = new IssuePCOverDueListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_IssuePCOverDueListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IssuePCOverDueListPageRsp>();
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

                var results = await _db.LoadData<Q_IssuePCOverDueListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_PackingOverDueListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IssuePCOverDueListPageRsp>)results;

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
                response.Data = new List<Q_IssuePCOverDueListPageRsp>();
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
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET  rec_status = 'P' WHERE PACKING_NO = '{pExpcMaster.PACKING_NO}' AND record_type = 'MASTER'");
                        _context.SaveChanges();
                        // 2 - Save Event
                        var pExpcEvent = (from row in _context.pExpcs
                                          where row.PACKING_NO == pExpc.PACKING_NO &&
                                                row.record_type == "EVENT" &&
                                                row.event_no == event_no
                                          select row).AsNoTracking().FirstOrDefault();

                        if (pExpcEvent == null)
                        {
                            //    pExpcEvent = new pExpc();
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

                        pExpc.principle_amt_thb1 = pExpcMaster.principle_amt_thb1;
                        pExpc.principle_amt_ccy1 = pExpcMaster.principle_amt_ccy1;
                        pExpc.PayNo = pExpcMaster.PayNo;
                        //pExpc.LastIntDate = pExpc.LastIntDate;
                        //pExpc.AutoOverdue = pExpc.AutoOverdue;
                        pExpc.PCOverdue = "N";
                        //pExpc.principle_amt_ccy2 = pExpc.principle_amt_ccy2;
                        //pExpc.principle_amt_thb2 = pExpc.principle_amt_thb2;
                        //pExpc.total_bal_thb = pExpc.total_bal_thb;
                        //pExpc.interest_ccy1 = pExpc.interest_ccy1;
                        //pExpc.interest_thb1 = pExpc.interest_thb1;
                        //pExpc.interest_ccy2 = pExpc.interest_ccy2;
                        //pExpc.interest_thb2 = pExpc.interest_thb2;
                        pExpc.pay_instruc = "2";
                        pExpc.received_no = "";
                        //pExpc.OINTCODE = pExpc.OINTCODE;
                        //pExpc.OINTDAY = pExpc.OINTDAY;
                        //pExpc.OINTRATE = pExpc.OINTRATE;
                        //pExpc.OINTSPDRATE = pExpc.OINTSPDRATE;
                        //pExpc.OINTCURRATE = pExpc.OINTCURRATE;
                        //pExpc.OBASEDAY = pExpc.OBASEDAY;
                        //pExpc.exch_rate2 = pExpc.exch_rate2;
                        //pExpc.exch_rate3 = pExpc.exch_rate3;
                        //pExpc.remark = pExpc.remark;
                        //pExpc.CalIntDate = pExpc.CalIntDate;
                        //pExpc.IntFlag = pExpc.IntFlag;
                        //pExpc.VALUE_DATE = pExpc.VALUE_DATE;
                        //pExpc.PCProfit = pExpc.PCProfit;
                        //pExpc.MidRate = pExpc.MidRate;
                        pExpc.in_Use = "0";
                        _context.pExpcs.Update(pExpc);

                        // Commit
                        _context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Packing Credit Saved";
                        response.Data = new();
                        response.Data.PEXPC = pExpc;// pExpcEvent;
                        response.Data.PPAYMENT = pexpcppaymentrequest.pPayment;


                        bool resGL;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = response.Data.PEXPC.event_type;
                        eventDate = response.Data.PEXPC.event_date.Value.ToString("dd/MM/yyyy",engDateFormat);
   
                    resVoucherID = ISPModule.GeneratrEXP.StartPEXPC(response.Data.PEXPC.PACKING_NO,
                        eventDate, GLEvent, response.Data.PEXPC.event_no, GLEvent,false,"U");

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

                        _context.Database.ExecuteSqlRaw($"DELETE pDailyGL WHERE VouchID = '{pExpcEvent.vouch_id}' AND VouchDate = '{pExpcEvent.LastIntDate}'");
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET rec_status = 'R' WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND rec_status = 'P' AND record_type = 'MASTER'");
                        _context.Database.ExecuteSqlRaw($"DELETE pExpc WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND rec_status = 'P' AND record_type = 'EVENT' AND event_type = '{EVENT_TYPE}' AND business_type = '{BUSINESS_TYPE}'");
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
                                                row.event_no == event_no
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExpcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PACKING_NO does not exist.";
                            return BadRequest(response);
                        }


                   //     pExpcMaster.event_no = event_no;
                        pExpcMaster.rec_status = "R";
                        pExpcMaster.event_type = EVENT_TYPE;
                        pExpcMaster.business_type = BUSINESS_TYPE;
                        pExpcMaster.event_mode = "E";
                        pExpcMaster.update_date = UpdateDateT;
                        pExpcMaster.auth_code = USER_ID;
                        pExpcMaster.auth_date = UpdateDateT;
                        pExpcMaster.vouch_id = pExpcEvent.vouch_id;
                        pExpcMaster.genacc_flag = "Y";
                        pExpcMaster.genacc_date = UpdateDateNT;
                        //pExpcMaster.pc_int_rate = pExpcEvent.pc_int_rate;
                        //pExpcMaster.spread_rate = pExpcEvent.spread_rate;
                        //pExpcMaster.current_intrate = pExpcEvent.current_intrate;


                        pExpcMaster.OINTCODE = pExpcEvent.OINTCODE;
                        pExpcMaster.OINTDAY = pExpcEvent.OINTDAY;
                        pExpcMaster.OBASEDAY = pExpcEvent.OBASEDAY;
                        pExpcMaster.OINTRATE = pExpcEvent.current_intrate;
                        pExpcMaster.OINTSPDRATE = pExpcEvent.OINTRATE;
                        pExpcMaster.OINTCURRATE = pExpcEvent.OINTCURRATE;
                        pExpcMaster.exch_rate2 = pExpcEvent.exch_rate2;
                        pExpcMaster.exch_rate3 = pExpcEvent.exch_rate3;
                        pExpcMaster.AutoOverdue = pExpcEvent.AutoOverdue;

                        pExpcMaster.PCOverdue = "Y";
                        pExpcMaster.doc_ccy = "THB";
                        pExpcMaster.packing_for = "T";
                        pExpcMaster.LastIntDate = pExpcEvent.LastPayDate;
                        pExpcMaster.PCPastDue = "O";
                        pExpcMaster.pack_ccy = 0;
                        pExpcMaster.pack_thb = pExpcEvent.principle_amt_thb2;
                      //  'AMOUNT
                        pExpcMaster.principle_amt_thb1 = pExpcEvent.principle_amt_thb2;
                        pExpcMaster.interest_thb1 = pExpcEvent.interest_thb2;
                        pExpcMaster.total_bal_thb = pExpcEvent.principle_amt_thb2;
                        pExpcMaster.LastIntAmt = pExpcEvent.interest_thb2;
                        if (pExpcEvent.packing_for=="O")
                        {
                            pExpcMaster.principle_amt_ccy1 = pExpcEvent.principle_amt_ccy2;
                            pExpcMaster.interest_ccy1 = pExpcEvent.interest_ccy2;
                            if  (pExpcMaster.principle_amt_ccy1 < 0)  pExpcMaster.principle_amt_ccy1 = 0;
                            if (pExpcMaster.interest_ccy1 < 0)  pExpcMaster.interest_ccy1 = 0;
                        }
                        else
                        {
                            if (pExpcMaster.principle_amt_thb1 < 0)  pExpcMaster.principle_amt_thb1 = 0;
                            if (pExpcMaster.interest_thb1 < 0)  pExpcMaster.interest_thb1 = 0;
                        }

                        pExpcMaster.LastPayDate = pExpcEvent.VALUE_DATE ;
                        pExpcMaster.received_no = "";
                        pExpcMaster.IntFlag = pExpcEvent.IntFlag;
                        pExpcMaster.VALUE_DATE = pExpcEvent.VALUE_DATE;
                        //             '----------------------- Cal Interest Date ---------------------------
                        string EndDate="";
                        var mControlDate = (from row in _context.mControlDates
                                          where row.ContFlag == "S"
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExpcEvent.PcIntType == "1")
                        {
                            EndDate = last_date(pExpcEvent.event_date.Value.ToString("dd/MM/yyyy"));

                            if (EndDate== pExpcEvent.VALUE_DATE.Value.ToString("dd/MM/yyyy") ||( pExpcEvent.VALUE_DATE.Value.ToString("dd/MM/yyyy").Substring(3, 2) != mControlDate.ContNextDate.Value.ToString("dd/MM/yyyy").Substring(3, 2)))
                                pExpcMaster.CalIntDate = pExpcEvent.VALUE_DATE;
                            else
                                pExpcMaster.CalIntDate = pExpcEvent.CalIntDate;
                        }
                        //  '------------------------- ACCRU------------------------------
                        pExpcMaster.AccruCcy = pExpcEvent.interest_thb2;
                        pExpcMaster.AccruAmt = pExpcEvent.interest_thb2;
                        pExpcMaster.AccruPending = pExpcEvent.interest_thb2;
                        pExpcMaster.DateStartAccru = pExpcEvent.VALUE_DATE;
                        pExpcMaster.DateToStop = pExpcEvent.VALUE_DATE;
                        pExpcMaster.PastDueDate = pExpcEvent.VALUE_DATE.Value.AddDays(89);
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET  rec_status= 'R', event_type = '{EVENT_TYPE}', auth_code = '{USER_ID}', auth_date = '{UpdateDateT}',event_no ={pExpcEvent.event_no} WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='MASTER'");
                        //Update Event
                        pExpcEvent.auth_code = USER_ID;
                        pExpcEvent.auth_date = UpdateDateT;
                        pExpcEvent.genacc_flag = "Y";
                        pExpcEvent.genacc_date = UpdateDateNT;
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET rec_status= 'R'  WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='EVENT' and Event_no ={pExpcEvent.event_no} ");

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

                        //  '------------- pExInterest

                        if (pExpcEvent.packing_for == "T")
                        {
                            if (pExpcEvent.interest_thb2 > 0)
                            {
                                var HistoryInt = HistInterest(_context, CenterID, USER_ID, pExpcEvent);
                            }
                        }
                        else
                        {
                            if (pExpcEvent.interest_ccy2 > 0)
                            {
                                var HistoryInt = HistInterest(_context, CenterID, USER_ID, pExpcEvent);
                            }
                        }
                        _context.SaveChanges();

                        //if (UpdateCustLiab(pExpcEvent, UpdateDateT))
                        //{
                        //    _context.SaveChanges();
                        //}

                        //// Commit
                        //_context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();
                        string eventDate;
                        string resCustLiab;
                        eventDate = pExpcEvent.event_date.Value.ToString("dd/MM/yyyy", engDateFormat);
                        resCustLiab = ISPModule.CustLiabEXPC.EXPC_Overdue(eventDate, "ISSUE", pExpcEvent.PACKING_NO, pExpcEvent.cust_id,
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

        private static string HistInterest(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, pExpc pc)
        {
            //  DateTime GetSysDate = ModDate.GetSystemDateTime();
            IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    int cSeqNo;
                    int maxSeq = 0;
                    var maxSeqRow = (from row in _context.pEXInterests
                                     where row.Login == "EXPC" &&
                                      row.DocNo == pc.PACKING_NO
                                     select row).ToList().OrderByDescending(x => x.Seqno);
                    foreach (var row in maxSeqRow)
                    {
                        maxSeq = row.Seqno;
                        break;
                    }
                    if (maxSeq == 0)
                    {
                        cSeqNo = 1;
                    }
                    else
                    {
                        cSeqNo = maxSeq + 1;
                    }
                    var pEXInterests = (from row in _context.pEXInterests
                                        where row.Login == "EXPC" &&
                                        row.DocNo == pc.PACKING_NO &&
                                        row.EventNo == pc.event_no &&
                                        row.Seqno == cSeqNo
                                        select row).AsNoTracking().FirstOrDefault();
                    pEXInterest exinterest = new pEXInterest();
                    if (pEXInterests == null)
                    {
                        //  cAddNew = True
                        exinterest.DocNo = pc.PACKING_NO;
                        exinterest.Login = "EXPC";
                        exinterest.Event = pc.event_type;
                        exinterest.EventNo = pc.event_no;
                    }

                    exinterest.CenterID = USER_CENTER_ID;
                    exinterest.Seqno = cSeqNo;
                    exinterest.CalDate = pc.event_date;
                    exinterest.IntTo = pc.VALUE_DATE;
                    if (pc.PcIntType == "0")
                    {
                        exinterest.IntDay = (pc.VALUE_DATE - pc.pc_start_date).Value.Days;
                        exinterest.IntFrom = pc.pc_start_date;
                    }
                    else if (pc.PcIntType == "1")
                    {
                        exinterest.IntTo = pc.VALUE_DATE;
                        exinterest.IntDay = (pc.VALUE_DATE - pc.CalIntDate).Value.Days;
                        exinterest.IntFrom = pc.CalIntDate;
                    }
                    exinterest.CurIntRate = pc.current_intrate;
                    exinterest.IntRate = pc.pc_int_rate;
                    exinterest.Spread = pc.spread_rate;
                    exinterest.IntAmt = pc.interest_thb2;
                    if (pc.packing_for == "T")
                    {
                        exinterest.BaseDay = 365;
                        if (pc.principle_amt_thb2 == 0)
                        {
                            exinterest.BalCcy = pc.principle_amt_thb1;
                        }
                        else
                        {
                            exinterest.BalCcy = pc.principle_amt_thb2;
                        }

                        exinterest.IntExchRate = 1;
                        exinterest.Ccy = "THB";
                        exinterest.IntCCy = pc.interest_thb2;
                    }
                    else
                    {
                        exinterest.BaseDay = 360;
                        if (pc.principle_amt_ccy2 == 0)
                        {
                            exinterest.BalCcy = pc.principle_amt_ccy1;
                        }
                        else
                        {
                            exinterest.BalCcy = pc.principle_amt_ccy2;
                        }

                        exinterest.IntExchRate = pc.exch_rate3;
                        exinterest.Ccy = pc.doc_ccy;
                        exinterest.IntCCy = pc.interest_ccy2;
                    }

                    if (pEXInterests == null)
                    {
                        _context.pEXInterests.Add(exinterest);
                    }
                    else
                    {
                        _context.pEXInterests.Update(exinterest);

                    }

                    _context.SaveChanges();

                    transaction.Complete();
                    return "OK";

                }
                catch (Exception e)
                {
                    // Rollback
                    return "ERROR";
                }

            }
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
            pPayment.UpdateDate = UpdateDateT;

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

        private bool UpdateCustLiab(pExpc pExpcEvent, DateTime UpdateDateT)
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
                    pCustLiab.UpdateDate = UpdateDateT;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        private  string last_date(string mytext)
        {
            string result="";
            string mday, dday, eyear;
            // 'must be pass function chk_date ready
            // 'find last day in month format mytext = "dd/mm/yyyy"

            eyear = mytext.Substring(6, 4);
            mday = mytext.Substring(3, 2);
            dday = mytext.Substring(0, 2);

            switch (mday)
            {
                case "01": case "03": case "05":
                case "07": case "08": case "10": case "12":

                    result = "31/" + mday + "/" + eyear;
                    break;
                case "02":
                    if (Convert.ToInt16(eyear) % 4 == 0)
                    {
                        result = "29/" + mday + "/" + eyear;
                    }
                    else
                    { 
                        result = "28/" + mday + "/" + eyear;

                    }
                    // co02de block
                    break;
                case "04":case "06":case "09":case "11":
                    result = "30/" + mday + "/" + eyear;
                    break;
                default:
                    // code block
                    break;
            }

            return result;
        }









    }
}
