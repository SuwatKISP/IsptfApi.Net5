﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.DomesticLC;
using ISPTF.Models.Remittance;
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

namespace ISPTF.API.Controllers.Remittance
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class Remittance_ReverseCleanBillController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public Remittance_ReverseCleanBillController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }


        [HttpGet("list")]
        public async Task<ActionResult<ReverseCleanBillListPageResponse>> List(string? ListType,string? CLNumber, string? CustCode, string? @CustInfo, string? Page, string? PageSize)
        {
            ReverseCleanBillListPageResponse response = new ReverseCleanBillListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType Page, PageSize is required";
                response.Data = new List<Q_ReverseCleanBillListPageRsp>();
                return BadRequest(response);
            }

            //if (ListType != "EDIT" && ListType != "RELEASE")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "List Type should be EDIT or RELEASE";
            //    response.Data = new List<Q_ReverseCleanBillListPageRsp>();
            //    return BadRequest(response);
            //}

            //if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "USER_ID is required";
            //    response.Data = new List<Q_ReverseCleanBillListPageRsp>();
            //    return BadRequest(response);
            //}

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                //param.Add("@CenterID", CenterID);
                param.Add("@CLNumber", CLNumber);
                param.Add("@CustCode", CustCode);
                param.Add("@CustInfo", CustInfo);
                //param.Add("@Amount", Amount);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (CLNumber == null)
                {
                    param.Add("@CLNumber", "");
                }

                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustInfo == null)
                {
                    param.Add("@CustInfo", "");
                }
                //if (Amount == null)
                //{
                //    param.Add("@Amount", 0);
                //}

                var results = await _db.LoadData<Q_ReverseCleanBillListPageRsp, dynamic>(
                            storedProcedure: "usp_Q_Remittance_ReverseCleanBillListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_ReverseCleanBillListPageRsp>)results;

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
                response.Data = new List<Q_ReverseCleanBillListPageRsp>();
            }
            return BadRequest(response);
        }














    }
}
