using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
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
    public class EXPCPaymentPackingCreditController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public EXPCPaymentPackingCreditController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<PaymentPCListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            PaymentPCListPageResponse response = new PaymentPCListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_PaymentPCListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_PaymentPCListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@PackingNo", PackingNo);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (PackingNo == null)
                {
                    param.Add("@PackingNo", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_PaymentPCListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_PaymentPackingListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_PaymentPCListPageRsp>)results;

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
                response.Data = new List<Q_PaymentPCListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult<PEXPCPPaymentResponse>> Select(string? PACKING_NO, string? record_type, string? rec_status, int? event_no, string? LFROM)
        {
            PEXPCPPaymentResponse response = new();
            response.Data = new();

            // Validate
            if (string.IsNullOrEmpty(PACKING_NO) || string.IsNullOrEmpty(record_type) || string.IsNullOrEmpty(rec_status) || event_no == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                return BadRequest(response);
            }

            try
            {
                // pExad
                var expc = (from row in _context.pExpcs
                            where row.PACKING_NO == PACKING_NO &&
                                  row.record_type == record_type &&
                                  row.rec_status == rec_status &&
                                  row.event_no == event_no
                            select row).FirstOrDefault();

                if (expc != null)
                {
                    // pPayment
                    if (expc.pay_instruc == "1")
                    {
                        response.Data.PPAYMENT = await EXHelper.GetPPayment(_context, expc.received_no);
                    }
                    response.Code = Constants.RESPONSE_OK;
                    response.Data.PEXPC = expc;
                    return Ok(response);
                }
                response.Message = "PACKING_NO does not exist";
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            return BadRequest(response);
        }












    }
}
