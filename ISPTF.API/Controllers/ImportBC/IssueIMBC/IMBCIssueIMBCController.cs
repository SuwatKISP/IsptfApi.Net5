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
    public class IMBCIssueIMBCController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMBCIssueIMBCController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("newlist")]
        public async Task<IEnumerable<IMBCNewListRsp>> GetNew(string? ListType ,string? CenterID,string? Reg_Docno, string? CustCode, string? CustName,string? UserCode, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@Reg_Docno", Reg_Docno);
            param.Add("@BCNumber", "");
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

            var results = await _db.LoadData<IMBCNewListRsp, dynamic>(
                        storedProcedure: "usp_q_IMBC_IssueIMBCListPage",
                        param);
            return results;
        }

        [HttpGet("editreleaselist")]
        public async Task<IEnumerable<IMBCEditReleaseListRsp>> GetEditRelease(string? ListType, string? CenterID, string? BCNumber, string? CustCode, string? CustName, string? UserCode, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@Reg_Docno", "");
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

            var results = await _db.LoadData<IMBCEditReleaseListRsp, dynamic>(
                        storedProcedure: "usp_q_IMBC_IssueIMBCListPage",
                        param);
            return results;
        }






    }
}
