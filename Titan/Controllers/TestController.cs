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
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _testService.Get());
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
                return null;

            }


        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _testService.GetById(id));
            }
            catch (Exception ex)
            {

                _log.LogError(ex, ex.Message, null);
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TestDto testDto)
        {
            try
            {
                await _testService.Add(testDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
                return null;
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await _testService.Delete(id);
               return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
