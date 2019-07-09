﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Collections;
using System.Threading;

namespace TestWebApp.Controllers
{

    public class HttpPostTimer : IDisposable
    {
        DateTime start;
        public HttpPostTimer()
        {
            start = DateTime.Now;
            if (ValuesController.HttpPostStartTime == DateTime.MinValue)
                ValuesController.HttpPostStartTime = start;
        }
        public void Dispose()
        {
            ValuesController.HttpPostEndTime = DateTime.Now;
            TimeSpan ts = ValuesController.HttpPostEndTime - start;
            ValuesController.HttpPostCounter++;
            ValuesController.HttpPostTimer += ts.TotalMilliseconds;
        }

    }
    public class TestResponse
    {
        public string name { get; set; }
        public string value { get; set; }

    };
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static double HttpPostCounter;
        public static double HttpPostTimer;
        public static DateTime HttpPostStartTime = DateTime.MinValue;
        public static DateTime HttpPostEndTime;
        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] string value)
        {


            using (HttpPostTimer hpt = new HttpPostTimer())
            {
                TestResponse t = new TestResponse();
                t.name = "testResponse";
                t.value = value;
                return new JsonResult(t);
            }
        }


    }

 

}
