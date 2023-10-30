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
    public class CategoryController : ControllerBase
    {
        //GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return CategoryDAO.Instance.GetCategories();
        }

        [HttpGet("get-category-by-id/{id}")]
        public IActionResult FindCategoryById(int id)
        {
            Category category = CategoryDAO.Instance.FindCategoryById(id);
            if (category == null)
            {
                return NotFound("Category does ndot exist");
            }
            return Ok(category);
        }

        [HttpGet("get-category-by-name/{name}")]
        public IActionResult GetCategoryByName(string name)
        {
            if (name.Equals("null"))
            {
                name = "";
            }
            List<Category> categoryList = CategoryDAO.Instance.GetCategoryByName(name);
            return Ok(categoryList);
        }
    }
}

