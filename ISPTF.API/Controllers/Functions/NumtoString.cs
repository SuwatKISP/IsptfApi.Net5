using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.Functions
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumtoString : ControllerBase
    {
        private readonly ILogger<SystemDateTimeController> _logger;
        private readonly IConfiguration _config;

        public NumtoString(ISqlDataAccess db, ILogger<SystemDateTimeController> logger,IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet("{conAmount}")]
        public ActionResult<string> Get(string conAmount)
        {
            try
            {
                return ISPModule.modNumToString.num2String(conAmount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
