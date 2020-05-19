using BookManagement.Entities.ViewModels;
using BookManagement.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookManagement.WEB.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private IBookService _bookService;
        private ILogger _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        // GET: api/Book
        [HttpGet]
        public IActionResult GetBooks()
        {
            var bookViews = _bookService.GetAll();
            return Ok(bookViews);
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.Get(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // GET: api/book/detail/5
        [HttpGet("detail/{id}")]
        public IActionResult GetBookDetail(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        // POST: api/Book
        [HttpPost]
        public IActionResult PostBook([FromBody]BookEditView bookEditView)
        {
            bool check = _bookService.AddBook(bookEditView);
            if (check == false)
            {
                return NotFound();
            }
            return Ok(check);
        }
        
        // PUT: api/Book/5
        [HttpPut]
        public IActionResult PutBook([FromBody]BookEditView bookEditView)
        {
            bool check = _bookService.UpdateBook(bookEditView);
            if (check == false)
            {
                return NotFound();
            }
            return Ok(check);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            bool check = _bookService.Delete(id);
            if(check == false)
            {
                return NotFound();
            }
            return Ok(check);
        }
    }
}
