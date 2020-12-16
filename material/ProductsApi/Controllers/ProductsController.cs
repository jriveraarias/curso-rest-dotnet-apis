using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // CRUD = Create, Read, Update, Delete
        private readonly ILogger<ProductsController> _logger;
        //private readonly AdventureWorksDbContext _context;

        private readonly object[] _products;
        public ProductsController(ILogger<ProductsController> logger,
            object[] products

            //, AdventureWorksDbContext context
            )
        {
            _logger = logger;
            //_context = con
            _products = products;
            _logger.LogInformation("ProductsController constructor");
        }
          [HttpGet]
        public IEnumerable<object> Get()
        {
            return _products;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
                return Ok(_products[0]);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
                //return CreatedAtAction(nameof(GetById), new { Id = value.Id }, value);
            }

            // PUT api/<ValuesController>/5
            [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => new ObjectResult(new object()) { StatusCode = (int)HttpStatusCode.NotImplemented };
    }
}
