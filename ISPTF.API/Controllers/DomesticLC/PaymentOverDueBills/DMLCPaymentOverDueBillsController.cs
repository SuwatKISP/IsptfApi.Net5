using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.DomesticLC;
using ISPTF.Models.ImportLC;
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

namespace ISPTF.API.Controllers.DomesticLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DMLCPaymentOverDueBillsController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public DMLCPaymentOverDueBillsController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

   
        [HttpGet("list")]
        public async Task<ActionResult<PaymentOverDueBillsListPageResponse>> List(string? ListType,string? CenterID, string? @BENumber, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            PaymentOverDueBillsListPageResponse response = new PaymentOverDueBillsListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_PaymentOverDueBillsListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_PaymentOverDueBillsListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@BENumber", BENumber);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (BENumber == null)
                {
                    param.Add("@BENumber", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_PaymentOverDueBillsListPageRsp, dynamic>(
                            storedProcedure: "usp_q_DMLC_PaymentOverDueBillsListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_PaymentOverDueBillsListPageRsp>)results;

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
                response.Data = new List<Q_PaymentOverDueBillsListPageRsp>();
            }
            return BadRequest(response);
        }





        [HttpHead("listSelect/ Use DMLCFormBEPayment/select  ")]

        public async Task<ActionResult<IMLCResultResponse>> Remark([FromBody] IMLC_RemarkAmend_JSON_req save)
        {
            IMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            try
            {
                DynamicParameters param = new DynamicParameters();
                ////ListType

                //await _db.SaveData(
                //  storedProcedure: "usp_pIMLC_Amend_Release", param);
                var resp = param.Get<int>("@Resp");

                if (resp > 0)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(response);
            }
        }











    }
}
