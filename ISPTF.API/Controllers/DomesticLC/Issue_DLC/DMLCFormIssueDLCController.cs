using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.DomesticLC;
using ISPTF.Models.ImportLC;
using ISPTF.Models.PackingCredit;
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
using System.Reflection;

namespace ISPTF.API.Controllers.DomesticLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DMLCFormIssueDLCController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public DMLCFormIssueDLCController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }


        [HttpGet("select")]
        public async Task<ActionResult<Q_DMLC_Issue_Select_Response>> NewSelect(string? ListType, string? LoadLC, string? DLCNumber, int? DLCSeqno, string? RecType, string? Event, string? CustCode)
        {
            Q_DMLC_Issue_Select_Response response = new Q_DMLC_Issue_Select_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(LoadLC))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, LoadLC is required";
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadLC != "ISSUE" && LoadLC != "REOPEN" & LoadLC != "AMEND-OTH" && LoadLC != "REVERSE" )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC shoud be ISSUE, REOPEN, AMEND-OTH, REVERSE";
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadLC == "ISSUE" && ListType != "EDIT" && ListType != "RELEASE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC = ISSUE ListType should be EDIT, RELEASE";
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadLC != "ISSUE" && ListType != "NEW" && ListType != "EDIT" && ListType != "RELEASE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be NEW, EDIT, RELEASE";
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@LoadLC", LoadLC);
                param.Add("@DLCNumber", DLCNumber);
                param.Add("@DLCSeqno", DLCSeqno);
                param.Add("@RecType", RecType);
                param.Add("@Event", Event);
                param.Add("@CustCode", CustCode);


                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@IssueResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_DMLC_Issue_Select_JSON_rsp, dynamic>(
                            storedProcedure: "[usp_q_DMLC_IssueDLCListSelect]",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var IssueResp = param.Get<dynamic>("@IssueResp");

                if (Resp == 1)
                {
                    Q_DMLC_Issue_Select_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_DMLC_Issue_Select_JSON_rsp>(IssueResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }
        }

























        [HttpHead("Remark1/1.For Select LoadLC = ISSUE with ListType = EDIT")]
        [HttpHead("Remark2/2.For Select Menu AmendOther, ReOpenDLC, ReverseDLC")]
        [HttpHead("Remark3/3.ListType for Remark 2 = NEW, EDIT, RELEASE")]
        [HttpHead("Remark4/4.LoadLC for Remark 2 = AMEND-OTH, REOPEN, REVERSE ")]
        public async Task<ActionResult<IMLCResultResponse>> Remark([FromBody] IMLC_RemarkAmend_JSON_req save)
        {
            IMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            try
            {
                DynamicParameters param = new DynamicParameters();
                //await _db.SaveData(
                //  storedProcedure: "usp_pIMLC_Amend_Release", param);
                var resp = param.Get<int>("@Resp");

                if (resp > 0)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(response);
            }
        }







    }
}
