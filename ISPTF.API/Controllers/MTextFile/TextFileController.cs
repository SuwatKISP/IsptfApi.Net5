using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.MTextFile;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace ISPTF.API.Controllers.MTextFile
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextFileController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TextFileController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("select")]
        public async Task<IEnumerable<MTextFileRsp>> GetAll(string? TextModule, string? TextField, string? TextCond)
        {
            DynamicParameters param = new();
            param.Add("@TextModule", TextModule);
            param.Add("@TextField", TextField);
            param.Add("@TextCond", TextCond);

            if(TextModule is null)
            {
                param.Add("@TextModule", "");
            }
            if(TextField is null)
            {
                param.Add("@TextField", "");
            }
            if (TextCond is null)
            {
                param.Add("@TextCond", "");
            }


            var results = await _db.LoadData<MTextFileRsp, dynamic>(
                        storedProcedure: "usp_mTextFile_Select",
                        param);
            return results;
        }













    }
}
