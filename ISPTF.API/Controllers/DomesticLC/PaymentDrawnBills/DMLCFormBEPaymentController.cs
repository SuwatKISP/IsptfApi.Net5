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
    public class DMLCFormBEPaymentController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public DMLCFormBEPaymentController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }


        [HttpGet("select")]
        public async Task<ActionResult<Q_DMLC_PaymentDBE_Select_Response>> NewSelect(string? ListType, string? LoadPay, string? BENumber, int? BESeqno, string? RecType, string? Event, string? RecStatus, string? BECcy, string? CustCode, string? UserCode)
        {
            Q_DMLC_PaymentDBE_Select_Response response = new Q_DMLC_PaymentDBE_Select_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(LoadPay))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, LoadPay is required";
                response.Data = new Q_DMLC_PaymentDBE_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadPay != "PAYMENT" && LoadPay != "PAY-OVERDUE" )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC shoud be PAYMENT, PAY-OVERDUE ";
                response.Data = new Q_DMLC_PaymentDBE_Select_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@LoadPay", LoadPay);
                param.Add("@BENumber", BENumber);
                param.Add("@BESeqno", BESeqno);
                param.Add("@RecType", RecType);
                param.Add("@Event", Event);
                param.Add("@RecStatus", RecStatus);
                param.Add("@BECcy", BECcy);
                param.Add("@CustCode", CustCode);
                param.Add("@UserCode", UserCode);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@PaymentResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_DMLC_PaymentDBE_Select_JSON_rsp, dynamic>(
                            storedProcedure: "[usp_q_DMLC_PaymentBillsSelect]",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var PaymentResp = param.Get<dynamic>("@PaymentResp");

                if (Resp == 1)
                {
                    Q_DMLC_PaymentDBE_Select_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_DMLC_PaymentDBE_Select_JSON_rsp>(PaymentResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_DMLC_PaymentDBE_Select_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_DMLC_PaymentDBE_Select_JSON_rsp();
                return BadRequest(response);
            }
        }

























        [HttpHead("Remark1/1.For Select Menu Payment Drawn Bills ")]
        [HttpHead("Remark2/2.For Select Menu Payment OverDue Bills")]
        [HttpHead("Remark3/3.ListType = NEW, EDIT, RELEASE")]
        [HttpHead("Remark4/4.LoadPay for PAYMENT , PAY-OVERDUE ")]
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
