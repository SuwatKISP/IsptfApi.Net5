using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.PSWExport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.PSWExport
{
    [ApiController]
    [Route("api/[controller]")]
    public class PSWExportController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PSWExportController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("select")]
        public async Task<IEnumerable<PSWExportRsp>> GetAll(string? DOCNO, int? EVENT_NO )
        {
            DynamicParameters param = new();

            param.Add("@DocNo", DOCNO);
            param.Add("@EVENT_NO", EVENT_NO);
            if(DOCNO is null)
            {
                param.Add("@DocNo", "");
            }
            if(EVENT_NO is null)
            {
                param.Add("@EVENT_NO", "");
            }

            var results = await _db.LoadData<PSWExportRsp, dynamic>(
                        storedProcedure: "usp_pSWExport_Select",
                        param);
            return results;
        }

        [HttpPost("save")]
        public async Task<ActionResult<List<PSWExportRsp>>> Save([FromBody] PSWExportReq savePSWExport)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@AutoNum", savePSWExport.AutoNum);
            param.Add("@DocNo", savePSWExport.DocNo);
            param.Add("@Event_No", savePSWExport.Event_No);
            param.Add("@Event", savePSWExport.Event);
            param.Add("@SwiftFile", savePSWExport.SwiftFile);
            param.Add("@MTType", savePSWExport.MTType);
            param.Add("@BankType", savePSWExport.BankType);
            param.Add("@BankID", savePSWExport.BankID);
            param.Add("@BankInFo", savePSWExport.BankInFo);
            param.Add("@NBankID", savePSWExport.NBankID);
            param.Add("@NBankInfo", savePSWExport.NBankInfo);
            param.Add("@MT742", savePSWExport.MT742);
            param.Add("@MT730", savePSWExport.MT730);
            param.Add("@MT499", savePSWExport.MT499);
            param.Add("@MT799", savePSWExport.MT799);
            param.Add("@MT999", savePSWExport.MT999);
            param.Add("@ValueDate", savePSWExport.ValueDate);
            param.Add("@RemitCcy", savePSWExport.RemitCcy);
            param.Add("@RemitAmt", savePSWExport.RemitAmt);
            param.Add("@ChargeAmt", savePSWExport.ChargeAmt);
            param.Add("@F20", savePSWExport.F20);
            param.Add("@F21", savePSWExport.F21);
            param.Add("@F23B", savePSWExport.F23B);
            param.Add("@F25", savePSWExport.F25);
            param.Add("@F26T", savePSWExport.F26T);
            param.Add("@F31", savePSWExport.F31);
            param.Add("@F32A", savePSWExport.F32A);
            param.Add("@F32B", savePSWExport.F32B);
            param.Add("@F33B", savePSWExport.F33B);
            param.Add("@F34A", savePSWExport.F34A);
            param.Add("@F34B", savePSWExport.F34B);
            param.Add("@F52A", savePSWExport.F52A);
            param.Add("@F52D", savePSWExport.F52D);
            param.Add("@F52UID", savePSWExport.F52UID);
            param.Add("@F53A", savePSWExport.F53A);
            param.Add("@F53D", savePSWExport.F53D);
            param.Add("@F56A", savePSWExport.F56A);
            param.Add("@F56D", savePSWExport.F56D);
            param.Add("@F56UID", savePSWExport.F56UID);
            param.Add("@F57A", savePSWExport.F57A);
            param.Add("@F57AC", savePSWExport.F57AC);
            param.Add("@F57D", savePSWExport.F57D);
            param.Add("@F57UID", savePSWExport.F57UID);
            param.Add("@F58A", savePSWExport.F58A);
            param.Add("@F58AC", savePSWExport.F58AC);
            param.Add("@F58D", savePSWExport.F58D);
            param.Add("@F58UID", savePSWExport.F58UID);
            param.Add("@F59A", savePSWExport.F59A);
            param.Add("@F59D", savePSWExport.F59D);
            param.Add("@F59UID", savePSWExport.F59UID);
            param.Add("@F71B", savePSWExport.F71B);
            param.Add("@F72", savePSWExport.F72);
            param.Add("@F73", savePSWExport.F73);
            param.Add("@F77", savePSWExport.F77);
            param.Add("@F77B", savePSWExport.F77B);
            param.Add("@F79", savePSWExport.F79);
            param.Add("@MT768", savePSWExport.MT768);

            param.Add("@TX30", savePSWExport.TX30);
            param.Add("@TX31C", savePSWExport.TX31C);
            param.Add("@TX799", savePSWExport.TX799);
            param.Add("@TX999", savePSWExport.TX999);


            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PSWExportRsp, dynamic>(
                    storedProcedure: "usp_pSWExport_Save",
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
                    response.Message = "Doc NO not found";
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
