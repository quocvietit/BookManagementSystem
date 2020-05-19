using BookManagement.Entities.DataModels;
using System;
using System.Linq;

namespace BookManagement.DAL.Infrastructure
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext _context)
        {
            _context.Database.EnsureCreated();

            //check database exist
            if (_context.Categorys.Any())
            {
                return;
            }

            for (int i = 0; i < 100; i++)
            {
                var category = new Category
                {
                    CateName = "Category" + i,
                    Description = "This is a Category",
                    IsAlive = true
                };
                _context.Categorys.Add(category);
                _context.SaveChanges();

                var author = new Author
                {
                    AuthorName = "Author" + i,
                    History = "This is a History",
                    IsAlive = true
                };
                _context.Authors.Add(author);
                _context.SaveChanges();

                var publisher = new Publisher
                {
                    Name = "Publisher" + i,
                    Description = "This is a Description",
                    IsAlive = true
                };
                _context.Publishers.Add(publisher);
                _context.SaveChanges();

                var book = new Book
                {
                    Title = "Book" + i,
                    CreatedDate = DateTime.Now,
                    Category = category,
                    Author = author,
                    Publisher = publisher,
                    Summary = "This is a Summary",
                    IsAlive = true
                };
                _context.Books.Add(book);
                _context.SaveChanges();

                var comment = new Comment
                {
                    Content = "This is a comment",
                    Book = book,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsAlive = true
                };
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            var user = new User
            {
                UserName = "UserName",
                Email = "ahihi@gmail.com",
                PasswordHash = "123",
                AccessFailedCount = 0
            };
            _context.Users.AddAsync(user);
            _context.SaveChanges();
        }
    }
}
