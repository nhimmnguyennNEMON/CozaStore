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
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUser()
        {
            return UserDAO.Instance.GetUser();
        }

        [HttpGet("get-user-by-id/{id}")]
        public IActionResult FindCategoryById(int id)
        {
            UserDTO User = UserDAO.Instance.FindUserById(id);
            if (User == null)
            {
                return NotFound("User does ndot exist");
            }
            return Ok(User);
        }

        [HttpGet("get-user-by-email/{email}")]
        public IActionResult GetUserByUserId(string email)
        {
            List<UserDTO> cartList = UserDAO.Instance.GetUserByEmail(email);
            return Ok(cartList);
        }

        [HttpGet("check-user-by-email-password/{email}{password}")]
        public IActionResult GetUserByUserId(string email, string password)
        {
            bool checkUser = UserDAO.Instance.CheckUserByEmailAndPassword(email, password);
            return Ok(checkUser);
        }

        [HttpPost("create-user")]
        public IActionResult SaveUser(UserDTO User)
        {
            UserDAO.Instance.SaveUser(User);
            return NoContent();
        }

        [HttpPut("update-user-by-id/{id}")]
        public IActionResult UpdateUser(int id, UserDTO User)
        {

            var cTemp = UserDAO.Instance.FindUserById(id);
            if (cTemp == null)
            {
                return NotFound();

            }
            UserDAO.Instance.UpdateUser(User);
            return NoContent();

        }

        [HttpDelete("delete-user-by-id/{id}")]
        public IActionResult DeleteUserById(int id)
        {

            UserDAO.Instance.DeleteUserById(id);
            return NoContent();
        }
    }
}

