using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.LoginRegis
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDocRegisterController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PDocRegisterController(ISqlDataAccess db)
        {
            _db = db;
        }
        //[HttpGet]
        //public async Task<IEnumerable<PDocRegister>> GetAll(string? RegDocNo)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@RegDocNo", RegDocNo);

        //    var results = await _db.LoadData<PDocRegister, dynamic>(
        //                storedProcedure: "usp_pDocRegisterSelect",
        //                param);
        //    return results;
        //}

        [HttpGet("select")]
        public async Task<IEnumerable<PDocRegister>> GetSelect(string? RegDocNo)
        {
            DynamicParameters param = new();

            param.Add("@RegDocNo", RegDocNo);

            var results = await _db.LoadData<PDocRegister, dynamic>(
                        storedProcedure: "usp_pDocRegisterSelect",
                        param);
            return results;
        }

        [HttpGet("select/SumBL")]
        public async Task<IEnumerable<PDocRegisterSumBLRsp>> GetSumBL(string? CustCode, string? RegRefNo)
        {
            DynamicParameters param = new();

            param.Add("@CustCode", CustCode);
            param.Add("@RegRefNo", RegRefNo);

            var results = await _db.LoadData<PDocRegisterSumBLRsp, dynamic>(
                        storedProcedure: "usp_pDocRegister_SumBL",
                        param);
            return results;
        }



    }
}
