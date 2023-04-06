using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.PackingCredit;
using ISPTF.Models.ImportLC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.PackingCredit
{
    [ApiController]
    [Route("api/[controller]")]
    public class PEXPCController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PEXPCController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("select")]
        public async Task<IEnumerable<PEXPCRsp>> GetAll(string? PACKINGNO, string? RECORDTYPE, int? EVENTNO)
        {
            DynamicParameters param = new();

            param.Add("@PACKINGNO", PACKINGNO);
            param.Add("@RECORDTYPE", RECORDTYPE);
            param.Add("@EVENTNO", EVENTNO);
            //if (EVENTNO == null)
            //{
            //    param.Add("@EVENTNO", "");
            //}


            var results = await _db.LoadData<PEXPCRsp, dynamic>(
                        storedProcedure: "usp_pExpc_Select",
                        param);
            return results;
        }

        [HttpGet("select/relatePC")]
        public async Task<IEnumerable<PEXPCRelatePCRsp>> GetRelateAll(string? CustID)
        {
            DynamicParameters param = new();

            param.Add("@CustID", CustID);


            var results = await _db.LoadData<PEXPCRelatePCRsp, dynamic>(
                        storedProcedure: "usp_pExpc_Select_Releated",
                        param);
            return results;
        }









    }
}
