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
    public class CountryController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public CountryController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<MCountry>> GetAll(string? cntycode)
        {
            DynamicParameters param = new DynamicParameters();
            if (cntycode == "*" || cntycode == null)
            {
                param.Add("@Cnty_Code", "*");
            }
            else
            {
                param.Add("@Cnty_Code", cntycode);
            }
            var results = await _db.LoadData<MCountry,dynamic>(
                storedProcedure: "usp_mcountryselect",
                param);
            return results;
        }

        [HttpGet("selectCntyCode")]
        public async Task<IEnumerable<MCountry>> GetCntyCode(string? cntycode)
        {
            DynamicParameters param = new DynamicParameters();
                param.Add("@Cnty_Code", cntycode);

            var results = await _db.LoadData<MCountry, dynamic>(
                storedProcedure: "usp_mcountry_CntyCode_select",
                param);
            return results;
        }

        [HttpPost("insert")]
        public async Task<ActionResult<List<MCountry>>> Insert([FromBody] MCountry country)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Cnty_Code", country.cnty_Code);
            param.Add("@Cnty_Name", country.cnty_Name);
            param.Add("@Cnty_Area", country.cnty_Area);
            param.Add("@createdate", country.createDate);
            param.Add("@updatedate", country.updateDate);
            param.Add("@usercode", country.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MCountry, dynamic>(
                    storedProcedure: "usp_mcountryinsert",
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
                    response.Message = "Country code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult<List<MCountry>>> Update([FromBody] MCountry country)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Cnty_Code", country.cnty_Code);
            param.Add("@Cnty_Name", country.cnty_Name);
            param.Add("@Cnty_Area", country.cnty_Area);
            param.Add("@createdate", country.createDate);
            param.Add("@updatedate", country.updateDate);
            param.Add("@usercode", country.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MCountry, dynamic>(
                    storedProcedure: "usp_mcountryupdate",
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
                    response.Message = "Country code not exist";
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
        public async Task<ActionResult<string>> Delete([FromBody] MCountryReq countryreq)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Cnty_Code", countryreq.Cnty_Code);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mcountrydelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Country code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Country code not exist";
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
