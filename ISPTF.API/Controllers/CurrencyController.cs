using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public CurrencyController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<MCurrency>> GetAll(string? ccycode)
        {
            DynamicParameters param = new DynamicParameters();
            if (ccycode=="*" || ccycode==null)
            {
                param.Add("@Ccy_Code", "*");
            }
            else
            {
                param.Add("@Ccy_Code", ccycode);
            }
            var results = await _db.LoadData<MCurrency, dynamic>(
                storedProcedure: "usp_mcurrencyselect",
                param);
            return results;

        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MCurrency>>> Insert([FromBody] MCurrency currency)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Ccy_Code", currency.ccy_Code);
            param.Add("@Ccy_Name", currency.ccy_Name);
            param.Add("@Ccy_Base", currency.ccy_Base);
            param.Add("@Ccy_GE", currency.ccy_GE);
            param.Add("@Ccy_GEC", currency.ccy_GEC);
            param.Add("@createdate", currency.createDate);
            param.Add("@updatedate", currency.updateDate);
            param.Add("@usercode", currency.userCode);
            param.Add("@Ccy_SWDEC", currency.ccy_SWDEC);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MCurrency, dynamic>(
                    storedProcedure: "usp_mcurrencyinsert",
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
                    response.Message = "Currency code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult<List<MCurrency>>> Update([FromBody] MCurrency currency)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Ccy_Code", currency.ccy_Code);
            param.Add("@Ccy_Name", currency.ccy_Name);
            param.Add("@Ccy_Base", currency.ccy_Base);
            param.Add("@Ccy_GE", currency.ccy_GE);
            param.Add("@Ccy_GEC", currency.ccy_GEC);
            param.Add("@createdate", currency.createDate);
            param.Add("@updatedate", currency.updateDate);
            param.Add("@usercode", currency.userCode);
            param.Add("@Ccy_SWDEC", currency.ccy_SWDEC);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MCurrency, dynamic>(
                    storedProcedure: "usp_mcurrencyupdate",
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
                    response.Message = "Currency code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<string>> Delete([FromBody]MCurrencyReq currencyreq)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Ccy_Code", currencyreq.Ccy_Code);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mcurrencydelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Currency code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Currency code not exist";
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
