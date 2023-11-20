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
    public class EXPCEditFlagController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "7";
        private const string EVENT_TYPE = "Edit/Flag";

        public EXPCEditFlagController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EditFlagListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            EditFlagListPageResponse response = new EditFlagListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EditFlagListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EditFlagListPageRsp>();
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

                var results = await _db.LoadData<Q_EditFlagListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_EditFlagListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EditFlagListPageRsp>)results;

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
                response.Data = new List<Q_EditFlagListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        public ActionResult<PEXPCPPaymentResponse> Select(string? PACKING_NO, string record_type, string rec_status, int event_no)
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
                var targetEventNo = 0;
                var pExpcMaster = (from row in _context.pExpcs
                                   where row.PACKING_NO == PACKING_NO &&
                                           row.record_type == "MASTER"
                                   select row).AsNoTracking().FirstOrDefault();
                if (record_type == "MASTER")
                {
                    var pExpc = pExpcMaster;
                    response.Code = Constants.RESPONSE_OK;
                    response.Data.PEXPC = pExpc;
                    response.Data.PPAYMENT = null;
                    return Ok(response);
                }
                else
                {
                    if (rec_status == "P")
                    {
                        if (pExpcMaster != null)
                        {
                            targetEventNo = pExpcMaster.event_no + 1;
                        }

                    }
                    else
                    {
                        targetEventNo = event_no;
                    }
                    var pExpc = (from row in _context.pExpcs
                                 where row.PACKING_NO == PACKING_NO &&
                                     row.event_type == EVENT_TYPE &&
                                     row.event_no == targetEventNo &&
                                     row.record_type == record_type &&
                                     (row.rec_status == rec_status)
                                 select row).AsNoTracking().FirstOrDefault();
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

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new();
            }
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
                        pExpc.CenterID = CenterID;
                        pExpc.user_id = user_id;
                        pExpc.update_date = UpdateDateT;
                        // End Default

                        pExpc.event_mode = "E";
                        pExpc.pay_instruc = "2";
                        pExpc.vouch_id = "";
                        pExpc.received_no = "";
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











    }
}
