using BookManagement.Entities.DataModels;
using System.Threading.Tasks;

namespace BookManagement.DAL.Core.Interfaces
{
    public interface IAccountManager
    {
        
        Task<User> GetUserByIDAsync(string id);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<bool> CheckPasswordAsync(User user, string password);
        //Task CreateAsync(User user, string v);
    }
}
