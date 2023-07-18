using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.Inquiry;
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
namespace ISPTF.API.Controllers.Inquiry
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class Inquiry_CreditLimitController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public Inquiry_CreditLimitController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("listpage")]
        public async Task<ActionResult<INQ_CreditLimitListPageResponse>> ListPage(string CustCode, string? Page, string? PageSize)
        {
            INQ_CreditLimitListPageResponse response = new INQ_CreditLimitListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CustCode) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CustCode, Page, PageSize is required";
                response.Data = new List<Q_Inq_CreditLimit_ListPage_rsp>();
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
                param.Add("@CustCode", CustCode);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }


                var results = await _db.LoadData<Q_Inq_CreditLimit_ListPage_rsp, dynamic>(
                            storedProcedure: "usp_q_Inquiry_CreditLimit_ListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_Inq_CreditLimit_ListPage_rsp>)results;

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
                response.Data = new List<Q_Inq_CreditLimit_ListPage_rsp>();
            }
            return BadRequest(response);
        }

        //[HttpGet("getTotSum")]
        //public async Task<ActionResult<INQ_CreditLimitGetTotSumResponse>> GetTotSum(string? CustCode)
        //{
        //    INQ_CreditLimitGetTotSumResponse response = new INQ_CreditLimitGetTotSumResponse();
        //    var USER_ID = User.Identity.Name;
        //    //var USER_ID = "API";
        //    // Validate
        //    if (string.IsNullOrEmpty(CustCode))
        //    {
        //        response.Code = Constants.RESPONSE_FIELD_REQUIRED;
        //        response.Message = "CustCode is required";
        //        response.Data = new List<Q_Inq_CreditLimit_GetTotSum_rsp>();
        //        return BadRequest(response);
        //    }
        //    //if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
        //    //{
        //    //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
        //    //    response.Message = "USER_ID is required";
        //    //    response.Data = new List<Q_AdvisingListPageRsp>();
        //    //    return BadRequest(response);
        //    //}

        //    // Call Store Procedure
        //    try
        //    {
        //        DynamicParameters param = new();
        //        param.Add("@CustCode", CustCode);

        //        var results = await _db.LoadData<Q_Inq_CreditLimit_GetTotSum_rsp, dynamic>(
        //                    storedProcedure: "usp_q_Inquiry_CreditLimit_GetTotSum",
        //                    param);

        //        response.Code = Constants.RESPONSE_OK;
        //        response.Message = "Success";
        //        response.Data = (List<Q_Inq_CreditLimit_GetTotSum_rsp>)results;

        //        try
        //        {
        //            response.Page = 1; //int.Parse(Page);
        //            response.Total = 1; //response.Data[0].RCount;
        //            response.TotalPage = 1; // Convert.ToInt32(Math.Ceiling(response.Total / decimal.Parse(PageSize)));
        //        }
        //        catch (Exception)
        //        {
        //            response.Page = 0;
        //            response.Total = 0;
        //            response.TotalPage = 0;
        //        }
        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        response.Code = Constants.RESPONSE_ERROR;
        //        response.Message = e.ToString();
        //        response.Data = new List<Q_Inq_CreditLimit_GetTotSum_rsp>();
        //    }
        //    return BadRequest(response);
        //}

        [HttpGet("getDetailbyFac")]
        public async Task<ActionResult<INQ_CreditLimitGetDetailbyFacSumAndTotalResponse>> GetDetailbyFac(string? CustCode, string? FacilityNo)
        {
            INQ_CreditLimitGetDetailbyFacSumAndTotalResponse response = new INQ_CreditLimitGetDetailbyFacSumAndTotalResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(CustCode))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CustCode is required";
                response.Data = new Q_Inq_CreditLimit_GetDetailbyFac_DetailAndTotal_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@CustCode", CustCode);
                param.Add("@FacilityNo", FacilityNo);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@GetDetailbyFacRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_Inq_CreditLimit_GetDetailbyFac_DetailAndTotal_rsp, dynamic>(
                            storedProcedure: "usp_q_Inquiry_CreditLimit_GetDetailbyFac",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var GetDetailbyFacRsp = param.Get<dynamic>("@GetDetailbyFacRsp");

                if (Resp == 1)
                {
                    Q_Inq_CreditLimit_GetDetailbyFac_DetailAndTotal_rsp jsonResponse = JsonSerializer.Deserialize<Q_Inq_CreditLimit_GetDetailbyFac_DetailAndTotal_rsp>(GetDetailbyFacRsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_Inq_CreditLimit_GetDetailbyFac_DetailAndTotal_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_Inq_CreditLimit_GetDetailbyFac_DetailAndTotal_rsp();
                return BadRequest(response);
            }
        }


        [HttpGet("Detail")]
        public async Task<ActionResult<INQ_CreditLimitDetailResponse>> Detail(string? cType, string? CustCode, string? FacilityNo)
        {
            INQ_CreditLimitDetailResponse response = new INQ_CreditLimitDetailResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(CustCode) || (string.IsNullOrEmpty(cType)))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "cType and CustCode is required";
                response.Data = new List<Q_Inq_CreditLimit_Detail_rsp>();
                return BadRequest(response);
            }

            if (cType == "CD" && (string.IsNullOrEmpty(FacilityNo)))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "cType = CD. FacilityNO is required";
                response.Data = new List<Q_Inq_CreditLimit_Detail_rsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@cType", cType);
                param.Add("@CustCode", CustCode);
                param.Add("@FacilityNo", FacilityNo);

                var results = await _db.LoadData<Q_Inq_CreditLimit_Detail_rsp, dynamic>(
                            storedProcedure: "usp_q_Inquiry_CreditLimit_Detail",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_Inq_CreditLimit_Detail_rsp>)results;

                try
                {
                    response.Page = 1; //int.Parse(Page);
                    response.Total = 1; //response.Data[0].RCount;
                    response.TotalPage = 1; // Convert.ToInt32(Math.Ceiling(response.Total / decimal.Parse(PageSize)));
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
                response.Data = new List<Q_Inq_CreditLimit_Detail_rsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("DetailNoneLine")]
        public async Task<ActionResult<INQ_CreditLimitDetailNoneLineResponse>> DetailNoneLine(string? CustCode)
        {
            INQ_CreditLimitDetailNoneLineResponse response = new INQ_CreditLimitDetailNoneLineResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(CustCode))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CustCode is required";
                response.Data = new Q_Inq_CreditLimit_DetailNoneLine_DetailAndTotal_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@CustCode", CustCode);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@DetailNoneLineRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_Inq_CreditLimit_DetailNoneLine_DetailAndTotal_rsp, dynamic>(
                            storedProcedure: "usp_q_Inquiry_CreditLimit_DetailNoneLine",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var DetailNoneLineRsp = param.Get<dynamic>("@DetailNoneLineRsp");

                if (Resp == 1)
                {
                    Q_Inq_CreditLimit_DetailNoneLine_DetailAndTotal_rsp jsonResponse = JsonSerializer.Deserialize<Q_Inq_CreditLimit_DetailNoneLine_DetailAndTotal_rsp>(DetailNoneLineRsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_Inq_CreditLimit_DetailNoneLine_DetailAndTotal_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_Inq_CreditLimit_DetailNoneLine_DetailAndTotal_rsp();
                return BadRequest(response);
            }
        }


        [HttpGet("SumAndTotal")]
        public async Task<ActionResult<INQ_CreditLimitSumAndTotalResponse>> SumAndTotal(string? CustCode)
        {
            INQ_CreditLimitSumAndTotalResponse response = new INQ_CreditLimitSumAndTotalResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(CustCode))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CustCode is required";
                response.Data = new Q_Inq_CreditLimit_SumAndTotal_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@CustCode", CustCode);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@TOTSumTOTLiabiRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_Inq_CreditLimit_SumAndTotal_rsp, dynamic>(
                            storedProcedure: "usp_q_Inquiry_CreditLimit_GetTotSum_TotLiability",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var TOTSumTOTLiabiRsp = param.Get<dynamic>("@TOTSumTOTLiabiRsp");

                if (Resp == 1)
                {
                    Q_Inq_CreditLimit_SumAndTotal_rsp jsonResponse = JsonSerializer.Deserialize<Q_Inq_CreditLimit_SumAndTotal_rsp>(TOTSumTOTLiabiRsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_Inq_CreditLimit_SumAndTotal_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_Inq_CreditLimit_SumAndTotal_rsp();
                return BadRequest(response);
            }
        }













    }
}