using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportBC;
using ISPTF.Models.ImportTR;
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


        [HttpGet("ListEXBC")]
        public async Task<ActionResult<EXBCQueryListPageResponse>> ListEXBC(string? CenterID, string? EXPORT_BC_NO, string? RECORD_TYPE, string? REC_STATUS, string? InvoiceNO, string? BENName, int Page, int PageSize)
        {
            EXBCQueryListPageResponse response = new EXBCQueryListPageResponse();
          //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(RECORD_TYPE) ||
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

        [HttpGet("ListEXLC")]
        public async Task<ActionResult<EXLCQueryListPageResponse>> ListEXLC(string? CenterID, string? EXPORT_LC_NO, string? RECORD_TYPE, string? REC_STATUS, string? InvoiceNO, string? BENName, int Page, int PageSize)
        {
            EXLCQueryListPageResponse response = new EXLCQueryListPageResponse();
            //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(RECORD_TYPE) ||
                Page == null ||
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, RECORD_TYPE,Page, PageSize is required";
                response.Data = new List<Q_EXLCQueryListPageRsp>();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
            param.Add("@RECORD_TYPE", RECORD_TYPE);
            param.Add("@REC_STATUS", REC_STATUS);
            param.Add("@InvoiceNO", InvoiceNO);
            param.Add("@BENName", BENName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_LC_NO == null)
            {
                param.Add("@EXPORT_LC_NO", "");
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
                var results = await _db.LoadData<Q_EXLCQueryListPageRsp, dynamic>(
                            storedProcedure: "usp_q_ExportLC",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCQueryListPageRsp>)results;
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
                response.Data = new List<Q_EXLCQueryListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("ListEXPC")]
        public async Task<ActionResult<EXPCQueryListPageResponse>> ListEXPC(string? CenterID, string? PACKING_NO, string? RECORD_TYPE, string? REC_STATUS, string? PNNo, string? CustName, int Page, int PageSize)
        {
            EXPCQueryListPageResponse response = new EXPCQueryListPageResponse();
            //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(RECORD_TYPE) ||
                Page == null ||
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, RECORD_TYPE,Page, PageSize is required";
                response.Data = new List<Q_EXPCQueryListPageRsp>();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@PACKING_NO", PACKING_NO);
            param.Add("@RECORD_TYPE", RECORD_TYPE);
            param.Add("@REC_STATUS", REC_STATUS);
            param.Add("@PNNo", PNNo);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (PACKING_NO == null)
            {
                param.Add("@PACKING_NO", "");
            }
            if (RECORD_TYPE == null)
            {
                param.Add("@RECORD_TYPE", "");
            }
            if (REC_STATUS == null)
            {
                param.Add("@REC_STATUS", "");
            }
            if (PNNo == null)
            {
                param.Add("@PNNo", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_EXPCQueryListPageRsp, dynamic>(
                            storedProcedure: "usp_q_ExportPC",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXPCQueryListPageRsp>)results;
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
                response.Data = new List<Q_EXPCQueryListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("ListEXAD")]
        public async Task<ActionResult<EXADQueryListPageResponse>> ListEXAD(string? CenterID, string? EXPORT_ADVICE_NO, string? RecType, string? RecStatus, string? BENName, int Page, int PageSize)
        {
            EXADQueryListPageResponse response = new EXADQueryListPageResponse();
            //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(RecType) ||
                Page == null ||
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, RecType,Page, PageSize is required";
                response.Data = new List<Q_EXADQueryListPageRsp>();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_ADVICE_NO", EXPORT_ADVICE_NO);
            param.Add("@RecType", RecType);
            param.Add("@RecStatus", RecStatus);
            param.Add("@BENName", BENName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_ADVICE_NO == null)
            {
                param.Add("@EXPORT_ADVICE_NO", "");
            }
            if (RecType == null)
            {
                param.Add("@RecType", "");
            }
            if (RecStatus == null)
            {
                param.Add("@RecStatus", "");
            }
            if (BENName == null)
            {
                param.Add("@BENName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_EXADQueryListPageRsp, dynamic>(
                            storedProcedure: "usp_q_ExportAD",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXADQueryListPageRsp>)results;
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
                response.Data = new List<Q_EXADQueryListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("ListIMTR")]
        public async Task<ActionResult<IMTRQueryListPageResponse>> ListIMTR(string? CenterID, string? TRNumber, string? RecType, string? RecStatus, string? BLNumber, string? CustName, int Page, int PageSize)
        {
            IMTRQueryListPageResponse response = new IMTRQueryListPageResponse();
            //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(RecType) ||
                Page == null ||
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, RecType,Page, PageSize is required";
                response.Data = new List<Q_IMTR_ListPage_rsp>();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@TRNumber", TRNumber);
            param.Add("@RecType", RecType);
            param.Add("@RecStatus", RecStatus);
            param.Add("@BLNumber", BLNumber);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (TRNumber == null)
            {
                param.Add("@TRNumber", "");
            }
            if (RecType == null)
            {
                param.Add("@RecType", "");
            }
            if (RecStatus == null)
            {
                param.Add("@RecStatus", "");
            }
            if (BLNumber == null)
            {
                param.Add("@BLNumber", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_IMTR_ListPage_rsp, dynamic>(
                            storedProcedure: "usp_q_ImportTR",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMTR_ListPage_rsp>)results;
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
                response.Data = new List<Q_IMTR_ListPage_rsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("ListIMLC")]
        public async Task<ActionResult<IMLCQueryListPageResponse>> ListIMLC(string? CenterID, string? LCNumber, string? RecType, string? RecStatus, string? CustName, int Page, int PageSize)
        {
            IMLCQueryListPageResponse response = new IMLCQueryListPageResponse();
            //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(RecType) ||
                Page == null ||
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, RecType,Page, PageSize is required";
                response.Data = new List<Q_IMLCQueryListPageRsp>();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@LCNumber", LCNumber);
            param.Add("@RecType", RecType);
            param.Add("@RecStatus", RecStatus);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (LCNumber == null)
            {
                param.Add("@LCNumber", "");
            }
            if (RecType == null)
            {
                param.Add("@RecType", "");
            }
            if (RecStatus == null)
            {
                param.Add("@RecStatus", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_IMLCQueryListPageRsp, dynamic>(
                            storedProcedure: "usp_q_ImportLC",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMLCQueryListPageRsp>)results;
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
                response.Data = new List<Q_IMLCQueryListPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("ListIMBC")]
        public async Task<ActionResult<IMBCQueryListPageResponse>> ListIMBC(string? CenterID, string? BCNumber, string? RecType, string? RecStatus, string? CustName, int Page, int PageSize)
        {
            IMBCQueryListPageResponse response = new IMBCQueryListPageResponse();
            //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(RecType) ||
                Page == null ||
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, RecType,Page, PageSize is required";
                response.Data = new List<Q_IMBCQueryListPageRsp>();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@BCNumber", BCNumber);
            param.Add("@RecType", RecType);
            param.Add("@RecStatus", RecStatus);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BCNumber == null)
            {
                param.Add("@BCNumber", "");
            }
            if (RecType == null)
            {
                param.Add("@RecType", "");
            }
            if (RecStatus == null)
            {
                param.Add("@RecStatus", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_IMBCQueryListPageRsp, dynamic>(
                            storedProcedure: "usp_q_ImportBC",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMBCQueryListPageRsp>)results;
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
                response.Data = new List<Q_IMBCQueryListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("ListIMBL")]
        public async Task<ActionResult<IMBLQueryListPageResponse>> ListIMBL(string? CenterID, string? BLNumber, string? RecType, string? RecStatus, string? CustName, int Page, int PageSize)
        {
            IMBLQueryListPageResponse response = new IMBLQueryListPageResponse();
            //  var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(RecType) ||
                Page == null ||
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, RecType,Page, PageSize is required";
                response.Data = new List<Q_IMBLQueryListPageRsp>();
                return BadRequest(response);

            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@BLNumber", BLNumber);
            param.Add("@RecType", RecType);
            param.Add("@RecStatus", RecStatus);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BLNumber == null)
            {
                param.Add("@BLNumber", "");
            }
            if (RecType == null)
            {
                param.Add("@RecType", "");
            }
            if (RecStatus == null)
            {
                param.Add("@RecStatus", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_IMBLQueryListPageRsp, dynamic>(
                            storedProcedure: "usp_q_ImportBL",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMBLQueryListPageRsp>)results;
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
                response.Data = new List<Q_IMBLQueryListPageRsp>();
            }
            return BadRequest(response);
        }


    }
}
