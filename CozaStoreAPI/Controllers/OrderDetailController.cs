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
    public class OrderDetailController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetailDTO>> GetOrderDetail()
        {
            return OrderDetailDAO.Instance.GetOrderDetail();
        }

        [HttpGet("get-orderDetail-by-id/{id}")]
        public IActionResult FindCategoryById(int id)
        {
            OrderDetailDTO OrderDetail = OrderDetailDAO.Instance.FindOrderDetailById(id);
            if (OrderDetail == null)
            {
                return NotFound("OrderDetail does ndot exist");
            }
            return Ok(OrderDetail);
        }

        [HttpGet("get-orderDetail-by-orderId/{id}")]
        public IActionResult GetOrderDetailByUserId(int id)
        {
            List<OrderDetailDTO> OrderDetailList = OrderDetailDAO.Instance.GetOrderDetailByOrderId(id);
            return Ok(OrderDetailList);
        }

        [HttpPost("create-orderDetail")]
        public IActionResult SaveOrderDetail(OrderDetailDTO OrderDetail)
        {
            OrderDetailDAO.Instance.SaveOrderDetail(OrderDetail);
            return NoContent();
        }

        [HttpPut("update-orderDetail-by-id/{id}")]
        public IActionResult UpdateOrderDetail(int id, OrderDetailDTO OrderDetail)
        {

            var cTemp = OrderDetailDAO.Instance.FindOrderDetailById(id);
            if (cTemp == null)
            {
                return NotFound();

            }
            OrderDetailDAO.Instance.UpdateOrderDetail(OrderDetail);
            return NoContent();

        }

        [HttpDelete("delete-orderDetail-by-id/{id}")]
        public IActionResult DeleteOrderDetailById(int id)
        {

            OrderDetailDAO.Instance.DeleteOrderDetailById(id);
            return NoContent();
        }
    }
}

