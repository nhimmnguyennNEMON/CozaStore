using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DTO;
using DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CartDTO>> GetCart()
        {
            return CartDAO.Instance.GetCart();
        }

        [HttpGet("get-cart-by-id/{id}")]
        public IActionResult FindCategoryById(int id)
        {
            CartDTO cart = CartDAO.Instance.FindCartById(id);
            if (cart == null)
            {
                return NotFound("Cart does ndot exist");
            }
            return Ok(cart);
        }

        [HttpGet("get-cart-by-userid/{id}")]
        public IActionResult GetCartByUserId(int id)
        {
            List<CartDTO> cartList = CartDAO.Instance.GetCartByUserId(id);
            return Ok(cartList);
        }

        [HttpPost("create-cart")]
        public IActionResult SaveCart(CartDTO cart)
        {
            CartDAO.Instance.SaveCart(cart);
            return NoContent();
        }

        [HttpPut("update-card-by-id/{id}")]
        public IActionResult UpdateCart(int id, CartDTO cart)
        {

            var cTemp = CartDAO.Instance.FindCartById(id);
            if (cTemp == null)
            {
                return NotFound();

            }
            CartDAO.Instance.UpdateCart(cart);
            return NoContent();

        }

        [HttpDelete("delete-cart-by-id/{id}")]
        public IActionResult DeleteCartById(int id)
        {

            CartDAO.Instance.DeleteCartById(id);
            return NoContent();
        }
    }
}

