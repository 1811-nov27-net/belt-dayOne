using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureREST.Models;

namespace TemperatureREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        public static List<Temperature> Data = new List<Temperature>();
        // GET: api/Temperature
        [HttpGet]
        public IEnumerable<Temperature> Get()
        {
            return Data;
        }

        // GET: api/Temperature/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Temperature> Get(int id)
        {
            var result = Data.FirstOrDefault(x => x.ID == id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST: api/Temperature
        [HttpPost]
        public void Post([FromBody] Temperature value)
        {
            Data.Add(value);
        }

        // PUT: api/Temperature/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Temperature value)
        {
            var existing = Data.FirstOrDefault(x => x.ID == id);
            if (existing == null)
            {
                return NotFound();
            }
            Data.Remove(existing);
            value.ID = id;
            Data.Add(value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existing = Data.FirstOrDefault(x => x.ID == id);
            if (existing == null)
            {
                return NotFound();
            }
            Data.Remove(existing);
            return Ok();
        }
    }
}
