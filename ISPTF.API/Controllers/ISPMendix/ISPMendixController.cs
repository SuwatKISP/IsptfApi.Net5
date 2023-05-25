using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ISPMendix;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISPTF.API.Controllers.ISPMendix
{
    [Route("api/[controller]")]
    [ApiController]
    public class ISPMendixController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public ISPMendixController(ISqlDataAccess db)
        {
            _db = db;
        }

 
        [HttpGet("GetOrderID")]
        public async Task<ActionResult<GetOrderIDRsp>> GetOrderID(string? UserID)
        {
            DynamicParameters param = new();
            param.Add("@UserID", UserID);

            param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            param.Add("@OrderID", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<GetOrderIDRsp, dynamic>(
                           storedProcedure: "usp_GetOrderID",
                           param);

                var resp = param.Get<dynamic>("@Resp");
                var OrderID = param.Get<dynamic>("@OrderID");

                if (resp > 0)
                {
                    return Ok(OrderID);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Not Found";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetParaAccount")]
        public async Task<ActionResult<GetAccountRsp>> GetParaAccount()
        {
            DynamicParameters param = new();

            param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);

            param.Add("@AccountResp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<GetAccountRsp, dynamic>(
                           storedProcedure: "usp_GetMendix_ParaAccount",
                           param);

                var resp = param.Get<dynamic>("@Resp");
                var AccountResp = param.Get<dynamic>("@AccountResp");

                if (resp > 0)
                {
                    return Ok(AccountResp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Not Found";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetParaAccount2")]
        public async Task<ActionResult<GetAccountRsp2>> GetParaAccount2(string? Cust_code, string? AccNo, int? AccSeq)
            {
            DynamicParameters param = new();
            param.Add("@Cust_code", Cust_code);
            param.Add("@AccountNo", AccNo);
            param.Add("@Acc_Seq", AccSeq);

            param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);

            param.Add("@AccountResp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<GetAccountRsp2, dynamic>(
                           storedProcedure: "usp_GetMendix_ParaAccount2",
                           param);

                var resp = param.Get<dynamic>("@Resp");
                var AccountResp = param.Get<dynamic>("@AccountResp");

                if (resp > 0)
                {
                    return Ok(AccountResp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Not Found";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetParaOrders")]
        public async Task<ActionResult<GetOrdersRsp>> GetParaOrders(string? CustCode, string? AccNo, int? AccSeq,string? OrderID ,string? ServiceCode , double? Amount, string? ReferNo, string? UserID )
        {
            DynamicParameters param = new();
            param.Add("Cust_code", CustCode);
            param.Add("@AccountNo", AccNo);
            param.Add("@Acc_Seq", AccSeq);
            param.Add("@order_id", OrderID);
            param.Add("@service_code", ServiceCode);
            param.Add("@Amount", Amount);
            param.Add("@ReferNo", ReferNo);
            param.Add("@UserID", UserID);

            param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);

            param.Add("@OrdersResp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<GetOrdersRsp, dynamic>(
                           storedProcedure: "usp_GetMendix_ParaOrders",
                           param);

                var resp = param.Get<dynamic>("@Resp");
                var OrderResp = param.Get<dynamic>("@OrdersResp");

                if (resp > 0)
                {
                    return Ok(OrderResp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Not Found";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAccountType")]
        public async Task<ActionResult<GetAccountTypeRsp>> GetAccType(string? Cust_code,string? AccNo,int? AccSeq)
        {
            DynamicParameters param = new();
            param.Add("Cust_code", Cust_code);
            param.Add("@Acc_No", AccNo);
            param.Add("@Acc_Seq", AccSeq);

            param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            param.Add("@AccountType", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<GetAccountTypeRsp, dynamic>(
                           storedProcedure: "usp_GetAccountType",
                           param);

                var resp = param.Get<dynamic>("@Resp");
                var AccountType = param.Get<dynamic>("@AccountType");

                if (resp > 0)
                {
                    return Ok(AccountType);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Not Found";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
