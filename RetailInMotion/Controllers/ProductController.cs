using Microsoft.AspNetCore.Mvc;
using RetailInMotion.Data.Abstract;
using RetailInMotion.Domain;
using System;

namespace RetailInMotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var product = _repository.GetById(id);

            if (product == null)
            {
                return NotFound($"Product {id} could not be found");
            }

            return Ok(product);
        }

        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetPaged(int page, int pageSize)
        {
            var product = _repository.GetPaged(page, pageSize);

            if (product == null)
            {
                return NotFound($"No Products Found");
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _repository.Create(product);

            return Ok("Resource created!");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            _repository.Update(product);

            return Ok("Resource updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);

            return Ok("Resource Deleted!");
        }
    }
}