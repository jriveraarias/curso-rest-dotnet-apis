using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsApi.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//////
namespace ProductsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // CRUD-> Create, Read, Update, Delete

        private readonly ILogger<ProductsController> _logger;
        //private readonly AdventureWorksDbContext _context;
        private readonly ProductRepository _repository;

        public ProductsController(ILogger<ProductsController> logger,
            ProductRepository repository
            //, AdventureWorksDbContext context
            )
        {
            _logger = logger;
            _repository = repository;

            //_context = context; 
            _logger.LogInformation("ProductsController constructor");
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.Get();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repository.Get().FirstOrDefault(p => p.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            // 200
            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            Product result = _repository.Add(value);

            return CreatedAtAction(nameof(GetById), new { Id = result.Id }, value);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return new ObjectResult(new object()) { StatusCode = (int)HttpStatusCode.OK};
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
