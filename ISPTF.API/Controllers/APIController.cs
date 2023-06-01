using ISPTF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ISPTFContext _context;
        public APIController(ISPTFContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("API is Running");
        }

        [HttpGet("test")]
        public IActionResult test()
        {
            var pExlcTest = (from row in _context.pExlcs
                               where row.RECORD_TYPE == "MASTER"
                               select row).Take(5).ToList();
            return Ok(pExlcTest);
        }
    }
}
