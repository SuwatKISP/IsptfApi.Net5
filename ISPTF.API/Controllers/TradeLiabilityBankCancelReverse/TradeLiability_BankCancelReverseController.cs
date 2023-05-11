using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
// ISPTF.Models.TradeCreditLimit;
using ISPTF.Models.TradeLiabilityCustCancelReverse;
using ISPTF.Models.TradeLiabilityBankCancelReverse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.TradeLiabilityBankCancelReverse

{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeLiability_BankCancelReverseController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeLiability_BankCancelReverseController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("InsGrdAppvList")]
        public async Task<IEnumerable<BankCancelReverseInsGrdAppvListRsp>> GetInsGrdAppvList(string? Cancel_Flag, string? CenterID,string? BankCode, string? CustCode, string? CustName, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Cancel_Flag", Cancel_Flag);
            param.Add("@CenterID", CenterID);
            param.Add("@Bank_Code", BankCode);
            param.Add("@Cust_Code", CustCode);
            param.Add("Cust_Name", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BankCode == null)
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

            var results = await _db.LoadData<BankCancelReverseInsGrdAppvListRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_BankCancelReverse_InsGrdAppvPage",
                        param);
            return results;
        }

        [HttpGet("InsGrdAppvSelect")]
        //public async Task<ActionResult<BankCancelReverseInsGrdAppvSelectRsp>> GetSelect(string? Cust_Code, string? Facility_No, string? Appv_No, string? Refer_DocNo, string? Cust_Parent, string? Refer_Facility)
        public async Task<ActionResult<CustCancelReverseInsGrdAppvSelectRsp>> GetSelect(string? Bank_Code,string? Refer_Ccy, string? Facility_No, string? Refer_DocNo)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Facility_No", Facility_No);
            param.Add("@Refer_Ccy", Refer_Ccy);
            param.Add("@Refer_DocNo", Refer_DocNo);
            //param.Add("@Cust_Parent", Cust_Parent);
            //param.Add("@Refer_Facility", Refer_Facility);

            //if (Cust_Parent == null)
            //{
            //    param.Add("@Cust_Parent", "");
            //}
            //if (Refer_Facility == null)
            //{
            //    param.Add("@Refer_Facility", "");
            //}

            param.Add("@InsGrdAppvSelectRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<BankCancelReverseInsGrdAppvSelectRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_BankCancelReverse_InsGrdAppvSelect",
                        param);
            var InsGrdAppvSelectRsp = param.Get<dynamic>("@InsGrdAppvSelectRsp");

            return Ok(@InsGrdAppvSelectRsp);
        }


        [HttpPost("save")]
        public async Task<ActionResult<string>> Save([FromBody] BankCancelReverseSaveReq bankcancelreverse)
        {
            DynamicParameters param = new();
            param.Add("@Cancel_Flag", bankcancelreverse.Cancel_Flag);
            param.Add("@Bank_Code", bankcancelreverse.Bank_Code);
            param.Add("@CenterID", bankcancelreverse.CenterID);
            param.Add("@UserCode", bankcancelreverse.UserCode);
            param.Add("@Appv_No", bankcancelreverse.Appv_No);
            param.Add("@Refer_Type", bankcancelreverse.Refer_Type);
            param.Add("@Refer_DocNo", bankcancelreverse.Refer_DocNo);
            param.Add("@Facility_No", bankcancelreverse.Facility_No);
            param.Add("@Refer_Ccy", bankcancelreverse.Refer_Ccy);
            param.Add("@Refer_CcyAmt", bankcancelreverse.Refer_CcyAmt);
            param.Add("@Refer_RefNo", bankcancelreverse.Refer_RefNo);
            param.Add("@Credit_Line", bankcancelreverse.Credit_Line);
            param.Add("@Refer_BhtAmt", bankcancelreverse.Refer_BhtAmt);
            param.Add("@Facility_Flag", bankcancelreverse.Facility_Flag);
            param.Add("@Credit_ccy", bankcancelreverse.Credit_ccy);
            param.Add("@LbEvent", bankcancelreverse.LbEvent);

            param.Add("@RespCancel", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                   storedProcedure: "usp_TradeLiability_BankCancelReverse_Save", param);

                var respcancel = param.Get<int>("@RespCancel");
                if (respcancel > 0)
                {
                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Save Customer Liability Complete";
                    return Ok(response);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Customer Liability Error";
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
