using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.ServiceImplementation;

namespace New_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("add")]
        [HttpPost]
        public ActionResult CreateProduct(Category category)
        {
            bool flag = _categoryService.AddCategory(category);
            if (!flag)
            {
                return BadRequest(new { message = "Category is exist" });
            }
            return Ok("Category Added sccessfully..");
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllCategory(int page = 1, int pagesize = 10)
        {
            var (lst, totalcount) = await _categoryService.GetCategory(page, pagesize);
            return Ok(lst);
        }
        [Route("update")]
        [HttpPost]
        public ActionResult UpdateProduct(Category category)
        {
            _categoryService.UpdateCategory(category);
            return Ok("Updated successfully..");
        }
        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok("Deleted successfully..");
        }
    }
}
