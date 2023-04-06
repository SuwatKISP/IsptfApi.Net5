using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.Remittance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.Remittance 
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemitRegistOutwardSWIFTController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public RemitRegistOutwardSWIFTController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("editlist")]
        public async Task<IEnumerable<Q_RegistOutwardSWITPageRsp>> GetEditList(string? CenterID, string? Cust_Code, string? CustInfo1, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@CenterID", CenterID);
            param.Add("@Cust_Code", Cust_Code);
            param.Add("@CustInfo1", CustInfo1);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (Cust_Code == null)
            {
                param.Add("@Cust_Code", "");
            }
            if (CustInfo1 == null)
            {
                param.Add("@CustInfo1", "");
            }

            var results = await _db.LoadData<Q_RegistOutwardSWITPageRsp, dynamic>(
                        storedProcedure: "usp_pRemittanceRegistOutwardSWITSelectPage",
                        param);
            return results;
        }


        [HttpGet("select")]
        public async Task<IEnumerable<PRemittance>> GetAllSelect(string? RemRefNo)
        {
            DynamicParameters param = new();

            param.Add("@RemRefNo", RemRefNo);

            var results = await _db.LoadData<PRemittance, dynamic>(
                        storedProcedure: "usp_pRemittanceSelect",
                        param);
            return results;
        }

        [HttpPost("insert")]
        public async Task<ActionResult<List<PRemittance>>> Insert([FromBody] PRemittance premittance)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@RemRefNo", premittance.RemRefNo);
            param.Add("@EventDate", premittance.EventDate);
            param.Add("@RemDate", premittance.RemDate);
            param.Add("@RegistDate", premittance.RegistDate);
            param.Add("@RemBankRefNo", premittance.RemBankRefNo);
            param.Add("@RemStatus", premittance.RemStatus);
            param.Add("@RecStatus", premittance.RecStatus);
            param.Add("@RemType", premittance.RemType);
            param.Add("@InUse", premittance.InUse);
            param.Add("@RemBank", premittance.RemBank);
            param.Add("@RemAddr", premittance.RemAddr);
            param.Add("@Cust_Bran", premittance.Cust_Bran);
            param.Add("@Cust_Code", premittance.Cust_Code);
            param.Add("@Cust_CCID", premittance.Cust_CCID);
            param.Add("@Cust_AO", premittance.Cust_AO);
            param.Add("@Cust_LO", premittance.Cust_LO);
            param.Add("@CustInfo1", premittance.CustInfo1);
            param.Add("@CustInfo2", premittance.CustInfo2);
            param.Add("@AppInfo1", premittance.AppInfo1);
            param.Add("@AppInfo2", premittance.AppInfo2);
            param.Add("@AppInfo3", premittance.AppInfo3);
            param.Add("@AppInfo4", premittance.AppInfo4);
            param.Add("@SenderInfo", premittance.SenderInfo);
            param.Add("@Rel_Code", premittance.Rel_Code);
            param.Add("@GoodsCode", premittance.GoodsCode);
            param.Add("@PurposeCode", premittance.PurposeCode);
            param.Add("@GoodsDesc", premittance.GoodsDesc);
            param.Add("@RemAcc", premittance.RemAcc);
            param.Add("@RemCcy", premittance.RemCcy);
            param.Add("@RateType", premittance.RateType);
            param.Add("@ExchRate", premittance.ExchRate);
            param.Add("@RmForward", premittance.RmForward);
            param.Add("@RmCcyAmt", premittance.RmCcyAmt);
            param.Add("@RmBhtAmt", premittance.RmBhtAmt);
            param.Add("@CableMail", premittance.CableMail);
            param.Add("@CommLieu", premittance.CommLieu);
            param.Add("@CommTrans", premittance.CommTrans);
            param.Add("@CommCerti", premittance.CommCerti);
            param.Add("@CommExch", premittance.CommExch);
            param.Add("@CommBNet", premittance.CommBNet);
            param.Add("@FBCharge", premittance.FBCharge);
            param.Add("@OthCharge", premittance.OthCharge);
            param.Add("@TotCharge", premittance.TotCharge);
            param.Add("@TaxRefund", premittance.TaxRefund);
            param.Add("@TaxAmt", premittance.TaxAmt);
            param.Add("@RmFCD", premittance.RmFCD);
            param.Add("@PaySubType", premittance.PaySubType);
            param.Add("@PayMainType", premittance.PayMainType);
            param.Add("@FCDDesc", premittance.FCDDesc);
            param.Add("@PayMethod", premittance.PayMethod);
            param.Add("@DatePaid", premittance.DatePaid);
            param.Add("@ReceiptNo", premittance.ReceiptNo);
            param.Add("@FCDRecNo", premittance.FCDRecNo);
            param.Add("@AppvNo", premittance.AppvNo);
            //param.Add("@UpdateDate", premittance.UpdateDate);
            param.Add("@UserCode", premittance.UserCode);
            //param.Add("@AuthDate", premittance.AuthDate);
            param.Add("@AuthCode", premittance.AuthCode);
            param.Add("@GenAccFlag", premittance.GenAccFlag);
            //param.Add("@DateGenAcc", premittance.DateGenAcc);
            param.Add("@VoucherID", premittance.VoucherID);
            param.Add("@DMS", premittance.DMS);
            param.Add("@MT103", premittance.MT103);
            param.Add("@MT202", premittance.MT202);
            param.Add("@BhtNet", premittance.BhtNet);
            param.Add("@F20", premittance.F20);
            param.Add("@F21", premittance.F21);
            param.Add("@F32A", premittance.F32A);
            param.Add("@F23E", premittance.F23E);
            param.Add("@F26", premittance.F26);
            param.Add("@F71A", premittance.F71A);
            param.Add("@Bank53", premittance.Bank53);
            param.Add("@Addr53", premittance.Addr53);
            param.Add("@Bank54", premittance.Bank54);
            param.Add("@Addr54", premittance.Addr54);
            param.Add("@Bank56", premittance.Bank56);
            param.Add("@UID56", premittance.UID56);
            param.Add("@Addr56", premittance.Addr56);
            param.Add("@Bank57", premittance.Bank57);
            param.Add("@UID57", premittance.UID57);
            param.Add("@Addr57", premittance.Addr57);
            param.Add("@Bank58", premittance.Bank58);
            param.Add("@UID58", premittance.UID58);
            param.Add("@Addr58", premittance.Addr58);
            param.Add("@F72", premittance.F72);
            param.Add("@F33B", premittance.F33B);
            param.Add("@F71F", premittance.F71F);
            param.Add("@F70", premittance.F70);
            param.Add("@SwiftInfo", premittance.SwiftInfo);
            param.Add("@Allocation", premittance.Allocation);
            param.Add("@CenterID", premittance.CenterID);
            param.Add("@F71Adch", premittance.F71Adch);
            param.Add("@FBAmt", premittance.FBAmt);
            param.Add("@FBRate", premittance.FBRate);
            param.Add("@FBAmtThb", premittance.FBAmtThb);
            param.Add("@Bank52", premittance.Bank52);
            param.Add("@Addr52", premittance.Addr52);
            param.Add("@UID53", premittance.UID53);
            param.Add("@UID54", premittance.UID54);
            param.Add("@SwiftFile", premittance.SwiftFile);
            param.Add("@FAmt71", premittance.FAmt71);
            param.Add("@Bank53B", premittance.Bank53B);
            param.Add("@Bank54B", premittance.Bank54B);
            param.Add("@F50K", premittance.F50K);
            param.Add("@Cov202", premittance.Cov202);
            param.Add("@CF50", premittance.CF50);
            param.Add("@CF59", premittance.CF59);
            param.Add("@F59", premittance.F59);
            param.Add("@SenderAC", premittance.SenderAC);
            param.Add("@RateFlag", premittance.RateFlag);
            param.Add("@RateRemark", premittance.RateRemark);
            param.Add("@SWUuid", premittance.SWUuid);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PRemittance, dynamic>(
                    storedProcedure: "usp_pRemittanceRegistOutwardSWITInsert",
                    param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = resp.ToString(); //response.Message = "Register Doc Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<List<PRemittance>>> update([FromBody] PRemittance premittance)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@RemRefNo", premittance.RemRefNo);
            param.Add("@EventDate", premittance.EventDate);
            param.Add("@RemDate", premittance.RemDate);
            param.Add("@RegistDate", premittance.RegistDate);
            param.Add("@RemBankRefNo", premittance.RemBankRefNo);
            param.Add("@RemStatus", premittance.RemStatus);
            param.Add("@RecStatus", premittance.RecStatus);
            param.Add("@RemType", premittance.RemType);
            param.Add("@InUse", premittance.InUse);
            param.Add("@RemBank", premittance.RemBank);
            param.Add("@RemAddr", premittance.RemAddr);
            param.Add("@Cust_Bran", premittance.Cust_Bran);
            param.Add("@Cust_Code", premittance.Cust_Code);
            param.Add("@Cust_CCID", premittance.Cust_CCID);
            param.Add("@Cust_AO", premittance.Cust_AO);
            param.Add("@Cust_LO", premittance.Cust_LO);
            param.Add("@CustInfo1", premittance.CustInfo1);
            param.Add("@CustInfo2", premittance.CustInfo2);
            param.Add("@AppInfo1", premittance.AppInfo1);
            param.Add("@AppInfo2", premittance.AppInfo2);
            param.Add("@AppInfo3", premittance.AppInfo3);
            param.Add("@AppInfo4", premittance.AppInfo4);
            param.Add("@SenderInfo", premittance.SenderInfo);
            param.Add("@Rel_Code", premittance.Rel_Code);
            param.Add("@GoodsCode", premittance.GoodsCode);
            param.Add("@PurposeCode", premittance.PurposeCode);
            param.Add("@GoodsDesc", premittance.GoodsDesc);
            param.Add("@RemAcc", premittance.RemAcc);
            param.Add("@RemCcy", premittance.RemCcy);
            param.Add("@RateType", premittance.RateType);
            param.Add("@ExchRate", premittance.ExchRate);
            param.Add("@RmForward", premittance.RmForward);
            param.Add("@RmCcyAmt", premittance.RmCcyAmt);
            param.Add("@RmBhtAmt", premittance.RmBhtAmt);
            param.Add("@CableMail", premittance.CableMail);
            param.Add("@CommLieu", premittance.CommLieu);
            param.Add("@CommTrans", premittance.CommTrans);
            param.Add("@CommCerti", premittance.CommCerti);
            param.Add("@CommExch", premittance.CommExch);
            param.Add("@CommBNet", premittance.CommBNet);
            param.Add("@FBCharge", premittance.FBCharge);
            param.Add("@OthCharge", premittance.OthCharge);
            param.Add("@TotCharge", premittance.TotCharge);
            param.Add("@TaxRefund", premittance.TaxRefund);
            param.Add("@TaxAmt", premittance.TaxAmt);
            param.Add("@RmFCD", premittance.RmFCD);
            param.Add("@PaySubType", premittance.PaySubType);
            param.Add("@PayMainType", premittance.PayMainType);
            param.Add("@FCDDesc", premittance.FCDDesc);
            param.Add("@PayMethod", premittance.PayMethod);
            param.Add("@DatePaid", premittance.DatePaid);
            param.Add("@ReceiptNo", premittance.ReceiptNo);
            param.Add("@FCDRecNo", premittance.FCDRecNo);
            param.Add("@AppvNo", premittance.AppvNo);
            //param.Add("@UpdateDate", premittance.UpdateDate);
            param.Add("@UserCode", premittance.UserCode);
            //param.Add("@AuthDate", premittance.AuthDate);
            param.Add("@AuthCode", premittance.AuthCode);
            param.Add("@GenAccFlag", premittance.GenAccFlag);
            //param.Add("@DateGenAcc", premittance.DateGenAcc);
            param.Add("@VoucherID", premittance.VoucherID);
            param.Add("@DMS", premittance.DMS);
            param.Add("@MT103", premittance.MT103);
            param.Add("@MT202", premittance.MT202);
            param.Add("@BhtNet", premittance.BhtNet);
            param.Add("@F20", premittance.F20);
            param.Add("@F21", premittance.F21);
            param.Add("@F32A", premittance.F32A);
            param.Add("@F23E", premittance.F23E);
            param.Add("@F26", premittance.F26);
            param.Add("@F71A", premittance.F71A);
            param.Add("@Bank53", premittance.Bank53);
            param.Add("@Addr53", premittance.Addr53);
            param.Add("@Bank54", premittance.Bank54);
            param.Add("@Addr54", premittance.Addr54);
            param.Add("@Bank56", premittance.Bank56);
            param.Add("@UID56", premittance.UID56);
            param.Add("@Addr56", premittance.Addr56);
            param.Add("@Bank57", premittance.Bank57);
            param.Add("@UID57", premittance.UID57);
            param.Add("@Addr57", premittance.Addr57);
            param.Add("@Bank58", premittance.Bank58);
            param.Add("@UID58", premittance.UID58);
            param.Add("@Addr58", premittance.Addr58);
            param.Add("@F72", premittance.F72);
            param.Add("@F33B", premittance.F33B);
            param.Add("@F71F", premittance.F71F);
            param.Add("@F70", premittance.F70);
            param.Add("@SwiftInfo", premittance.SwiftInfo);
            param.Add("@Allocation", premittance.Allocation);
            param.Add("@CenterID", premittance.CenterID);
            param.Add("@F71Adch", premittance.F71Adch);
            param.Add("@FBAmt", premittance.FBAmt);
            param.Add("@FBRate", premittance.FBRate);
            param.Add("@FBAmtThb", premittance.FBAmtThb);
            param.Add("@Bank52", premittance.Bank52);
            param.Add("@Addr52", premittance.Addr52);
            param.Add("@UID53", premittance.UID53);
            param.Add("@UID54", premittance.UID54);
            param.Add("@SwiftFile", premittance.SwiftFile);
            param.Add("@FAmt71", premittance.FAmt71);
            param.Add("@Bank53B", premittance.Bank53B);
            param.Add("@Bank54B", premittance.Bank54B);
            param.Add("@F50K", premittance.F50K);
            param.Add("@Cov202", premittance.Cov202);
            param.Add("@CF50", premittance.CF50);
            param.Add("@CF59", premittance.CF59);
            param.Add("@F59", premittance.F59);
            param.Add("@SenderAC", premittance.SenderAC);
            param.Add("@RateFlag", premittance.RateFlag);
            param.Add("@RateRemark", premittance.RateRemark);
            param.Add("@SWUuid", premittance.SWUuid);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PRemittance, dynamic>(
                    storedProcedure: "usp_pRemittanceRegistOutwardSWITUpdate",
                    param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = resp.ToString();
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("cancel")]
        public async Task<ActionResult<List<PRemittanceCancelReq>>> cancel([FromBody] PRemittanceCancelReq premittancecancel)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@RemRefNo", premittancecancel.RemRefNo);
            param.Add("@UserCode", premittancecancel.UserCode);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                //var results = await _db.LoadData<PRemittanceCancelReq, dynamic>(
                //    storedProcedure: "usp_pRemittanceRegistInwardSWITCancel",
                //param);
                //var resp = param.Get<int>("@Resp");
                await _db.SaveData(
                  storedProcedure: "usp_pRemittanceRegistOutwardSWITCancel", param);

                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {
                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Cancel Remittance Data Complete";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Remittance code not exist";
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
