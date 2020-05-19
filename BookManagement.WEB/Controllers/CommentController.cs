using System.Collections.Generic;
using AutoMapper;
using BookManagement.DAL.Infrastructure.Interfaces;
using BookManagement.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookManagement.WEB.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;

        public CommentController(IUnitOfWork unitOfWork, ILogger<CommentController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }



        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var allComment = _unitOfWork.Comment.GetAll();
            return Ok(Mapper.Map<IEnumerable<CommentView>>(allComment));
        }

        // GET: api/values/{id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var comment = _unitOfWork.Comment.Get(id);
            return comment.CreatedDate.ToString();
        }
    }
}