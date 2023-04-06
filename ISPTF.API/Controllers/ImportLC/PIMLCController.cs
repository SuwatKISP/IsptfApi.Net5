using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ImportLC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.ImportLC
{
    [ApiController]
    [Route("api/[controller]")]
    public class PIMLCController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PIMLCController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("select")]
        public async Task<IEnumerable<PIMLCRsp>> GetAll(string? LCNumber, string? RecType, int? LCSeqno)
        {
            DynamicParameters param = new();

            param.Add("@LCNumber", LCNumber);
            param.Add("@RecType", RecType);
            param.Add("@LCSeqno", LCSeqno);
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

            var results = await _db.LoadData<PIMLCRsp, dynamic>(
                        storedProcedure: "usp_pIMLC_Select",
                        param);
            return results;
        }








    }
}
