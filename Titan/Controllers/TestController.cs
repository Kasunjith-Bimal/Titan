﻿using System;
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
        public async Task<TestDto> Get(int id)
        {
            try
            {
                TestDto obj = await _testService.GetById(id);
                if (obj != null)
                {
                   
                    return obj;
                }
                else
                {
                    throw new NotFoundCustomException("No data found", $"Please check your parameters id: {id}");
                }
              
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message, null);
                throw new NotFoundCustomException("No data found", $"Please check your parameters id: {id}");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<bool> Post([FromBody]TestDto testDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _testService.Add(testDto))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }   
                }
                else
                {
                    return false;
                    throw new NotSaveCustomException("No data save", $"Please check your ented data");
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
        public async Task Put(int id ,[FromBody]TestDto testDto)
        {
            try
            {

              await _testService.Update(testDto);
             
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
