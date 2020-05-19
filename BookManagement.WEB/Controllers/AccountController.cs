using System.Threading.Tasks;
using AutoMapper;
using BookManagement.DAL.Core.Interfaces;
using BookManagement.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookManagement.WEB.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountManager _accountManager;
        readonly ILogger _logger;

        public AccountController(IAccountManager accountManager, ILogger<AccountController> logger)
        {
            _accountManager = accountManager;
            _logger = logger;
        }
/*
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register()
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = "abc", Email = "abc@gmail.com" };
                var result = await _accountManager.CreateAsync(user, "Abc@123456");
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        // GET: api/Account
        [HttpGet]
        public async Task<UserView> GetUserById(int id)
        {
            var user = _accountManager.GetUserByIDAsync(id.ToString());
            UserView userView = Mapper.Map<UserView>(user);

            if (userView != null)
                return userView;
            return null;
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        [Produces(typeof(UserView))]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var account = _accountManager.GetUserByUserNameAsync(userName);
            if (account != null)
                return Ok(account);
            return NotFound(account);
        }*/
        [HttpPost]
        public IActionResult CheckAccount([FromBody]AccountView accountView)
        {
            _logger.LogInformation("Getting item: {}-{}", accountView.UserName, accountView.Password);
            if (accountView.UserName == "Admin" && accountView.Password == "123")
            {
                return Ok(true);
            }

            return Ok(false);
        }
    }
}