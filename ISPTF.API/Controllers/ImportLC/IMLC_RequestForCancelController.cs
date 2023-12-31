﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.Inquiry;
using ISPTF.Models.ImportTR;
using ISPTF.Models.ImportLC;
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
namespace ISPTF.API.Controllers.ImportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IMLC_RequestForCancelController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IMLC_RequestForCancelController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("listpage")]
        public async Task<ActionResult<Q_IMLC_ReqForCancel_ListPage_Response>> ListPage(string? ListType, string? LCNumber, string CustCode, string? CustName, string? CenterID, string? Page, string? PageSize)
        {
            Q_IMLC_ReqForCancel_ListPage_Response response = new Q_IMLC_ReqForCancel_ListPage_Response();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_IMLC_ReqForCancel_ListPage_rsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IMLC_ReqForCancel_ListPage_rsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@LCNumber", LCNumber);
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
                if (LCNumber == null)
                {
                    param.Add("@LCNumber", "");
                }


                var results = await _db.LoadData<Q_IMLC_ReqForCancel_ListPage_rsp, dynamic>(
                            storedProcedure: "usp_q_IMLC_RequestForCancelListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMLC_ReqForCancel_ListPage_rsp>)results;

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
                response.Data = new List<Q_IMLC_ReqForCancel_ListPage_rsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("Select")]
        public async Task<ActionResult<Q_IMLC_Select_Response>> Select(string? LCNumber, string? LCSeqno, string? RecType, string? Event)
        {
            Q_IMLC_Select_Response response = new Q_IMLC_Select_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(LCNumber) || string.IsNullOrEmpty(LCSeqno) ||
                string.IsNullOrEmpty(RecType) || string.IsNullOrEmpty(Event))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LCNumber, LCSeqno, RecType, Event are required";
                response.Data = new Q_IMLC_Select_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@LCNumber", LCNumber);
                param.Add("@LCSeqno", LCSeqno);
                param.Add("@Event", Event);
                param.Add("@RecType", RecType);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@ListResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_IMLC_Select_JSON_rsp, dynamic>(
                            storedProcedure: "usp_Q_IMLC_ListSelect",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var ListResp = param.Get<dynamic>("@ListResp");

                if (Resp == 1)
                {
                    Q_IMLC_Select_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_IMLC_Select_JSON_rsp>(ListResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_IMLC_Select_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_IMLC_Select_JSON_rsp();
                return BadRequest(response);
            }
        }

























    }
}