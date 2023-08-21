﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ImportBL;
using ISPTF.Models.PPayment;
using ISPTF.Models.LoginRegis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ISPTF.Models.ImportBC;

namespace ISPTF.API.Controllers.ImportBL
{
    [ApiController]
    [Route("api/[controller]")]
    public class IMBLIssuedController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMBLIssuedController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        public async Task<ActionResult<IEnumerable<object>>> GetAll(string ListType, string CenterID, string BLNumber, string CustCode, string CustName, string UserCode, string Page, string PageSize, string RegDocno)
        {
            DynamicParameters param = new();

            //param.Add("@SupType", SupType);
            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@BLNumber", BLNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@UserCode", UserCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);
            param.Add("@Reg_Docno", RegDocno);

            if (RegDocno == null)
            {
                param.Add("@Reg_Docno", "");
            }
            if (BLNumber == null)
            {
                param.Add("@BLNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            IEnumerable<object> results;

            if (ListType == "EDIT" || ListType == "RELEASE")
            {
                results = await _db.LoadData<PIMBLListRsp, dynamic>(
                    storedProcedure: "usp_q_IMBL_IssueBillsListPage",
                    param
                );
                return Ok(results);
            }
            else if (ListType == "NEW")
            {

                results = await _db.LoadData<PIMBLListRspNewList, dynamic>(
                    storedProcedure: "usp_q_IMBL_IssueBillsListPage",
                    param
                );
                return Ok(results);
            }
            else
            {
                ReturnResponse response = new();
                response.StatusCode = "400";
                response.Message = "Invalid ListType.";
                return BadRequest(response);
            }
        }


        // Select from pDocRegister
        [HttpGet("newselect")]
        public async Task<IEnumerable<PDocRegister>> GetNewSelect(string? RegDocNo)
        {
            DynamicParameters param = new();

            param.Add("@RegDocNo", RegDocNo);

            var results = await _db.LoadData<PDocRegister, dynamic>(
                        storedProcedure: "usp_pDocRegisterSelect",
                        param);
            return results;
        }

        [HttpGet("select")]
        public async Task<ActionResult<PIMBLPPaymentRsp>> GetAllSelect(string ADNumber, string BLSeqno, string RecType, string EVENT, string RecStatus)
        {
            DynamicParameters param = new();

            param.Add("@ADNumber", ADNumber);
            param.Add("@BLSeqno", BLSeqno);
            param.Add("@RecType", RecType);
            param.Add("@EVENT", EVENT);
            param.Add("@RecStatus", RecStatus);

            param.Add("@PIMBLRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBLPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<PIMBLPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pIMBL_Issued_Select",
                           param);

                var PIMBLRsp = param.Get<dynamic>("@PIMBLRsp");
                var PIMBLPPaymentRsp = param.Get<dynamic>("@PIMBLPPaymentRsp");

                if (PIMBLRsp > 0)
                {
                    return Ok(PIMBLPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "IMPORT B/L NO Bill does not exit";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("select/master")]
        public async Task<ActionResult<PIMBLPPaymentRsp>> GetAllSelect(string ADNumber, string BLSeqno, string EVENT, string RecStatus)
        {
            DynamicParameters param = new();

            param.Add("@ADNumber", ADNumber);
            param.Add("@BLSeqno", BLSeqno);
            param.Add("@EVENT", EVENT);
            param.Add("@RecStatus", RecStatus);

            param.Add("@PIMBLRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBLPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<PIMBLPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pIMBL_Issued_Select_Master",
                           param);

                var PIMBLRsp = param.Get<dynamic>("@PIMBLRsp");
                var PIMBLPPaymentRsp = param.Get<dynamic>("@PIMBLPPaymentRsp");

                if (PIMBLRsp > 0)
                {
                    return Ok(PIMBLPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "IMPORT B/L NO Bill does not exit";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("release")]
        public async Task<ActionResult<List<PIMBLPPaymentRsp>>> GetAllRelease([FromBody] PIMBLReleaseReq pimbcrsp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BCNumber", pimbcrsp.BLNumber);
            param.Add("@RecType", pimbcrsp.RecType);
            param.Add("@BCSeqno", pimbcrsp.BLSeqno);
            param.Add("@Event", pimbcrsp.Event);
            param.Add("@AuthCode", pimbcrsp.AuthCode);

            param.Add("@PIMBLRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PIMBLPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PIMBCPPaymentRsp, dynamic>(
                    storedProcedure: "usp_pIMBL_Issued_Release",
                    param);
                var PIMBCRsp = param.Get<dynamic>("@PIMBLRsp");
                var PIMBCPPaymentRsp = param.Get<dynamic>("@PIMBLPPaymentRsp");
                var resp = param.Get<int>("@Resp");

                if (PIMBCRsp == 1)
                {
                    return Ok(PIMBCPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "BL Number not exist";
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
