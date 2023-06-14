using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.PackingCredit;
using ISPTF.Models.ShippingGuarantee;
using ISPTF.Models.ImportLC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.ShippingGuarantee
{
    [ApiController]
    [Route("api/[controller]")]
    public class IMSGCollectRefundController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public IMSGCollectRefundController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("newlist")]
        public async Task<IEnumerable<CollectRefundSGListRsp>> GetNewList(string? CenterID, string? SGNumber, string? CustCode, string? CustName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@CenterID", CenterID);
            param.Add("@SGNumber", SGNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (SGNumber == null)
            {
                param.Add("@SGNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<CollectRefundSGListRsp, dynamic>(
                        storedProcedure: "usp_q_IMSG_CollectRefundSGNewListPage",
                        param);
            return results;
        }


        [HttpGet("editlist")]
        public async Task<IEnumerable<CollectRefundSGListRsp>> GetEditList(string? CenterID, string? @SGNumber, string? CustCode, string? CustName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@CenterID", CenterID);
            param.Add("@@SGNumber", @SGNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (@SGNumber == null)
            {
                param.Add("@@SGNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<CollectRefundSGListRsp, dynamic>(
                        storedProcedure: "usp_q_IMSG_CollectRefundSGEditListPage",
                        param);
            return results;
        }

        [HttpGet("releaselist")]
        public async Task<IEnumerable<CollectRefundSGListRsp>> GetReleaseList(string? CenterID, string? @SGNumber, string? CustCode, string? CustName,string? UserCode , string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@CenterID", CenterID);
            param.Add("@@SGNumber", @SGNumber);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@UserCode", UserCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (@SGNumber == null)
            {
                param.Add("@@SGNumber", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<CollectRefundSGListRsp, dynamic>(
                        storedProcedure: "usp_q_IMSG_CollectRefundSGReleaseListPage",
                        param);
            return results;
        }











    }
}
