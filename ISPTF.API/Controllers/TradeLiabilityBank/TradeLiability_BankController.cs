﻿using Dapper;
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
        public async Task<IEnumerable<ReferenceNoLisBanktRsp>> ReferenceList(string? CenterID, string? CustCode, string? CustName, string? ReferDocNo, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Refer_DocNo", ReferDocNo);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }
            if (ReferDocNo == null)
            {
                param.Add("@Refer_DocNo", "");
            }

            var results = await _db.LoadData<ReferenceNoLisBanktRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_RefNo_List",
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
                            storedProcedure: "usp_TradeLiability_Bank_RefNo_Select",
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
        public async Task<IEnumerable<InsGrdFacilityLiabilityBank_Rsp>> GetInsGrdFacility(string? Bank_Code)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);

            var results = await _db.LoadData<InsGrdFacilityLiabilityBank_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_InsGrdFacility",
                        param);
            return results;
        }

       [HttpGet("InsGrdFacilitySelect")]
        public async Task<ActionResult<InsGrdFacilitySelectJSONBank_Rsp>> GetInsGrdFacility(string Login , string? BankCode, string? ReferDocNo,string? Facility_No, string? Facility_No_Old)
        {
            DynamicParameters param = new();
            param.Add("@Reg_Login", Login);
            param.Add("@Bank_Code", BankCode);
            param.Add("@Reg_Docno", ReferDocNo);
            param.Add("@Facility_No", Facility_No);
            param.Add("@Facility_Old", Facility_No_Old);



            if (BankCode == null)
            {
                param.Add("@Bank_Code", "");
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
                var results = await _db.LoadData<InsGrdFacilitySelectJSONBank_Rsp, dynamic>(
                            storedProcedure: "usp_TradeLiability_Bank_InsGrdFac_Select",
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
        public async Task<IEnumerable<InsGrdAppvBankRsp>> GetInsGrdAppvList(string? ListType,string? CenterID, string? UserCode,string? Bank_Code, string? CustCode, string? CustName, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@listtype", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@UserCode", UserCode);
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
        //public async Task<IEnumerable<ReleaseCustLisPageRsp>> GetSelect(string? CustCode, string? FacilityNo)
        public async Task<ActionResult<InsGrdAppvSelectRsp>> GetSelect(string? Bank_Code, string? Facility_No, string? Appv_No)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Facility_No", Facility_No);
            param.Add("@Appv_No", Appv_No);

            param.Add("@BankReleaseSelectRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<InsGrdAppvSelectRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_InsGrdAppvSelect",
                        param);
            var CustReleaseSelectRsp = param.Get<dynamic>("@BankReleaseSelectRsp");

            return Ok(CustReleaseSelectRsp);
        }


        [HttpGet("GetOriginalAmount")]
        public async Task<IEnumerable<OrignalAmtRsp>> GetOriginalAmount(string Bank_Code, string Facility_no,string Credit_Ccy)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Facility_no", Facility_no);
            param.Add("@Credit_Ccy", Credit_Ccy);

            var results = await _db.LoadData<OrignalAmtRsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_GetOriginalAmt",
                        param);
            return results;
        }

        [HttpGet("ChkOverDue")]
        public async Task<IEnumerable<ChkOverDueBank_Rsp>> GetOveDue(string? Bank_Code)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);

            //param.Add("@CHK_OverDue", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);

            var results = await _db.LoadData<ChkOverDueBank_Rsp, dynamic>(
                        storedProcedure: "usp_TradeLiability_Bank_CHKOverDue",
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
            param.Add("@PCustAppvRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);


            try
            {
                var results = await _db.LoadData<PCustAppvRsp, dynamic>(
                    storedProcedure: "usp_TradeLiability_Bank_Save",
                    param);

                var PCustAppvRsp = param.Get<dynamic>("@PCustAppvRsp");
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    //ReturnResponse response = new();
                    //response.StatusCode = "200";
                    //response.Message = "Save Bank Liability Complete";
                    return Ok(PCustAppvRsp);
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

        [HttpPost("AddTempReport")]
        public async Task<ActionResult<string>> Add2Temp([FromBody] LiabAdd2TempBankReq LiabAdd2Tem)
        {
            DynamicParameters param = new();
            param.Add("@AppvNo", LiabAdd2Tem.Appv_No);
            param.Add("@Bank_Code", LiabAdd2Tem.Bank_Code);
            param.Add("@Facility_No", LiabAdd2Tem.Facility_No);
            param.Add("@Credit_Ccy", LiabAdd2Tem.Credit_Ccy);
            param.Add("@TxStatus", LiabAdd2Tem.Status);
            param.Add("@LbLogin", LiabAdd2Tem.Login);
            param.Add("@TxCredit", LiabAdd2Tem.TxCredit);

            param.Add("@Resp", dbType: DbType.Int32,
            //param.Add("@Resp", dbType: DbType.String, 
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_TradeLiability_Bank_AddtmpLiab", param);
                var resp = param.Get<int>("@Resp");
                //var resp = param.Get<string>("@Resp");
                if (resp > 0)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Add tmp_liability  Complete";
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
