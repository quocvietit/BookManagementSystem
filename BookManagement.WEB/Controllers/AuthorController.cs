using System.Collections.Generic;
using BookManagement.Entities.ViewModels;
using BookManagement.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookManagement.WEB.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        readonly IAuthorService _authorService;
        readonly ILogger _logger;

        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        // GET: api/Author
        [HttpGet]
        public IActionResult GetAuthors()
        {
            
            var authorViews = _authorService.GetAll();

            return Ok(authorViews);
        }

        // GET: api/Author/5

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            _logger.LogInformation("Getting item {ID}", id);
            var authorView = _authorService.Get(id);

            if (authorView == null)
            {
                _logger.LogInformation("Item author: Notfound{ID} ", id);
                return NotFound();
            }
            return Ok(authorView);
        }
        
        // POST: api/Author
        [HttpPost]
        public IActionResult PostAuthor([FromBody]AuthorView authorView)
        {
            return Ok(_authorService.Add(authorView));
        }
        
        // PUT: api/Author/5
        [HttpPut]
        public IActionResult PutAuthor([FromBody]AuthorView authorView)
        {
            return Ok(_authorService.Update(authorView));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            return Ok(_authorService.Delete(id));
        }
    }
}
