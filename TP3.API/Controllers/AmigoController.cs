using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TP3.ApplicationService;
using TP3.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP3.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmigoController : ControllerBase
    {
        
        private AmigoServices Services { get; set; }

        public AmigoController(AmigoServices services)
        {
            this.Services = services;
        }


        // GET: api/<AmigoController>
        [HttpGet]
        public IEnumerable<Amigo> Get()
        {
            return Services.GetAll();
        }

        // GET api/<AmigoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AmigoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AmigoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AmigoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
