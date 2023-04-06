using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.PControlPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.PcontrolPack
{
    [ApiController]
    [Route("api/[controller]")]
    public class PControlPackController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PControlPackController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("select")]
        public async Task<IEnumerable<PControlPackRsp>> GetAll(string? ContNo)
        {
            DynamicParameters param = new();

            param.Add("@ContNo", ContNo);
            if (ContNo == null)
            {
                param.Add("@ContNo", null);
            }

            var results = await _db.LoadData<PControlPackRsp, dynamic>(
                        storedProcedure: "usp_pControlPack_Select",
                        param);
            return results;
        }
    }
}
