using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISPTF.API.Controllers.TestAPI
{
    //[OpenApiTag("Test")]
    [ApiExplorerSettings(GroupName = "StandingApi")]
    
    //[SwaggerTags("Test")]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class testController : ControllerBase
    {
        // GET: api/<testController>
        [HttpGet]
        //[OpenApiTags("TestAPI")]
        //[Description("TestAPI")]
        //[OpenApiOperation("TestAPI")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<testController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<testController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<testController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<testController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
