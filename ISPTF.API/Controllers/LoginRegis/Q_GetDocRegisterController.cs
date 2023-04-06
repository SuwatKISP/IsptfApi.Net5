using Dapper;
using ISPTF.DataAccess.DbAccess;
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
    public class Q_GetDocRegisterController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public Q_GetDocRegisterController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<Q_GetDocRegister>> GetAll(string? CenterID, string? Reg_Login)
        {
            DynamicParameters param = new();
        
            param.Add("@CenterID", CenterID);
            param.Add("@Reg_Login", Reg_Login);

            var results = await _db.LoadData<Q_GetDocRegister, dynamic>(
                        storedProcedure: "usp_q_GetDocRegisterSelect",
                        param);
            return results;
        }
    }
}
