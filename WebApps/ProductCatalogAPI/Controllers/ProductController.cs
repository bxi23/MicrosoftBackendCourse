using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.0m },
            new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20.0m }
        };

        [HttpGet]
        public ActionResult<List<Product>> GetAll()=> Products;

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public ActionResult<Product> Create(Product newProduct)
        {
            newProduct.Id = Products.Count + 1;
            Products.Add(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            Products.Remove(product);
            return NoContent();
        }
    }
}