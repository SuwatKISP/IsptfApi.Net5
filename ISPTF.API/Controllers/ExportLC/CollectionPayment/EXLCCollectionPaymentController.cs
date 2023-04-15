﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models.ExportLC;
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
    public class EXLCCollectionPaymentController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public EXLCCollectionPaymentController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public async Task<EXLCCollectionPaymentListResponse> GetAllList(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        {
            EXLCCollectionPaymentListResponse response = new EXLCCollectionPaymentListResponse();

            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCCollectionPaymentListPageRsp>();
                return response;
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCCollectionPaymentListPageRsp>();
                return response;
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", @ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENName", BENName);
                param.Add("@USER_ID", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENName == null)
                {
                    param.Add("@BENName", "");
                }

                var results = await _db.LoadData<Q_EXLCCollectionPaymentListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_CollectionPaymentListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCCollectionPaymentListPageRsp>)results;
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_EXLCCollectionPaymentListPageRsp>();
            }
            return response;
        }

        //[HttpGet("query")]
        //public async Task<IEnumerable<Q_EXBCPurchasePaymentQueryPageRsp>> GetAllQuery( string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    //param.Add("@ListType", @ListType);
        //    param.Add("@CenterID", CenterID);
        //    param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
        //    param.Add("@BENName", BENName);
        //    param.Add("@USER_ID", USER_ID);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (EXPORT_BC_NO == null)
        //    {
        //        param.Add("@EXPORT_BC_NO", "");
        //    }
        //    if (BENName == null)
        //    {
        //        param.Add("@BENName", "");
        //    }

        //    var results = await _db.LoadData<Q_EXBCPurchasePaymentQueryPageRsp, dynamic>(
        //                storedProcedure: "usp_q_EXLC_PurchasePaymentQueryPage",
        //                param);
        //    return results;
        //}


        [HttpGet("select")]
//        public async Task<IEnumerable<PEXBCPEXPaymentRsp>> GetAllSelect(string? EXPORT_BC_NO , string? EVENT_NO, string? LFROM)
        public async Task<PEXLCPEXPaymentPPaymentResponse> GetAllSelect(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXLCPEXPaymentPPaymentResponse response = new PEXLCPEXPaymentPPaymentResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || string.IsNullOrEmpty(EVENT_NO) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCPEXPaymentPPaymentRsp();
                return response;
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@LFROM", LFROM);
                param.Add("@PEXLCRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);
                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPEXPaymentPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_CollectionPayment_Select",
                           param);
                var PEXLCRsp = param.Get<dynamic>("@PEXLCRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PEXLCRsp > 0 && !string.IsNullOrEmpty(pexlcpexpaymentrsp))
                {
                    PEXLCPEXPaymentPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPEXPaymentPPaymentRsp>(pexlcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return response;
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT L/C NO does not exit";
                    response.Data = new PEXLCPEXPaymentPPaymentRsp();
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPEXPaymentPPaymentRsp();
            }
            return response;
        }
    }
}
