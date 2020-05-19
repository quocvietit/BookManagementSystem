using System.Collections.Generic;

namespace BookManagement.Entities.DataModels
{
    public class Author : AuditableEntity
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string History { get; set; }

        //primary key Book
        public virtual ICollection<Book> Books { get; set; }
    }
}
