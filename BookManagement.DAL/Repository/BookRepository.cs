using BookManagement.DAL.Repository.Interfaces;
using BookManagement.Entities.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        {
        }
    }
}
