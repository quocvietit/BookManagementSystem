using BookManagement.DAL.Repository.Interfaces;
using BookManagement.Entities.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(DbContext context) : base(context)
        {
        }
    }
}
