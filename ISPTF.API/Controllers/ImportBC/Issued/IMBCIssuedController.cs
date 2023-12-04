using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ImportBC;
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

namespace ISPTF.API.Controllers.ImportBC
{
    [ApiController]
    [Route("api/[controller]")]
    public class IMBCCollectIssuedController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMBCCollectIssuedController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        public async Task<ActionResult<IEnumerable<object>>> GetAll(string ListType, string CenterID, string BCNumber, string CustCode, string CustName, string UserCode, string Page, string PageSize, string RegDocno)
        {
            DynamicParameters param = new();

            //param.Add("@SupType", SupType);
            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@BCNumber", BCNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@UserCode", UserCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);
            param.Add("@Reg_Docno", RegDocno);

            if (RegDocno == null)
            {
                param.Add("@Reg_Docno", "");
            }
            if (BCNumber == null)
            {
                param.Add("@BCNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            IEnumerable<object> results;

            if (ListType == "EDIT" || ListType == "RELEASE")
            {
                results = await _db.LoadData<PIMBCListRsp, dynamic>(
                    storedProcedure: "usp_q_IMBC_IssueIMBCListPage",
                    param
                );
                return Ok(results);
            }
            else if (ListType == "NEW")
            {
                
                results = await _db.LoadData<PIMBC_IssueIMBC_New_List, dynamic>(
                    storedProcedure: "usp_q_IMBC_IssueIMBCListPage",
                    param
                );
                return Ok(results);
            }
            else
            {
                ReturnResponse response = new();
                response.StatusCode = "400";
                response.Message = "Invalid ListType.";
                return BadRequest(response);
            }
        }

        [HttpGet("select")]
        public async Task<ActionResult<PIMBCPPaymentRsp>> GetAllSelect(string BCNumber, string BCSeqno, string RecType, string EVENT, string RecStatus)
        {
            DynamicParameters param = new();

            param.Add("@BCNumber", BCNumber);
            param.Add("@BCSeqno", BCSeqno);
            param.Add("@RecType", RecType);
            param.Add("@EVENT", EVENT);
            param.Add("@RecStatus", RecStatus);

            param.Add("@PIMBCRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBCPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<PIMBCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pIMBC_Issued_Select",
                           param);

                var PIMBCRsp = param.Get<dynamic>("@PIMBCRsp");
                var PIMBCPPaymentRsp = param.Get<dynamic>("@PIMBCPPaymentRsp");

                if (PIMBCRsp > 0)
                {
                    return Ok(PIMBCPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "IMPORT B/C NO for Collect Refund does not exit";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Select from pDocRegister
        [HttpGet("newselect")]
        public async Task<IEnumerable<PDocRegister>> GetNewSelect(string? RegDocNo)
        {
            DynamicParameters param = new();

            param.Add("@RegDocNo", RegDocNo);

            var results = await _db.LoadData<PDocRegister, dynamic>(
                        storedProcedure: "usp_pDocRegisterSelect",
                        param);
            return results;
        }

        [HttpGet("select/master")]
        public async Task<ActionResult<PIMBCMasterRsp>> GetMasterSelect(string BCNumber)
        {
            DynamicParameters param = new();

            param.Add("@BCNumber", BCNumber);

            param.Add("@PIMBCRsp", dbType: DbType.Int32,
                        direction: ParameterDirection.Output,
                        size: 12800);

            param.Add("@PIMBCPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<PIMBCMasterRsp, dynamic>(
                           storedProcedure: "usp_pIMBC_Issued_Select_Master",
                           param);

                var PIMBCRsp = param.Get<dynamic>("@PIMBCRsp");
                var PIMBCPPaymentRsp = param.Get<dynamic>("@PIMBCPPaymentRsp");

                if (PIMBCRsp > 0)
                {
                    return Ok(PIMBCPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "IMPORT B/C NO does not exit";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("insert")]
        public async Task<ActionResult<List<PIMBCPPaymentRsp>>> Insert([FromBody] PIMBCPPaymentRsp pimbcrsp)
        {
            DynamicParameters param = new DynamicParameters();
            //PIMBC
            param.Add("@BCNumber", pimbcrsp.PIMBC.BCNumber);
            param.Add("@RecType", pimbcrsp.PIMBC.RecType);
            param.Add("@BCSeqno", pimbcrsp.PIMBC.BCSeqno);
            param.Add("@BCStatus", pimbcrsp.PIMBC.BCStatus);
            param.Add("@RecStatus", pimbcrsp.PIMBC.RecStatus);
            param.Add("@EventMode", pimbcrsp.PIMBC.EventMode);
            param.Add("@Event", pimbcrsp.PIMBC.Event);
            param.Add("@EventDate", pimbcrsp.PIMBC.EventDate);
            param.Add("@EventFlag", pimbcrsp.PIMBC.EventFlag);
            param.Add("@LOCode", pimbcrsp.PIMBC.LOCode);
            param.Add("@AOCode", pimbcrsp.PIMBC.AOCode);
            param.Add("@BCType", pimbcrsp.PIMBC.BCType);
            param.Add("@SGAmt", pimbcrsp.PIMBC.SGAmt);
            param.Add("@SGAmt1", pimbcrsp.PIMBC.SGAmt1);
            param.Add("@SGNumber", pimbcrsp.PIMBC.SGNumber);
            param.Add("@SGNumber1", pimbcrsp.PIMBC.SGNumber1);
            param.Add("@SGNumber2", pimbcrsp.PIMBC.SGNumber2);
            param.Add("@SGNumber3", pimbcrsp.PIMBC.SGNumber3);
            param.Add("@SGNumber4", pimbcrsp.PIMBC.SGNumber4);
            param.Add("@TransFrom", pimbcrsp.PIMBC.TransFrom);
            param.Add("@TransBy", pimbcrsp.PIMBC.TransBy);
            param.Add("@OverdueDate", pimbcrsp.PIMBC.OverdueDate);
            param.Add("@BCOverDue", pimbcrsp.PIMBC.BCOverDue);
            param.Add("@AutoOverDue", pimbcrsp.PIMBC.AutoOverDue);
            param.Add("@BLNumber", pimbcrsp.PIMBC.BLNumber);
            param.Add("@INVNumber", pimbcrsp.PIMBC.INVNumber);
            param.Add("@CustCode", pimbcrsp.PIMBC.CustCode);
            param.Add("@CustAddr", pimbcrsp.PIMBC.CustAddr);
            param.Add("@DrawerName", pimbcrsp.PIMBC.DrawerName);
            param.Add("@DrawerInfo", pimbcrsp.PIMBC.DrawerInfo);
            param.Add("@DrawerCnty", pimbcrsp.PIMBC.DrawerCnty);
            param.Add("@DrawerCity", pimbcrsp.PIMBC.DrawerCity);
            param.Add("@BCCcy", pimbcrsp.PIMBC.BCCcy);
            param.Add("@BCAmount", pimbcrsp.PIMBC.BCAmount);
            param.Add("@BCBalance", pimbcrsp.PIMBC.BCBalance);
            param.Add("@AmendFlag", pimbcrsp.PIMBC.AmendFlag);
            param.Add("@AmendAmt", pimbcrsp.PIMBC.AmendAmt);
            param.Add("@DraftDate", pimbcrsp.PIMBC.DraftDate);
            param.Add("@StartDate", pimbcrsp.PIMBC.StartDate);
            param.Add("@DueDate", pimbcrsp.PIMBC.DueDate);
            param.Add("@PrevDueDate", pimbcrsp.PIMBC.PrevDueDate);
            param.Add("@TenorTerm", pimbcrsp.PIMBC.TenorTerm);
            param.Add("@TenorDay", pimbcrsp.PIMBC.TenorDay);
            param.Add("@AcceptFlag", pimbcrsp.PIMBC.AcceptFlag);
            param.Add("@AcceptDate", pimbcrsp.PIMBC.AcceptDate);
            param.Add("@MTNo", pimbcrsp.PIMBC.MTNo);
            param.Add("@FBCharge", pimbcrsp.PIMBC.FBCharge);
            param.Add("@FBInterest", pimbcrsp.PIMBC.FBInterest);
            param.Add("@DeductAmt", pimbcrsp.PIMBC.DeductAmt);
            param.Add("@Goods", pimbcrsp.PIMBC.Goods);
            param.Add("@Document", pimbcrsp.PIMBC.Document);
            param.Add("@RemitFlag", pimbcrsp.PIMBC.RemitFlag);
            param.Add("@RemitDate", pimbcrsp.PIMBC.RemitDate);
            param.Add("@MTNego", pimbcrsp.PIMBC.MTNego);
            param.Add("@RemitBank", pimbcrsp.PIMBC.RemitBank);
            param.Add("@RemitAddr", pimbcrsp.PIMBC.RemitAddr);
            param.Add("@RemitRefno", pimbcrsp.PIMBC.RemitRefno);
            param.Add("@RemitCity", pimbcrsp.PIMBC.RemitCity);
            param.Add("@RemitCnty", pimbcrsp.PIMBC.RemitCnty);
            param.Add("@RemitChipUID", pimbcrsp.PIMBC.RemitChipUID);
            param.Add("@ThirdBank", pimbcrsp.PIMBC.ThirdBank);
            param.Add("@ThirdAddr", pimbcrsp.PIMBC.ThirdAddr);
            param.Add("@ThirdRefno", pimbcrsp.PIMBC.ThirdRefno);
            param.Add("@ReimBank", pimbcrsp.PIMBC.ReimBank);
            param.Add("@ChipReim", pimbcrsp.PIMBC.ChipReim);
            param.Add("@ReimAddr", pimbcrsp.PIMBC.ReimAddr);
            param.Add("@IntermBank", pimbcrsp.PIMBC.IntermBank);
            param.Add("@ChipInterm", pimbcrsp.PIMBC.ChipInterm);
            param.Add("@IntermAddr", pimbcrsp.PIMBC.IntermAddr);
            param.Add("@AcBank", pimbcrsp.PIMBC.AcBank);
            param.Add("@ChipAcBank", pimbcrsp.PIMBC.ChipAcBank);
            param.Add("@AcAddr", pimbcrsp.PIMBC.AcAddr);
            param.Add("@IntBefore", pimbcrsp.PIMBC.IntBefore);
            param.Add("@ExchBefore", pimbcrsp.PIMBC.ExchBefore);
            param.Add("@IntRateCode", pimbcrsp.PIMBC.IntRateCode);
            param.Add("@IntRate", pimbcrsp.PIMBC.IntRate);
            param.Add("@IntSpread", pimbcrsp.PIMBC.IntSpread);
            param.Add("@IntFlag", pimbcrsp.PIMBC.IntFlag);
            param.Add("@IntBaseDay", pimbcrsp.PIMBC.IntBaseDay);
            param.Add("@IntStartDate", pimbcrsp.PIMBC.IntStartDate);
            param.Add("@LastIntDate", pimbcrsp.PIMBC.LastIntDate);
            param.Add("@LastIntAmt", pimbcrsp.PIMBC.LastIntAmt);
            param.Add("@IntBalance", pimbcrsp.PIMBC.IntBalance);
            param.Add("@ExchRate", pimbcrsp.PIMBC.ExchRate);
            param.Add("@EngageRate", pimbcrsp.PIMBC.EngageRate);
            param.Add("@EngageComm", pimbcrsp.PIMBC.EngageComm);
            param.Add("@FBChargeTHB", pimbcrsp.PIMBC.FBChargeTHB);
            param.Add("@FBInterestTHB", pimbcrsp.PIMBC.FBInterestTHB);
            param.Add("@CommFCD", pimbcrsp.PIMBC.CommFCD);
            param.Add("@CableAmt", pimbcrsp.PIMBC.CableAmt);
            param.Add("@DutyAmt", pimbcrsp.PIMBC.DutyAmt);
            param.Add("@PostageAmt", pimbcrsp.PIMBC.PostageAmt);
            param.Add("@PayableAmt", pimbcrsp.PIMBC.PayableAmt);
            param.Add("@CommOther", pimbcrsp.PIMBC.CommOther);
            param.Add("@IBCComRate", pimbcrsp.PIMBC.IBCComRate);
            param.Add("@IBCComm", pimbcrsp.PIMBC.IBCComm);
            param.Add("@CommLieu", pimbcrsp.PIMBC.CommLieu);
            param.Add("@ProtestAmt", pimbcrsp.PIMBC.ProtestAmt);
            param.Add("@CommExch", pimbcrsp.PIMBC.CommExch);
            param.Add("@TaxRefund", pimbcrsp.PIMBC.TaxRefund);
            param.Add("@TaxAmt", pimbcrsp.PIMBC.TaxAmt);
            param.Add("@PayFlag", pimbcrsp.PIMBC.PayFlag);
            param.Add("@PayType", pimbcrsp.PIMBC.PayType);
            param.Add("@PayAmount", pimbcrsp.PIMBC.PayAmount);
            param.Add("@PayInterest", pimbcrsp.PIMBC.PayInterest);
            param.Add("@PayMethod", pimbcrsp.PIMBC.PayMethod);
            param.Add("@PayRemark", pimbcrsp.PIMBC.PayRemark);
            param.Add("@Allocation", pimbcrsp.PIMBC.Allocation);
            param.Add("@DateLastPaid", pimbcrsp.PIMBC.DateLastPaid);
            param.Add("@LastReceiptNo", pimbcrsp.PIMBC.LastReceiptNo);
            param.Add("@AppvNo", pimbcrsp.PIMBC.AppvNo);
            param.Add("@FacNo", pimbcrsp.PIMBC.FacNo);
            param.Add("@FCyPayFlag", pimbcrsp.PIMBC.FCyPayFlag);
            param.Add("@FCyAcNo", pimbcrsp.PIMBC.FCyAcNo);
            param.Add("@FCyReceiptNo", pimbcrsp.PIMBC.FCyReceiptNo);
            //param.Add("@UpdateDate", pimbcrsp.PIMBC.UpdateDate);
            param.Add("@UserCode", pimbcrsp.PIMBC.UserCode);
            //param.Add("@AuthDate", pimbcrsp.PIMBC.AuthDate);
            param.Add("@AuthCode", pimbcrsp.PIMBC.AuthCode);
            param.Add("@GenAccFlag", pimbcrsp.PIMBC.GenAccFlag);
            param.Add("@VoucherID", pimbcrsp.PIMBC.VoucherID);
            param.Add("@TotalAccruAmt", pimbcrsp.PIMBC.TotalAccruAmt);
            param.Add("@TotalAccruBht", pimbcrsp.PIMBC.TotalAccruBht);
            param.Add("@AccruAmt", pimbcrsp.PIMBC.AccruAmt);
            param.Add("@AccruBht", pimbcrsp.PIMBC.AccruBht);
            param.Add("@DateLastAccru", pimbcrsp.PIMBC.DateLastAccru);
            param.Add("@GoodsDesc", pimbcrsp.PIMBC.GoodsDesc);
            param.Add("@Tx72", pimbcrsp.PIMBC.Tx72);
            param.Add("@Tx79", pimbcrsp.PIMBC.Tx79);
            param.Add("@Tx23E", pimbcrsp.PIMBC.Tx23E);
            param.Add("@Tx71A", pimbcrsp.PIMBC.Tx71A);
            param.Add("@Tx26", pimbcrsp.PIMBC.Tx26);
            param.Add("@Tx59A", pimbcrsp.PIMBC.Tx59A);
            param.Add("@Tx59D", pimbcrsp.PIMBC.Tx59D);
            param.Add("@Tx70", pimbcrsp.PIMBC.Tx70);
            param.Add("@DMS", pimbcrsp.PIMBC.DMS);
            param.Add("@CenterID", pimbcrsp.PIMBC.CenterID);
            param.Add("@CCS_ACCT", pimbcrsp.PIMBC.CCS_ACCT);
            param.Add("@CCS_LmType", pimbcrsp.PIMBC.CCS_LmType);
            param.Add("@CCS_CNUM", pimbcrsp.PIMBC.CCS_CNUM);
            param.Add("@CCS_CIFRef", pimbcrsp.PIMBC.CCS_CIFRef);
            param.Add("@InUse", pimbcrsp.PIMBC.InUse);
            param.Add("@ObjectType", pimbcrsp.PIMBC.ObjectType);
            param.Add("@UnderlyName", pimbcrsp.PIMBC.UnderlyName);
            param.Add("@BPOFlag", pimbcrsp.PIMBC.BPOFlag);
            param.Add("@Campaign_Code", pimbcrsp.PIMBC.Campaign_Code);
            param.Add("@Campaign_EffDate", pimbcrsp.PIMBC.Campaign_EffDate);
            param.Add("@PurposeCode", pimbcrsp.PIMBC.PurposeCode);

            //PPayment
            //param.Add("@RpReceiptNo", pimbcrsp.PPayment.RpReceiptNo);
            //param.Add("@RpModule", pimbcrsp.PPayment.RpModule);
            //param.Add("@RpEvent", pimbcrsp.PPayment.RpEvent);
            //param.Add("@RpDocNo", pimbcrsp.PPayment.RpDocNo);
            //param.Add("@RpCustCode", pimbcrsp.PPayment.RpCustCode);
            //param.Add("@RpPayDate", pimbcrsp.PPayment.RpPayDate);
            //param.Add("@RpPayBy", pimbcrsp.PPayment.RpPayBy);
            //param.Add("@RpNote", pimbcrsp.PPayment.RpNote);
            if (pimbcrsp.PPayment != null)
            {
                param.Add("@RpCashAmt", pimbcrsp.PPayment.RpCashAmt);
                param.Add("@RpChqAmt", pimbcrsp.PPayment.RpChqAmt);
                param.Add("@RpChqNo", pimbcrsp.PPayment.RpChqNo);
                param.Add("@RpChqBank", pimbcrsp.PPayment.RpChqBank);
                param.Add("@RpChqBranch", pimbcrsp.PPayment.RpChqBranch);
                param.Add("@RpCustAc1", pimbcrsp.PPayment.RpCustAc1);
                param.Add("@RpCustAmt1", pimbcrsp.PPayment.RpCustAmt1);
                param.Add("@RpCustAc2", pimbcrsp.PPayment.RpCustAc2);
                param.Add("@RpCustAmt2", pimbcrsp.PPayment.RpCustAmt2);
                param.Add("@RpCustAc3", pimbcrsp.PPayment.RpCustAc3);
                param.Add("@RpCustAmt3", pimbcrsp.PPayment.RpCustAmt3);
                //param.Add("@RpRefer1", pimbcrsp.PPayment.RpRefer1);
                //param.Add("@RpRefer2", pimbcrsp.PPayment.RpRefer2);
                //param.Add("@RpApplicant", pimbcrsp.PPayment.RpApplicant);
                //param.Add("@RpIssBank", pimbcrsp.PPayment.RpIssBank);
                param.Add("@RpStatus", pimbcrsp.PPayment.RpStatus);
                //param.Add("@RpRecStatus", pimbcrsp.PPayment.RpRecStatus);
                //param.Add("@RpPrint", pimbcrsp.PPayment.RpPrint);
                //param.Add("@UserCode", pimbcrsp.PPayment.UserCode);
                //param.Add("@AuthCode", pimbcrsp.PPayment.AuthCode);
            }
            param.Add("@PIMBCRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBCPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);


            param.Add("@Resp", dbType: DbType.String,
               direction: ParameterDirection.Output,
               size: 5215585);

            param.Add("@BCSeqNoRsp", dbType: DbType.Int32,
               direction: ParameterDirection.Output,
               size: 12800);

            try
            {
                var results = await _db.LoadData<PIMBCPPaymentRsp, dynamic>(
                    storedProcedure: "usp_pIMBC_Issued_Insert",
                    param);

                var PIMBCRsp = param.Get<dynamic>("@PIMBCRsp");
                var PIMBCPPaymentRsp = param.Get<dynamic>("@PIMBCPPaymentRsp");
                var BCSeqNoRsp = param.Get<dynamic>("@BCSeqNoRsp");

                var resp = param.Get<string>("@Resp");
                if (PIMBCRsp == 1)
                {
                    string eventDate;
                    string resVoucherID;
                    eventDate = pimbcrsp.PIMBC.EventDate.ToString("dd/MM/yyyy");
                    PIMBCPPaymentRsp2 resultJson = new();
                    resultJson.PIMBC = JsonConvert.DeserializeObject<PIMBCPPaymentRsp>(PIMBCPPaymentRsp);

                    resVoucherID = ISPModuleIMP.GenerateGL.StartPIMBC(resultJson.PIMBC.PIMBC.BCNumber,
                        eventDate, resultJson.PIMBC.PIMBC.BCSeqno,
                         resultJson.PIMBC.PIMBC.Event);


                    if (resVoucherID != "ERROR")
                    {
                        resultJson.PIMBC.PIMBC.VoucherID = resVoucherID;
                    }
                    else
                    {
                        ReturnResponse response = new();
                        response.StatusCode = Constants.RESPONSE_ERROR;
                        response.Message = "Error for  Gen.G/L  ";
                        return BadRequest(response);
                    }
                    return Ok(resultJson);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = resp.ToString(); //"Insert IMBC Collect Refund Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<List<PIMBCPPaymentRsp>>> Update([FromBody] PIMBCPPaymentRsp pimbcrsp)
        {
            DynamicParameters param = new DynamicParameters();
            //PIMBC
            param.Add("@BCNumber", pimbcrsp.PIMBC.BCNumber);
            param.Add("@RecType", pimbcrsp.PIMBC.RecType);
            param.Add("@BCSeqno", pimbcrsp.PIMBC.BCSeqno);
            param.Add("@BCStatus", pimbcrsp.PIMBC.BCStatus);
            param.Add("@RecStatus", pimbcrsp.PIMBC.RecStatus);
            param.Add("@EventMode", pimbcrsp.PIMBC.EventMode);
            param.Add("@Event", pimbcrsp.PIMBC.Event);
            param.Add("@EventDate", pimbcrsp.PIMBC.EventDate);
            param.Add("@EventFlag", pimbcrsp.PIMBC.EventFlag);
            param.Add("@LOCode", pimbcrsp.PIMBC.LOCode);
            param.Add("@AOCode", pimbcrsp.PIMBC.AOCode);
            param.Add("@BCType", pimbcrsp.PIMBC.BCType);
            param.Add("@SGAmt", pimbcrsp.PIMBC.SGAmt);
            param.Add("@SGAmt1", pimbcrsp.PIMBC.SGAmt1);
            param.Add("@SGNumber", pimbcrsp.PIMBC.SGNumber);
            param.Add("@SGNumber1", pimbcrsp.PIMBC.SGNumber1);
            param.Add("@SGNumber2", pimbcrsp.PIMBC.SGNumber2);
            param.Add("@SGNumber3", pimbcrsp.PIMBC.SGNumber3);
            param.Add("@SGNumber4", pimbcrsp.PIMBC.SGNumber4);
            param.Add("@TransFrom", pimbcrsp.PIMBC.TransFrom);
            param.Add("@TransBy", pimbcrsp.PIMBC.TransBy);
            param.Add("@OverdueDate", pimbcrsp.PIMBC.OverdueDate);
            param.Add("@BCOverDue", pimbcrsp.PIMBC.BCOverDue);
            param.Add("@AutoOverDue", pimbcrsp.PIMBC.AutoOverDue);
            param.Add("@BLNumber", pimbcrsp.PIMBC.BLNumber);
            param.Add("@INVNumber", pimbcrsp.PIMBC.INVNumber);
            param.Add("@CustCode", pimbcrsp.PIMBC.CustCode);
            param.Add("@CustAddr", pimbcrsp.PIMBC.CustAddr);
            param.Add("@DrawerName", pimbcrsp.PIMBC.DrawerName);
            param.Add("@DrawerInfo", pimbcrsp.PIMBC.DrawerInfo);
            param.Add("@DrawerCnty", pimbcrsp.PIMBC.DrawerCnty);
            param.Add("@DrawerCity", pimbcrsp.PIMBC.DrawerCity);
            param.Add("@BCCcy", pimbcrsp.PIMBC.BCCcy);
            param.Add("@BCAmount", pimbcrsp.PIMBC.BCAmount);
            param.Add("@BCBalance", pimbcrsp.PIMBC.BCBalance);
            param.Add("@AmendFlag", pimbcrsp.PIMBC.AmendFlag);
            param.Add("@AmendAmt", pimbcrsp.PIMBC.AmendAmt);
            param.Add("@DraftDate", pimbcrsp.PIMBC.DraftDate);
            param.Add("@StartDate", pimbcrsp.PIMBC.StartDate);
            param.Add("@DueDate", pimbcrsp.PIMBC.DueDate);
            param.Add("@PrevDueDate", pimbcrsp.PIMBC.PrevDueDate);
            param.Add("@TenorTerm", pimbcrsp.PIMBC.TenorTerm);
            param.Add("@TenorDay", pimbcrsp.PIMBC.TenorDay);
            param.Add("@AcceptFlag", pimbcrsp.PIMBC.AcceptFlag);
            param.Add("@AcceptDate", pimbcrsp.PIMBC.AcceptDate);
            param.Add("@MTNo", pimbcrsp.PIMBC.MTNo);
            param.Add("@FBCharge", pimbcrsp.PIMBC.FBCharge);
            param.Add("@FBInterest", pimbcrsp.PIMBC.FBInterest);
            param.Add("@DeductAmt", pimbcrsp.PIMBC.DeductAmt);
            param.Add("@Goods", pimbcrsp.PIMBC.Goods);
            param.Add("@Document", pimbcrsp.PIMBC.Document);
            param.Add("@RemitFlag", pimbcrsp.PIMBC.RemitFlag);
            param.Add("@RemitDate", pimbcrsp.PIMBC.RemitDate);
            param.Add("@MTNego", pimbcrsp.PIMBC.MTNego);
            param.Add("@RemitBank", pimbcrsp.PIMBC.RemitBank);
            param.Add("@RemitAddr", pimbcrsp.PIMBC.RemitAddr);
            param.Add("@RemitRefno", pimbcrsp.PIMBC.RemitRefno);
            param.Add("@RemitCity", pimbcrsp.PIMBC.RemitCity);
            param.Add("@RemitCnty", pimbcrsp.PIMBC.RemitCnty);
            param.Add("@RemitChipUID", pimbcrsp.PIMBC.RemitChipUID);
            param.Add("@ThirdBank", pimbcrsp.PIMBC.ThirdBank);
            param.Add("@ThirdAddr", pimbcrsp.PIMBC.ThirdAddr);
            param.Add("@ThirdRefno", pimbcrsp.PIMBC.ThirdRefno);
            param.Add("@ReimBank", pimbcrsp.PIMBC.ReimBank);
            param.Add("@ChipReim", pimbcrsp.PIMBC.ChipReim);
            param.Add("@ReimAddr", pimbcrsp.PIMBC.ReimAddr);
            param.Add("@IntermBank", pimbcrsp.PIMBC.IntermBank);
            param.Add("@ChipInterm", pimbcrsp.PIMBC.ChipInterm);
            param.Add("@IntermAddr", pimbcrsp.PIMBC.IntermAddr);
            param.Add("@AcBank", pimbcrsp.PIMBC.AcBank);
            param.Add("@ChipAcBank", pimbcrsp.PIMBC.ChipAcBank);
            param.Add("@AcAddr", pimbcrsp.PIMBC.AcAddr);
            param.Add("@IntBefore", pimbcrsp.PIMBC.IntBefore);
            param.Add("@ExchBefore", pimbcrsp.PIMBC.ExchBefore);
            param.Add("@IntRateCode", pimbcrsp.PIMBC.IntRateCode);
            param.Add("@IntRate", pimbcrsp.PIMBC.IntRate);
            param.Add("@IntSpread", pimbcrsp.PIMBC.IntSpread);
            param.Add("@IntFlag", pimbcrsp.PIMBC.IntFlag);
            param.Add("@IntBaseDay", pimbcrsp.PIMBC.IntBaseDay);
            param.Add("@IntStartDate", pimbcrsp.PIMBC.IntStartDate);
            param.Add("@LastIntDate", pimbcrsp.PIMBC.LastIntDate);
            param.Add("@LastIntAmt", pimbcrsp.PIMBC.LastIntAmt);
            param.Add("@IntBalance", pimbcrsp.PIMBC.IntBalance);
            param.Add("@ExchRate", pimbcrsp.PIMBC.ExchRate);
            param.Add("@EngageRate", pimbcrsp.PIMBC.EngageRate);
            param.Add("@EngageComm", pimbcrsp.PIMBC.EngageComm);
            param.Add("@FBChargeTHB", pimbcrsp.PIMBC.FBChargeTHB);
            param.Add("@FBInterestTHB", pimbcrsp.PIMBC.FBInterestTHB);
            param.Add("@CommFCD", pimbcrsp.PIMBC.CommFCD);
            param.Add("@CableAmt", pimbcrsp.PIMBC.CableAmt);
            param.Add("@DutyAmt", pimbcrsp.PIMBC.DutyAmt);
            param.Add("@PostageAmt", pimbcrsp.PIMBC.PostageAmt);
            param.Add("@PayableAmt", pimbcrsp.PIMBC.PayableAmt);
            param.Add("@CommOther", pimbcrsp.PIMBC.CommOther);
            param.Add("@IBCComRate", pimbcrsp.PIMBC.IBCComRate);
            param.Add("@IBCComm", pimbcrsp.PIMBC.IBCComm);
            param.Add("@CommLieu", pimbcrsp.PIMBC.CommLieu);
            param.Add("@ProtestAmt", pimbcrsp.PIMBC.ProtestAmt);
            param.Add("@CommExch", pimbcrsp.PIMBC.CommExch);
            param.Add("@TaxRefund", pimbcrsp.PIMBC.TaxRefund);
            param.Add("@TaxAmt", pimbcrsp.PIMBC.TaxAmt);
            param.Add("@PayFlag", pimbcrsp.PIMBC.PayFlag);
            param.Add("@PayType", pimbcrsp.PIMBC.PayType);
            param.Add("@PayAmount", pimbcrsp.PIMBC.PayAmount);
            param.Add("@PayInterest", pimbcrsp.PIMBC.PayInterest);
            param.Add("@PayMethod", pimbcrsp.PIMBC.PayMethod);
            param.Add("@PayRemark", pimbcrsp.PIMBC.PayRemark);
            param.Add("@Allocation", pimbcrsp.PIMBC.Allocation);
            param.Add("@DateLastPaid", pimbcrsp.PIMBC.DateLastPaid);
            param.Add("@LastReceiptNo", pimbcrsp.PIMBC.LastReceiptNo);
            param.Add("@AppvNo", pimbcrsp.PIMBC.AppvNo);
            param.Add("@FacNo", pimbcrsp.PIMBC.FacNo);
            param.Add("@FCyPayFlag", pimbcrsp.PIMBC.FCyPayFlag);
            param.Add("@FCyAcNo", pimbcrsp.PIMBC.FCyAcNo);
            param.Add("@FCyReceiptNo", pimbcrsp.PIMBC.FCyReceiptNo);
            //param.Add("@UpdateDate", pimbcrsp.PIMBC.UpdateDate);
            param.Add("@UserCode", pimbcrsp.PIMBC.UserCode);
            //param.Add("@AuthDate", pimbcrsp.PIMBC.AuthDate);
            param.Add("@AuthCode", pimbcrsp.PIMBC.AuthCode);
            param.Add("@GenAccFlag", pimbcrsp.PIMBC.GenAccFlag);
            param.Add("@VoucherID", pimbcrsp.PIMBC.VoucherID);
            param.Add("@TotalAccruAmt", pimbcrsp.PIMBC.TotalAccruAmt);
            param.Add("@TotalAccruBht", pimbcrsp.PIMBC.TotalAccruBht);
            param.Add("@AccruAmt", pimbcrsp.PIMBC.AccruAmt);
            param.Add("@AccruBht", pimbcrsp.PIMBC.AccruBht);
            param.Add("@DateLastAccru", pimbcrsp.PIMBC.DateLastAccru);
            param.Add("@GoodsDesc", pimbcrsp.PIMBC.GoodsDesc);
            param.Add("@Tx72", pimbcrsp.PIMBC.Tx72);
            param.Add("@Tx79", pimbcrsp.PIMBC.Tx79);
            param.Add("@Tx23E", pimbcrsp.PIMBC.Tx23E);
            param.Add("@Tx71A", pimbcrsp.PIMBC.Tx71A);
            param.Add("@Tx26", pimbcrsp.PIMBC.Tx26);
            param.Add("@Tx59A", pimbcrsp.PIMBC.Tx59A);
            param.Add("@Tx59D", pimbcrsp.PIMBC.Tx59D);
            param.Add("@Tx70", pimbcrsp.PIMBC.Tx70);
            param.Add("@DMS", pimbcrsp.PIMBC.DMS);
            param.Add("@CenterID", pimbcrsp.PIMBC.CenterID);
            param.Add("@CCS_ACCT", pimbcrsp.PIMBC.CCS_ACCT);
            param.Add("@CCS_LmType", pimbcrsp.PIMBC.CCS_LmType);
            param.Add("@CCS_CNUM", pimbcrsp.PIMBC.CCS_CNUM);
            param.Add("@CCS_CIFRef", pimbcrsp.PIMBC.CCS_CIFRef);
            param.Add("@InUse", pimbcrsp.PIMBC.InUse);
            param.Add("@ObjectType", pimbcrsp.PIMBC.ObjectType);
            param.Add("@UnderlyName", pimbcrsp.PIMBC.UnderlyName);
            param.Add("@BPOFlag", pimbcrsp.PIMBC.BPOFlag);
            param.Add("@Campaign_Code", pimbcrsp.PIMBC.Campaign_Code);
            param.Add("@Campaign_EffDate", pimbcrsp.PIMBC.Campaign_EffDate);
            param.Add("@PurposeCode", pimbcrsp.PIMBC.PurposeCode);

            //PPayment
            //param.Add("@RpReceiptNo", pimbcrsp.PPayment.RpReceiptNo);
            //param.Add("@RpModule", pimbcrsp.PPayment.RpModule);
            //param.Add("@RpEvent", pimbcrsp.PPayment.RpEvent);
            //param.Add("@RpDocNo", pimbcrsp.PPayment.RpDocNo);
            //param.Add("@RpCustCode", pimbcrsp.PPayment.RpCustCode);
            //param.Add("@RpPayDate", pimbcrsp.PPayment.RpPayDate);
            //param.Add("@RpPayBy", pimbcrsp.PPayment.RpPayBy);
            //param.Add("@RpNote", pimbcrsp.PPayment.RpNote);
            if (pimbcrsp.PPayment != null)
            {
                param.Add("@RpCashAmt", pimbcrsp.PPayment.RpCashAmt);
                param.Add("@RpChqAmt", pimbcrsp.PPayment.RpChqAmt);
                param.Add("@RpChqNo", pimbcrsp.PPayment.RpChqNo);
                param.Add("@RpChqBank", pimbcrsp.PPayment.RpChqBank);
                param.Add("@RpChqBranch", pimbcrsp.PPayment.RpChqBranch);
                param.Add("@RpCustAc1", pimbcrsp.PPayment.RpCustAc1);
                param.Add("@RpCustAmt1", pimbcrsp.PPayment.RpCustAmt1);
                param.Add("@RpCustAc2", pimbcrsp.PPayment.RpCustAc2);
                param.Add("@RpCustAmt2", pimbcrsp.PPayment.RpCustAmt2);
                param.Add("@RpCustAc3", pimbcrsp.PPayment.RpCustAc3);
                param.Add("@RpCustAmt3", pimbcrsp.PPayment.RpCustAmt3);
                //param.Add("@RpRefer1", pimbcrsp.PPayment.RpRefer1);
                //param.Add("@RpRefer2", pimbcrsp.PPayment.RpRefer2);
                //param.Add("@RpApplicant", pimbcrsp.PPayment.RpApplicant);
                //param.Add("@RpIssBank", pimbcrsp.PPayment.RpIssBank);
                param.Add("@RpStatus", pimbcrsp.PPayment.RpStatus);
            }
            //param.Add("@RpRecStatus", pimbcrsp.PPayment.RpRecStatus);
            //param.Add("@RpPrint", pimbcrsp.PPayment.RpPrint);
            //param.Add("@UserCode", pimbcrsp.PPayment.UserCode);
            //param.Add("@AuthCode", pimbcrsp.PPayment.AuthCode);

            param.Add("@PIMBCRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBCPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PIMBCPPaymentRsp, dynamic>(
                    storedProcedure: "usp_pIMBC_Issued_Update",
                    param);

                var PIMBCRsp = param.Get<dynamic>("@PIMBCRsp");
                var PIMBCPPaymentRsp = param.Get<dynamic>("@PIMBCPPaymentRsp");

                var resp = param.Get<int>("@Resp");
                if (PIMBCRsp == 1)
                {
                    string eventDate;
                    string resVoucherID;
                    eventDate = pimbcrsp.PIMBC.EventDate.ToString("dd/MM/yyyy");
                    PIMBCPPaymentRsp2 resultJson = new();
                    resultJson.PIMBC = JsonConvert.DeserializeObject<PIMBCPPaymentRsp>(PIMBCPPaymentRsp);
                    resVoucherID = ISPModuleIMP.GenerateGL.StartPIMBC(resultJson.PIMBC.PIMBC.BCNumber,
                   eventDate, resultJson.PIMBC.PIMBC.BCSeqno,
                    resultJson.PIMBC.PIMBC.Event);


                    if (resVoucherID != "ERROR")
                    {
                        resultJson.PIMBC.PIMBC.VoucherID = resVoucherID;
                    }
                    else
                    {
                        ReturnResponse response = new();
                        response.StatusCode = Constants.RESPONSE_ERROR;
                        response.Message = "Error for  Gen.G/L  ";
                        return BadRequest(response);
                    }
                    return Ok(resultJson);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Register DocNo not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("release")]
        public async Task<ActionResult<List<PIMBCPPaymentRsp>>> GetAllRelease([FromBody] PIMBCReleaseReq pimbcrsp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BCNumber", pimbcrsp.BCNumber);
            param.Add("@RecType", pimbcrsp.RecType);
            param.Add("@BCSeqno", pimbcrsp.BCSeqno);
            param.Add("@Event", pimbcrsp.Event);
            param.Add("@AuthCode", pimbcrsp.AuthCode);


            param.Add("@PIMBCRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBCPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PIMBCPPaymentRsp, dynamic>(
                    storedProcedure: "usp_pIMBC_Issued_Release",
                    param);
                var PIMBCRsp = param.Get<dynamic>("@PIMBCRsp");
                var PIMBCPPaymentRsp = param.Get<dynamic>("@PIMBCPPaymentRsp");
                var resp = param.Get<int>("@Resp");

                if (PIMBCRsp == 1)
                {
                    return Ok(PIMBCPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "BC Number not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult<List<PIMBCMasterDeleteReq>>> GetAllDelete(string BCNumber, string BCSeqno, DateTime? EventDate)
        {
            DynamicParameters param = new();

            param.Add("@BCNumber", BCNumber);
            param.Add("@BCSeqno", BCSeqno);
            param.Add("@EventDate", EventDate);
            param.Add("@BCNumber", BCNumber);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PDocRegister, dynamic>(
                    storedProcedure: "usp_pIMBC_Issued_Delete",
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
                    response.Message = "BC Number not exist";
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
