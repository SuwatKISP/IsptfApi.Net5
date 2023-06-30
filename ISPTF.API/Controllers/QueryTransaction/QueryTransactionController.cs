using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportBC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.QueryTransaction
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueryTransactionController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public QueryTransactionController(ISqlDataAccess db)
        {
            _db = db;
        }
        //[HttpGet("ExportBC")]
        //public async Task<IEnumerable<PEXBC>> GetQuery(string? CenterID, string? EXPORT_BC_NO, string? RECORD_TYPE, string? REC_STATUS, string? InvoiceNO, string? BENName, int Page, int PageSize)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@CenterID", CenterID);
        //    param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
        //    param.Add("@RECORD_TYPE", RECORD_TYPE);
        //    param.Add("@REC_STATUS", REC_STATUS);
        //    param.Add("@InvoiceNO", InvoiceNO);
        //    param.Add("@BENName", BENName);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (EXPORT_BC_NO == null)
        //    {
        //        param.Add("@EXPORT_BC_NO", "");
        //    }
        //    if (RECORD_TYPE == null)
        //    {
        //        param.Add("@RECORD_TYPE", "");
        //    }
        //    if (REC_STATUS == null)
        //    {
        //        param.Add("@REC_STATUS", "");
        //    }
        //    if (InvoiceNO == null)
        //    {
        //        param.Add("@InvoiceNO", "");
        //    }
        //    if (BENName == null)
        //    {
        //        param.Add("@BENName", "");
        //    }


        //    var results = await _db.LoadData<PEXBC, dynamic>(
        //        storedProcedure: "usp_q_ExportBC",
        //        param);
        //    return results;
        //}


        [HttpGet("list")]
        public async Task<ActionResult<EXBCQueryListPageResponse>> List(string? CenterID, string? EXPORT_BC_NO, string? RECORD_TYPE, string? REC_STATUS, string? InvoiceNO, string? BENName, int Page, int PageSize)
        {
            EXBCQueryListPageResponse response = new EXBCQueryListPageResponse();
          //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(@CenterID) ||
                string.IsNullOrEmpty(@RECORD_TYPE) ||
                Page == null ||
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, RECORD_TYPE,Page, PageSize is required";
                response.Data = new List<Q_EXBCQueryListPageRsp>();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@RECORD_TYPE", RECORD_TYPE);
            param.Add("@REC_STATUS", REC_STATUS);
            param.Add("@InvoiceNO", InvoiceNO);
            param.Add("@BENName", BENName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_BC_NO == null)
            {
                param.Add("@EXPORT_BC_NO", "");
            }
            if (RECORD_TYPE == null)
            {
                param.Add("@RECORD_TYPE", "");
            }
            if (REC_STATUS == null)
            {
                param.Add("@REC_STATUS", "");
            }
            if (InvoiceNO == null)
            {
                param.Add("@InvoiceNO", "");
            }
            if (BENName == null)
            {
                param.Add("@BENName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_EXBCQueryListPageRsp, dynamic>(
                            storedProcedure: "usp_q_ExportBC",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCQueryListPageRsp>)results;
                try
                {
                    response.Page = (int)Page;
                    response.Total = (int)response.Data[0].RCount;
                    response.TotalPage = (int)((response.Total + PageSize - 1) / PageSize);
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
                response.Data = new List<Q_EXBCQueryListPageRsp>();
            }
            return BadRequest(response);
        }




    }
}
