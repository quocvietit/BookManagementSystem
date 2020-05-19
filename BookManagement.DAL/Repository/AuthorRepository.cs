using BookManagement.DAL.Repository.Interfaces;
using BookManagement.Entities.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context)
        {
        }
    }
}
