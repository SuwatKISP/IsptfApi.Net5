using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.TradeCreditLimit.QuoteRate;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISPTF.API.Controllers.TradeCreditLimit.QuoteRate
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteINTController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public QuoteINTController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        public async Task<IEnumerable<QuoteINTListRsp>> GetAll(string Status)
        {
            DynamicParameters param = new();
            param.Add("@Status", Status);

            var results = await _db.LoadData<QuoteINTListRsp, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteINTList",
                        param);
            return results;
        }
        // Listpage
        [HttpGet("select")]
        public async Task<IEnumerable<QuoteINTSelect>> GetSel(string Txn_ID)
        {
            DynamicParameters param = new();
            param.Add("@Txn_ID", Txn_ID);

            var results = await _db.LoadData<QuoteINTSelect, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteINTSelect",
                        param);
            return results;
        }
        // Select
        [HttpPost("Save")]
        public async Task<ActionResult<List<QuoteINTSaveRsp>>> Insert([FromBody] QuoteINTSaveRsp Quote)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Txn_ID", Quote.Txn_ID);
            param.Add("@CFR_1", Quote.CFR_1);
            param.Add("@CFR_2", Quote.CFR_2);
            param.Add("@CFR_3", Quote.CFR_3);
            param.Add("@CFR_Rate", Quote.CFR_Rate);
            param.Add("@Quote_Rate", Quote.CFR_Rate);
            param.Add("@TPR", Quote.CFR_Rate);
            param.Add("@Status", Quote.Status);
            param.Add("@TF_Sale", Quote.TF_Sale);
            param.Add("@RM1", Quote.RM1);
            param.Add("@RM2", Quote.RM2);
            param.Add("@EditApprove_Flag", Quote.EditApprove_Flag);
            param.Add("@EditApprove_UID", Quote.EditApprove_UID);
            param.Add("@EditApprove_Seq", Quote.EditApprove_Seq);
            param.Add("@ReBOT", Quote.ReBOT);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<QuoteINTSaveRsp, dynamic>(
                    storedProcedure: "usp_AQuote_QuoteINTUpdate",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Quote Rate dose not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Save
        [HttpPost("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] QuoteINTDeleteReq Quote)
        {

            DynamicParameters param = new();
            param.Add("@Txn_ID", Quote.Txn_ID);
            param.Add("@Delete_user", Quote.Delete_user);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_AQuote_QuoteINTDelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = " Rate deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = " Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//delete
    }//main
}


