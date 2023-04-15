﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models.ExportLC;
using ISPTF.Models.LoginRegis;
using ISPTF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using System;

namespace ISPTF.API.Controllers.ExportLC
{
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCIssuePurchaseController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public EXLCIssuePurchaseController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("newlist")]
        public async Task<EXLCIssuePurchaseNewListResponse> GetAllNew(string? CenterID, string? RegDocNo, string? BENName, string? Page, string? PageSize)
        {
            EXLCIssuePurchaseNewListResponse response = new EXLCIssuePurchaseNewListResponse();

            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueNewPageRsp>();
                return response;
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@CenterID", CenterID);
                param.Add("@RegDocNo", RegDocNo);
                param.Add("@BENName", BENName);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (RegDocNo == null)
                {
                    param.Add("@RegDocNo", "");
                }
                if (BENName == null)
                {
                    param.Add("@BENName", "");
                }
                var results = await _db.LoadData<Q_EXLCIssueNewPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXLC_IssuePurchNewPage",
                        param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueNewPageRsp>)results;
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_EXLCIssueNewPageRsp>();
            }
            return response;
        }

        [HttpGet("editlist")]
        public async Task<EXLCIssuePurchaseEditListResponse> GetAllEdit(string? CenterID, string? EXPORT_LC_NO, string? BENNAME, string? Page, string? PageSize)
        {
            EXLCIssuePurchaseEditListResponse response = new EXLCIssuePurchaseEditListResponse();

            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
                return response;
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENNAME", BENNAME);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENNAME == null)
                {
                    param.Add("@BENNAME", "");
                }

                var results = await _db.LoadData<Q_EXLCIssueEditPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_IssuePurchEditPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueEditPageRsp>)results;
            }
            catch(Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
            }
            return response;
        }

        [HttpGet("releaselist")]
        public async Task<EXLCIssuePurchaseReleaseListResponse> GetAllrelease(string? CenterID,string? USER_ID, string? EXPORT_LC_NO, string? BENNAME, string? Page, string? PageSize)
        {
            EXLCIssuePurchaseReleaseListResponse response = new EXLCIssuePurchaseReleaseListResponse();

            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(USER_ID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, USER_ID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
                return response;
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@CenterID", CenterID);
                param.Add("@USER_ID", USER_ID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENNAME", BENNAME);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENNAME == null)
                {
                    param.Add("@BENNAME", "");
                }

                var results = await _db.LoadData<Q_EXLCIssueEditPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_IssuePurchReleasePage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueEditPageRsp>)results;
            }
            catch(Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
            }
            return response;
        }

        // Select from pDocRegister
        [HttpGet("newselect")]
        public async Task<EXLCIssuePurchaseNewSelectResponse> GetNewSelect(string? RegDocNo)
        {
            EXLCIssuePurchaseNewSelectResponse response = new EXLCIssuePurchaseNewSelectResponse();

            // Validate
            if (string.IsNullOrEmpty(RegDocNo))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "RegDocNo is required";
                response.Data = new List<PDocRegister>();
                return response;
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@RegDocNo", RegDocNo);

                var results = await _db.LoadData<PDocRegister, dynamic>(
                            storedProcedure: "usp_pDocRegisterSelect",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<PDocRegister>)results;
            }
            catch(Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<PDocRegister>();
            }
            return response;
        }

// editselect new with jaon
        [HttpGet("select")]
        public async Task<PEXLCPPaymentResponse> GetAllSelect(string? EXPORT_LC_NO, string? RECORD_TYPE, string? REC_STATUS, string? EVENT_NO)
        {
            PEXLCPPaymentResponse response = new PEXLCPPaymentResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || string.IsNullOrEmpty(EVENT_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                response.Data = new PEXLCPPaymentRsp();
                return response;
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@RECORD_TYPE", RECORD_TYPE);
                param.Add("@REC_STATUS", REC_STATUS);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);
                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_IssuePurchase_Select",
                           param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PExLcRsp > 0 && !string.IsNullOrEmpty(pexlcpexpaymentrsp))
                {
                    PEXLCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPPaymentRsp>(pexlcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return response;
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT L/C NO does not exit";
                    response.Data = new PEXLCPPaymentRsp();
                    return response;
                }
            }
            catch(Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPPaymentRsp();
            }
            return response;
        }
    }
}
