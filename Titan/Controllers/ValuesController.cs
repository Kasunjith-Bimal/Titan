using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Titan.Middleware.MiddlewareModel;

namespace Titan.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        readonly ILogger<ValuesController> _log;

        public ValuesController(ILogger<ValuesController> log)
        {
            _log = log;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _log.LogInformation("API Work");
            return new string[] { "value1", "value2" };
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            _log.LogInformation("Not Work");

            throw new NotFoundCustomException("No data found", $"Please check your parameters id: {id}");
          
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
