using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Titan.Interface.ServiceInterface;
using Titan.Middleware.MiddlewareModel;
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
        public async Task<IEnumerable<TestDto>> Get()
        {
            try
            {
                return await _testService.Get();
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                TestDto obj = await _testService.GetById(id);
                if (obj == null)
                {
                    return NotFound();

                }

                return Ok(obj);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
                throw new NotFoundCustomException("No data found", $"Please check your parameters id: {id} or connection string");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TestDto testDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _testService.Add(testDto))
                    {
                        return Ok(new MessageDto { Message = "Data is Saved", StatusCode = "201" });
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }   
                }
                else
                {
                    return BadRequest(ModelState);
                }
               
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
                throw new NotSaveCustomException("No data save", $"Please check your ented data");
 
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id ,[FromBody]TestDto testDto)
        {
            try
            { 

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testDto.TestEntityId)
            {
                return BadRequest();
            }

            if (await _testService.Update(testDto)){

                    return Ok(new MessageDto { Message = "Data is updated" , StatusCode = "200" });
            }
            else
            {
             return NotFound();
            }

            }
            catch (Exception ex)
            {
                TestDto obj = await _testService.GetById(id);
                if (obj == null)
                {
                    return NotFound();

                }
                else
                {
                    _log.LogError(ex, ex.Message, null);
                    throw new NotUpdateCustomeException("No data update", $"Please check your ented data or connection");
                  
                }      
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _testService.Delete(id))
                {
                    return Ok(new MessageDto { Message = "Data is deleted", StatusCode = "200" });
                }
                else
                {
                    return NotFound();
                }    
            }
            catch (Exception ex)
            {

                _log.LogError(ex, ex.Message, null);
                throw new NotDeleteCustomeException("No data delete", $"Please check your enterd data or connection");
            }
        }
    }
}
