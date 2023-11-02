using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> GetOrder()
        {
            return OrderDAO.Instance.GetOrder();
        }

        [HttpGet("get-order-by-id/{id}")]
        public IActionResult FindCategoryById(int id)
        {
            OrderDTO order = OrderDAO.Instance.FindOrderById(id);
            if (order == null)
            {
                return NotFound("order does ndot exist");
            }
            return Ok(order);
        }

        [HttpGet("get-order-by-userid/{id}")]
        public IActionResult GetOrderByUserId(int id)
        {
            List<OrderDTO> orderList = OrderDAO.Instance.GetOrderByUserId(id);
            return Ok(orderList);
        }

        [HttpPost("create-order")]
        public IActionResult Saveorder(OrderDTO order)
        {
            OrderDAO.Instance.SaveOrder(order);
            return NoContent();
        }

        [HttpPut("update-card-by-id/{id}")]
        public IActionResult Updateorder(int id, OrderDTO order)
        {

            var cTemp = OrderDAO.Instance.FindOrderById(id);
            if (cTemp == null)
            {
                return NotFound();

            }
            OrderDAO.Instance.UpdateOrder(order);
            return NoContent();

        }

        [HttpDelete("delete-order-by-id/{id}")]
        public IActionResult DeleteOrderById(int id)
        {

            OrderDAO.Instance.DeleteOrderById(id);
            return NoContent();
        }
    }
}

