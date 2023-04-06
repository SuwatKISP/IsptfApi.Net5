using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models.PIMTRInvoice;
using ISPTF.Models.PControlPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.PIMTRInvoice

{
    [ApiController]
    [Route("api/[controller]")]
    public class PIMTRInvoiceController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PIMTRInvoiceController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("select")]
        public async Task<IEnumerable<PIMTRInvoiceRsp>> GetAll(string? CustCode,string? InvNumber)
        {
            DynamicParameters param = new();

            param.Add("@CustCode", CustCode);
            param.Add("@InvNumber", InvNumber);
            //param.Add("@InvStatus", InvStatus);
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (InvNumber == null)
            {
                param.Add("@InvNumber", "");
            }
            //if (InvStatus == null)
            //{
            //    param.Add("@InvStatus", "");
            //}

            var results = await _db.LoadData<PIMTRInvoiceRsp, dynamic>(
                        storedProcedure: "usp_pIMTRInvoice_Select",
                        param);
            return results;
        }
    }
}
