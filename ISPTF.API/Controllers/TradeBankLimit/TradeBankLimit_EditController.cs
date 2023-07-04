using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.TradeBankLimit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.TradeBankLimit

{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeBankLimit_EditController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeBankLimit_EditController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("InsGrdFacility")]
        public async Task<IEnumerable<InsGrdFacilityBK_EditCrLimitRsp>> GetInsGrdFacility(string? Bank_Code)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);

            var results = await _db.LoadData<InsGrdFacilityBK_EditCrLimitRsp, dynamic>(
                        storedProcedure: "usp_TredBankLimit_InsGrdFacility_EditCRLimit",
                        param);
            return results;
        }


        [HttpGet("InsGrdProduct")]
        public async Task<IEnumerable<InsGrdProductBK_EditCrLimitRsp>> GetInsGrdProduct(string? Bank_Code, string? Facility_No)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Facility_No", Facility_No);

            var results = await _db.LoadData<InsGrdProductBK_EditCrLimitRsp, dynamic>(
                        storedProcedure: "usp_TredBankLimit_InsGrdProduct_EditCRLimit",
                        param);
            return results;
        }


        [HttpGet("InsGrdPending")]
        public async Task<IEnumerable<InsGrdPendingBK_EditCrLimitRsp>> GetReleaseList(string? Bank_Code, int? Page, int? PageSize)
        {
            DynamicParameters param = new();


            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (Bank_Code == null)
            {
                param.Add("@Bank_Code", "");
            }

            var results = await _db.LoadData<InsGrdPendingBK_EditCrLimitRsp, dynamic>(
                        storedProcedure: "usp_TredBankLimit_InsGrdPending_EditCRLimit",
                        param);
            return results;
        }

        [HttpGet("select")]
        public async Task<ActionResult<PBLogLimitRsp>> GetSelect(string? Bank_Code, string? Facility_No)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Facility_No", Facility_No);

            param.Add("@PBankLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<PBLogLimitRsp, dynamic>(
                        storedProcedure: "usp_pBankLimit_SelectEdit",
                        param);
            var PBankLimitRsp = param.Get<dynamic>("@PBankLimitRsp");

            return Ok(PBankLimitRsp);
        }



        [HttpPost("save")]
        public async Task<ActionResult<PBLogLimitRsp>> Save([FromBody] PBLogLimitReq pBLogLimitReq)
        {
            DynamicParameters param = new();
            param.Add("@LRecType", pBLogLimitReq.pbloglimit.LRecType);
            param.Add("@LLogSeq", pBLogLimitReq.pbloglimit.LLogSeq);
            param.Add("@LBank_Code", pBLogLimitReq.pbloglimit.LBank_Code);
            param.Add("@LFacility_No", pBLogLimitReq.pbloglimit.LFacility_No);
            param.Add("@LCCS_No", pBLogLimitReq.pbloglimit.LCCS_No);
            param.Add("@LLimit_Code", pBLogLimitReq.pbloglimit.LLimit_Code);
            param.Add("@LUpdNo", pBLogLimitReq.pbloglimit.LUpdNo);
            param.Add("@LStatus", pBLogLimitReq.pbloglimit.LStatus);
            param.Add("@LStartDate", pBLogLimitReq.pbloglimit.LStartDate);
            param.Add("@LExpiryDate", pBLogLimitReq.pbloglimit.LExpiryDate);
            param.Add("@LFacility_Type", pBLogLimitReq.pbloglimit.LFacility_Type);
            param.Add("@LRevol_Flag", pBLogLimitReq.pbloglimit.LRevol_Flag);
            param.Add("@LCredit_Ccy", pBLogLimitReq.pbloglimit.LCredit_Ccy);
            param.Add("@LCredit_Amount", pBLogLimitReq.pbloglimit.LCredit_Amount);
            param.Add("@LCredit_Share", pBLogLimitReq.pbloglimit.LCredit_Share);
            param.Add("@LRemark", pBLogLimitReq.pbloglimit.LRemark);
            param.Add("@LBlock_Code", pBLogLimitReq.pbloglimit.LBlock_Code);
            param.Add("@LBlockDate", pBLogLimitReq.pbloglimit.LBlockDate);
            param.Add("@LBlock_Note", pBLogLimitReq.pbloglimit.LBlock_Note);
            param.Add("@LHold_Amount", pBLogLimitReq.pbloglimit.LHold_Amount);
            param.Add("@RecStatus", pBLogLimitReq.pbloglimit.RecStatus);
            param.Add("@LCreateDate", pBLogLimitReq.pbloglimit.CreateDate);
            //param.Add("@UpdateDate", pBLogLimitReq.pbloglimit.UpdateDate);
            param.Add("@UserCode", pBLogLimitReq.pbloglimit.UserCode);
            //param.Add("@AuthDate", pBLogLimitReq.pbloglimit.AuthDate);
            param.Add("@AuthCode", pBLogLimitReq.pbloglimit.AuthCode);
            param.Add("@LSseqno", pBLogLimitReq.pbloglimit.LSseqno);
            param.Add("@LCondition", pBLogLimitReq.pbloglimit.LCondition);
            param.Add("@LOrigin_Amount", pBLogLimitReq.pbloglimit.LOrigin_Amount);
            param.Add("@LCFRRate", pBLogLimitReq.pbloglimit.LCFRRate);
            param.Add("@LCFRSpread", pBLogLimitReq.pbloglimit.LCFRSpread);
            param.Add("@LCFRAmount", pBLogLimitReq.pbloglimit.LCFRAmount);
            param.Add("@lCnty_Code", pBLogLimitReq.pbloglimit.lCnty_Code);
            param.Add("@Campaign_Code", pBLogLimitReq.pbloglimit.Campaign_Code);
            param.Add("@Campaign_EffDate", pBLogLimitReq.pbloglimit.Campaign_EffDate);


            var dtBank = new DataTable();
            //-----pBLogLmProduct
            dtBank = new DataTable();
            dtBank.Columns.Add("LRecType", typeof(string));
            dtBank.Columns.Add("LLogSeq", typeof(int));
            dtBank.Columns.Add("LBank_Code", typeof(string));
            dtBank.Columns.Add("LFacility_No", typeof(string));
            dtBank.Columns.Add("LseqNo", typeof(int));
            dtBank.Columns.Add("LProd_Code", typeof(string));
            dtBank.Columns.Add("LProd_Limit", typeof(string));
            dtBank.Columns.Add("LStartDate", typeof(DateTime));
            dtBank.Columns.Add("LExpiryDate", typeof(DateTime));
            dtBank.Columns.Add("LProdAmount", typeof(double));
            dtBank.Columns.Add("LCCS_No", typeof(string));
            dtBank.Columns.Add("LCCS_Ref", typeof(string));
            dtBank.Columns.Add("LCCS_Limit", typeof(string));

            if (pBLogLimitReq.pbloglmproduct != null)
            {
                for (int i = 0; i < pBLogLimitReq.pbloglmproduct.Length; i++)
                {
                    dtBank.Rows.Add(
                             pBLogLimitReq.pbloglmproduct[i].LRecType
                           , pBLogLimitReq.pbloglmproduct[i].LLogSeq
                           , pBLogLimitReq.pbloglmproduct[i].LBank_Code
                           , pBLogLimitReq.pbloglmproduct[i].LFacility_No
                           , pBLogLimitReq.pbloglmproduct[i].LseqNo
                           , pBLogLimitReq.pbloglmproduct[i].LProd_Code
                           , pBLogLimitReq.pbloglmproduct[i].LProd_Limit
                           , pBLogLimitReq.pbloglmproduct[i].LStartDate
                           , pBLogLimitReq.pbloglmproduct[i].LExpiryDate
                           , pBLogLimitReq.pbloglmproduct[i].LProdAmount
                           , pBLogLimitReq.pbloglmproduct[i].LCCS_No
                           , pBLogLimitReq.pbloglmproduct[i].LCCS_Ref
                           , pBLogLimitReq.pbloglmproduct[i].LCCS_Limit
                        );
                }
            }
            param.Add("@BLogLmProduct", dtBank.AsTableValuedParameter("Type_pBLogLmProduct"));

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            param.Add("PBLogLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            try
            {
                var results = await _db.LoadData<PBLogLimitRsp, dynamic>(
                    storedProcedure: "usp_pBankLimit_Edit_Save",
                    param);

                var PBLogLimitRsp = param.Get<dynamic>("@PBLogLimitRsp");

                var resp = param.Get<int>("@Resp");
                if (resp >= 1)
                {
                    return Ok(PBLogLimitRsp);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Save Bank Credit Limit Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("release")]
        public async Task<ActionResult<string>> Release([FromBody] PBankLimitReleaseReq pBankLimitReleaseReq)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", pBankLimitReleaseReq.Bank_Code);
            param.Add("@Facility_No", pBankLimitReleaseReq.Facility_No);
            param.Add("@UserCode", pBankLimitReleaseReq.UserCode);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pBankLimit_EDIT_Release", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Release Bank Credit Limit Complete";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    //response.Message = "Release Bank Credit Limit Complete";
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
        public async Task<IEnumerable<SumAmountBankRsp>> SumAmtCust(string? BankCode, string? SumType)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", BankCode);
            param.Add("SumType", SumType);

            var results = await _db.LoadData<SumAmountBankRsp, dynamic>(
                        storedProcedure: "usp_GetSumAmtBank",
                        param);
            return results;
        }





    }
}
