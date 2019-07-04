using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Collections;
using System.Threading;

namespace testweb.Controllers
{

    public class HttpPostTimer : IDisposable
    {
        DateTime start;
        public HttpPostTimer()
        {
            start = DateTime.Now;
            if (Program.HttpPostStartTime == DateTime.MinValue)
                Program.HttpPostStartTime = start;
        }
        public void Dispose()
        {
            Program.HttpPostEndTime = DateTime.Now;
            TimeSpan ts = Program.HttpPostEndTime - start;
            Program.HttpPostCounter++;
            Program.HttpPostTimer += ts.TotalMilliseconds;
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
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {

            //return "[{\"value\": \"1\"},{\"value\": \"2\"}]";
            return new JsonResult(new List <TestResponse>
            {
                new TestResponse {name="test1", value="1"},
                new TestResponse {name="test2", value="2"}

            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{

        //    return "{\"value\": \""+ id.ToString() + "}\"";
        //}
        public JsonResult Get(int id)
        {
            TestResponse t = new TestResponse();
            t.name = "testResponse";
            t.value = id.ToString();
            return new JsonResult(t);
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] string value)
        {
            //                        System.IO.Stream requestBody = Request.Body;
            //                        Response.Body = requestBody;
            //                      object requestBody = await request.Content.ReadAsAsync<object>();
            //                      return request.CreateResponse(HttpStatusCode.OK, requestBody);
            //return value;

            using (HttpPostTimer hpt = new HttpPostTimer())
            {
                TestResponse t = new TestResponse();
                t.name = "testResponse";
                t.value = value;
                return new JsonResult(t);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {

            //return "[{\"value\": \"1\"},{\"value\": \"2\"}]";
            return new JsonResult(new List<TestResponse>
            {
                new TestResponse {name="HttpPostTimerMs", value=Program.HttpPostTimer.ToString()},
                new TestResponse {name="HttpPostCounter", value=Program.HttpPostCounter.ToString()},
                new TestResponse {name="HttpPostStartTime", value=Program.HttpPostStartTime.ToString()},
                new TestResponse {name="HttpPostEndTime", value=Program.HttpPostEndTime.ToString()}

            });
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
