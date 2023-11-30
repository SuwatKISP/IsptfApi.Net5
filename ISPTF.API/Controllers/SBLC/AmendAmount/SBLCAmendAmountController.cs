using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.SBLC;
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
using ISPTF.Models.PIMSBLC;

namespace ISPTF.API.Controllers.SBLC
{
    [ApiController]
    [Route("api/[controller]")]
    public class SBLCAmendAmountController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public SBLCAmendAmountController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("newlist")]
        public async Task<IEnumerable<SBLCAmendAmountNewListRsp>> GetNew(string? ListType ,string? CenterID,string? Reg_Docno, string? CustCode, string? CustName,string? UserCode, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@Reg_Docno", Reg_Docno);
            param.Add("@SBLCNumber", "");
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@UserCode", UserCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (Reg_Docno == null)
            {
                param.Add("@Reg_Docno", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<SBLCAmendAmountNewListRsp, dynamic>(
                        storedProcedure: "usp_q_SBLC_AmendAmountListPage",
                        param);
            return results;
        }

        [HttpGet("editreleaselist")]
        public async Task<IEnumerable<PIMSBLCRsp>> GetEditRelease(string? ListType, string? CenterID,  string? SBLCNumber, string? CustCode, string? CustName, string? UserCode, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            //param.Add("@Reg_Docno", Reg_Docno);
            param.Add("@Reg_Docno", "");
            param.Add("@SBLCNumber", SBLCNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@UserCode", UserCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);
           

            if (SBLCNumber == null)
            {
                param.Add("@SBLCNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<PIMSBLCRsp, dynamic>(
                        storedProcedure: "usp_q_SBLC_AmendAmountListPage",
                        param);
            return results;
        }

        [HttpGet("select")]
        public async Task<ActionResult<PSBLCPaymentRsp>> GetAllSelect(string SBLCNumber, string SBLCSeqno, string RecType, string EVENT, string RecStatus)
        {
            DynamicParameters param = new();

            param.Add("@SBLCNumber", SBLCNumber);
            param.Add("@SBLCSeqno", SBLCSeqno);
            param.Add("@RecType", RecType);
            param.Add("@EVENT", EVENT);
            param.Add("@RecStatus", RecStatus);

            param.Add("@PSBLCRsp", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@PSBLCPPaymentRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<PSBLCPaymentRsp, dynamic>(
                           storedProcedure: "usp_pSBLC_AmendAmount_Select",
                           param);

                var pSBLCRsp = param.Get<dynamic>("@PSBLCRsp");
                var pSBLCPPaymentRsp = param.Get<dynamic>("@PSBLCPPaymentRsp");

                if (pSBLCRsp > 0)
                {
                    return Ok(pSBLCPPaymentRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "IMPORT SB/LC NO for Collection does not exit";
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
