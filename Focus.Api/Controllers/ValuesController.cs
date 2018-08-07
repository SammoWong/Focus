using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : FocusApiControllerBase
    {
        // GET api/values
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get(int skip, int take)
        {
            //throw new Exception("一个已知的异常");
            //return new string[] { "value1", "value2" };
            var result = new List<object>();
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            result.Add(new { id = 1, name = "name1" });
            return Ok(new { total = result.Count, rows = result.Skip(skip).Take(take) });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return CurrentUserId;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
}
