using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ImportTR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Transactions;


using ISPTF.Models.ExportLC;
namespace ISPTF.API.Controllers.ImportTR
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IMTR_ReverseTRController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IMTR_ReverseTRController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("listpage")]
        public async Task<ActionResult<Q_IMTR_ReverseIssue_ListPage_Response>> ListPage(string? ListType, string CustCode,string? CustName,string? TRNumber ,string? CenterID, string? Page, string? PageSize)
        {
            Q_IMTR_ReverseIssue_ListPage_Response response = new Q_IMTR_ReverseIssue_ListPage_Response();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType,CenterID, Page, PageSize is required";
                response.Data = new List<Q_IMTR_ReverseIssue_ListPage_rsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IMTR_ReverseIssue_ListPage_rsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@TRNumber", TRNumber);
                param.Add("@CenterID", CenterID);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }
                if (TRNumber == null)
                {
                    param.Add("@TRNumber", "");
                }

                var results = await _db.LoadData<Q_IMTR_ReverseIssue_ListPage_rsp, dynamic>(
                            storedProcedure: "usp_q_IMTR_ReverseTRListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMTR_ReverseIssue_ListPage_rsp>)results;

                try
                {
                    response.Page = int.Parse(Page);
                    response.Total = response.Data[0].RCount;
                    response.TotalPage = Convert.ToInt32(Math.Ceiling(response.Total / decimal.Parse(PageSize)));
                }
                catch (Exception)
                {
                    response.Page = 0;
                    response.Total = 0;
                    response.TotalPage = 0;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_IMTR_ReverseIssue_ListPage_rsp>();
            }
            return BadRequest(response);
        }













    }
}