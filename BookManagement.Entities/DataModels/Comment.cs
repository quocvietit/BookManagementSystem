using System;

namespace BookManagement.Entities.DataModels
{
    public class Comment : AuditableEntity
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        //foreign key Book
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
