using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ImportBC;
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

namespace ISPTF.API.Controllers.ImportBC
{
    [ApiController]
    [Route("api/[controller]")]
    public class IMBCSwiftController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMBCSwiftController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("select")]
        public async Task<ActionResult<IMBCSwift>> GetAllSelect(string loginType, string BCNumber, string BCSeqno)
        {
            DynamicParameters param = new();

            param.Add("@BCNumber", BCNumber);
            param.Add("@BCSeqno", BCSeqno);
            param.Add("@LoginType", loginType);

            param.Add("@swiftIMBCExist", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@swiftIMBCRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<IMBCSwift, dynamic>(
                           storedProcedure: "usp_pIMBC_psSWIFT_SELECT",
                           param);

                var SwiftExist = param.Get<dynamic>("@swiftIMBCExist");
                var SwiftRsp = param.Get<dynamic>("@swiftIMBCRsp");

                if (SwiftExist > 0)
                {
                    return Ok(SwiftRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "IMPORT B/L Swift does not exit";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("insert")]
        public async Task<ActionResult<IMBCSwift>> insert([FromBody] IMBCSwiftReq swiftReq)
        {
            DynamicParameters param = new();

            param.Add("@BCNumber", swiftReq.PIMBC.BCNumber);
            param.Add("@BCSeqno", swiftReq.PIMBC.BCSeqno);
            param.Add("@LoginType", "IMBC");
            param.Add("@Login", "IMBC");

            param.Add("@RefNumber", swiftReq.pSwift?.RefNumber ?? "");
            param.Add("@RemitCcy", swiftReq.pSwift?.RemitCcy);
            param.Add("@RemitAmt", swiftReq.pSwift?.RemitAmt);
            param.Add("@DeductAmt", swiftReq.pSwift?.DeductAmt);
            param.Add("@ChargeAmt", swiftReq.pSwift?.ChargeAmt);
            param.Add("@Amt71", swiftReq.pSwift?.Amt71 ?? 0);
            param.Add("@ValueDate", swiftReq.pSwift?.ValueDate ?? null);
            param.Add("@SwiftFile", swiftReq.pSwift?.SwiftFile ?? "");
            param.Add("@MT103", swiftReq.pSwift?.MT103 ?? 0);
            param.Add("@MT202", swiftReq.pSwift?.MT202 ?? 0);
            param.Add("@MT734", swiftReq.pSwift?.MT734 ?? 0);
            param.Add("@MT752", swiftReq.pSwift?.MT752 ?? 0);
            param.Add("@MT754", swiftReq.pSwift?.MT754 ?? 0);
            param.Add("@MT756", swiftReq.pSwift?.MT756 ?? 0);
            param.Add("@MT799", swiftReq.pSwift?.MT799 ?? 0);
            param.Add("@MT999", swiftReq.pSwift?.MT999 ?? 0);
            param.Add("@MT412", swiftReq.pSwift?.MT412 ?? 0);
            param.Add("@MT499", swiftReq.pSwift?.MT499 ?? 0);
            param.Add("@MT202Cov", swiftReq.pSwift?.MT202Cov ?? 0);
            param.Add("@MT400", swiftReq.pSwift?.MT400 ?? 0);
            param.Add("@BNet", swiftReq.pSwift?.BNet ?? 0);
            param.Add("@ToNego", swiftReq.pSwift?.ToNego ?? "");
            param.Add("@ToName", swiftReq.pSwift?.ToName ?? "");
            param.Add("@ToRefer", swiftReq.pSwift?.ToRefer ?? "");
            param.Add("@ToBank", swiftReq.pSwift?.ToBank ?? "");
            param.Add("@ToWhom", swiftReq.pSwift?.ToWhom ?? "");
            param.Add("@F20", swiftReq.pSwift?.F20 ?? "");
            param.Add("@F20_X", swiftReq.pSwift?.F20_X ?? "");
            param.Add("@F21", swiftReq.pSwift?.F21 ?? "");
            param.Add("@F21_X", swiftReq.pSwift?.F21_X ?? "");
            param.Add("@F23", swiftReq.pSwift?.F23 ?? "");
            param.Add("@F23_X", swiftReq.pSwift?.F23_X ?? "");
            param.Add("@F26", swiftReq.pSwift?.F26 ?? "");
            param.Add("@F30", swiftReq.pSwift?.F30 ?? "");
            param.Add("@F32A", swiftReq.pSwift?.F32A ?? "");
            param.Add("@F32B", swiftReq.pSwift?.F32B ?? "");
            param.Add("@F33A", swiftReq.pSwift?.F33A ?? "");
            param.Add("@F33B", swiftReq.pSwift?.F33B ?? "");
            param.Add("@F34A", swiftReq.pSwift?.F34A ?? "");
            param.Add("@F50K", swiftReq.pSwift?.F50K ?? "");
            param.Add("@F59", swiftReq.pSwift?.F59 ?? "");
            param.Add("@F70", swiftReq.pSwift?.F70 ?? "");
            param.Add("@F71A", swiftReq.pSwift?.F71A ?? "");
            param.Add("@F71F", swiftReq.pSwift?.F71F ?? "");
            param.Add("@F52A", swiftReq.pSwift?.F52A ?? "");
            param.Add("@F52D", swiftReq.pSwift?.F52D ?? "");
            param.Add("@F53A", swiftReq.pSwift?.F53A ?? "");
            param.Add("@F53B", swiftReq.pSwift?.F53B ?? "");
            param.Add("@F53D", swiftReq.pSwift?.F53D ?? "");
            param.Add("@F53UID", swiftReq.pSwift?.F53UID ?? "");
            param.Add("@F54A", swiftReq.pSwift?.F54A ?? "");
            param.Add("@F54D", swiftReq.pSwift?.F54D ?? "");
            param.Add("@F54UID", swiftReq.pSwift?.F54UID ?? "");
            param.Add("@F56A", swiftReq.pSwift?.F56A ?? "");
            param.Add("@F56D", swiftReq.pSwift?.F56D ?? "");
            param.Add("@F56UID", swiftReq.pSwift?.F56UID ?? "");
            param.Add("@F57A", swiftReq.pSwift?.F57A ?? "");
            param.Add("@F57D", swiftReq.pSwift?.F57D ?? "");
            param.Add("@F57UID", swiftReq.pSwift?.F57UID ?? "");
            param.Add("@F58A", swiftReq.pSwift?.F58A ?? "");
            param.Add("@F58D", swiftReq.pSwift?.F58D ?? "");
            param.Add("@F58UID", swiftReq.pSwift?.F58UID ?? "");
            param.Add("@F71B", swiftReq.pSwift?.F71B ?? "");
            param.Add("@F72", swiftReq.pSwift?.F72 ?? "");
            param.Add("@F72_X", swiftReq.pSwift?.F72_X ?? "");
            param.Add("@F73", swiftReq.pSwift?.F73 ?? "");
            param.Add("@F79", swiftReq.pSwift?.F79 ?? "");
            param.Add("@F79_X", swiftReq.pSwift?.F79_X ?? "");
            param.Add("@F77A", swiftReq.pSwift?.F77A ?? "");
            param.Add("@F77B", swiftReq.pSwift?.F77B ?? "");
            param.Add("@F77J", swiftReq.pSwift?.F77J ?? "");
            param.Add("@F53A_X", swiftReq.pSwift?.F53A_X ?? "");
            param.Add("@F53B_X", swiftReq.pSwift?.F53B_X ?? "");
            param.Add("@F53D_X", swiftReq.pSwift?.F53D_X ?? "");
            param.Add("@F53UID_X", swiftReq.pSwift?.F53UID_X ?? "");
            param.Add("@F54A_X", swiftReq.pSwift?.F54A_X ?? "");
            param.Add("@F54D_X", swiftReq.pSwift?.F54D_X ?? "");
            param.Add("@F54UID_X", swiftReq.pSwift?.F54UID_X ?? "");
            param.Add("@F72103", swiftReq.pSwift?.F72103 ?? "");
            param.Add("@Flag32", swiftReq.pSwift?.Flag32 ?? 0);
            param.Add("@Detail32", swiftReq.pSwift?.Detail32 ?? "");
            param.Add("@F21_B", swiftReq.pSwift?.F21_B ?? "");
            param.Add("@F21_C", swiftReq.pSwift?.F21_C ?? "");
            param.Add("@MT199", swiftReq.pSwift?.MT199 ?? 0);
            param.Add("@CF50", swiftReq.pSwift?.CF50 ?? 0);
            param.Add("@CF59", swiftReq.pSwift?.CF59 ?? 0);
            param.Add("@F79_Z", swiftReq.pSwift?.F79_Z ?? "");
            param.Add("@SWUuid", swiftReq.pSwift?.SWUuid ?? "");
            param.Add("@swiftIMBCExist", dbType: DbType.Int32,
                       direction: ParameterDirection.Output,
                       size: 12800);

            param.Add("@swiftIMBCRsp", dbType: DbType.String,
                       direction: ParameterDirection.Output,
                       size: 5215585);

            try
            {
                var results = await _db.LoadData<IMBCSwift, dynamic>(
                           storedProcedure: "usp_pIMBC_psSWIFT_UPSERT",
                           param);

                var SwiftExist = param.Get<dynamic>("@swiftIMBCExist");
                var SwiftRsp = param.Get<dynamic>("@swiftIMBCRsp");

                if (SwiftExist > 0)
                {
                    return Ok(SwiftRsp);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "IMPORT B/L Swift does not exit";
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
