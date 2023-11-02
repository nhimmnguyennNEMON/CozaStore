using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts() => ProductDAO.Instance.GetProducts();

        [HttpGet("get-product-by-id/{id}")]
        public IActionResult FindProductById(int id)
        {
            ProductDTO product = ProductDAO.Instance.FindProductById(id);
            if (product == null)
            {
                return NotFound("Product does ndot exist");
            }
            return Ok(product);
        }

        [HttpGet("get-product-by-categoryId/{id}")]
        public IActionResult GetListProductsByCateId(int id)
        {
            List<ProductDTO> listProduct = ProductDAO.Instance.GetListProductsByCateId(id);
            if (listProduct == null)
            {
                return NotFound("Product does ndot exist");
            }
            return Ok(listProduct);
        }

        [HttpGet("get-product-by-name/{name}")]
        public IActionResult GetListProductsByProductName(string name)
        {
            List<ProductDTO> listProduct = ProductDAO.Instance.GetListProductsByProductName(name);
            if (listProduct == null)
            {
                return NotFound("Product does ndot exist");
            }
            return Ok(listProduct);
        }

        [HttpGet("get-product-by-price/{startPrice}/{endPrice}")]
        public IActionResult GetProductByPriceRange(decimal startPrice, decimal endPrice)
        {
            List<ProductDTO> listProduct = ProductDAO.Instance.GetProductByPriceRange(startPrice, endPrice);
            if (listProduct == null)
            {
                return NotFound("Product does ndot exist");
            }
            return Ok(listProduct);
        }

        [HttpPost("create-product")]
        public IActionResult PostProduct(ProductDTO product)
        {
            ProductDAO.Instance.SaveProduct(product);
            return NoContent();
        }

        [HttpPut("update-product-by-id/{id}")]
        public IActionResult UpdateProduct(int id, ProductDTO product)
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
            } else {
                ProductDAO.Instance.DeleteProductById(id);
                return NoContent();
            }
        }
    }
}

