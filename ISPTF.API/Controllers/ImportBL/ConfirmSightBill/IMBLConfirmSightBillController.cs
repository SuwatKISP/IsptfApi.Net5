using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ImportBL;
using ISPTF.Models.PPayment;
using ISPTF.Models.LoginRegis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ISPTF.Models.ImportBC;

namespace ISPTF.API.Controllers.ImportBL
{
    [ApiController]
    [Route("api/[controller]")]
    public class IMBLConfirmSightBillController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMBLConfirmSightBillController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        public async Task<IEnumerable<PIMBLListRsp>> GetAll(string ListType, string CenterID, string BLNumber, string CustCode, string CustName, string UserCode, string Page, string PageSize)
        {
            DynamicParameters param = new();

            //param.Add("@SupType", SupType);
            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@BLNumber", BLNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@UserCode", UserCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BLNumber == null)
            {
                param.Add("@BLNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }
            var results = await _db.LoadData<PIMBLListRsp, dynamic>(
                storedProcedure: "usp_q_IMBL_ConfirmSightBillsListPage",
            param);
            return results;
        }

        [HttpGet("select")]
        public async Task<ActionResult<PIMBLPPaymentRsp>> GetAllSelect(string ADNumber, string BLSeqno, string RecType, string EVENT, string RecStatus)
        {
            DynamicParameters param = new();

            param.Add("@ADNumber", ADNumber);
            param.Add("@BLSeqno", BLSeqno);
            param.Add("@RecType", RecType);
            param.Add("@EVENT", EVENT);
            param.Add("@RecStatus", RecStatus);

            param.Add("@PIMBLRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBLPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<PIMBLPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pIMBL_ConfirmSight_Select",
                           param);

                var PIMBLRsp = param.Get<dynamic>("@PIMBLRsp");
                var PIMBLPPaymentRsp = param.Get<dynamic>("@PIMBLPPaymentRsp");

                if (PIMBLRsp > 0)
                {
                    return Ok(PIMBLPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "IMPORT B/L NO Bill does not exit";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("release")]
        public async Task<ActionResult<List<PIMBLPPaymentRsp>>> GetAllRelease([FromBody] PIMBLReleaseReq pimbcrsp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BCNumber", pimbcrsp.BLNumber);
            param.Add("@RecType", pimbcrsp.RecType);
            param.Add("@BCSeqno", pimbcrsp.BLSeqno);
            param.Add("@Event", pimbcrsp.Event);
            param.Add("@AuthCode", pimbcrsp.AuthCode);


            param.Add("@PIMBLRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBLPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PIMBCPPaymentRsp, dynamic>(
                    storedProcedure: "usp_pIMBL_ConfirmSight_Release",
                    param);
                var PIMBCRsp = param.Get<dynamic>("@PIMBLRsp");
                var PIMBCPPaymentRsp = param.Get<dynamic>("@PIMBLPPaymentRsp");
                var resp = param.Get<int>("@Resp");

                if (PIMBCRsp == 1)
                {
                    return Ok(PIMBCPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "BL Number not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<List<PIMBLPPaymentRsp>>> Update([FromBody] PIMBLPPaymentRsp pimblcrsp)
        {
            DynamicParameters param = new DynamicParameters();
            //PIMBL
            param.Add("@ADNumber", pimblcrsp.PIMBL.ADNumber);
            param.Add("@RecType", pimblcrsp.PIMBL.RecType);
            param.Add("@BLSeqno", pimblcrsp.PIMBL.BLSeqno);
            param.Add("@BLNumber", pimblcrsp.PIMBL.BLNumber);
            param.Add("@BLStatus", pimblcrsp.PIMBL.BLStatus);
            param.Add("@RecStatus", pimblcrsp.PIMBL.RecStatus);
            param.Add("@EventMode", pimblcrsp.PIMBL.EventMode);
            param.Add("@Event", pimblcrsp.PIMBL.Event);
            param.Add("@EventDate", pimblcrsp.PIMBL.EventDate);
            param.Add("@EventFlag", pimblcrsp.PIMBL.EventFlag);
            param.Add("@LOCode", pimblcrsp.PIMBL.LOCode);
            param.Add("@AOCode", pimblcrsp.PIMBL.AOCode);
            param.Add("@OverdueDate", pimblcrsp.PIMBL.OverdueDate);
            param.Add("@BLOverDue", pimblcrsp.PIMBL.BLOverDue);
            param.Add("@AutoOverDue", pimblcrsp.PIMBL.AutoOverDue);
            param.Add("@AdviceDisc", pimblcrsp.PIMBL.AdviceDisc);
            param.Add("@AdviceResult", pimblcrsp.PIMBL.AdviceResult);
            param.Add("@LCNumber", pimblcrsp.PIMBL.LCNumber);
            param.Add("@DocCCy", pimblcrsp.PIMBL.DocCCy);
            param.Add("@CustCode", pimblcrsp.PIMBL.CustCode);
            param.Add("@CustAddr", pimblcrsp.PIMBL.CustAddr);
            param.Add("@BenInfo", pimblcrsp.PIMBL.BenInfo);
            param.Add("@BenCnty", pimblcrsp.PIMBL.BenCnty);
            param.Add("@TenorType", pimblcrsp.PIMBL.TenorType);
            param.Add("@TenorDay", pimblcrsp.PIMBL.TenorDay);
            param.Add("@TenorTerm", pimblcrsp.PIMBL.TenorTerm);
            param.Add("@CommBenCcy", pimblcrsp.PIMBL.CommBenCcy);
            param.Add("@NegoBank", pimblcrsp.PIMBL.NegoBank);
            param.Add("@NegoAddr", pimblcrsp.PIMBL.NegoAddr);
            param.Add("@NegoCity", pimblcrsp.PIMBL.NegoCity);
            param.Add("@NegoCnty", pimblcrsp.PIMBL.NegoCnty);
            param.Add("@ChipNego", pimblcrsp.PIMBL.ChipNego);
            param.Add("@NegoRefno", pimblcrsp.PIMBL.NegoRefno);
            param.Add("@NegoACNo", pimblcrsp.PIMBL.NegoACNo);
            param.Add("@NegoDate", pimblcrsp.PIMBL.NegoDate);
            param.Add("@ValueDate", pimblcrsp.PIMBL.ValueDate);
            param.Add("@RemitFlag", pimblcrsp.PIMBL.RemitFlag);
            param.Add("@GoodsFlag", pimblcrsp.PIMBL.GoodsFlag);
            param.Add("@LCBal", pimblcrsp.PIMBL.LCBal);
            param.Add("@LCAmt", pimblcrsp.PIMBL.LCAmt);
            param.Add("@BLCcy", pimblcrsp.PIMBL.BLCcy);
            param.Add("@BLAmount", pimblcrsp.PIMBL.BLAmount);
            param.Add("@BLBalance", pimblcrsp.PIMBL.BLBalance);
            param.Add("@FBCcy", pimblcrsp.PIMBL.FBCcy);
            param.Add("@FBCharge", pimblcrsp.PIMBL.FBCharge);
            param.Add("@FBInterest", pimblcrsp.PIMBL.FBInterest);
            param.Add("@PrevFBChrg", pimblcrsp.PIMBL.PrevFBChrg);
            param.Add("@PrevFBInt", pimblcrsp.PIMBL.PrevFBInt);
            param.Add("@Discrepancy", pimblcrsp.PIMBL.Discrepancy);
            param.Add("@LC740", pimblcrsp.PIMBL.LC740);
            param.Add("@MT999", pimblcrsp.PIMBL.MT999);
            param.Add("@MT799", pimblcrsp.PIMBL.MT799);
            param.Add("@MTTelex", pimblcrsp.PIMBL.MTTelex);
            param.Add("@MTNo", pimblcrsp.PIMBL.MTNo);
            param.Add("@ReimBank", pimblcrsp.PIMBL.ReimBank);
            param.Add("@DeductCcy", pimblcrsp.PIMBL.DeductCcy);
            param.Add("@DeductDisc", pimblcrsp.PIMBL.DeductDisc);
            param.Add("@DeductSwift", pimblcrsp.PIMBL.DeductSwift);
            param.Add("@DeductComm", pimblcrsp.PIMBL.DeductComm);
            param.Add("@DeductOther", pimblcrsp.PIMBL.DeductOther);
            param.Add("@IssueAdvice", pimblcrsp.PIMBL.IssueAdvice);
            param.Add("@SGNumber", pimblcrsp.PIMBL.SGNumber);
            param.Add("@SGNumber1", pimblcrsp.PIMBL.SGNumber1);
            param.Add("@SGNumber2", pimblcrsp.PIMBL.SGNumber2);
            param.Add("@StartDate", pimblcrsp.PIMBL.StartDate);
            param.Add("@DueDate", pimblcrsp.PIMBL.DueDate);
            param.Add("@PrevDueDate", pimblcrsp.PIMBL.PrevDueDate);
            param.Add("@IntermBank", pimblcrsp.PIMBL.IntermBank);
            param.Add("@ChipInterm", pimblcrsp.PIMBL.ChipInterm);
            param.Add("@AcBank", pimblcrsp.PIMBL.AcBank);
            param.Add("@ChipAcBank", pimblcrsp.PIMBL.ChipAcBank);
            param.Add("@SettleFlag", pimblcrsp.PIMBL.SettleFlag);
            param.Add("@RemitDate", pimblcrsp.PIMBL.RemitDate);
            param.Add("@IntBefore", pimblcrsp.PIMBL.IntBefore);
            param.Add("@ExchBefore", pimblcrsp.PIMBL.ExchBefore);
            param.Add("@IntRateCode", pimblcrsp.PIMBL.IntRateCode);
            param.Add("@IntRate", pimblcrsp.PIMBL.IntRate);
            param.Add("@IntSpread", pimblcrsp.PIMBL.IntSpread);
            param.Add("@IntFlag", pimblcrsp.PIMBL.IntFlag);
            param.Add("@IntBaseDay", pimblcrsp.PIMBL.IntBaseDay);
            param.Add("@IntStartDate", pimblcrsp.PIMBL.IntStartDate);
            param.Add("@LastIntDate", pimblcrsp.PIMBL.LastIntDate);
            param.Add("@LastIntAmt", pimblcrsp.PIMBL.LastIntAmt);
            param.Add("@IntBalance", pimblcrsp.PIMBL.IntBalance);
            param.Add("@OverDrawAmt", pimblcrsp.PIMBL.OverDrawAmt);
            param.Add("@OverDrawRate", pimblcrsp.PIMBL.OverDrawRate);
            param.Add("@OverDrawComm", pimblcrsp.PIMBL.OverDrawComm);
            param.Add("@ExchRate", pimblcrsp.PIMBL.ExchRate);
            param.Add("@EngageRate", pimblcrsp.PIMBL.EngageRate);
            param.Add("@EngageComm", pimblcrsp.PIMBL.EngageComm);
            param.Add("@FBChargeTHB", pimblcrsp.PIMBL.FBChargeTHB);
            param.Add("@FBInterestTHB", pimblcrsp.PIMBL.FBInterestTHB);
            param.Add("@CommFCD", pimblcrsp.PIMBL.CommFCD);
            param.Add("@OpenAmt", pimblcrsp.PIMBL.OpenAmt);
            param.Add("@CableAmt", pimblcrsp.PIMBL.CableAmt);
            param.Add("@PostageAmt", pimblcrsp.PIMBL.PostageAmt);
            param.Add("@DutyAmt", pimblcrsp.PIMBL.DutyAmt);
            param.Add("@PayableAmt", pimblcrsp.PIMBL.PayableAmt);
            param.Add("@CommOther", pimblcrsp.PIMBL.CommOther);
            param.Add("@CommLieu", pimblcrsp.PIMBL.CommLieu);
            param.Add("@CommExch", pimblcrsp.PIMBL.CommExch);
            param.Add("@TaxRefund", pimblcrsp.PIMBL.TaxRefund);
            param.Add("@TaxAmt", pimblcrsp.PIMBL.TaxAmt);
            param.Add("@CommDesc", pimblcrsp.PIMBL.CommDesc);
            param.Add("@PayFlag", pimblcrsp.PIMBL.PayFlag);
            param.Add("@PayMethod", pimblcrsp.PIMBL.PayMethod);
            param.Add("@PayType", pimblcrsp.PIMBL.PayType);
            param.Add("@PayAmount", pimblcrsp.PIMBL.PayAmount);
            param.Add("@PayInterest", pimblcrsp.PIMBL.PayInterest);
            param.Add("@Allocation", pimblcrsp.PIMBL.Allocation);
            param.Add("@DateLastPaid", pimblcrsp.PIMBL.DateLastPaid);
            param.Add("@LastReceiptNo", pimblcrsp.PIMBL.LastReceiptNo);
            param.Add("@AppvNo", pimblcrsp.PIMBL.AppvNo);
            param.Add("@FacNo", pimblcrsp.PIMBL.FacNo);
            param.Add("@FCyPayFlag", pimblcrsp.PIMBL.FCyPayFlag);
            param.Add("@FCyAcNo", pimblcrsp.PIMBL.FCyAcNo);
            param.Add("@FCyReceiptNo", pimblcrsp.PIMBL.FCyReceiptNo);
            // param.Add("@UpdateDate", pimblcrsp.PIMBL.UpdateDate);
            param.Add("@UserCode", pimblcrsp.PIMBL.UserCode);
            // param.Add("@AuthDate", pimblcrsp.PIMBL.AuthDate);
            param.Add("@AuthCode", pimblcrsp.PIMBL.AuthCode);
            param.Add("@GenAccFlag", pimblcrsp.PIMBL.GenAccFlag);
            param.Add("@VoucherID", pimblcrsp.PIMBL.VoucherID);
            param.Add("@DateToStop", pimblcrsp.PIMBL.DateToStop);
            param.Add("@DateStartAccru", pimblcrsp.PIMBL.DateStartAccru);
            param.Add("@TotalAccruAmt", pimblcrsp.PIMBL.TotalAccruAmt);
            param.Add("@TotalAccruBht", pimblcrsp.PIMBL.TotalAccruBht);
            param.Add("@AccruCCy", pimblcrsp.PIMBL.AccruCCy);
            param.Add("@AccruAmt", pimblcrsp.PIMBL.AccruAmt);
            param.Add("@AccruBht", pimblcrsp.PIMBL.AccruBht);
            param.Add("@DateLastAccru", pimblcrsp.PIMBL.DateLastAccru);
            param.Add("@LastAccruCcy", pimblcrsp.PIMBL.LastAccruCcy);
            param.Add("@LastAccruAmt", pimblcrsp.PIMBL.LastAccruAmt);
            param.Add("@NewAccruCcy", pimblcrsp.PIMBL.NewAccruCcy);
            param.Add("@NewAccruAmt", pimblcrsp.PIMBL.NewAccruAmt);
            param.Add("@DAccruAmt", pimblcrsp.PIMBL.DAccruAmt);
            param.Add("@PAccruAmt", pimblcrsp.PIMBL.PAccruAmt);
            param.Add("@AccruPending", pimblcrsp.PIMBL.AccruPending);
            param.Add("@RevAccru", pimblcrsp.PIMBL.RevAccru);
            param.Add("@RevAccruTax", pimblcrsp.PIMBL.RevAccruTax);
            param.Add("@PastDueDate", pimblcrsp.PIMBL.PastDueDate);
            param.Add("@PastDueFlag", pimblcrsp.PIMBL.PastDueFlag);
            param.Add("@TotalSuspAmt", pimblcrsp.PIMBL.TotalSuspAmt);
            param.Add("@TotalSuspBht", pimblcrsp.PIMBL.TotalSuspBht);
            param.Add("@SuspAmt", pimblcrsp.PIMBL.SuspAmt);
            param.Add("@SuspBht", pimblcrsp.PIMBL.SuspBht);
            param.Add("@DMS", pimblcrsp.PIMBL.DMS);
            param.Add("@PayRemark", pimblcrsp.PIMBL.PayRemark);
            param.Add("@CenterID", pimblcrsp.PIMBL.CenterID);
            param.Add("@Instruction", pimblcrsp.PIMBL.Instruction);
            param.Add("@CCS_ACCT", pimblcrsp.PIMBL.CCS_ACCT);
            param.Add("@CCS_LmType", pimblcrsp.PIMBL.CCS_LmType);
            param.Add("@CCS_CNUM", pimblcrsp.PIMBL.CCS_CNUM);
            param.Add("@CCS_CIFRef", pimblcrsp.PIMBL.CCS_CIFRef);
            param.Add("@InUse", pimblcrsp.PIMBL.InUse);
            param.Add("@ObjectType", pimblcrsp.PIMBL.ObjectType);
            param.Add("@UnderlyName", pimblcrsp.PIMBL.UnderlyName);
            param.Add("@BPOFlag", pimblcrsp.PIMBL.BPOFlag);
            param.Add("@Campaign_Code", pimblcrsp.PIMBL.Campaign_Code);
            param.Add("@Campaign_EffDate", pimblcrsp.PIMBL.Campaign_EffDate);
            param.Add("@Pending_Payable", pimblcrsp.PIMBL.Pending_Payable);
            param.Add("@PurposeCode", pimblcrsp.PIMBL.PurposeCode);
            //PPayment
            //param.Add("@RpReceiptNo", pimblcrsp.PPayment.RpReceiptNo);
            //param.Add("@RpModule", pimblcrsp.PPayment.RpModule);
            //param.Add("@RpEvent", pimblcrsp.PPayment.RpEvent);
            //param.Add("@RpDocNo", pimblcrsp.PPayment.RpDocNo);
            //param.Add("@RpCustCode", pimblcrsp.PPayment.RpCustCode);
            //param.Add("@RpPayDate", pimblcrsp.PPayment.RpPayDate);
            //param.Add("@RpPayBy", pimblcrsp.PPayment.RpPayBy);
            //param.Add("@RpNote", pimblcrsp.PPayment.RpNote);
            if (pimblcrsp.PPayment != null)
            {
                param.Add("@RpCashAmt", pimblcrsp.PPayment.RpCashAmt);
                param.Add("@RpChqAmt", pimblcrsp.PPayment.RpChqAmt);
                param.Add("@RpChqNo", pimblcrsp.PPayment.RpChqNo);
                param.Add("@RpChqBank", pimblcrsp.PPayment.RpChqBank);
                param.Add("@RpChqBranch", pimblcrsp.PPayment.RpChqBranch);
                param.Add("@RpCustAc1", pimblcrsp.PPayment.RpCustAc1);
                param.Add("@RpCustAmt1", pimblcrsp.PPayment.RpCustAmt1);
                param.Add("@RpCustAc2", pimblcrsp.PPayment.RpCustAc2);
                param.Add("@RpCustAmt2", pimblcrsp.PPayment.RpCustAmt2);
                param.Add("@RpCustAc3", pimblcrsp.PPayment.RpCustAc3);
                param.Add("@RpCustAmt3", pimblcrsp.PPayment.RpCustAmt3);
                //param.Add("@RpRefer1", pimblcrsp.PPayment.RpRefer1);
                //param.Add("@RpRefer2", pimblcrsp.PPayment.RpRefer2);
                //param.Add("@RpApplicant", pimblcrsp.PPayment.RpApplicant);
                //param.Add("@RpIssBank", pimblcrsp.PPayment.RpIssBank);
                param.Add("@RpStatus", pimblcrsp.PPayment.RpStatus);
            }
            //param.Add("@RpRecStatus", pimblcrsp.PPayment.RpRecStatus);
            //param.Add("@RpPrint", pimblcrsp.PPayment.RpPrint);
            //param.Add("@UserCode", pimblcrsp.PPayment.UserCode);
            //param.Add("@AuthCode", pimblcrsp.PPayment.AuthCode);

            param.Add("@PIMBLRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBLPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PIMBLPPaymentRsp, dynamic>(
                    storedProcedure: "usp_pIMBL_ConfirmSight_Update",
                    param);

                var PIMBLRsp = param.Get<dynamic>("@PIMBLRsp");
                var PIMBLPPaymentRsp = param.Get<dynamic>("@PIMBLPPaymentRsp");

                var resp = param.Get<int>("@Resp");
                if (PIMBLRsp == 1)
                {
                    string? eventDate;
                    string resVoucherID;
                    eventDate = pimblcrsp.PIMBL.EventDate?.ToString("dd/MM/yyyy") ?? "";
                    PIMBLPPaymentRsp2 resultJson = new();
                    resultJson.PIMBL = JsonConvert.DeserializeObject<PIMBLPPaymentRsp>(PIMBLPPaymentRsp);
                    return Ok(resultJson);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Update PIMBL failed";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult<List<PIMBLMasterDeleteReq>>> GetAllDelete(string BLNumber, string BLSeqno, DateTime? EventDate)
        {
            DynamicParameters param = new();

            param.Add("@BLNumber", BLNumber);
            param.Add("@BLSeqno", BLSeqno);
            param.Add("@EventDate", EventDate);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PDocRegister, dynamic>(
                    storedProcedure: "usp_pIMBL_ConfirmSight_Delete",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "BL Number not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("insert")]
        public async Task<ActionResult<List<PIMBLPPaymentRsp>>> Insert([FromBody] PIMBLPPaymentRsp pimblcrsp)
        {
            DynamicParameters param = new DynamicParameters();
            //PIMBL
            param.Add("@ADNumber", pimblcrsp.PIMBL.BLNumber);
            param.Add("@RecType", pimblcrsp.PIMBL.RecType);
            param.Add("@BLSeqno", pimblcrsp.PIMBL.BLSeqno);
            param.Add("@BLNumber", pimblcrsp.PIMBL.BLNumber);
            param.Add("@BLStatus", pimblcrsp.PIMBL.BLStatus);
            param.Add("@RecStatus", pimblcrsp.PIMBL.RecStatus);
            param.Add("@EventMode", pimblcrsp.PIMBL.EventMode);
            param.Add("@Event", pimblcrsp.PIMBL.Event);
            param.Add("@EventDate", pimblcrsp.PIMBL.EventDate);
            param.Add("@EventFlag", pimblcrsp.PIMBL.EventFlag);
            param.Add("@LOCode", pimblcrsp.PIMBL.LOCode);
            param.Add("@AOCode", pimblcrsp.PIMBL.AOCode);
            param.Add("@OverdueDate", pimblcrsp.PIMBL.OverdueDate);
            param.Add("@BLOverDue", pimblcrsp.PIMBL.BLOverDue);
            param.Add("@AutoOverDue", pimblcrsp.PIMBL.AutoOverDue);
            param.Add("@AdviceDisc", pimblcrsp.PIMBL.AdviceDisc);
            param.Add("@AdviceResult", pimblcrsp.PIMBL.AdviceResult);
            param.Add("@LCNumber", pimblcrsp.PIMBL.LCNumber);
            param.Add("@DocCCy", pimblcrsp.PIMBL.DocCCy);
            param.Add("@CustCode", pimblcrsp.PIMBL.CustCode);
            param.Add("@CustAddr", pimblcrsp.PIMBL.CustAddr);
            param.Add("@BenInfo", pimblcrsp.PIMBL.BenInfo);
            param.Add("@BenCnty", pimblcrsp.PIMBL.BenCnty);
            param.Add("@TenorType", pimblcrsp.PIMBL.TenorType);
            param.Add("@TenorDay", pimblcrsp.PIMBL.TenorDay);
            param.Add("@TenorTerm", pimblcrsp.PIMBL.TenorTerm);
            param.Add("@CommBenCcy", pimblcrsp.PIMBL.CommBenCcy);
            param.Add("@NegoBank", pimblcrsp.PIMBL.NegoBank);
            param.Add("@NegoAddr", pimblcrsp.PIMBL.NegoAddr);
            param.Add("@NegoCity", pimblcrsp.PIMBL.NegoCity);
            param.Add("@NegoCnty", pimblcrsp.PIMBL.NegoCnty);
            param.Add("@ChipNego", pimblcrsp.PIMBL.ChipNego);
            param.Add("@NegoRefno", pimblcrsp.PIMBL.NegoRefno);
            param.Add("@NegoACNo", pimblcrsp.PIMBL.NegoACNo);
            param.Add("@NegoDate", pimblcrsp.PIMBL.NegoDate);
            param.Add("@ValueDate", pimblcrsp.PIMBL.ValueDate);
            param.Add("@RemitFlag", pimblcrsp.PIMBL.RemitFlag);
            param.Add("@GoodsFlag", pimblcrsp.PIMBL.GoodsFlag);
            param.Add("@LCBal", pimblcrsp.PIMBL.LCBal);
            param.Add("@LCAmt", pimblcrsp.PIMBL.LCAmt);
            param.Add("@BLCcy", pimblcrsp.PIMBL.BLCcy);
            param.Add("@BLAmount", pimblcrsp.PIMBL.BLAmount);
            param.Add("@BLBalance", pimblcrsp.PIMBL.BLBalance);
            param.Add("@FBCcy", pimblcrsp.PIMBL.FBCcy);
            param.Add("@FBCharge", pimblcrsp.PIMBL.FBCharge);
            param.Add("@FBInterest", pimblcrsp.PIMBL.FBInterest);
            param.Add("@PrevFBChrg", pimblcrsp.PIMBL.PrevFBChrg);
            param.Add("@PrevFBInt", pimblcrsp.PIMBL.PrevFBInt);
            param.Add("@Discrepancy", pimblcrsp.PIMBL.Discrepancy);
            param.Add("@LC740", pimblcrsp.PIMBL.LC740);
            param.Add("@MT999", pimblcrsp.PIMBL.MT999);
            param.Add("@MT799", pimblcrsp.PIMBL.MT799);
            param.Add("@MTTelex", pimblcrsp.PIMBL.MTTelex);
            param.Add("@MTNo", pimblcrsp.PIMBL.MTNo);
            param.Add("@ReimBank", pimblcrsp.PIMBL.ReimBank);
            param.Add("@DeductCcy", pimblcrsp.PIMBL.DeductCcy);
            param.Add("@DeductDisc", pimblcrsp.PIMBL.DeductDisc);
            param.Add("@DeductSwift", pimblcrsp.PIMBL.DeductSwift);
            param.Add("@DeductComm", pimblcrsp.PIMBL.DeductComm);
            param.Add("@DeductOther", pimblcrsp.PIMBL.DeductOther);
            param.Add("@IssueAdvice", pimblcrsp.PIMBL.IssueAdvice);
            param.Add("@SGNumber", pimblcrsp.PIMBL.SGNumber);
            param.Add("@SGNumber1", pimblcrsp.PIMBL.SGNumber1);
            param.Add("@SGNumber2", pimblcrsp.PIMBL.SGNumber2);
            param.Add("@StartDate", pimblcrsp.PIMBL.StartDate);
            param.Add("@DueDate", pimblcrsp.PIMBL.DueDate);
            param.Add("@PrevDueDate", pimblcrsp.PIMBL.PrevDueDate);
            param.Add("@IntermBank", pimblcrsp.PIMBL.IntermBank);
            param.Add("@ChipInterm", pimblcrsp.PIMBL.ChipInterm);
            param.Add("@AcBank", pimblcrsp.PIMBL.AcBank);
            param.Add("@ChipAcBank", pimblcrsp.PIMBL.ChipAcBank);
            param.Add("@SettleFlag", pimblcrsp.PIMBL.SettleFlag);
            param.Add("@RemitDate", pimblcrsp.PIMBL.RemitDate);
            param.Add("@IntBefore", pimblcrsp.PIMBL.IntBefore);
            param.Add("@ExchBefore", pimblcrsp.PIMBL.ExchBefore);
            param.Add("@IntRateCode", pimblcrsp.PIMBL.IntRateCode);
            param.Add("@IntRate", pimblcrsp.PIMBL.IntRate);
            param.Add("@IntSpread", pimblcrsp.PIMBL.IntSpread);
            param.Add("@IntFlag", pimblcrsp.PIMBL.IntFlag);
            param.Add("@IntBaseDay", pimblcrsp.PIMBL.IntBaseDay);
            param.Add("@IntStartDate", pimblcrsp.PIMBL.IntStartDate);
            param.Add("@LastIntDate", pimblcrsp.PIMBL.LastIntDate);
            param.Add("@LastIntAmt", pimblcrsp.PIMBL.LastIntAmt);
            param.Add("@IntBalance", pimblcrsp.PIMBL.IntBalance);
            param.Add("@OverDrawAmt", pimblcrsp.PIMBL.OverDrawAmt);
            param.Add("@OverDrawRate", pimblcrsp.PIMBL.OverDrawRate);
            param.Add("@OverDrawComm", pimblcrsp.PIMBL.OverDrawComm);
            param.Add("@ExchRate", pimblcrsp.PIMBL.ExchRate);
            param.Add("@EngageRate", pimblcrsp.PIMBL.EngageRate);
            param.Add("@EngageComm", pimblcrsp.PIMBL.EngageComm);
            param.Add("@FBChargeTHB", pimblcrsp.PIMBL.FBChargeTHB);
            param.Add("@FBInterestTHB", pimblcrsp.PIMBL.FBInterestTHB);
            param.Add("@CommFCD", pimblcrsp.PIMBL.CommFCD);
            param.Add("@OpenAmt", pimblcrsp.PIMBL.OpenAmt);
            param.Add("@CableAmt", pimblcrsp.PIMBL.CableAmt);
            param.Add("@PostageAmt", pimblcrsp.PIMBL.PostageAmt);
            param.Add("@DutyAmt", pimblcrsp.PIMBL.DutyAmt);
            param.Add("@PayableAmt", pimblcrsp.PIMBL.PayableAmt);
            param.Add("@CommOther", pimblcrsp.PIMBL.CommOther);
            param.Add("@CommLieu", pimblcrsp.PIMBL.CommLieu);
            param.Add("@CommExch", pimblcrsp.PIMBL.CommExch);
            param.Add("@TaxRefund", pimblcrsp.PIMBL.TaxRefund);
            param.Add("@TaxAmt", pimblcrsp.PIMBL.TaxAmt);
            param.Add("@CommDesc", pimblcrsp.PIMBL.CommDesc);
            param.Add("@PayFlag", pimblcrsp.PIMBL.PayFlag);
            param.Add("@PayMethod", pimblcrsp.PIMBL.PayMethod);
            param.Add("@PayType", pimblcrsp.PIMBL.PayType);
            param.Add("@PayAmount", pimblcrsp.PIMBL.PayAmount);
            param.Add("@PayInterest", pimblcrsp.PIMBL.PayInterest);
            param.Add("@Allocation", pimblcrsp.PIMBL.Allocation);
            param.Add("@DateLastPaid", pimblcrsp.PIMBL.DateLastPaid);
            param.Add("@LastReceiptNo", pimblcrsp.PIMBL.LastReceiptNo);
            param.Add("@AppvNo", pimblcrsp.PIMBL.AppvNo);
            param.Add("@FacNo", pimblcrsp.PIMBL.FacNo);
            param.Add("@FCyPayFlag", pimblcrsp.PIMBL.FCyPayFlag);
            param.Add("@FCyAcNo", pimblcrsp.PIMBL.FCyAcNo);
            param.Add("@FCyReceiptNo", pimblcrsp.PIMBL.FCyReceiptNo);
            // param.Add("@UpdateDate", pimblcrsp.PIMBL.UpdateDate);
            param.Add("@UserCode", pimblcrsp.PIMBL.UserCode);
            // param.Add("@AuthDate", pimblcrsp.PIMBL.AuthDate);
            param.Add("@AuthCode", pimblcrsp.PIMBL.AuthCode);
            param.Add("@GenAccFlag", pimblcrsp.PIMBL.GenAccFlag);
            param.Add("@VoucherID", pimblcrsp.PIMBL.VoucherID);
            param.Add("@DateToStop", pimblcrsp.PIMBL.DateToStop);
            param.Add("@DateStartAccru", pimblcrsp.PIMBL.DateStartAccru);
            param.Add("@TotalAccruAmt", pimblcrsp.PIMBL.TotalAccruAmt);
            param.Add("@TotalAccruBht", pimblcrsp.PIMBL.TotalAccruBht);
            param.Add("@AccruCCy", pimblcrsp.PIMBL.AccruCCy);
            param.Add("@AccruAmt", pimblcrsp.PIMBL.AccruAmt);
            param.Add("@AccruBht", pimblcrsp.PIMBL.AccruBht);
            param.Add("@DateLastAccru", pimblcrsp.PIMBL.DateLastAccru);
            param.Add("@LastAccruCcy", pimblcrsp.PIMBL.LastAccruCcy);
            param.Add("@LastAccruAmt", pimblcrsp.PIMBL.LastAccruAmt);
            param.Add("@NewAccruCcy", pimblcrsp.PIMBL.NewAccruCcy);
            param.Add("@NewAccruAmt", pimblcrsp.PIMBL.NewAccruAmt);
            param.Add("@DAccruAmt", pimblcrsp.PIMBL.DAccruAmt);
            param.Add("@PAccruAmt", pimblcrsp.PIMBL.PAccruAmt);
            param.Add("@AccruPending", pimblcrsp.PIMBL.AccruPending);
            param.Add("@RevAccru", pimblcrsp.PIMBL.RevAccru);
            param.Add("@RevAccruTax", pimblcrsp.PIMBL.RevAccruTax);
            param.Add("@PastDueDate", pimblcrsp.PIMBL.PastDueDate);
            param.Add("@PastDueFlag", pimblcrsp.PIMBL.PastDueFlag);
            param.Add("@TotalSuspAmt", pimblcrsp.PIMBL.TotalSuspAmt);
            param.Add("@TotalSuspBht", pimblcrsp.PIMBL.TotalSuspBht);
            param.Add("@SuspAmt", pimblcrsp.PIMBL.SuspAmt);
            param.Add("@SuspBht", pimblcrsp.PIMBL.SuspBht);
            param.Add("@DMS", pimblcrsp.PIMBL.DMS);
            param.Add("@PayRemark", pimblcrsp.PIMBL.PayRemark);
            param.Add("@CenterID", pimblcrsp.PIMBL.CenterID);
            param.Add("@Instruction", pimblcrsp.PIMBL.Instruction);
            param.Add("@CCS_ACCT", pimblcrsp.PIMBL.CCS_ACCT);
            param.Add("@CCS_LmType", pimblcrsp.PIMBL.CCS_LmType);
            param.Add("@CCS_CNUM", pimblcrsp.PIMBL.CCS_CNUM);
            param.Add("@CCS_CIFRef", pimblcrsp.PIMBL.CCS_CIFRef);
            param.Add("@InUse", pimblcrsp.PIMBL.InUse);
            param.Add("@ObjectType", pimblcrsp.PIMBL.ObjectType);
            param.Add("@UnderlyName", pimblcrsp.PIMBL.UnderlyName);
            param.Add("@BPOFlag", pimblcrsp.PIMBL.BPOFlag);
            param.Add("@Campaign_Code", pimblcrsp.PIMBL.Campaign_Code);
            param.Add("@Campaign_EffDate", pimblcrsp.PIMBL.Campaign_EffDate);
            param.Add("@Pending_Payable", pimblcrsp.PIMBL.Pending_Payable);
            param.Add("@PurposeCode", pimblcrsp.PIMBL.PurposeCode);
            //PPayment
            //param.Add("@RpReceiptNo", pimblcrsp.PPayment.RpReceiptNo);
            //param.Add("@RpModule", pimblcrsp.PPayment.RpModule);
            //param.Add("@RpEvent", pimblcrsp.PPayment.RpEvent);
            //param.Add("@RpDocNo", pimblcrsp.PPayment.RpDocNo);
            //param.Add("@RpCustCode", pimblcrsp.PPayment.RpCustCode);
            //param.Add("@RpPayDate", pimblcrsp.PPayment.RpPayDate);
            //param.Add("@RpPayBy", pimblcrsp.PPayment.RpPayBy);
            //param.Add("@RpNote", pimblcrsp.PPayment.RpNote);
            if (pimblcrsp.PPayment != null)
            {
                param.Add("@RpCashAmt", pimblcrsp.PPayment.RpCashAmt);
                param.Add("@RpChqAmt", pimblcrsp.PPayment.RpChqAmt);
                param.Add("@RpChqNo", pimblcrsp.PPayment.RpChqNo);
                param.Add("@RpChqBank", pimblcrsp.PPayment.RpChqBank);
                param.Add("@RpChqBranch", pimblcrsp.PPayment.RpChqBranch);
                param.Add("@RpCustAc1", pimblcrsp.PPayment.RpCustAc1);
                param.Add("@RpCustAmt1", pimblcrsp.PPayment.RpCustAmt1);
                param.Add("@RpCustAc2", pimblcrsp.PPayment.RpCustAc2);
                param.Add("@RpCustAmt2", pimblcrsp.PPayment.RpCustAmt2);
                param.Add("@RpCustAc3", pimblcrsp.PPayment.RpCustAc3);
                param.Add("@RpCustAmt3", pimblcrsp.PPayment.RpCustAmt3);
                //param.Add("@RpRefer1", pimblcrsp.PPayment.RpRefer1);
                //param.Add("@RpRefer2", pimblcrsp.PPayment.RpRefer2);
                //param.Add("@RpApplicant", pimblcrsp.PPayment.RpApplicant);
                //param.Add("@RpIssBank", pimblcrsp.PPayment.RpIssBank);
                param.Add("@RpStatus", pimblcrsp.PPayment.RpStatus);
            }
            //param.Add("@RpRecStatus", pimblcrsp.PPayment.RpRecStatus);
            //param.Add("@RpPrint", pimblcrsp.PPayment.RpPrint);
            //param.Add("@UserCode", pimblcrsp.PPayment.UserCode);
            //param.Add("@AuthCode", pimblcrsp.PPayment.AuthCode);

            param.Add("@PIMBLRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBLPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);


            param.Add("@Resp", dbType: DbType.String,
               direction: ParameterDirection.Output,
               size: 5215585);

            param.Add("@BLSeqNoRsp", dbType: DbType.Int32,
               direction: ParameterDirection.Output,
               size: 12800);

            try
            {
                var results = await _db.LoadData<PIMBLPPaymentRsp, dynamic>(
                    storedProcedure: "usp_pIMBL_ConfirmSight_Insert",
                    param);

                var PIMBLRsp = param.Get<dynamic>("@PIMBLRsp");
                var PIMBLPPaymentRsp = param.Get<dynamic>("@PIMBLPPaymentRsp");
                var BCSeqNoRsp = param.Get<dynamic>("@BLSeqNoRsp");

                var resp = param.Get<string>("@Resp");
                if (PIMBLRsp == 1)
                {
                    string eventDate;
                    string resVoucherID;
                    eventDate = pimblcrsp.PIMBL.EventDate?.ToString("dd/MM/yyyy") ?? "";
                    PIMBLPPaymentRsp2 resultJson = new();
                    resultJson.PIMBL = JsonConvert.DeserializeObject<PIMBLPPaymentRsp>(PIMBLPPaymentRsp);
                    return Ok(resultJson);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = resp.ToString(); //"Insert IMBL Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
