using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Entities.ViewModels
{
    public class BookView
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int IsActive { get; set; }
    }
}
