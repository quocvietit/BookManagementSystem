using BookManagement.DAL.Repository.Interfaces;

namespace BookManagement.DAL.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        ICommentRepository Comment { get; }

        ICategoryRepository Category { get; }

        IPublisherRepository Publisher { get; }

        IAuthorRepository Author { get; }
        IBookRepository Book { get; }

        int SaveChanges();
    }
}
