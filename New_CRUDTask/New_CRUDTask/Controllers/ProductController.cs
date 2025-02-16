using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;

namespace New_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Route("add")]
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            bool flag = _productService.AddProduct(product); ;
            if (!flag)
            {
                return BadRequest(new { message = "Product is exist" });
            }
            return Ok("Product Added sccessfully..");
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllProduct(int page = 1, int pagesize = 10)
        {
            var (lst, totalcount)  =  await _productService.GetProducts(page,pagesize);
            return Ok(lst);
        }
        [Route("update")]
        [HttpPost]
        public ActionResult UpdateProduct(Product product) 
        {
            _productService.UpdateProduct(product);
            return Ok("Updated successfully..");
        }
        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteProduct(int id) 
        {
            _productService.DeleteProduct(id);
            return Ok("Deleted successfully..");
        }
    }
}
