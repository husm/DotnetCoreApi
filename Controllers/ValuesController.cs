using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public ValuesController()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        // GET api/values
        [HttpGet]
        [Authorize(Policy = "DisneyUser")]
        public IEnumerable<Value> Get()
        {
            return new Value[] { new Value{Id = 1, Text = "value1" }, new Value{ Id = 2, Text="value2"} };
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public Value Get(int id)
        {
            return new Value { Id = id, Text = "value" };
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            return CreatedAtAction("Get", new { id = value.Id }, value);
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

    public class Value {
        public int Id { get; set; }
        public string Text { get; set; } 
    }
}
