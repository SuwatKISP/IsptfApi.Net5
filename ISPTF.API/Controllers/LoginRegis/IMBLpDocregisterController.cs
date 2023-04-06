using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
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
    public class IMBLpDocregisterController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMBLpDocregisterController(ISqlDataAccess db)
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

        [HttpGet("register")]
        public async Task<IEnumerable<Q_GetDocRegisterPagebyModuleRsp>> GetAll(string? LogType, string? CenterID, string? RegDocNo, string? CustCode, string? CustName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("LogType", LogType);
            param.Add("@CenterID", CenterID);
            param.Add("@RegDocNo", RegDocNo);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (RegDocNo == null)
            {
                param.Add("@RegDocNo", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<Q_GetDocRegisterPagebyModuleRsp, dynamic>(
                        storedProcedure: "usp_q_GetDocRegisterSelectPageIMBL",
                        param);
            return results;
        }


        [HttpGet("register/referLCnum")]
        public async Task<IEnumerable<Q_GetDocRegisterReferLCNoIMBLRsp>> GetAllRefLC(string? CenterID, string? LCNumber, string? CustCode, string? CustName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            //param.Add("LogType", LogType);
            param.Add("@CenterID", CenterID);
            param.Add("@LCNumber", LCNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (LCNumber == null)
            {
                param.Add("@LCNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<Q_GetDocRegisterReferLCNoIMBLRsp, dynamic>(
                        storedProcedure: "usp_q_GetDocRegisterReferLCPageIMBL",
                        param);
            return results;
        }



        [HttpPost("register/insert")]
        public async Task<ActionResult<List<PDocRegisterInsUpdReq>>> Insert([FromBody] PDocRegisterInsUpdReq pdocregisterreq)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@LogType", pdocregisterreq.logType);
            param.Add("@Reg_Login", pdocregisterreq.reg_Login);
            param.Add("@Reg_Funct", pdocregisterreq.reg_Funct);
            param.Add("@Reg_Docno", pdocregisterreq.reg_Docno);
            param.Add("@Reg_Date", pdocregisterreq.reg_Date);
            param.Add("@Reg_Time", pdocregisterreq.reg_Time);
            param.Add("@Reg_seq", pdocregisterreq.reg_seq);
            param.Add("@Reg_DocType", pdocregisterreq.reg_DocType);
            param.Add("@Reg_RefType", pdocregisterreq.reg_RefType);
            param.Add("@Reg_RefNo", pdocregisterreq.reg_RefNo);
            param.Add("@Reg_RefNo2", pdocregisterreq.reg_RefNo2);
            param.Add("@Reg_RefNo3", pdocregisterreq.reg_RefNo3);
            param.Add("@Reg_RefAmt", pdocregisterreq.reg_RefAmt);
            param.Add("@Reg_CustCode", pdocregisterreq.reg_CustCode);
            param.Add("@Reg_BankCode", pdocregisterreq.reg_BankCode);
            param.Add("@Reg_Ccy", pdocregisterreq.reg_Ccy);
            param.Add("@Reg_CcyAmt", pdocregisterreq.reg_CcyAmt);
            param.Add("@Reg_CcyBal", pdocregisterreq.reg_CcyBal);
            param.Add("@Reg_ExchRate", pdocregisterreq.reg_ExchRate);
            param.Add("@Reg_BhtAmt", pdocregisterreq.reg_BhtAmt);
            param.Add("@Reg_Plus", pdocregisterreq.reg_Plus);
            param.Add("@Reg_Minus", pdocregisterreq.reg_Minus);
            param.Add("@Reg_Amt", pdocregisterreq.reg_Amt);
            param.Add("@Reg_Amt1", pdocregisterreq.reg_Amt1);
            param.Add("@Reg_Tenor", pdocregisterreq.reg_Tenor);
            param.Add("@Reg_Appv", pdocregisterreq.reg_Appv);
            param.Add("@Reg_Status", pdocregisterreq.reg_Status);
            param.Add("@Reg_RecStat", pdocregisterreq.reg_RecStat);
            param.Add("@Reg_FacilityNo", pdocregisterreq.reg_FacilityNo);
            param.Add("@Reg_AppvNo", pdocregisterreq.reg_AppvNo);
            param.Add("@Remark", pdocregisterreq.remark);
            //param.Add("@UpdateDate", DateTime.Now);
            param.Add("@UserCode", pdocregisterreq.userCode);
            //param.Add("@Authdate", pdocregisterreq.AuthDate);
            param.Add("@AuthCode", pdocregisterreq.authCode);
            param.Add("@CenterID", pdocregisterreq.centerID);
            param.Add("@ACCESS_ID", pdocregisterreq.accesS_ID);
            param.Add("@Trade_ref_Number", pdocregisterreq.trade_ref_Number);
            param.Add("@Edition_Number", pdocregisterreq.edition_Number);
            param.Add("@CIF", pdocregisterreq.cif);
            param.Add("@WithOut", pdocregisterreq.withOut);
            param.Add("@WithOutFlag", pdocregisterreq.withOutFlag);
            param.Add("@WithOutType", pdocregisterreq.withOutType);
            param.Add("@TenorDay", pdocregisterreq.tenorDay);
            param.Add("@BPOFlag", pdocregisterreq.bpoFlag);
            param.Add("@Reg_RefNo4", pdocregisterreq.reg_RefNo4);

            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<PDocRegister, dynamic>(
                    storedProcedure: "usp_pDocRegisterIMBLInsert",
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
                    response.Message = resp.ToString(); // "Register Doc Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/update")]
        public async Task<ActionResult<List<PDocRegisterInsUpdReq>>> Update([FromBody] PDocRegisterInsUpdReq pdocregisterreq)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@LogType", pdocregisterreq.logType);
            param.Add("@Reg_Login", pdocregisterreq.reg_Login);
            param.Add("@Reg_Funct", pdocregisterreq.reg_Funct);
            param.Add("@Reg_Docno", pdocregisterreq.reg_Docno);
            param.Add("@Reg_Date", pdocregisterreq.reg_Date);
            param.Add("@Reg_Time", pdocregisterreq.reg_Time);
            param.Add("@Reg_seq", pdocregisterreq.reg_seq);
            param.Add("@Reg_DocType", pdocregisterreq.reg_DocType);
            param.Add("@Reg_RefType", pdocregisterreq.reg_RefType);
            param.Add("@Reg_RefNo", pdocregisterreq.reg_RefNo);
            param.Add("@Reg_RefNo2", pdocregisterreq.reg_RefNo2);
            param.Add("@Reg_RefNo3", pdocregisterreq.reg_RefNo3);
            param.Add("@Reg_RefAmt", pdocregisterreq.reg_RefAmt);
            param.Add("@Reg_CustCode", pdocregisterreq.reg_CustCode);
            param.Add("@Reg_BankCode", pdocregisterreq.reg_BankCode);
            param.Add("@Reg_Ccy", pdocregisterreq.reg_Ccy);
            param.Add("@Reg_CcyAmt", pdocregisterreq.reg_CcyAmt);
            param.Add("@Reg_CcyBal", pdocregisterreq.reg_CcyBal);
            param.Add("@Reg_ExchRate", pdocregisterreq.reg_ExchRate);
            param.Add("@Reg_BhtAmt", pdocregisterreq.reg_BhtAmt);
            param.Add("@Reg_Plus", pdocregisterreq.reg_Plus);
            param.Add("@Reg_Minus", pdocregisterreq.reg_Minus);
            param.Add("@Reg_Amt", pdocregisterreq.reg_Amt);
            param.Add("@Reg_Amt1", pdocregisterreq.reg_Amt1);
            param.Add("@Reg_Tenor", pdocregisterreq.reg_Tenor);
            param.Add("@Reg_Appv", pdocregisterreq.reg_Appv);
            param.Add("@Reg_Status", pdocregisterreq.reg_Status);
            param.Add("@Reg_RecStat", pdocregisterreq.reg_RecStat);
            param.Add("@Reg_FacilityNo", pdocregisterreq.reg_FacilityNo);
            param.Add("@Reg_AppvNo", pdocregisterreq.reg_AppvNo);
            param.Add("@Remark", pdocregisterreq.remark);
            //param.Add("@UpdateDate", DateTime.Now);
            param.Add("@UserCode", pdocregisterreq.userCode);
            //param.Add("@Authdate", pdocregisterreq.AuthDate);
            param.Add("@AuthCode", pdocregisterreq.authCode);
            param.Add("@CenterID", pdocregisterreq.centerID);
            param.Add("@ACCESS_ID", pdocregisterreq.accesS_ID);
            param.Add("@Trade_ref_Number", pdocregisterreq.trade_ref_Number);
            param.Add("@Edition_Number", pdocregisterreq.edition_Number);
            param.Add("@CIF", pdocregisterreq.cif);
            param.Add("@WithOut", pdocregisterreq.withOut);
            param.Add("@WithOutFlag", pdocregisterreq.withOutFlag);
            param.Add("@WithOutType", pdocregisterreq.withOutType);
            param.Add("@TenorDay", pdocregisterreq.tenorDay);
            param.Add("@BPOFlag", pdocregisterreq.bpoFlag);
            param.Add("@Reg_RefNo4", pdocregisterreq.reg_RefNo4);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PDocRegister, dynamic>(
                    storedProcedure: "usp_pDocRegisterIMBLUpdate",
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
                    response.Message = "Register DocNo not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/cancel")]
        public async Task<ActionResult<List<PDocRegisterInsUpdReq>>> Cancel([FromBody] PDocRegisterInsUpdReq pdocregisterreq)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@LogType", pdocregisterreq.logType);
            param.Add("@Reg_Login", pdocregisterreq.reg_Login);
            param.Add("@Reg_Funct", pdocregisterreq.reg_Funct);
            param.Add("@Reg_Docno", pdocregisterreq.reg_Docno);
            param.Add("@Reg_Date", pdocregisterreq.reg_Date);
            param.Add("@Reg_Time", pdocregisterreq.reg_Time);
            param.Add("@Reg_seq", pdocregisterreq.reg_seq);
            param.Add("@Reg_DocType", pdocregisterreq.reg_DocType);
            param.Add("@Reg_RefType", pdocregisterreq.reg_RefType);
            param.Add("@Reg_RefNo", pdocregisterreq.reg_RefNo);
            param.Add("@Reg_RefNo2", pdocregisterreq.reg_RefNo2);
            param.Add("@Reg_RefNo3", pdocregisterreq.reg_RefNo3);
            param.Add("@Reg_RefAmt", pdocregisterreq.reg_RefAmt);
            param.Add("@Reg_CustCode", pdocregisterreq.reg_CustCode);
            param.Add("@Reg_BankCode", pdocregisterreq.reg_BankCode);
            param.Add("@Reg_Ccy", pdocregisterreq.reg_Ccy);
            param.Add("@Reg_CcyAmt", pdocregisterreq.reg_CcyAmt);
            param.Add("@Reg_CcyBal", pdocregisterreq.reg_CcyBal);
            param.Add("@Reg_ExchRate", pdocregisterreq.reg_ExchRate);
            param.Add("@Reg_BhtAmt", pdocregisterreq.reg_BhtAmt);
            param.Add("@Reg_Plus", pdocregisterreq.reg_Plus);
            param.Add("@Reg_Minus", pdocregisterreq.reg_Minus);
            param.Add("@Reg_Amt", pdocregisterreq.reg_Amt);
            param.Add("@Reg_Amt1", pdocregisterreq.reg_Amt1);
            param.Add("@Reg_Tenor", pdocregisterreq.reg_Tenor);
            param.Add("@Reg_Appv", pdocregisterreq.reg_Appv);
            param.Add("@Reg_Status", pdocregisterreq.reg_Status);
            param.Add("@Reg_RecStat", pdocregisterreq.reg_RecStat);
            param.Add("@Reg_FacilityNo", pdocregisterreq.reg_FacilityNo);
            param.Add("@Reg_AppvNo", pdocregisterreq.reg_AppvNo);
            param.Add("@Remark", pdocregisterreq.remark);
            //param.Add("@UpdateDate", DateTime.Now);
            param.Add("@UserCode", pdocregisterreq.userCode);
            //param.Add("@Authdate", pdocregisterreq.AuthDate);
            param.Add("@AuthCode", pdocregisterreq.authCode);
            param.Add("@CenterID", pdocregisterreq.centerID);
            param.Add("@ACCESS_ID", pdocregisterreq.accesS_ID);
            param.Add("@Trade_ref_Number", pdocregisterreq.trade_ref_Number);
            param.Add("@Edition_Number", pdocregisterreq.edition_Number);
            param.Add("@CIF", pdocregisterreq.cif);
            param.Add("@WithOut", pdocregisterreq.withOut);
            param.Add("@WithOutFlag", pdocregisterreq.withOutFlag);
            param.Add("@WithOutType", pdocregisterreq.withOutType);
            param.Add("@TenorDay", pdocregisterreq.tenorDay);
            param.Add("@BPOFlag", pdocregisterreq.bpoFlag);
            param.Add("@Reg_RefNo4", pdocregisterreq.reg_RefNo4);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PDocRegister, dynamic>(
                    storedProcedure: "usp_pDocRegisterIMBLCancel",
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
                    response.Message = "Register DocNo not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("issue")]
        //public async Task<IEnumerable<Q_GetDocRegisterIssueRsp>> GetAll(string? CenterID, string? RegDocNo, string? CustCode, string? CustName, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@CenterID", CenterID);
        //    param.Add("@RegDocNo", RegDocNo);
        //    param.Add("@CustCode", CustCode);
        //    param.Add("@CustName", CustName);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (RegDocNo == null)
        //    {
        //        param.Add("@RegDocNo", "");
        //    }
        //    if (CustCode == null)
        //    {
        //        param.Add("@CustCode", "");
        //    }
        //    if (CustName == null)
        //    {
        //        param.Add("@CustName", "");
        //    }

        //    var results = await _db.LoadData<Q_GetDocRegisterIssueRsp, dynamic>(
        //                storedProcedure: "usp_q_GetDocRegisterIssuedIMBL",
        //                param);
        //    return results;
        //}








    }
}
