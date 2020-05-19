using BookManagement.Interface.Repository;
using System.Collections.Generic;

namespace BookManagement.Entities.DataModels
{
    /// <summary>
    /// Category Entity
    /// </summary>
    public class Category : AuditableEntity
    {
        public int CateId { get; set; }
        public string CateName { get; set; }
        public string Description { get; set; }

        //primary Book
        public virtual ICollection<Book> Books { get; set; }
    }
}
