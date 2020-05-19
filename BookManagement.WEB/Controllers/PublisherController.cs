using BookManagement.Entities.ViewModels;
using BookManagement.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookManagement.WEB.Controllers
{

    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        readonly IPublisherService _publisherService;
        readonly ILogger _logger;

        public PublisherController(IPublisherService publisherService, ILogger<PublisherController> logger)
        {
            _publisherService = publisherService;
            _logger = logger;
        }

        // GET: api/Publisher
        [HttpGet]
        public IActionResult GetPublishers()
        {
            var publisherViews = _publisherService.GetAll();
            return Ok(publisherViews);
        }

        // GET: api/Publisher/5

        [HttpGet("{id}")]
        public IActionResult GetPublisher(int id)
        {
            var publisherView = _publisherService.Get(id);
            return Ok(publisherView);
        }

        // POST: api/Publisher
        [HttpPost]
        public IActionResult PostPublisher([FromBody]PublisherView publisherView)
        {
            return Ok(_publisherService.Add(publisherView));
        }

        // PUT: api/Publisher/5
        [HttpPut]
        public IActionResult PutPublisher([FromBody]PublisherView publisherView)
        {
            return Ok(_publisherService.Update(publisherView));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            return Ok(_publisherService.Delete(id));
        }
    }
}
