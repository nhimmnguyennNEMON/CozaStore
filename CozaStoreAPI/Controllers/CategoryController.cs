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
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories()
        {
            return CategoryDAO.Instance.GetCategories();
        }

        [HttpGet("get-category-by-id/{id}")]
        public IActionResult FindCategoryById(int id)
        {
            CategoryDTO category = CategoryDAO.Instance.FindCategoryById(id);
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
            List<CategoryDTO> categoryList = CategoryDAO.Instance.GetCategoryByName(name);
            return Ok(categoryList);
        }

        [HttpPost("create-category")]
        public IActionResult PostCategory(CategoryDTO category)
        {
            CategoryDAO.Instance.SaveCategories(category);
            return NoContent();
        }

        [HttpPut("update-category-by-id/{id}")]
        public IActionResult UpdateCategory(int id, CategoryDTO category)
        {

            var cTemp = CategoryDAO.Instance.FindCategoryById(id);
            if (cTemp == null)
            {
                return NotFound();

            }
            CategoryDAO.Instance.UpdateCategory(category);
            return NoContent();

        }

        [HttpDelete("delete-category-by-id/{id}")]
        public IActionResult DeleteCategoryById(int id)
        {

            CategoryDAO.Instance.DeleteCategoryById(id);
            return NoContent();
        }
    }
}

