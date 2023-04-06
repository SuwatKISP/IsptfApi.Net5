using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
// ISPTF.Models.TradeCreditLimit;
using ISPTF.Models.TradeLiabilityCust;
using ISPTF.Models.TradeLiabilityBank;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.TradeLiabilityBank

{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeLiability_BankController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeLiability_BankController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("ReferenceNoList")]
        public async Task<IEnumerable<ReferenceNoLisBanktRsp>> ReferenceList(string? CenterID, string? CustCode, string? FacilityNo,string? Bank_Code, string? Credit_Ccy, string? ReferDocNo, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@CustCode", CustCode);
            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Credit_Ccy", Credit_Ccy);
            param.Add("@Facility_No", FacilityNo);
            param.Add("@Refer_DocNo", ReferDocNo);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (Bank_Code == null)
            {
                param.Add("@Bank_Code", "");
            }
            if (Credit_Ccy == null)
            {
                param.Add("@Credit_Ccy", "");
            }
            if (FacilityNo == null)
            {
                param.Add("@Facility_No", "");
            }
            if (ReferDocNo == null)
            {
                param.Add("@Refer_DocNo", "");
            }

            var results = await _db.LoadData<ReferenceNoLisBanktRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_RefNo_SelectPage",
                        param);
            return results;
        }

        [HttpGet("InsGrdFacility")]
        public async Task<IEnumerable<InsGrdFacilityLiabilityBank_Rsp>> GetInsGrdFacility(string? Bank_Code)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);

            var results = await _db.LoadData<InsGrdFacilityLiabilityBank_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_InsGrdFacility",
                        param);
            return results;
        }


        [HttpGet("InsGrdAppvList")]
        public async Task<IEnumerable<InsGrdAppvBankRsp>> GetInsGrdAppvList(string? CenterID,string? Bank_Code, string? CustCode, string? CustName, int? Page, int? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@CenterID", CenterID);
            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Cust_Code", CustCode);
            param.Add("Cust_Name", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (Bank_Code == null)
            {
                param.Add("@Bank_Code", "");
            }
            if (CustCode == null)
            {
                param.Add("@Cust_Code", "");
            }
            if (CustName == null)
            {
                param.Add("@Cust_Name", "");
            }

            var results = await _db.LoadData<InsGrdAppvBankRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_InsGrdAppvPage",
                        param);
            return results;
        }

        [HttpGet("InsGrdAppvSelect")]
        public async Task<ActionResult<BankReleaseSelectRsp>> GetSelect(string? Bank_Code,string? Cust_Code,string? Credit_Ccy, string? Facility_No, string? Appv_No, string? Refer_DocNo)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", Bank_Code);         
            param.Add("@Cust_Code", Cust_Code);
            param.Add("Credit_Ccy", Credit_Ccy);
            param.Add("@Facility_No", Facility_No);
            param.Add("@Appv_No", Appv_No);
            param.Add("@Refer_DocNo", Refer_DocNo);

            param.Add("@BankReleaseSelectRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<BankReleaseSelectRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_InsGrdAppvSelect",
                        param);
            var CustReleaseSelectRsp = param.Get<dynamic>("@BankReleaseSelectRsp");

            return Ok(CustReleaseSelectRsp);
        }


        [HttpPost("save")]
        public async Task<ActionResult<PCustAppvRsp>> Save([FromBody] PCustAppvReq pCustAppvReq)
        {
            DynamicParameters param = new();
            param.Add("@Appv_No", pCustAppvReq.Appv_No);
            param.Add("@RecStatus", pCustAppvReq.RecStatus);
            param.Add("@Appv_Status", pCustAppvReq.Appv_Status);
            param.Add("@EntryDate", pCustAppvReq.EntryDate);
            param.Add("@Refer_Type", pCustAppvReq.Refer_Type);
            param.Add("@Refer_DocNo", pCustAppvReq.Refer_DocNo);
            param.Add("@Refer_RefNo", pCustAppvReq.Refer_RefNo);
            param.Add("@Refer_Ccy", pCustAppvReq.Refer_Ccy);
            param.Add("@Refer_CcyAmt", pCustAppvReq.Refer_CcyAmt);
            param.Add("@Refer_ExchRate", pCustAppvReq.Refer_ExchRate);
            param.Add("@Refer_BhtAmt", pCustAppvReq.Refer_BhtAmt);
            param.Add("@Cust_Code", pCustAppvReq.Cust_Code);
            param.Add("@Facility_Flag", pCustAppvReq.Facility_Flag);
            param.Add("@Facility_No", pCustAppvReq.Facility_No);
            param.Add("@Hold_Cust", pCustAppvReq.Hold_Cust);
            param.Add("@Hold_FacNo", pCustAppvReq.Hold_FacNo);
            param.Add("@Hold_Amt", pCustAppvReq.Hold_Amt);
            param.Add("@Credit_Line", pCustAppvReq.Credit_Line);
            param.Add("@Liab_Amt", pCustAppvReq.Liab_Amt);
            param.Add("@Appv_Amt", pCustAppvReq.Appv_Amt);
            param.Add("@Share_Amt", pCustAppvReq.Share_Amt);
            param.Add("@Susp_Amt", pCustAppvReq.Susp_Amt);
            param.Add("@TotCredit_Line", pCustAppvReq.TotCredit_Line);
            param.Add("@TotLiab_Amt", pCustAppvReq.TotLiab_Amt);
            param.Add("@TotAppv_Amt", pCustAppvReq.TotAppv_Amt);
            param.Add("@TotShare_Amt", pCustAppvReq.TotShare_Amt);
            param.Add("@TotSusp_Amt", pCustAppvReq.TotSusp_Amt);
            param.Add("@Comment", pCustAppvReq.Comment);
            param.Add("@Event", pCustAppvReq.Event);
            param.Add("@Appv_Cancel", pCustAppvReq.Appv_Cancel);
            param.Add("@Appv_CanDate", pCustAppvReq.Appv_CanDate);
            param.Add("@Reverse_Amt", pCustAppvReq.Reverse_Amt);
            param.Add("@Share_Type", pCustAppvReq.Share_Type);
            param.Add("@TxHold_Amt", pCustAppvReq.TxHold_Amt);
            param.Add("@TotHold_Amt", pCustAppvReq.TotHold_Amt);
            param.Add("@NonLine_Amt", pCustAppvReq.NonLine_Amt);
            param.Add("@TotNonLine_Amt", pCustAppvReq.TotNonLine_Amt);
            param.Add("@Remark", pCustAppvReq.Remark);
            param.Add("@UpdateDate", pCustAppvReq.UpdateDate);
            param.Add("@UserCode", pCustAppvReq.UserCode);
            param.Add("@AuthDate", pCustAppvReq.AuthDate);
            param.Add("@AuthCode", pCustAppvReq.AuthCode);
            param.Add("@CenterID", pCustAppvReq.CenterID);
            param.Add("@Bank_Code", pCustAppvReq.Bank_Code);
            param.Add("@Over_Amt", pCustAppvReq.Over_Amt);
            param.Add("@Group_Amt", pCustAppvReq.Group_Amt);
            param.Add("@Available_Amt", pCustAppvReq.Available_Amt);
            param.Add("@TotOver_Amt", pCustAppvReq.TotOver_Amt);
            param.Add("@TotGroup_Amt", pCustAppvReq.TotGroup_Amt);
            param.Add("@TAvailable_Amt", pCustAppvReq.TAvailable_Amt);
            param.Add("@Campaign_Code", pCustAppvReq.Campaign_Code);
            param.Add("@Campaign_EffDate", pCustAppvReq.Campaign_EffDate);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            //param.Add("@PCustLimitRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);

            try
            {
                var results = await _db.LoadData<PCustAppvRsp, dynamic>(
                    storedProcedure: "usp_TradeLiability_Bank_Save",
                    param);

                //var PCustLimitRsp = param.Get<dynamic>("@PCustLimitRsp");

                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    //return Ok(PCustLimitRsp);
                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Save Bank Liability Complete";
                    return Ok(response);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Bank Liability Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("release")]
            public async Task<ActionResult<string>> Release([FromBody] TardeLibBankReleaseReq TradeLibBankRelease)
            {
                DynamicParameters param = new();
                param.Add("@Appv_No", TradeLibBankRelease.Appv_No);
                param.Add("@Bank_Code", TradeLibBankRelease.Bank_Code);
                param.Add("@Facility_No", TradeLibBankRelease.Facility_No);
                param.Add("@Facility_Type", TradeLibBankRelease.Facility_Type);
                param.Add("@Credit_Ccy", TradeLibBankRelease.Credit_Ccy);
                param.Add("@Refer_DocNo", TradeLibBankRelease.Refer_DocNo);
                param.Add("@Revol_Flag", TradeLibBankRelease.Revol_Flag);
                param.Add("@Event", TradeLibBankRelease.Event);
                param.Add("@UserCode", TradeLibBankRelease.UserCode);
                param.Add("@Resp", dbType: DbType.Int32,
            //param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_TradeLiability_Bank_Release", param);
                var resp = param.Get<int>("@Resp");
                //var resp = param.Get<string>("@Resp");
                if (resp > 0)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "RELEASE Customer Liability Complete";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    //response.Message = "RELEASE Customer Liability Error";
                    response.Message = resp.ToString();
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
