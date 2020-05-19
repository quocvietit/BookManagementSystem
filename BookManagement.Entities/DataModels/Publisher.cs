using System.Collections.Generic;

namespace BookManagement.Entities.DataModels
{
    public class Publisher : AuditableEntity
    {
        public int PubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //primary key Book
        public virtual ICollection<Book> Books { get; set; }
    }
}

