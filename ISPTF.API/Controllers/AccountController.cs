using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ISPTF.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]", Order =2)]
    //[ApiVersion("2.0")]

    public class AccountController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public AccountController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        //[Route("api/[controller]", Order = 1)]
        //[Route("api/v{version:apiVersion}/[controller]", Order = 2)]
        //[ApiVersion="1.0"]
        public async Task<IEnumerable<MAccount>> GetAll(string? acccode)
        {
            DynamicParameters param = new DynamicParameters();
            if (acccode == "*" || acccode == null)
            {
                param.Add("@Acc_Code", "*");
            }
            else
            {
                param.Add("@Acc_Code", acccode);
            }
            var results = await _db.LoadData<MAccount, dynamic>(
                        storedProcedure: "usp_maccountselect",
                        param);
            return results.ToList();
        }
    
        [HttpPost("insert")]
        public async Task<ActionResult<List<MAccount>>> Insert([FromBody] MAccount account)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Acc_Code", account.acc_Code);
            param.Add("@Acc_Name", account.acc_Name);
            param.Add("@Acc_Map", account.acc_Map);
            param.Add("@createdate", account.createDate);
            param.Add("@updatedate", account.updateDate);
            param.Add("@usercode", account.userCode);
            param.Add("@Acc_GFMS", account.acc_GFMS);
            param.Add("@Acc_GFMS_Sub", account.acc_GFMS_Sub);
            param.Add("@GFMS_Map", account.gfmS_Map);
            param.Add("@GFMS_Prod", account.gfmS_Prod);
            param.Add("@GFMS_Bran", account.gfmS_Bran);
            param.Add("@GFMS_SBU", account.gfmS_SBU);
            param.Add("@Acc_Flag", account.acc_Flag);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results=await _db.LoadData<MAccount,dynamic>(
                    storedProcedure: "usp_maccountinsert",
                    param
                    );
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Account code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("update")]
        public async Task<ActionResult<List<MAccount>>> Update([FromBody] MAccount account)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Acc_Code", account.acc_Code);
            param.Add("@Acc_Name", account.acc_Name);
            param.Add("@Acc_Map", account.acc_Map);
            param.Add("@createdate", account.createDate);
            param.Add("@updatedate", account.updateDate);
            param.Add("@usercode", account.userCode);
            param.Add("@Acc_GFMS", account.acc_GFMS);
            param.Add("@Acc_GFMS_Sub", account.acc_GFMS_Sub);
            param.Add("@GFMS_Map", account.gfmS_Map);
            param.Add("@GFMS_Prod", account.gfmS_Prod);
            param.Add("@GFMS_Bran", account.gfmS_Bran);
            param.Add("@GFMS_SBU", account.gfmS_SBU);
            param.Add("@Acc_Flag", account.acc_Flag);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                var results=await _db.LoadData<MAccount, dynamic>(
                      storedProcedure: "usp_maccountupdate",
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
                    response.Message = "Account code not exist";
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
        public async Task<ActionResult<string>> Delete([FromBody] MAccountReq account)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@Acc_Code", account.acc_Code);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                    storedProcedure: "usp_maccountdelete",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Account code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Account code not exist";
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
