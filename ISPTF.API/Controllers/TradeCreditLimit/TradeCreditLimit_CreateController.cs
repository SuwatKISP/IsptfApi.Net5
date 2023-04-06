using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.TradeCreditLimit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.TradeCreditLimit

{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeCreditLimit_CreateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeCreditLimit_CreateController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("InsGrdFacility")]
        public async Task<IEnumerable<InsGrdFacilityRsp>> GetInsGrdFacility(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);

            var results = await _db.LoadData<InsGrdFacilityRsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdFacility",
                        param);
            return results;
        }

        [HttpGet("InsGrdShare")]
        public async Task<IEnumerable<InsGrdShareRsp>> InsGrdShare(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);

            var results = await _db.LoadData<InsGrdShareRsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdShare",
                        param);
            return results;
        }

        [HttpGet("InsGrdProduct")]
        public async Task<IEnumerable<InsGrdProductRsp>> GetInsGrdProduct(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);

            var results = await _db.LoadData<InsGrdProductRsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdProduct",
                        param);
            return results;
        }


        [HttpGet("InsGrdCCS")]
        public async Task<IEnumerable<InsGrdCCSRsp>> GetInsGrdCCS(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);

            var results = await _db.LoadData<InsGrdCCSRsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdCCS",
                        param);
            return results;
        }

        [HttpGet("ReleaseList")]
        public async Task<IEnumerable<ReleaseCustLisPageRsp>> GetReleaseList(string? FacilityNo, string? CustCode, string? CustName,int Page,int PageSize)
        {
            DynamicParameters param = new();

            param.Add("@FacilityNo", FacilityNo);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (FacilityNo == null)
            {
                param.Add("@FacilityNo", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<ReleaseCustLisPageRsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_ReleaseList_Page",
                        param);
            return results;
        }

        [HttpGet("select")]
        //public async Task<IEnumerable<ReleaseCustLisPageRsp>> GetSelect(string? CustCode, string? FacilityNo)
        public async Task<ActionResult<PCustLimitRsp>> GetSelect(string? Cust_Code, string? Facility_No)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", Cust_Code);
            param.Add("@Facility_No", Facility_No);

            param.Add("@PCustLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<PCustLimitRsp, dynamic>(
                        storedProcedure: "usp_pCustLimit_Select",
                        param);
            var PCustLimitRsp = param.Get<dynamic>("@PCustLimitRsp");

            return Ok(PCustLimitRsp);
        }



        [HttpPost("save")]
        public async Task<ActionResult<PCustLimitRsp>> Save([FromBody] PCustLimitReq pCustLimitReq)
        {
            DynamicParameters param = new();
            param.Add("@Cust_Code", pCustLimitReq.pcustlimit.Cust_Code);
            param.Add("@Facility_No", pCustLimitReq.pcustlimit.Facility_No);
            param.Add("@Seq_No", pCustLimitReq.pcustlimit.Seq_No);
            param.Add("@CCS_No", pCustLimitReq.pcustlimit.CCS_No);
            param.Add("@Limit_Code", pCustLimitReq.pcustlimit.Limit_Code);
            param.Add("@Status", pCustLimitReq.pcustlimit.Status);
            param.Add("@RecStatus", pCustLimitReq.pcustlimit.RecStatus);
            param.Add("@UsingRec", pCustLimitReq.pcustlimit.UsingRec);
            param.Add("@StartDate", pCustLimitReq.pcustlimit.StartDate);
            param.Add("@ExpiryDate", pCustLimitReq.pcustlimit.ExpiryDate);
            param.Add("@ExpiryDate2", pCustLimitReq.pcustlimit.ExpiryDate2);
            param.Add("@Parent_Id", pCustLimitReq.pcustlimit.Parent_Id);
            param.Add("@Facility_Type", pCustLimitReq.pcustlimit.Facility_Type);
            param.Add("@Refer_Cust", pCustLimitReq.pcustlimit.Refer_Cust);
            param.Add("@Refer_Facility", pCustLimitReq.pcustlimit.Refer_Facility);
            param.Add("@Revol_Flag", pCustLimitReq.pcustlimit.Revol_Flag);
            param.Add("@Share_Flag", pCustLimitReq.pcustlimit.Share_Flag);
            param.Add("@Share_Type", pCustLimitReq.pcustlimit.Share_Type);
            param.Add("@Credit_Ccy", pCustLimitReq.pcustlimit.Credit_Ccy);
            param.Add("@Credit_Amount", pCustLimitReq.pcustlimit.Credit_Amount);
            param.Add("@Credit_Share", pCustLimitReq.pcustlimit.Credit_Share);
            param.Add("@Origin_Amount", pCustLimitReq.pcustlimit.Origin_Amount);
            param.Add("@Share_Amount", pCustLimitReq.pcustlimit.Share_Amount);
            param.Add("@Susp_Amount", pCustLimitReq.pcustlimit.Susp_Amount);
            param.Add("@Hold_Amount", pCustLimitReq.pcustlimit.Hold_Amount);
            param.Add("@Ear_Amount", pCustLimitReq.pcustlimit.Ear_Amount);
            param.Add("@Remark", pCustLimitReq.pcustlimit.Remark);
            param.Add("@Condition", pCustLimitReq.pcustlimit.Condition);
            param.Add("@Block_Code", pCustLimitReq.pcustlimit.Block_Code);
            param.Add("@BlockDate", pCustLimitReq.pcustlimit.BlockDate);
            param.Add("@Block_Note", pCustLimitReq.pcustlimit.Block_Note);
            param.Add("@RecCode", pCustLimitReq.pcustlimit.RecCode);
            param.Add("@AutoRec", pCustLimitReq.pcustlimit.AutoRec);
            param.Add("@UpdNo", pCustLimitReq.pcustlimit.UpdNo);
          //  param.Add("@CreateDate", pCustLimitReq.CreateDate);
            //param.Add("@UpdateDate", pCustLimitReq.UpdateDate);
            param.Add("@UserCode", pCustLimitReq.pcustlimit.UserCode);
            //param.Add("@AuthDate", pCustLimitReq.AuthDate);
            //param.Add("@AuthCode", pCustLimitReq.AuthCode);
            param.Add("@CFRRate", pCustLimitReq.pcustlimit.CFRRate);
            param.Add("@CFRSpread", pCustLimitReq.pcustlimit.CFRSpread);
            param.Add("@CFRAmount", pCustLimitReq.pcustlimit.CFRAmount);
            param.Add("@Campaign_Code", pCustLimitReq.pcustlimit.Campaign_Code);
            param.Add("@Campaign_EffDate", pCustLimitReq.pcustlimit.Campaign_EffDate);
            param.Add("@CLMS_Flag", pCustLimitReq.pcustlimit.CLMS_Flag);

            var dtCust = new DataTable();
            //-----pCustShare-------------
            dtCust.Columns.Add("Cust_Code", typeof(string));
            dtCust.Columns.Add("Facility_No", typeof(string));
            dtCust.Columns.Add("Seqno", typeof(int));
            dtCust.Columns.Add("Share_Cust", typeof(string));
            dtCust.Columns.Add("Share_Imp", typeof(string));
            dtCust.Columns.Add("Share_Exp", typeof(string));
            dtCust.Columns.Add("Share_Dlc", typeof(string));
            dtCust.Columns.Add("Share_LG", typeof(string));
            dtCust.Columns.Add("Share_Limit", typeof(string));
            dtCust.Columns.Add("Share_Credit", typeof(double));
            dtCust.Columns.Add("Share_Used", typeof(double));
            dtCust.Columns.Add("Share_CCS", typeof(string));
            dtCust.Columns.Add("Share_Mode", typeof(string));
            dtCust.Columns.Add("Status", typeof(string));
            if (pCustLimitReq.pcustshare != null)
            {
                for (int i = 0; i < pCustLimitReq.pcustshare.Length; i++)
                {
                    dtCust.Rows.Add(
                       pCustLimitReq.pcustshare[i].Cust_Code
                        , pCustLimitReq.pcustshare[i].Facility_No
                        , pCustLimitReq.pcustshare[i].Seqno
                        , pCustLimitReq.pcustshare[i].Share_Cust
                        , pCustLimitReq.pcustshare[i].Share_Imp
                        , pCustLimitReq.pcustshare[i].Share_Exp
                        , pCustLimitReq.pcustshare[i].Share_Dlc
                        , pCustLimitReq.pcustshare[i].Share_LG
                        , pCustLimitReq.pcustshare[i].Share_Limit
                        , pCustLimitReq.pcustshare[i].Share_Credit
                        , pCustLimitReq.pcustshare[i].Share_Used
                        , pCustLimitReq.pcustshare[i].Share_CCS
                        , pCustLimitReq.pcustshare[i].Share_Mode
                        , pCustLimitReq.pcustshare[i].Status
                        );
                }
            }
            param.Add("@CustShare", dtCust.AsTableValuedParameter("Type_pCustShare"));

            //-----pCustLmProduct
             dtCust = new DataTable();
            dtCust.Columns.Add("Cust_Code", typeof(string));
            dtCust.Columns.Add("Facility_No", typeof(string));
            dtCust.Columns.Add("SeqNo", typeof(int));
            dtCust.Columns.Add("Prod_Code", typeof(string));
            dtCust.Columns.Add("Prod_Limit", typeof(string));
            dtCust.Columns.Add("StartDate", typeof(DateTime));
            dtCust.Columns.Add("ExpiryDate", typeof(DateTime));
            dtCust.Columns.Add("ProdAmount", typeof(float));
            dtCust.Columns.Add("CCS_No", typeof(string));
            dtCust.Columns.Add("CCS_ref", typeof(string));
            dtCust.Columns.Add("CCS_Limit", typeof(string));
            if (pCustLimitReq.pcustlmproduct != null)
            {
                for (int i = 0; i < pCustLimitReq.pcustlmproduct.Length; i++)
                {
                    dtCust.Rows.Add(
                       pCustLimitReq.pcustlmproduct[i].Cust_Code
                        , pCustLimitReq.pcustlmproduct[i].Facility_No
                        , pCustLimitReq.pcustlmproduct[i].SeqNo
                        , pCustLimitReq.pcustlmproduct[i].Prod_Code
                        , pCustLimitReq.pcustlmproduct[i].Prod_Limit
                        , pCustLimitReq.pcustlmproduct[i].StartDate
                        , pCustLimitReq.pcustlmproduct[i].ExpiryDate
                        , pCustLimitReq.pcustlmproduct[i].ProdAmount
                        , pCustLimitReq.pcustlmproduct[i].CCS_No
                        , pCustLimitReq.pcustlmproduct[i].CCS_ref
                        , pCustLimitReq.pcustlmproduct[i].CCS_Limit
                        );
                }
            }
            param.Add("@CustProduct", dtCust.AsTableValuedParameter("Type_pCustLmProduct"));

            //-----pCustLmCCS
            dtCust = new DataTable();
            dtCust.Columns.Add("Cust_Code", typeof(string));
            dtCust.Columns.Add("Facility_No", typeof(string));
            dtCust.Columns.Add("SeqNo", typeof(int));
            dtCust.Columns.Add("Prod_Mod", typeof(string));
            dtCust.Columns.Add("Prod_Ref", typeof(string));
            dtCust.Columns.Add("CCS_Ccy", typeof(string));
            dtCust.Columns.Add("CCS_DocStat", typeof(string));
            dtCust.Columns.Add("CCS_Stat", typeof(string));
            dtCust.Columns.Add("CCS_No", typeof(string));
            dtCust.Columns.Add("CCS_LmType", typeof(string));
            if (pCustLimitReq.pcustlmccs != null)
            {
                for (int i = 0; i < pCustLimitReq.pcustlmccs.Length; i++)
                {
                    dtCust.Rows.Add(
                       pCustLimitReq.pcustlmccs[i].Cust_Code
                        , pCustLimitReq.pcustlmccs[i].Facility_No
                        , pCustLimitReq.pcustlmccs[i].SeqNo
                        , pCustLimitReq.pcustlmccs[i].Prod_Mod
                        , pCustLimitReq.pcustlmccs[i].Prod_Ref
                        , pCustLimitReq.pcustlmccs[i].CCS_Ccy
                        , pCustLimitReq.pcustlmccs[i].CCS_DocStat
                        , pCustLimitReq.pcustlmccs[i].CCS_Stat
                        , pCustLimitReq.pcustlmccs[i].CCS_No
                        , pCustLimitReq.pcustlmccs[i].CCS_LmType
                        );
                }
            }
            param.Add("@CustCCS", dtCust.AsTableValuedParameter("Type_pCustLmCCS"));


            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            param.Add("@PCustLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            try
            {
                var results = await _db.LoadData<PCustLimitRsp, dynamic>(
                    storedProcedure: "usp_pCustLimit_Create_Save",
                    param);

                var PCustLimitRsp = param.Get<dynamic>("@PCustLimitRsp");

                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(PCustLimitRsp);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Save Customer Credit Limit Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("release")]
        public async Task<ActionResult<string>> Release([FromBody] PCustLimitReleaseReq pCustLimitReleaseReq)
        {
            DynamicParameters param = new();
            param.Add("@Cust_Code", pCustLimitReleaseReq.Cust_Code);
            param.Add("@Facility_No", pCustLimitReleaseReq.Facility_No);
            param.Add("@AuthCode", pCustLimitReleaseReq.UserCode);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pCustLimit_Create_Release", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Release Customer Credit Limit Complete";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    //response.Message = "Export BC No Not Exist";
                    response.Message = resp.ToString();
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetCombineLineAmt")]
        public async Task<IEnumerable<SumAmountCustRsp>> SumAmtCust(string? CustCode, string? SumType)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);
            param.Add("SumType", SumType);

            var results = await _db.LoadData<SumAmountCustRsp, dynamic>(
                        storedProcedure: "usp_GetSumAmtCust",
                        param);
            return results;
        }






    }
}
