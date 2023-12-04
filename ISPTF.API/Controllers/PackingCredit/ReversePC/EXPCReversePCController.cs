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
    public class EXPCReversePCController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "11";
        private const string EVENT_TYPE = "Reverse";
        public IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
        public EXPCReversePCController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ReversePCListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            ReversePCListPageResponse response = new ReversePCListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_ReversePCListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_ReversePCListPageRsp>();
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

                var results = await _db.LoadData<Q_ReversePCListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_ReversePackingCreditListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_ReversePCListPageRsp>)results;

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
                response.Data = new List<Q_ReversePCListPageRsp>();
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
                   // pExpc = pExpcMaster;
                    pExpc = (from row in _context.pExpcs
                             where row.PACKING_NO == PACKING_NO &&
                                 row.event_type == "ISSUE" &&
                                 row.record_type == "EVENT" 
                             select row).AsNoTracking().FirstOrDefault();
                }

                if (pExpc == null)
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "record not Found !";
                    response.Data = new();
                }
                if (pExpc.pay_instruc != "2")
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
                            pExpc.vouch_id = "";
                            pExpc.received_no = "";
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
                        pExpc.principle_amt_ccy1 = pExpcMaster.principle_amt_ccy1;
                        pExpc.PayNo = pExpcMaster.PayNo;

                        pExpc.PCOverdue = "N";
                        pExpc.in_Use = "0";
                        if (pExpc.pay_instruc == "1")
                        {
                            pExpc.method = pExpc.method;
                            if (pExpc.received_no == "" || pExpc.received_no == null)
                            {
                                pExpc.received_no = ExportLCHelper.GenRefNo(_context, CenterID, user_id, "PAYD", UpdateDateT, UpdateDateNT);
                                SavePayment(pExpc, pexpcppaymentrequest.pPayment, UpdateDateT);
                            }
                        }
                        else if (pExpc.pay_instruc == "2")
                        {
                            pExpc.method = "";
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayment WHERE rpReceiptNo = '{pExpc.received_no}'");
                            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE dpReceiptNo = '{pExpc.received_no}'");
                        }
                        else if (pExpc.pay_instruc == "3")
                        {
                            if (pExpc.received_no == "" || pExpc.received_no == null)
                            {
                                pExpc.received_no = EXHelper.GenRefNo(_context, "PAYD", user_id, CenterID);
                                pExpc.AcBahtnet = pExpc.AcBahtnet;
                                pExpc.BahtNet = pExpc.BahtNet;
                            }
                        }

                        _context.pExpcs.Update(pExpc);

                        // Commit
                        _context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Packing Credit Saved";
                        response.Data = new();
                        response.Data.PEXPC = pExpc;// pExpcEvent;
                        var pPaymentEvent = (from row in _context.pPayments
                                             where row.RpReceiptNo == pExpc.received_no
                                             select row).AsNoTracking().FirstOrDefault();

                        response.Data.PPAYMENT = pPaymentEvent;


                        bool resGL;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = response.Data.PEXPC.event_type;
                        eventDate = response.Data.PEXPC.event_date.Value.ToString("dd/MM/yyyy", engDateFormat);

                        resVoucherID = ISPModule.GeneratrEXP.StartPEXPC(response.Data.PEXPC.PACKING_NO,
                            eventDate, GLEvent, response.Data.PEXPC.event_no, GLEvent, false, "U");

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

                        if (pExpcEvent.received_no != "")
                        {
                            _context.Database.ExecuteSqlRaw($"UPDATE pPayment SET RpStatus = 'C' WHERE RpReceiptNo = '{pExpcEvent.received_no}'");
                        }
                        _context.Database.ExecuteSqlRaw($"DELETE pPayDetail WHERE DpReceiptNo = '{pExpcEvent.received_no}'");
                        _context.Database.ExecuteSqlRaw($"DELETE pDailyGL WHERE TranDocNo = '{pExpcEvent.PACKING_NO}' AND VouchDate = '{pExpcEvent.LastIntDate}'");
                        _context.Database.ExecuteSqlRaw($"Update pExpc SET REC_STATUS ='T' WHERE RECORD_TYPE ='EVENT' and PACKING_NO = '{pExpcEvent.PACKING_NO}' AND EventNo ={pExpcEvent.event_no} and EVENT_TYPE ='{EVENT_TYPE}' and BUSINESS_TYPE ='{BUSINESS_TYPE}' ");
                        _context.Database.ExecuteSqlRaw($"Update pExpc SET REC_STATUS ='R',in_use ='0', EventNo ={pExpcEvent.event_no}  WHERE RECORD_TYPE ='MASTER' ");

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
        private void SavePayment(pExpc pExpcMaster, pPayment pPaymentReq, DateTime UpdateDateT)
        {
            var pPayment = (from row in _context.pPayments
                            where row.RpReceiptNo == pExpcMaster.received_no
                            select row).AsNoTracking().FirstOrDefault();
            if (pPayment == null)
            {
                pPayment = new();
                pPayment.RpReceiptNo = pExpcMaster.received_no;
                pPayment.RpDocNo = pExpcMaster.PACKING_NO;
                pPayment.RpEvent = pExpcMaster.event_no.ToString();
                _context.pPayments.Add(pPayment);
            }
            pPayment.RpPayBy = pPaymentReq.RpPayBy;
            pPayment.RpEvent = "1";
            pPayment.RpModule = "EXPC";
            pPayment.RpPayDate = pExpcMaster.event_date;
            pPayment.RpNote = "";
            pPayment.RpCustCode = pExpcMaster.cust_id;
            if (pPaymentReq.RpApplicant == null)
            {
                pPayment.RpApplicant = "";
            }
            else
            {
                pPayment.RpApplicant = pPaymentReq.RpApplicant.ToUpper();
            }

            if (pPaymentReq.RpChqNo == null)
            {
                pPayment.RpChqNo = "";
            }
            else
            {
                pPayment.RpChqNo = pPaymentReq.RpChqNo.ToUpper();
            }

            if (pPaymentReq.RpChqBank == null)
            {
                pPayment.RpChqBank = "";
            }
            else
            {
                pPayment.RpChqBank = pPaymentReq.RpChqBank.ToUpper();
            }


            if (pPaymentReq.RpChqBranch == null)
            {
                pPayment.RpChqBranch = "";
            }
            else
            {
                pPayment.RpChqBranch = pPaymentReq.RpChqBranch.ToUpper();
            }


            if (pPaymentReq.RpCustAc1 == null)
            {
                pPayment.RpCustAc1 = "";
            }
            else
            {
                pPayment.RpCustAc1 = pPaymentReq.RpCustAc1;
            }

            if (pPaymentReq.RpCustAc2 == null)
            {
                pPayment.RpCustAc2 = "";
            }
            else
            {
                pPayment.RpCustAc2 = pPaymentReq.RpCustAc2;
            }

            if (pPaymentReq.RpCustAc3 == null)
            {
                pPayment.RpCustAc3 = "";
            }
            else
            {
                pPayment.RpCustAc3 = pPaymentReq.RpCustAc3;
            }
            pPayment.RpCustAmt1 = pPaymentReq.RpCustAmt1;
            pPayment.RpCustAmt2 = pPaymentReq.RpCustAmt2;
            pPayment.RpCustAmt3 = pPaymentReq.RpCustAmt3;
            pPayment.RpRefer1 = "";
            pPayment.RpRefer2 = "";
            pPayment.RpIssBank = "";
            pPayment.RpStatus = "A";
            pPayment.RpRecStatus = pExpcMaster.rec_status;
            pPayment.UserCode = pExpcMaster.user_id;
            pPayment.UpdateDate = UpdateDateT;

            _context.Database.ExecuteSqlRaw($"DELETE FROM pPayDetail WHERE DpReceiptNo = '{pExpcMaster.received_no}'");

            int li_seq = 0;
            if (pExpcMaster.partial_full_rate == "0")
            {
                li_seq++;
                if (pExpcMaster.packing_for == "T")
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
                if (pExpcMaster.partial_amt_thb1 > 0)
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
                        pExpcMaster.user_id = USER_ID;
                        pExpcMaster.event_type = EVENT_TYPE;
                        pExpcMaster.event_mode = "E";
                        pExpcMaster.update_date = UpdateDateT;
                        pExpcMaster.auth_code = USER_ID;
                        pExpcMaster.auth_date = UpdateDateT;


                        _context.SaveChanges();
                        _context.Database.ExecuteSqlRaw($"UPDATE pExpc SET  rec_status= 'C', event_type = '{EVENT_TYPE}', auth_code = '{USER_ID}', auth_date = '{UpdateDateT}',event_no ={pExpcEvent.event_no} WHERE PACKING_NO = '{pExpcEvent.PACKING_NO}' AND record_type ='MASTER'");
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

                        string eventDate;
                        string resCustLiab;
                        eventDate = pExpcEvent.event_date.Value.ToString("dd/MM/yyyy");
                        resCustLiab = ISPModule.CustLiabEXPC.EXPC_ReverseISS(eventDate, "ISSUE", pExpcEvent.PACKING_NO,
                        pExpcEvent.cust_id, pExpcEvent.doc_ccy,
                        pExpcEvent.pack_ccy.ToString(),pExpcEvent.pack_thb.ToString(),
                        pExpcEvent.packing_for);
                        if (resCustLiab != "ERROR")
                        {
                            return Ok(response);
                        }
                        else
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export L/C Error for Update Liability";
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




    }
}
