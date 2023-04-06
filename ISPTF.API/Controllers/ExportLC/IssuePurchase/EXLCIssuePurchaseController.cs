using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.ExportLC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.ExportLC
{
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCIssuePurchaseController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public EXLCIssuePurchaseController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("newlist")]
        public async Task<IEnumerable<Q_EXLCIssueNewPageRsp>> GetAllNew(string? CenterID, string? RegDocNo, string? BENName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@CenterID", CenterID);
            param.Add("@RegDocNo", RegDocNo);
            param.Add("@BENName", BENName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (RegDocNo == null)
            {
                param.Add("@RegDocNo", "");
            }
            if (BENName == null)
            {
                param.Add("@BENName", "");
            }

            var results = await _db.LoadData<Q_EXLCIssueNewPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXLC_IssuePurchNewPage",
                        param);
            return results;
        }

        [HttpGet("editlist")]
        public async Task<IEnumerable<Q_EXLCIssueEditPageRsp>> GetAllEdit(string? CenterID, string? EXPORT_LC_NO, string? BENNAME, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
            param.Add("@BENNAME", BENNAME);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_LC_NO == null)
            {
                param.Add("@EXPORT_LC_NO", "");
            }
            if (BENNAME == null)
            {
                param.Add("@BENNAME", "");
            }

            var results = await _db.LoadData<Q_EXLCIssueEditPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXLC_IssuePurchEditPage",
                        param);
            return results;
        }

        [HttpGet("releaselist")]
        public async Task<IEnumerable<Q_EXLCIssueEditPageRsp>> GetAllrelease(string? CenterID,string? USER_ID, string? EXPORT_LC_NO, string? BENNAME, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@CenterID", CenterID);
            param.Add("@USER_ID", USER_ID);
            param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
            param.Add("@BENNAME", BENNAME);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_LC_NO == null)
            {
                param.Add("@EXPORT_LC_NO", "");
            }
            if (BENNAME == null)
            {
                param.Add("@BENNAME", "");
            }

            var results = await _db.LoadData<Q_EXLCIssueEditPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXLC_IssuePurchReleasePage",
                        param);
            return results;
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

// editselect new with jaon
        [HttpGet("select")]
        public async Task<ActionResult<PEXLCPPaymentRsp>> GetAllSelect(string? EXPORT_LC_NO, string? RECORD_TYPE, string? REC_STATUS, string? EVENT_NO)
        {
            DynamicParameters param = new();

            param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
            param.Add("@RECORD_TYPE", RECORD_TYPE);
            param.Add("@REC_STATUS", REC_STATUS);
            param.Add("@EVENT_NO", EVENT_NO);

            param.Add("@PExLcRsp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                       direction: System.Data.ParameterDirection.Output,
                       size: 5215585);
            try
            {
                var results = await _db.LoadData<PEXLCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_IssuePurchase_Select",
                           param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PExLcRsp > 0)
                {
                    return Ok(pexlcpexpaymentrsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "EXPORT L/C NO does not exit";
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
