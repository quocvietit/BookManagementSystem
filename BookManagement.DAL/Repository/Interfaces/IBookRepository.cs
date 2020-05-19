using BookManagement.Entities.DataModels;
using BookManagement.Interface.Repository;

namespace BookManagement.DAL.Repository.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
