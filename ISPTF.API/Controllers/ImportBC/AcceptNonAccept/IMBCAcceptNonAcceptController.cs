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
    public class IMBCAcceptNonAcceptController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMBCAcceptNonAcceptController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<IMBCAcceptNonAcceptListRsp>> Getlist(string? ListType, string? CenterID, string? BCNumber, string? CustCode, string? CustName, string? UserCode, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@BCNumber", BCNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@UserCode", UserCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BCNumber == null)
            {
                param.Add("@BCNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<IMBCAcceptNonAcceptListRsp, dynamic>(
                        storedProcedure: "usp_q_IMBC_AcceptNonAcceptListPage",
                        param);
            return results;
        }






    }
}
