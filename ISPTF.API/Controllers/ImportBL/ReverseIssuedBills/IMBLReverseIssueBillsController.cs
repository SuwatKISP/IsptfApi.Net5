using Dapper;
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

namespace ISPTF.API.Controllers.ImportBL
{
    [ApiController]
    [Route("api/[controller]")]
    public class IMBLReverseIssueBillsController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMBLReverseIssueBillsController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<IMBLEditReleaseListRsp>> GetEditRelease(string? ListType, string? CenterID, string? BLNumber, string? CustCode, string? CustName, string? UserCode, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@BLNumber", BLNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@UserCode", UserCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

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

            var results = await _db.LoadData<IMBLEditReleaseListRsp, dynamic>(
                        storedProcedure: "usp_q_IMBL_ReverseIssueBillsListPage",
                        param);
            return results;
        }






    }
}
