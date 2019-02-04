using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Titan.Interface.ServiceInterface;
using Titan.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Titan.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public readonly ILogger<ValuesController> _log;

        public readonly ITestService _testService;


        public TestController(ILogger<ValuesController> log, ITestService testService)
        {
            _log = log;
            _testService = testService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<TestDto> Get()
        {
            try
            {
                return _testService.getAll();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
                return null;
               
            }
         
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
