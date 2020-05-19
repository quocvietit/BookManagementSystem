using BookManagement.Entities.DataModels;
using BookManagement.Entities.ViewModels;

namespace BookManagement.WEB.Services.Interfaces
{
    public interface IBookService : IService<Book, BookView>
    {
        bool AddBook(BookEditView bookEditView);
        BookEditView GetBook(int id);
        bool UpdateBook(BookEditView bookEdit);
        Book MapEditToDataModel(BookEditView bookEditView);
        BookEditView MapDataToEditModel(Book book);
    }
}
