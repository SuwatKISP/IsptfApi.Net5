using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportAdvLC;
using ISPTF.Models.PurchasePayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Security.Claims;

namespace ISPTF.API.Controllers.ExportAdvLC
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXADVLCAdvicingController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public EXADVLCAdvicingController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }
    }

    [HttpGet("select")]
    public async Task<ActionResult<PEXADResponse>> GetAllSelect(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, string? EVENT_NO)
    {
        PEXADResponse response = new PEXADResponse();
        var USER_ID = User.Identity.Name;
        var claimsPrincipal = HttpContext.User;
        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

        // Validate
        if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || string.IsNullOrEmpty(EVENT_NO))
        {
            response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
            response.Data = new pExad();
            return BadRequest(response);
        }

        DynamicParameters param = new();
        param.Add("@EXPORT_ADVICE_NO", EXPORT_ADVICE_NO);
        param.Add("@RECORD_TYPE", RECORD_TYPE);
        param.Add("@REC_STATUS", REC_STATUS);
        param.Add("@EVENT_NO", EVENT_NO);
        //param.Add("@LFROM", LFROM);

        using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                // Select pExad
                var pExad = (from row in _context.pExads
                             where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                   row.RECORD_TYPE == RECORD_TYPE &&
                                   row.REC_STATUS == REC_STATUS &&
                                   row.EVENT_NO == EVENT_NO
                             select row).FirstOrDefault();
                if (pExad == null)
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export Advice L/C does not exist";
                    return BadRequest(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Data = pExad;
                    return Ok(response);
                }
            }
            catch(Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new pExad();
            }
            return BadRequest(response);
        }
    }
}
