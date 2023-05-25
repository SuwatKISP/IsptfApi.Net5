using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
// ISPTF.Models.TradeCreditLimit;
using ISPTF.Models.TradeLiabilityCust;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.TradeLiabilityCust

{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeLiability_CustController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeLiability_CustController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("ReferenceNoList")]
        public async Task<IEnumerable<ReferenceNoListRsp>> ReferenceList(string? CenterID, string? CustCode, string? ReferDocNo, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@CustCode", CustCode);
            param.Add("@Refer_DocNo", ReferDocNo);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (ReferDocNo == null)
            {
                param.Add("@Refer_DocNo", "");
            }

            var results = await _db.LoadData<ReferenceNoListRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Cust_RefNo_List",
                        param);
            return results;
        }

        [HttpGet("ReferenceNoSelect")]
        public async Task<ActionResult<List<ReferenceNoSelectRsp>>> ReferenceSelect(string? CustCode, string? ReferDocNo)
        {
            try
            {
             //  ISPModule.modLiability.RevalueLiab(CustCode, "");
               DynamicParameters param = new();
                param.Add("@Cust_Code", CustCode);
                param.Add("@Reg_Docno", ReferDocNo);

                

            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (ReferDocNo == null)
            {
                param.Add("@Refer_DocNo", "");
            }

            param.Add("@ReferNoRsp", dbType: DbType.String,
           direction: System.Data.ParameterDirection.Output,
           size: 5215585);

            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

                var results = await _db.LoadData<ReferenceNoSelectRsp, dynamic>(
                            storedProcedure: "usp_TradeLiability_Cust_RefNo_Select",
                            param);

                var resp = param.Get<dynamic>("@Resp");

                var refernorsp = param.Get<dynamic>("@ReferNoRsp");

                if (resp == 1)
                {
                    return Ok(refernorsp);
                }
                else if (resp == 9)
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Reference No. is not USED !!!";
                    return BadRequest(response);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Error for Select Facility No";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("InsGrdFacility")]
        public async Task<IEnumerable<InsGrdFacilityLiability_Rsp>> GetInsGrdFacility(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);

            var results = await _db.LoadData<InsGrdFacilityLiability_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Cust_InsGrdFacility",
                        param);
            return results;
        }

        [HttpGet("InsGrdFacilitySelect")]
        public async Task<ActionResult<InsGrdFacilitySelectJSON_Rsp>> GetInsGrdFacility(string Login , string? CustCode, string? ReferDocNo,string? Facility_No, string? Facility_No_Old)
        {
            DynamicParameters param = new();
            param.Add("@Reg_Login", Login);
            param.Add("@Cust_Code", CustCode);
            param.Add("@Reg_Docno", ReferDocNo);
            param.Add("@Facility_No", Facility_No);
            param.Add("@Facility_Old", Facility_No_Old);



            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (Facility_No == null)
            {
                param.Add("@Facility_No", "");
            }
            if (ReferDocNo == null)
            {
                param.Add("@Refer_DocNo", "");
            }

            param.Add("@ReferNoRsp", dbType: DbType.String,
           direction: System.Data.ParameterDirection.Output,
           size: 5215585);

            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<InsGrdFacilitySelectJSON_Rsp, dynamic>(
                            storedProcedure: "usp_TradeLiability_Cust_InsGrdFac_Select",
                            param);

                var resp = param.Get<dynamic>("@Resp");

                var refernorsp = param.Get<dynamic>("@ReferNoRsp");
    
                if (resp == 1)
                {
                    return Ok(refernorsp);
                }
                else if (resp == 2)
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Can not use Auto Create Facility or One Time";
                    return BadRequest(response);
                }
                else if (resp == 3)
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Credit Line in used Please select new or wait and save again";
                    return BadRequest(response);
                }

                else if (resp == 4)
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Selected Facility does not Support This Product";
                    return BadRequest(response);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Error for Select Facility No";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("InsGrdAppvList")]
        public async Task<IEnumerable<InsGrdAppvRsp>> GetInsGrdAppvList(string? ListType ,string? CenterID,string?UserCode, string? CustCode, string? CustName, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@listtype", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@UserCode", UserCode);
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

            var results = await _db.LoadData<InsGrdAppvRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Cust_InsGrdAppvPage",
                        param);
            return results;
        }

        [HttpGet("InsGrdAppvSelect")]
        //public async Task<IEnumerable<ReleaseCustLisPageRsp>> GetSelect(string? CustCode, string? FacilityNo)
        public async Task<ActionResult<InsGrdAppvSelectRsp>> GetSelect(string? Cust_Code, string? Facility_No, string? Appv_No)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", Cust_Code);
            param.Add("@Facility_No", Facility_No);
            param.Add("@Appv_No", Appv_No);

            param.Add("@CustReleaseSelectRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<InsGrdAppvSelectRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Cust_InsGrdAppvSelect",
                        param);
            var CustReleaseSelectRsp = param.Get<dynamic>("@CustReleaseSelectRsp");

            return Ok(CustReleaseSelectRsp);
        }

        [HttpGet("GetTotSum")]
        //public async Task<IEnumerable<ChkOverDue_Rsp>> GetTotSum(string? Cust_Code, string? Reg_Docno, double? TxBhtAmt)
        public async Task<ActionResult<GetTotalSumJson_Rsp>> GetTotSum(string? Cust_Code, string? Reg_Docno, double? TxBhtAmt)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", Cust_Code);
            param.Add("@Reg_Docno", Reg_Docno);
            param.Add("@TxBhtAmt", TxBhtAmt);

            param.Add("@ReferNoRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<GetTotalSumJson_Rsp, dynamic>(
                            storedProcedure: "usp_TradeLiability_Cust_GetTotSum",
                            param);

                var resp = param.Get<dynamic>("@Resp");

                var refernorsp = param.Get<dynamic>("@ReferNoRsp");

                if (resp == 1)
                {
                    return Ok(refernorsp);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Error for Get Total Sum";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


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

            //param.Add("@Resp2", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);

            try
            {
                var results = await _db.LoadData<PCustAppvRsp, dynamic>(
                    storedProcedure: "usp_TradeLiability_Cust_Save",
                    param);

                //var PCustLimitRsp = param.Get<dynamic>("@PCustLimitRsp");

                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                  //  ISPModule.modLiability.RevalueLiab(pCustAppvReq.Cust_Code, "");
                    //return Ok(PCustLimitRsp);
                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message =  "Save Customer Liability Complete";
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

        [HttpPost("release")]
        public async Task<ActionResult<string>> Release([FromBody] TardeLibCustReleaseReq TradeLibCustRelease)
        {
            DynamicParameters param = new();
            param.Add("@Appv_No", TradeLibCustRelease.Appv_No);
            param.Add("@Cust_Code", TradeLibCustRelease.Cust_Code);
            param.Add("@Facility_No", TradeLibCustRelease.Facility_No);
            param.Add("@Facility_Type", TradeLibCustRelease.Facility_Type);
            param.Add("@Refer_DocNo", TradeLibCustRelease.Refer_DocNo);
            param.Add("@Revol_Flag", TradeLibCustRelease.Revol_Flag);
            param.Add("@Event", TradeLibCustRelease.Event);
            param.Add("@UserCode", TradeLibCustRelease.UserCode);

            param.Add("@Resp", dbType: DbType.Int32,
            //param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_TradeLiability_Cust_Release", param);
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

        [HttpPost("UpdateUsing")]
        public async Task<ActionResult<List<UpdateUsingReq>>> chkinuse([FromBody] UpdateUsingReq updateusing)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Using_Type", updateusing.Using_Type);
            param.Add("@Cust_Code", updateusing.Cust_Code);
            param.Add("@Facility_No", updateusing.Facility_No);
            param.Add("@UsingRec", updateusing.UsingRec);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<UpdateUsingReq, dynamic>(
                    storedProcedure: "usp_TradeLiability_UpdateUsingRec",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Update UsingRec Complete";
                    return Ok(response);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Update UsingRec Not Complete";
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
