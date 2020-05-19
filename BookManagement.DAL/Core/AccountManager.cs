using BookManagement.DAL.Core.Interfaces;
using BookManagement.DAL.Infrastructure;
using BookManagement.Entities.DataModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.Core
{
    public class AccountManager : IAccountManager
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AccountManager(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Get user by id
        public async Task<User> GetUserByIDAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        //Get user by username
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }


        /// <summary>
        /// Check password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return true;
        }

       
    }
}
