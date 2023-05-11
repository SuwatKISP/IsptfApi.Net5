using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportADV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ISPTF.Models.LoginRegis;
using System.Transactions;
using Microsoft.AspNetCore.Http;

namespace ISPTF.API.Controllers.ExportADV
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXADVAdvicingController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public EXADVAdvicingController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("select")]
        public async Task<ActionResult<PEXADResponse>> Select(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
        {
            PEXADResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                response.Data = new();
                return BadRequest(response);
            }

            try
            {
                // Select pExad
                var exad = await EXADVHelper.GetExad(_context.pExads, EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO);

                if (exad != null)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Data = exad;
                    return Ok(response);
                }
                response.Message = "Export Advice L/C does not exist";
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            response.Data = new();
            return BadRequest(response);
        }
    }
}
