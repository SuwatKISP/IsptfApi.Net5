using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
// ISPTF.Models.TradeCreditLimit;
using ISPTF.Models.TradeLiabilityCustCancelReverse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.TradeLiabilityCustCancelReverse

{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeLiability_CustCancelReverseController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeLiability_CustCancelReverseController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("InsGrdAppvList")]
        public async Task<IEnumerable<CustCancelReverseInsGrdAppvListRsp>> GetInsGrdAppvList(string? Cancel_Flag, string? CenterID, string? CustCode, string? CustName, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Cancel_Flag", Cancel_Flag);
            param.Add("@CenterID", CenterID);
            param.Add("@Cust_Code", CustCode);
            param.Add("Cust_Name", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (CustCode == null)
            {
                param.Add("@Cust_Code", "");
            }
            if (CustName == null)
            {
                param.Add("@Cust_Name", "");
            }

            var results = await _db.LoadData<CustCancelReverseInsGrdAppvListRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_CustCancelReverse_InsGrdAppvPage",
                        param);
            return results;
        }

        [HttpGet("InsGrdAppvSelect")]
        //public async Task<ActionResult<CustCancelInsGrdAppvSelectRsp>> GetSelect(string? Cust_Code, string? Facility_No, string? Appv_No, string? Refer_DocNo, string? Cust_Parent, string? Refer_Facility)
        public async Task<ActionResult<CustCancelReverseInsGrdAppvSelectRsp>> GetSelect(string? Cust_Code, string? Facility_No, string? Appv_No, string? Refer_DocNo)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", Cust_Code);
            param.Add("@Facility_No", Facility_No);
            param.Add("@Appv_No", Appv_No);
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

            var results = await _db.LoadData<CustCancelReverseInsGrdAppvSelectRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_CustCancelReverse_InsGrdAppvSelect",
                        param);
            var InsGrdAppvSelectRsp = param.Get<dynamic>("@InsGrdAppvSelectRsp");

            return Ok(@InsGrdAppvSelectRsp);
        }


        [HttpPost("save")]
        public async Task<ActionResult<string>> Save([FromBody] CustCancelReverseSaveReq custcancelreverse)
        {
            DynamicParameters param = new();
            param.Add("@Cancel_Flag", custcancelreverse.Cancel_Flag);
            param.Add("@Cust_Code", custcancelreverse.Cust_Code);
            param.Add("@CenterID", custcancelreverse.CenterID);
            param.Add("@UserCode", custcancelreverse.UserCode);
            param.Add("@Appv_No", custcancelreverse.Appv_No);
            param.Add("@Refer_Type", custcancelreverse.Refer_Type);
            param.Add("@Refer_DocNo", custcancelreverse.Refer_DocNo);
            param.Add("@Facility_No", custcancelreverse.Facility_No);
            param.Add("@Refer_Ccy", custcancelreverse.Refer_Ccy);
            param.Add("@Refer_CcyAmt", custcancelreverse.Refer_CcyAmt);
            param.Add("@Refer_RefNo", custcancelreverse.Refer_RefNo);
            param.Add("@Credit_Line", custcancelreverse.Credit_Line);
            param.Add("@Refer_BhtAmt", custcancelreverse.Refer_BhtAmt);
            param.Add("@Facility_Flag", custcancelreverse.Facility_Flag);
            param.Add("@LbEvent", custcancelreverse.LbEvent);

            param.Add("@RespCancel", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                   storedProcedure: "usp_TradeLiability_CustCancelReverse_Save", param);

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
