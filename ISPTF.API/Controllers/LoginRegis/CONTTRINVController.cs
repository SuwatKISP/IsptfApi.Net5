using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.PControlPack;
using ISPTF.Models.PIMTRInvoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.LoginRegis
{
    [ApiController]
    [Route("api/[controller]")]
    public class CONTTRINVController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public CONTTRINVController(ISqlDataAccess db)
        {
            _db = db;
        }
        //[HttpGet("select")]
        //public async Task<IEnumerable<PDocRegister>> GetAll(string? RegDocNo)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@RegDocNo", RegDocNo);

        //    var results = await _db.LoadData<PDocRegister, dynamic>(
        //                storedProcedure: "usp_pDocRegisterSelect",
        //                param);
        //    return results;
        //}

        [HttpGet("TRInvoice/list")]
        public async Task<IEnumerable<Q_Get_pIMTRInvoiceNumver_PageRsp>> GetTRList(string? InvNumber, string? CustCode, string? CustName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            //param.Add("LogType", LogType);
            //param.Add("@CenterID", CenterID);
            param.Add("@InvNumber", InvNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (InvNumber == null)
            {
                param.Add("@InvNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<Q_Get_pIMTRInvoiceNumver_PageRsp, dynamic>(
                        storedProcedure: "usp_q_Get_pIMTRInvoice_SelectPageTR",
                        param);
            return results;
        }

        [HttpPost("TRInvoice/save")]
        public async Task<ActionResult<List<PIMTRInvoiceRsp>>> Save([FromBody] PIMTRInvoiceSaveReq pIMTRInvoice)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@CustCode", pIMTRInvoice.CustCode);
            param.Add("@InvNumber", pIMTRInvoice.InvNumber);
            param.Add("@InvDate", pIMTRInvoice.InvDate);
            param.Add("@InvGroup", pIMTRInvoice.InvGroup);
            param.Add("@InvSupply", pIMTRInvoice.InvSupply);
            param.Add("@InvCcy", pIMTRInvoice.InvCcy);
            param.Add("@InvAmount", pIMTRInvoice.InvAmount);
            param.Add("@InvUse", pIMTRInvoice.InvUse);
            param.Add("@InvBalance", pIMTRInvoice.InvBalance);
            param.Add("@InvStatus", pIMTRInvoice.InvStatus);
            //param.Add("@LastUpDate", pIMTRInvoice.LastUpDate);
            param.Add("@UserCode", pIMTRInvoice.UserCode);
            param.Add("@UserDate", pIMTRInvoice.UserDate);
            param.Add("@TRFlag", pIMTRInvoice.TRFlag);


            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<PIMTRInvoiceRsp, dynamic>(
                    storedProcedure: "usp_pIMTRInvoice_Save",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Invoice Number Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("TRInvoice/delete")]
        public async Task<ActionResult<List<PIMTRInvoiceRsp>>> Delete([FromBody] PIMTRInvoiceDeleteReq pIMTRInvoice)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@CustCode", pIMTRInvoice.CustCode);
            param.Add("@InvNumber", pIMTRInvoice.InvNumber);

            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<PIMTRInvoiceRsp, dynamic>(
                    storedProcedure: "usp_pIMTRInvoice_Delete",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Register Doc Error";
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
