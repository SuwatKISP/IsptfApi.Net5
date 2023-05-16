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
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Soda!");
        }
    }
}
