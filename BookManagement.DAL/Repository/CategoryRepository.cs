using System.Collections.Generic;
using BookManagement.DAL.Repository.Interfaces;
using BookManagement.Entities.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
