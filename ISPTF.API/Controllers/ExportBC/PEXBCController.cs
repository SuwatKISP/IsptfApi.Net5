using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.ExportBC
{
    [ApiController]
    [Route("api/[controller]")]
    public class PEXBCController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PEXBCController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("select")]
        public async Task<IEnumerable<PEXBC_issue>> GetAll(string? EXPORT_BC_NO, string? RECORD_TYPE, string? REC_STATUS, string? EVENT_NO)
        {
            DynamicParameters param = new();

            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@RECORD_TYPE", RECORD_TYPE);
            param.Add("@REC_STATUS", REC_STATUS);
            param.Add("@EVENT_NO", EVENT_NO);
            //if (RECORD_TYPE == null)
            //{
            //    param.Add("@RECORD_TYPE", "");
            //}
            //if (REC_STATUS == null)
            //{
            //    param.Add("@REC_STATUS", "");
            //}
            //if (EVENT_NO == null)
            //{
            //    param.Add("@EVENT_NO", "");
            //}

            var results = await _db.LoadData<PEXBC_issue, dynamic>(
                        storedProcedure: "usp_pEXBC_Select",
                        param);
            return results;
        }








    }
}
