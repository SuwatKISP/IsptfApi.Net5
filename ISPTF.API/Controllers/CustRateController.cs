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
    public class CustRateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public CustRateController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("select")]
        public async Task<IEnumerable<MCustRateDefault>> GetAll(string defcust,string defmod,string defexp)
        {
            DynamicParameters param = new();
            param.Add("@Def_Cust", defcust);
            param.Add("@Def_Mod", defmod);
            param.Add("@Def_Exp", defexp);
            var results = await _db.LoadData<MCustRateDefault, dynamic>(
                storedProcedure: "usp_mcustrateselect",
                param);
            return results;
        }

        [HttpGet("editlist")]
        public async Task<IEnumerable<MCustRateDefaultRsp>> GetCustRate(string? defcust, string? recstatus, string Page, string PageSize)
        {
            DynamicParameters param = new();
            if (defcust == null)
            {
                param.Add("@Def_Cust", "");
            }
            else
            {
                param.Add("@Def_Cust", defcust);
            }
            if (recstatus == null)
            {
                param.Add("@RecStatus", "");
            }
            else
            {
                param.Add("@RecStatus", recstatus);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);
            var results = await _db.LoadData<MCustRateDefaultRsp, dynamic>(
                storedProcedure: "usp_mCustRateGet",
                param);
            return results;
        }
        [HttpGet("editlistRateType")]
        public async Task<IEnumerable<MCustRateType>> GetRatetType( string Page, string PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);
            var results = await _db.LoadData<MCustRateType, dynamic>(
                storedProcedure: "usp_mCustRateGetRateType",
                param);
            return results;
        }

        [HttpPost("insert")]
        public async Task<ActionResult<List<MCustRateDefault>>> Insert([FromBody] MCustRateDefault custratereq)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Def_Cust", custratereq.Def_Cust);
            param.Add("@Def_Mod", custratereq.Def_Mod);
            param.Add("@Def_Exp", custratereq.Def_Exp);
            param.Add("@Def_Type", custratereq.Def_Type);
            param.Add("@Def_Rate", custratereq.Def_Rate);
            param.Add("@Def_Max", custratereq.Def_Max);
            param.Add("@Def_Min", custratereq.Def_Min);
            param.Add("@RecStatus", custratereq.RecStatus);
            param.Add("@usercode", custratereq.UserCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MCustRateDefault, dynamic>(
                    storedProcedure: "usp_mcustrateinsert",
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
                    response.Message = "Rate code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult<List<MCustRateDefault>>> Update([FromBody] MCustRateDefault custratereq)
        {
            DynamicParameters param = new();
            param.Add("@Def_Cust", custratereq.Def_Cust);
            param.Add("@Def_Mod", custratereq.Def_Mod);
            param.Add("@Def_Exp", custratereq.Def_Exp);
            param.Add("@Def_Type", custratereq.Def_Type);
            param.Add("@Def_Rate", custratereq.Def_Rate);
            param.Add("@Def_Max", custratereq.Def_Max);
            param.Add("@Def_Min", custratereq.Def_Min);
            param.Add("@RecStatus", custratereq.RecStatus);
            param.Add("@usercode", custratereq.UserCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MCustRateDefault, dynamic>(
                    storedProcedure: "usp_mcustrateupdate",
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
                    response.Message = "Customer rate code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//update
        [HttpPost("release")]
        public async Task<ActionResult<List<MCustRateDefault>>> Release([FromBody] MCustRateDefault custratereq)
        {
            DynamicParameters param = new();
            param.Add("@Def_Cust", custratereq.Def_Cust);
            param.Add("@Def_Mod", custratereq.Def_Mod);
            param.Add("@Def_Exp", custratereq.Def_Exp);
            param.Add("@RecStatus", custratereq.RecStatus);
            param.Add("@AuthCode", custratereq.AuthCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MCustRateDefault, dynamic>(
                    storedProcedure: "usp_mCustRateRelase",
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
                    response.Message = "Customer rate code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//update
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<string>>  Delete([FromBody] MCustRateCodeReq custratereq)
        {
            DynamicParameters param = new();
            param.Add("@Def_Cust", custratereq.Def_Cust);
            param.Add("@Def_Mod", custratereq.Def_Mod);
            param.Add("@Def_Exp", custratereq.Def_Exp);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mcustratedelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Customer rate code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Customer rate code not exist";
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
