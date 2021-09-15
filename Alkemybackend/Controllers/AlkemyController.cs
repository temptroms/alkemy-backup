using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alkemy_backend.models;
using Microsoft.AspNetCore.Mvc;


namespace Alkemy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlkemyController : ControllerBase
    {
        private readonly AlkemyContext _context;

        public AlkemyController(AlkemyContext context)
        {
            _context = context;
        }

        // GET: api/<AlkemyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlkemyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlkemyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlkemyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlkemyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        

    }
}
