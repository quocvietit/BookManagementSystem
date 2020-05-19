using BookManagement.Interface.Models;
using Microsoft.AspNetCore.Identity;

namespace BookManagement.Entities.DataModels
{
    public class User : IdentityUser, IAuditableEntity
    { 
        public bool IsAlive { get; set; }
    }
}
