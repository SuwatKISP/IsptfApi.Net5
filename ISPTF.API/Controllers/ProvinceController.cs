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
    public class ProvinceController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public ProvinceController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<MProvince>> GetAll(string? provcode)
        {
            DynamicParameters param = new();
            if (provcode == "*" || provcode == null)
            {
                param.Add("@Prov_Code", "*");
            }
            else
            {
                param.Add("@Prov_Code", provcode);
            }
            var results = await _db.LoadData<MProvince, dynamic>(
                storedProcedure: "usp_mprovinceselect",
                param);
            return results;
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MProvince>>> Insert([FromBody] MProvince province)
        {
            DynamicParameters param = new();
            param.Add("@Prov_Code", province.prov_Code);
            param.Add("@Prov_name", province.prov_Name);
            param.Add("@createdate", province.createDate);
            param.Add("@updatedate", province.updateDate);
            param.Add("@usercode", province.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MProvince, dynamic>(
                    storedProcedure: "usp_mprovinceinsert",
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
                    response.Message = "Province code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult<List<MProvince>>> Update([FromBody] MProvince province)
        {
            DynamicParameters param = new();
            param.Add("@Prov_code", province.prov_Code);
            param.Add("@Prov_Name", province.prov_Name);
            param.Add("@createdate", DateTime.Now);
            param.Add("@updatedate", DateTime.Now);
            param.Add("@usercode", province.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MProvince, dynamic>(
                    storedProcedure: "usp_mprovinceupdate",
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
                    response.Message = "Province code not exist";
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
        public async Task<ActionResult<string>> Delete([FromBody] MProvinceReq provincereq)
        {
            DynamicParameters param = new();
            param.Add("@Prov_Code", provincereq.Prov_Code);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mprovincedelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Prtovince code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Province code not exist";
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
