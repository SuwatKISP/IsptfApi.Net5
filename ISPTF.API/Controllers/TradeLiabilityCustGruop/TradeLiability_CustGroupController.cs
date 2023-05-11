using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
// ISPTF.Models.TradeCreditLimit;
using ISPTF.Models.TradeLiabilityCust;
using ISPTF.Models.TradeLiabilityCustGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.TradeLiabilityCustGroup

{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeLiability_CustGroupController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeLiability_CustGroupController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("ReferenceNoList")]
        public async Task<IEnumerable<ReferenceNoListGroup_Rsp>> ReferenceList(string? CenterID, string? CustCode, string? FacilityNo,string? NewFacilityNo, string? ReferDocNo, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@CustCode", CustCode);
            param.Add("@Facility_No", FacilityNo);
            param.Add("@NewFacility_No", NewFacilityNo);
            param.Add("@Refer_DocNo", ReferDocNo);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (FacilityNo == null)
            {
                param.Add("@Facility_No", "");
            }
            if (NewFacilityNo == null)
            {
                param.Add("@NewFacility_No", "");
            }
            if (ReferDocNo == null)
            {
                param.Add("@Refer_DocNo", "");
            }

            var results = await _db.LoadData<ReferenceNoListGroup_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_CustGroup_RefNo_SelectPage",
                        param);
            return results;
        }

        [HttpGet("InsGrdFacility")]
        public async Task<IEnumerable<InsGrdFacilityLiabilityGroup_Rsp>> GetInsGrdFacility(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);

            var results = await _db.LoadData<InsGrdFacilityLiabilityGroup_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_CustGroup_InsGrdFacility",
                        param);
            return results;
        }

        [HttpGet("InsGrdShare")]
        public async Task<IEnumerable<InsGrdShare_Rsp>> GetInsGrdShare(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);
            //if (CustCode == null)
            //{
            //    param.Add("@CustCode", "");
            //}

            var results = await _db.LoadData<InsGrdShare_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_CustGroup_InsGrdShare",
                        param);
            return results;
        }

        [HttpGet("Group")]
        public async Task<IEnumerable<Group_Rsp>> GetGroup(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);

            var results = await _db.LoadData<Group_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_CustGroup_Group",
                        param);
            return results;
        }

        [HttpGet("ChkOverDue")]
        public async Task<IEnumerable<ChkOverDue_Rsp>> GetOveDue(string? Cust_Code)
        //public async Task<ActionResult<ChkOverDue_Rsp>> GetSelect(string? Cust_Code)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", Cust_Code);

            //param.Add("@CHK_OverDue", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);

            var results = await _db.LoadData<ChkOverDue_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_CustGroup_CHKOverDue",
                        param);
            return results;
            //var chkoverdue = param.Get<dynamic>("@CHK_OverDue");
            //return Ok(chkoverdue);
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
                    storedProcedure: "usp_TradeLiability_CustGroup_Save",
                    param);

                //var PCustLimitRsp = param.Get<dynamic>("@PCustLimitRsp");

                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    //return Ok(PCustLimitRsp);
                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Save Customer Liability Group Complete";
                    return Ok(response);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Customer Liability Group Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









//old from Cust
        //[HttpGet("InsGrdAppvList")]
        //public async Task<IEnumerable<InsGrdAppvRsp>> GetInsGrdAppvList(string? CenterID, string? CustCode, string? CustName, int? Page, int? PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@CenterID", CenterID);
        //    param.Add("@Cust_Code", CustCode);
        //    param.Add("Cust_Name", CustName);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (CustCode == null)
        //    {
        //        param.Add("@Cust_Code", "");
        //    }
        //    if (CustName == null)
        //    {
        //        param.Add("@Cust_Name", "");
        //    }

        //    var results = await _db.LoadData<InsGrdAppvRsp, dynamic>(
        //                storedProcedure: "usp_TradeLiability_Cust_InsGrdAppvPage",
        //                param);
        //    return results;
        //}

        //[HttpGet("InsGrdAppvSelect")]
        ////public async Task<IEnumerable<ReleaseCustLisPageRsp>> GetSelect(string? CustCode, string? FacilityNo)
        //public async Task<ActionResult<CustReleaseSelectRsp>> GetSelect(string? Cust_Code, string? Facility_No, string? Appv_No, string? Refer_DocNo)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@Cust_Code", Cust_Code);
        //    param.Add("@Facility_No", Facility_No);
        //    param.Add("@Appv_No", Appv_No);
        //    param.Add("@Refer_DocNo", Refer_DocNo);

        //    param.Add("@CustReleaseSelectRsp", dbType: DbType.String,
        //       direction: System.Data.ParameterDirection.Output,
        //       size: 5215585);

        //    var results = await _db.LoadData<CustReleaseSelectRsp, dynamic>(
        //                storedProcedure: "usp_TradeLiability_Cust_InsGrdAppvSelect",
        //                param);
        //    var CustReleaseSelectRsp = param.Get<dynamic>("@CustReleaseSelectRsp");

        //    return Ok(CustReleaseSelectRsp);
        //}


        //[HttpGet("ReleaseList")]
        //public async Task<IEnumerable<ReleaseCustLisPageRsp>> GetReleaseList(string? FacilityNo, string? CustCode, string? CustName,int Page,int PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@FacilityNo", FacilityNo);
        //    param.Add("@CustCode", CustCode);
        //    param.Add("@CustName", CustName);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (FacilityNo == null)
        //    {
        //        param.Add("@FacilityNo", "");
        //    }
        //    if (CustCode == null)
        //    {
        //        param.Add("@CustCode", "");
        //    }
        //    if (CustName == null)
        //    {
        //        param.Add("@CustName", "");
        //    }

        //    var results = await _db.LoadData<ReleaseCustLisPageRsp, dynamic>(
        //                storedProcedure: "usp_TredCrLimit_ReleaseList_Page",
        //                param);
        //    return results;
        //}



        //[HttpPost("release")]
        //public async Task<ActionResult<string>> Release([FromBody] TardeLibCustReleaseReq TradeLibCustRelease)
        //{
        //    DynamicParameters param = new();
        //    param.Add("@Appv_No", TradeLibCustRelease.Appv_No);
        //    param.Add("@Cust_Code", TradeLibCustRelease.Cust_Code);
        //    param.Add("@Facility_No", TradeLibCustRelease.Facility_No);
        //    param.Add("@Facility_Type", TradeLibCustRelease.Facility_Type);
        //    param.Add("@Refer_DocNo", TradeLibCustRelease.Refer_DocNo);
        //    param.Add("@Revol_Flag", TradeLibCustRelease.Revol_Flag);
        //    param.Add("@Event", TradeLibCustRelease.Event);
        //    param.Add("@UserCode", TradeLibCustRelease.UserCode);

        //    param.Add("@Resp", dbType: DbType.Int32,
        //    //param.Add("@Resp", dbType: DbType.String,
        //        direction: System.Data.ParameterDirection.Output,
        //        size: 5215585);
        //    try
        //    {
        //        await _db.SaveData(
        //          storedProcedure: "usp_TradeLiability_Cust_Release", param);
        //        var resp = param.Get<int>("@Resp");
        //        //var resp = param.Get<string>("@Resp");
        //        if (resp > 0)
        //        {

        //            ReturnResponse response = new();
        //            response.StatusCode = "200";
        //            response.Message = "RELEASE Customer Liability Complete";
        //            return Ok(response);
        //        }
        //        else
        //        {

        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            //response.Message = "RELEASE Customer Liability Error";
        //            response.Message = resp.ToString();
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}








    }
}
