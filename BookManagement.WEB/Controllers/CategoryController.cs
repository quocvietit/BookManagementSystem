using BookManagement.Entities.ViewModels;
using BookManagement.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookManagement.WEB.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;
        readonly ILogger _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult GetCategories()
        {
            var allCategoryView = _categoryService.GetAll();
            return Ok(allCategoryView);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var categoryView = _categoryService.Get(id);
            if (categoryView != null)
                return Ok(categoryView);
            else
                return NotFound(categoryView);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult PostCategory([FromBody]CategoryView categoryView)
        {
            return Ok(_categoryService.Add(categoryView));
        }

        [HttpPut]
        public IActionResult PutCategory([FromBody]CategoryView categoryView)
        {
            return Ok(_categoryService.Update(categoryView));
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            return Ok(_categoryService.Delete(id));
        }
    }
}
