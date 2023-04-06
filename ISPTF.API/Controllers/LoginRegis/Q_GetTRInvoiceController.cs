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

    public class Q_GetTRInvoiceController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public Q_GetTRInvoiceController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<Q_GetTRInvoice>> GetAll(string? CustCode, string? InvNumber, string? InvDate)
        {
            DynamicParameters param = new();

            param.Add("@CustCode", CustCode);
            param.Add("@InvNumber", InvNumber);
            param.Add("@InvDate", InvDate);

            var results = await _db.LoadData<Q_GetTRInvoice, dynamic>(
                        storedProcedure: "usp_q_GetTRInvoiceSelect",
                        param);
            return results;
        }

    }
}
