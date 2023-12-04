using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.QuoteRate;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISPTF.API.Controllers.QuoteRate
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteMailController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public QuoteMailController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        // Listpage  add parameter  ,int? Page, int? PageSize
        public async Task<IEnumerable<QuoteMailList>> GetAll(string UserCode, string UserRole,  int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@UserCode", UserCode);
            param.Add("@UserRole", UserRole);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (UserCode == null)
            {
                param.Add("@UserCode", "");
            }

            if (UserRole == null)
            {
                param.Add("@UserRole", "");
            }

            var results = await _db.LoadData<QuoteMailList, dynamic>(
                        storedProcedure: "usp_AQuote_MailList",
                        param);
            return results;
        }

        // Listpage
        [HttpGet("select")]
        public async Task<IEnumerable<QuoteMailSelect>> select(string UserCode)
        {
            DynamicParameters param = new();
            param.Add("@UserCode", UserCode);

            var results = await _db.LoadData<QuoteMailSelect, dynamic>(
                        storedProcedure: "usp_AQuote_MailSelect",
                        param);
            return results;
        }

        [HttpPost("Save")]
        public async Task<ActionResult<List<QuoteMailSaveRsp>>> Insert([FromBody] QuoteMailSaveReq Quote)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserCode", Quote.UserCode);
            param.Add("@UserRole", Quote.UserRole);
            param.Add("@UserMail", Quote.UserMail);
            param.Add("@GroupMail", Quote.GroupMail);
            if (Quote.UserCode==null || Quote.UserCode=="" || Quote.UserRole == null || Quote.UserRole == "" )
            {
                ReturnResponse response = new();
                response.StatusCode = "400";
                response.Message = "UserCode,UserRloe is Require";
                return BadRequest(response);
            }
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<QuoteMailSaveRsp, dynamic>(
                    storedProcedure: "usp_AQuote_MailSave",
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
                    response.Message = "Error for Setup E-mail";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Save
    }
}
