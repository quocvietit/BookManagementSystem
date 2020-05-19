using AutoMapper;
using BookManagement.Entities.DataModels;

namespace BookManagement.Entities.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryView, Category>().ReverseMap();
            CreateMap<Category, CategoryView>().ReverseMap();

            CreateMap<Author, AuthorView>().ReverseMap();
            CreateMap<AuthorView, Author>().ReverseMap();
           
            CreateMap<Publisher, PublisherView>().ReverseMap();
            CreateMap<PublisherView, Publisher>().ReverseMap();

            CreateMap<Book, BookView>().ReverseMap();
            CreateMap<BookView, Book>().ReverseMap();
            CreateMap<Book, BookEditView>().ReverseMap();
            CreateMap<BookEditView, Book>().ReverseMap();
        }
    }
}
