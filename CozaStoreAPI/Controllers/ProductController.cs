using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => ProductDAO.Instance.GetProducts();

        [HttpGet("get-product-by-id/{id}")]
        public IActionResult FindProductById(int id)
        {
            Product product = ProductDAO.Instance.FindProductById(id);
            if (product == null)
            {
                return NotFound("Product does ndot exist");
            }
            return Ok(product);
        }

        [HttpGet("get-product-by-categoryId/{id}")]
        public IActionResult GetListProductsByCateId(int id)
        {
            List<Product> listProduct = ProductDAO.Instance.GetListProductsByCateId(id);
            if (listProduct == null)
            {
                return NotFound("Product does ndot exist");
            }
            return Ok(listProduct);
        }

        [HttpGet("get-product-by-name/{name}")]
        public IActionResult GetListProductsByProductName(string name)
        {
            List<Product> listProduct = ProductDAO.Instance.GetListProductsByProductName(name);
            if (listProduct == null)
            {
                return NotFound("Product does ndot exist");
            }
            return Ok(listProduct);
        }

        [HttpGet("get-product-by-price/{startPrice}/{endPrice}")]
        public IActionResult GetProductByPriceRange(decimal startPrice, decimal endPrice)
        {
            List<Product> listProduct = ProductDAO.Instance.GetProductByPriceRange(startPrice, endPrice);
            if (listProduct == null)
            {
                return NotFound("Product does ndot exist");
            }
            return Ok(listProduct);
        }

        [HttpPost("create-product")]
        public IActionResult PostProduct(Product product)
        {
            ProductDAO.Instance.SaveProduct(product);
            return NoContent();
        }

        [HttpPut("update-product-by-id/{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {

            var pTemp = ProductDAO.Instance.FindProductById(id);
            if (pTemp == null)
            {
                return NotFound();

            }
            ProductDAO.Instance.UpdateProduct(product);
            return NoContent();

        }

        [HttpDelete("delete-product-by-id/{id}")]
        public IActionResult DeleteProductById(int id)
        {

            var p = ProductDAO.Instance.FindProductById(id);
            if (p == null)
            {
                return NotFound();
            }

            ProductDAO.Instance.DeleteProduct(p);
            return NoContent();
        }
    }
}

