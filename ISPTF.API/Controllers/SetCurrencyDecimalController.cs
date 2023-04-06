using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.MSetCurrencyDecimal;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace ISPTF.API.Controllers.SetCurrencyDecimalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetCurrencyDecimalController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public SetCurrencyDecimalController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("select")]
        public async Task<IEnumerable<MSetCurrencyDecimalRsp>> GetAll(string CurrencyCode, string HaveDecimal)
        {
            DynamicParameters param = new();
            param.Add("@CurrencyCode", CurrencyCode);
            param.Add("@HaveDecimal", HaveDecimal);

            var results = await _db.LoadData<MSetCurrencyDecimalRsp, dynamic>(
                        storedProcedure: "usp_SetCurrDecSelect",
                        param);
            return results;
        }
        [HttpGet("editlist")]
        public async Task<IEnumerable<MSetCurrencyDecimalRsp>> GetSetCurrDec( string ? CurrencyCode, string ? HaveDecimal, string Page, string PageSize)
        {
            DynamicParameters param = new();

            if (CurrencyCode == null)
            {
                param.Add("@CurrencyCode", "");
            }
            else
            {
                param.Add("@CurrencyCode", CurrencyCode);
            }
            if (HaveDecimal == null)
            {
                param.Add("@HaveDecimal", "");
            }
            else
            {
                param.Add("@HaveDecimal", HaveDecimal);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            var results = await _db.LoadData<MSetCurrencyDecimalRsp, dynamic>(
                        storedProcedure: "usp_SetCurrDecGet",
                        param);
            return results; 
        }
 
        [HttpPost("update")]
        public async Task<ActionResult<List<MSetCurrencyDecimal>>> Update([FromBody] MSetCurrencyDecimal SetCurrDesc)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CurrencyCode", SetCurrDesc.CurrencyCode);
            param.Add("@HaveDecimal", SetCurrDesc.HaveDecimal);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MSetCurrencyDecimal, dynamic>(
                    storedProcedure: "usp_SetCurrDecUpdate",
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
                    response.Message = "Se tCurrency Decimal not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//update
   
   
    }//main
}
