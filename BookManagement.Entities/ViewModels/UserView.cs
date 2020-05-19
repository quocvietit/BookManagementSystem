using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Entities.ViewModels
{
    public class UserView
    {
        public int UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
