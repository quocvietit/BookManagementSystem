using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Entities.ViewModels
{
    public class CommentView
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
