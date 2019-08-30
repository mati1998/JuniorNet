using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JuniorDotNet.Models;

namespace JuniorDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return repository.Products;
        }

        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return repository.Products.Where(e => e.Id.Equals(id)).FirstOrDefault();
        }

        [HttpPost]
        public Guid Post([FromBody] Product model)
        {
           return repository.AddProduct(model);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Product value)
        {
            repository.UpdateProduct(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            repository.DeleteProduct(id);
        }
    }
}
