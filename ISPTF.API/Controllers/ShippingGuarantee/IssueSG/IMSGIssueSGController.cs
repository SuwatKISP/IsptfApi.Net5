﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ShippingGuarantee;
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

namespace ISPTF.API.Controllers.PackingCredit
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IMSGIssueSGController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public IMSGIssueSGController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("newlist")]
        public async Task<ActionResult<IssueSGNewListPageResponse>> NewList(string? CenterID, string? RegDocNo,string? CustCode , string? @CustName, string? Page, string? PageSize)
        {
            IssueSGNewListPageResponse response = new IssueSGNewListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_IssueSGNewListPageRsp>();
                return BadRequest(response);
            }
            //if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "USER_ID is required";
            //    response.Data = new List<Q_IssuePCNewListPageRsp>();
            //    return BadRequest(response);
            //}

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                //param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@RegDocNo", RegDocNo);
                param.Add("@CustName", @CustName);
                param.Add("@CustCode", @CustCode);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (RegDocNo == null)
                {
                    param.Add("@RegDocNo", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_IssueSGNewListPageRsp, dynamic>(
                            storedProcedure: "usp_q_IMSG_IssueSGNewListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IssueSGNewListPageRsp>)results;

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
                response.Data = new List<Q_IssueSGNewListPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("list")]
        public async Task<ActionResult<IssueSGListPageResponse>> List(string? ListType, string? CenterID, string? SGNumber, string? CustCode, string? CustName, string? Page, string? PageSize)
        {
            IssueSGListPageResponse response = new IssueSGListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_IssueSGListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IssueSGListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@SGNumber", SGNumber);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (SGNumber == null)
                {
                    param.Add("@SGNumber", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_IssueSGListPageRsp, dynamic>(
                            storedProcedure: "usp_q_IMSG_IssueSGListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IssueSGListPageRsp>)results;

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
                response.Data = new List<Q_IssueSGListPageRsp>();
            }
            return BadRequest(response);
        }














    }
}
