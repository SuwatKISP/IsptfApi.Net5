using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExchangeRate;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace ISPTF.API.Controllers.ExchangeRate
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PExchangeController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PExchangeController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("select")]
        public async Task<IEnumerable<PExchangeRsp>> GetAll(DateTime ExchDate, string ExchTime,string ExchCcy)
        {
            DynamicParameters param = new();
            param.Add("@Exch_Date", ExchDate);
            param.Add("@Exch_Time", ExchTime);
            param.Add("@Exch_Ccy", ExchCcy);

            var results = await _db.LoadData<PExchangeRsp, dynamic>(
                        storedProcedure: "usp_pExchangeSelect",
                        param);
            return results;
        }

        [HttpGet("getexchangerate")]
        public async Task<IEnumerable<PExchangeRegistRsp>> GetRegist(string ExchCcy)
        {
            DynamicParameters param = new();

            param.Add("@ExchCcy", ExchCcy);

            var results = await _db.LoadData<PExchangeRegistRsp, dynamic>(
                        storedProcedure: "usp_pExchangeSelectGetEXRate",
                        param);
            return results;
        }
        [HttpGet("editlist")]
        public async Task<IEnumerable<PExchangeRsp>> GetExchByDate(DateTime ExchDate, string ?recstatus, string ?ExchCcy,string Page, string PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ExchDate", ExchDate);
            if (ExchCcy == null)
            {
                param.Add("@Exch_Ccy", "");
            }
            else
            {
                param.Add("@Exch_Ccy", ExchCcy);
            }
            if (recstatus == null)
            {
                param.Add("@recStatus", "");
            }
            else
            {
                param.Add("@recStatus", recstatus);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            var results = await _db.LoadData<PExchangeRsp, dynamic>(
                        storedProcedure: "usp_pExchangeGetExRateByDate",
                        param);
            return results; 
        }
 
        [HttpPost("insert")]
        public async Task<ActionResult<List<PExchange>>> Insert([FromBody] PExchange exchange)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@exch_Date", exchange.exch_Date);
            param.Add("@exch_Time", exchange.exch_Time);
            param.Add("@exch_Ccy", exchange.exch_Ccy);
            param.Add("@exch_BNBuy", exchange.exch_BNBuy);
            param.Add("@exch_BNSell", exchange.exch_BNSell);
            param.Add("@exch_TRate1", exchange.exch_TRate1);
            param.Add("@exch_TRate2", exchange.exch_TRate2);
            param.Add("@exch_TRate3", exchange.exch_TRate3);
            param.Add("@recStatus", exchange.recStatus);
            param.Add("@UserCode", exchange.UserCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<PExchange, dynamic>(
                    storedProcedure: "usp_pExchangeInsert",
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
                    response.Message = "Exchange Rate code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//insert
        [HttpPost("update")]
        public async Task<ActionResult<List<PExchange>>> Update([FromBody] PExchange exchange)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@exch_Date", exchange.exch_Date);
            param.Add("@exch_Time", exchange.exch_Time);
            param.Add("@exch_Ccy", exchange.exch_Ccy);
            param.Add("@exch_BNBuy", exchange.exch_BNBuy);
            param.Add("@exch_BNSell", exchange.exch_BNSell);
            param.Add("@exch_TRate1", exchange.exch_TRate1);
            param.Add("@exch_TRate2", exchange.exch_TRate2);
            param.Add("@exch_TRate3", exchange.exch_TRate3);
            param.Add("@recStatus", exchange.recStatus);
            param.Add("@UserCode", exchange.UserCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PExchange, dynamic>(
                    storedProcedure: "usp_pExchangeUpdate",
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
                    response.Message = "Exchange Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//update
        [HttpPost("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] PExchangeReq exchange)
        {
            DynamicParameters param = new();
            param.Add("@exch_Date", exchange.exch_Date);
            param.Add("@exch_Time", exchange.exch_Time);
            param.Add("@exch_Ccy", exchange.exch_Ccy);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pExchangeDelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Exchange Rate deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Exchange Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }//delete
        [HttpPost("release")]
        public async Task<ActionResult<List<PExchange>>> Release([FromBody] PExchange exchange)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@exch_Date", exchange.exch_Date);
            param.Add("@exch_Time", exchange.exch_Time);
            param.Add("@exch_Ccy", exchange.exch_Ccy);
            param.Add("@recStatus", exchange.recStatus);
            param.Add("@AuthCode", exchange.authCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PExchange, dynamic>(
                    storedProcedure: "usp_pExchangeRelease",
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
                    response.Message = "Exchange Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Release
        [HttpPost("LOADRATE")]
        public async Task<ActionResult<List<string>>> LoadExch([FromBody] PExchangeLoadReq exchange)
        {
            DynamicParameters param = new DynamicParameters();
            var USER_ID = User.Identity.Name;
            param.Add("@ExchDate", exchange.exch_Date);
            param.Add("@UserCode", USER_ID);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_LOADRATE", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Load Exchange Rate";
                    return Ok(response);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Eror for Load Exchange Rate ";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Release
        //[HttpPost("unrelease")]
        //public async Task<ActionResult<List<PExchange>>> UnRelease([FromBody] PExchange exchange)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@exch_Date", exchange.exch_Date);
        //    param.Add("@exch_Time", exchange.exch_Time);
        //    param.Add("@exch_Ccy", exchange.exch_Ccy);
        //    param.Add("@recStatus", exchange.recStatus);
        //    param.Add("@AuthCode", exchange.authCode);
        //    param.Add("@Resp", dbType: DbType.Int32,
        //        direction: System.Data.ParameterDirection.Output,
        //        size: 5215585);
        //    try
        //    {
        //        var results = await _db.LoadData<PExchange, dynamic>(
        //            storedProcedure: "usp_pExchangeUnRelease",
        //            param);
        //        var resp = param.Get<int>("@Resp");
        //        if (resp == 1)
        //        {
        //            return Ok(results);
        //        }
        //        else
        //        {
        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            response.Message = "Exchange Rate not exist";
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}//unRelease
    }//main
}
