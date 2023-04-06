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
    public class Q_GetDocRegisterPageController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public Q_GetDocRegisterPageController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<Q_GetDocRegisterPageRsp>> GetAll(string? ScreenMenu, string? LogType, string? CenterID, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            param.Add("@ScreenMenu", ScreenMenu);
            param.Add("LogType", LogType);
            param.Add("@CenterID", CenterID);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            var results = await _db.LoadData<Q_GetDocRegisterPageRsp, dynamic>(
                        storedProcedure: "usp_q_GetDocRegisterSelectPage",
                        param);
            return results;
        }
    }
}
