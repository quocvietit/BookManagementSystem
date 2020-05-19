using BookManagement.DAL.Infrastructure.Interfaces;
using BookManagement.DAL.Repository;
using BookManagement.DAL.Repository.Interfaces;

namespace BookManagement.DAL.Infrastructure
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        public ICommentRepository _comment;
        public ICategoryRepository _category;
        public IAuthorRepository _author;
        public IBookRepository _book;
        public IPublisherRepository _publisher;

        public ApplicationUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICommentRepository Comment
        {
            get
            {
                if (_comment == null)
                    _comment = new CommentRepository(_context);
                return _comment;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                    _category = new CategoryRepository(_context);
                return _category;
            }
        }

        public IPublisherRepository Publisher
        {
            get
            {
                if (_publisher == null)
                    _publisher = new PublisherRepository(_context);
                return _publisher;
            }
        }

        public IAuthorRepository Author
        {
            get
            {
                if (_author == null)
                    _author = new AuthorRepository(_context);
                return _author;
            }
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                    _book = new BookRepository(_context);
                return _book;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
