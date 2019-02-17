using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Titan.Interface.ServiceInterface;
using Titan.Model;


namespace Titan.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public readonly ILogger<TestController> _log;

        public readonly ITestService _testService;


        public TestController(ILogger<TestController> log, ITestService testService)
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
                return _testService.Get();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
                return null;

            }


        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public TestDto Get(int id)
        {
            try
            {
                return _testService.GetById(id);
            }
            catch (Exception ex)
            {

                _log.LogError(ex, ex.Message, null);
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]TestDto testDto)
        {
            try
            {
                _testService.Add(testDto);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]TestDto testDto)
        {
            try
            {
                _testService.Update(testDto);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _testService.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
