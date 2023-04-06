using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models.PEXDoc;
using ISPTF.Models.PControlPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.PEXDoc
{
    [ApiController]
    [Route("api/[controller]")]
    public class PEXDocController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PEXDocController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("select")]
        public async Task<IEnumerable<PEXDOCRsp>> GetAll(string? EXLCNO, int? EVENTNO )
        {
            DynamicParameters param = new();

            param.Add("@EXLCNO", EXLCNO);
            param.Add("@EVENTNO", EVENTNO);
            if(EXLCNO is null)
            {
                param.Add("@EXLCNO", "");
            }
            if(EVENTNO is null)
            {
                param.Add("@EVENTNO", "");
            }

            var results = await _db.LoadData<PEXDOCRsp, dynamic>(
                        storedProcedure: "usp_pExdoc_Select",
                        param);
            return results;
        }
    }
}
