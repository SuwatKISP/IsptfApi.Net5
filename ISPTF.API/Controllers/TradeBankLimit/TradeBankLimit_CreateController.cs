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
    public class TradeBankLimit_CreateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeBankLimit_CreateController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("InsGrdFacility")]
        public async Task<IEnumerable<InsGrdFacilityBKRsp>> GetInsGrdFacility(string? Bank_Code)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);

            var results = await _db.LoadData<InsGrdFacilityBKRsp, dynamic>(
                        storedProcedure: "usp_TredBankLimit_InsGrdFacility",
                        param);
            return results;
        }


        [HttpGet("InsGrdProduct")]
        public async Task<IEnumerable<InsGrdProductBKRsp>> GetInsGrdProduct(string? Bank_Code, string? Facility_No)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Facility_No", Facility_No);

            var results = await _db.LoadData<InsGrdProductBKRsp, dynamic>(
                        storedProcedure: "usp_TredBankLimit_InsGrdProduct",
                        param);
            return results;
        }


        [HttpGet("InsGrdPending")]
        public async Task<IEnumerable<InsGrdPendingBKRsp>> GetReleaseList(string? Bank_Code, int? Page, int? PageSize)
        {
            DynamicParameters param = new();


            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (Bank_Code == null)
            {
                param.Add("@Bank_Code", "");
            }

            var results = await _db.LoadData<InsGrdPendingBKRsp, dynamic>(
                        storedProcedure: "usp_TredBankLimit_InsGrdPending",
                        param);
            return results;
        }

        [HttpGet("select")]
        public async Task<ActionResult<PBankLimitRsp>> GetSelect(string? Bank_Code, string? Facility_No)
        {
            DynamicParameters param = new();

            param.Add("@Bank_Code", Bank_Code);
            param.Add("@Facility_No", Facility_No);

            param.Add("@PBankLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<PBankLimitRsp, dynamic>(
                        storedProcedure: "usp_pBankLimit_Select",
                        param);
            var PBankLimitRsp = param.Get<dynamic>("@PBankLimitRsp");

            return Ok(PBankLimitRsp);
        }



        [HttpPost("save")]
        public async Task<ActionResult<PBankLimitRsp>> Save([FromBody] PBankLimitReq pBankLimitReq)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", pBankLimitReq.pbanklimit.Bank_Code);
            param.Add("@Facility_No", pBankLimitReq.pbanklimit.Facility_No);
            param.Add("@Seq_No", pBankLimitReq.pbanklimit.Seq_No);
            param.Add("@CCS_No", pBankLimitReq.pbanklimit.CCS_No);
            param.Add("@Limit_Code", pBankLimitReq.pbanklimit.Limit_Code);
            param.Add("@Status", pBankLimitReq.pbanklimit.Status);
            param.Add("@RecStatus", pBankLimitReq.pbanklimit.RecStatus);
            param.Add("@UsingRec", pBankLimitReq.pbanklimit.UsingRec);
            param.Add("@StartDate", pBankLimitReq.pbanklimit.StartDate);
            param.Add("@ExpiryDate", pBankLimitReq.pbanklimit.ExpiryDate);
            param.Add("@ExpiryDate2", pBankLimitReq.pbanklimit.ExpiryDate2);
            param.Add("@Facility_Type", pBankLimitReq.pbanklimit.Facility_Type);
            param.Add("@Revol_Flag", pBankLimitReq.pbanklimit.Revol_Flag);
            param.Add("@Credit_Ccy", pBankLimitReq.pbanklimit.Credit_Ccy);
            param.Add("@Credit_Amount", pBankLimitReq.pbanklimit.Credit_Amount);
            param.Add("@Origin_Amount", pBankLimitReq.pbanklimit.Origin_Amount);
            param.Add("@Susp_Amount", pBankLimitReq.pbanklimit.Susp_Amount);
            param.Add("@Hold_Amount", pBankLimitReq.pbanklimit.Hold_Amount);
            param.Add("@Remark", pBankLimitReq.pbanklimit.Remark);
            param.Add("@Condition", pBankLimitReq.pbanklimit.Condition);
            param.Add("@Block_Code", pBankLimitReq.pbanklimit.Block_Code);
            param.Add("@BlockDate", pBankLimitReq.pbanklimit.BlockDate);
            param.Add("@Block_Note", pBankLimitReq.pbanklimit.Block_Note);
            param.Add("@RecCode", pBankLimitReq.pbanklimit.RecCode);
            param.Add("@AutoRec", pBankLimitReq.pbanklimit.AutoRec);
            param.Add("@UpdNo", pBankLimitReq.pbanklimit.UpdNo);
            param.Add("@CreateDate", pBankLimitReq.pbanklimit.CreateDate);
            //param.Add("@UpdateDate", pBankLimitReq.pbanklimit.UpdateDate);
            param.Add("@UserCode", pBankLimitReq.pbanklimit.UserCode);
            //param.Add("@AuthDate", pBankLimitReq.pbanklimit.AuthDate);
            param.Add("@AuthCode", pBankLimitReq.pbanklimit.AuthCode);
            param.Add("@Cnty_Code", pBankLimitReq.pbanklimit.Cnty_Code);
            param.Add("@Campaign_Code", pBankLimitReq.pbanklimit.Campaign_Code);
            param.Add("@Campaign_EffDate", pBankLimitReq.pbanklimit.Campaign_EffDate);

            var dtBank = new DataTable();
            //-----pBankLmProduct
            dtBank = new DataTable();
            dtBank.Columns.Add("Bank_Code", typeof(string));
            dtBank.Columns.Add("Facility_No", typeof(string));
            dtBank.Columns.Add("SeqNo", typeof(int));
            dtBank.Columns.Add("Prod_Code", typeof(string));
            dtBank.Columns.Add("Prod_Limit", typeof(string));
            dtBank.Columns.Add("StartDate", typeof(DateTime));
            dtBank.Columns.Add("ExpiryDate", typeof(DateTime));
            dtBank.Columns.Add("ProdAmount", typeof(double));
            dtBank.Columns.Add("CCS_No", typeof(string));
            dtBank.Columns.Add("CCS_ref", typeof(string));
            dtBank.Columns.Add("CCS_Limit", typeof(string));

            if (pBankLimitReq.pbanklmproduct != null)
            {
                for (int i = 0; i < pBankLimitReq.pbanklmproduct.Length; i++)
                {
                    dtBank.Rows.Add(
                          pBankLimitReq.pbanklmproduct[i].Bank_Code
                        , pBankLimitReq.pbanklmproduct[i].Facility_No
                        , pBankLimitReq.pbanklmproduct[i].SeqNo
                        , pBankLimitReq.pbanklmproduct[i].Prod_Code
                        , pBankLimitReq.pbanklmproduct[i].Prod_Limit
                        , pBankLimitReq.pbanklmproduct[i].StartDate
                        , pBankLimitReq.pbanklmproduct[i].ExpiryDate
                        , pBankLimitReq.pbanklmproduct[i].ProdAmount
                        , pBankLimitReq.pbanklmproduct[i].CCS_No
                        , pBankLimitReq.pbanklmproduct[i].CCS_ref
                        , pBankLimitReq.pbanklmproduct[i].CCS_Limit
                        );
                }
            }
            param.Add("@BankLmProduct", dtBank.AsTableValuedParameter("Type_pBankLmProduct"));



            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            param.Add("@PBankLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            try
            {
                var results = await _db.LoadData<PBankLimitRsp, dynamic>(
                    storedProcedure: "usp_pBankLimit_Create_Save",
                    param);

                var PBankLimitRsp = param.Get<dynamic>("@PBankLimitRsp");

                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(PBankLimitRsp);
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
                  storedProcedure: "usp_pBankLimit_Create_Release", param);
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
