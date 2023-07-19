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

namespace ISPTF.API.Controllers.SBLC
{
    [ApiController]
    [Route("api/[controller]")]
    public class SBLCAmendExpiryDateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public SBLCAmendExpiryDateController(ISqlDataAccess db)
        {
            _db = db;
        }


        [HttpGet("list")]
        public async Task<IEnumerable<SBLCEditReleaseListRsp>> GetList(string? ListType, string? CenterID,  string? SBLCNumber, string? CustCode, string? CustName, string? UserCode, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
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

            var results = await _db.LoadData<SBLCEditReleaseListRsp, dynamic>(
                        storedProcedure: "usp_q_SBLC_AmendExpiryDateListPage",
                        param);
            return results;
        }






    }
}
