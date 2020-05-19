using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Entities.ViewModels
{
    public class BookEditView
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImgUrl { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public int AuthorId { get; set; }
        public int CateId { get; set; }
        public int PubId { get; set; }
    }
}
