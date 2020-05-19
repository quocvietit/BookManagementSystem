using System;
using System.Collections.Generic;

namespace BookManagement.Entities.DataModels
{
    /// <summary>
    /// Book Entity
    /// </summary>
    public class Book : AuditableEntity
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImgUrl { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Modified { get; set; }
        public bool IsActive { get; set; }

        //primary key
        public virtual ICollection<Comment> Comments { get; set; }

        //foreign key author
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        //foreign key category 
        public int CateId { get; set; }
        public Category Category { get; set; }

        //foreign key publicher 
        public int PubId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
