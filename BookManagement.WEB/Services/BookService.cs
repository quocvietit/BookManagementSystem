using System;
using System.Collections.Generic;
using AutoMapper;
using BookManagement.DAL.Infrastructure.Interfaces;
using BookManagement.Entities.DataModels;
using BookManagement.Entities.ViewModels;
using BookManagement.WEB.Services.Interfaces;

namespace BookManagement.WEB.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //not support
        public bool Add(BookView model)
        {
            throw new System.NotImplementedException();
        }

        //not support
        public bool Update(BookView model)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            Book book = _unitOfWork.Book.Get(id);
            if (book != null)
            {
                book.IsAlive = false;
                _unitOfWork.Book.Update(book);
                Save();
                return true;
            }
            return false;
        }

        public BookView Get(int id)
        {
            Book book = _unitOfWork.Book.Get(id);
            BookView bookView = MapToViewModel(book);
            return bookView;
        }

        public IEnumerable<BookView> GetAll()
        {
            IEnumerable<Book> books = _unitOfWork.Book.GetAll();
            List<BookView> bookViews = new List<BookView>();
            foreach (Book book in books)
            {
                if (book.IsAlive == true)
                {
                    BookView bookView = MapToViewModel(book);
                    bookViews.Add(bookView);
                }
            }
            return bookViews;
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }

        //get book edit view
        public BookEditView GetBook(int id)
        {
            Book book = _unitOfWork.Book.Get(id);
            BookEditView bookEditView = MapDataToEditModel(book);
            return bookEditView;
        }

        //Update book with information book edit view model
        public bool UpdateBook(BookEditView bookEdit)
        {
            if (bookEdit == null)
                return false;

            Book book = _unitOfWork.Book.Get(bookEdit.BookId);
            Book bookNew = MapEditToDataModel(bookEdit);

            if (bookNew != null)
            {
                book.Title = bookNew.Title;
                book.Price = bookNew.Price;
                book.Quantity = bookNew.Quantity;
                book.IsActive = bookNew.IsActive;
                book.ImgUrl = bookNew.ImgUrl;
                book.Modified = DateTime.Now;
                book.AuthorId = bookNew.AuthorId;
                book.CateId = bookNew.CateId;
                book.PubId = bookNew.PubId;
            }

            if (book != null)
            {
                _unitOfWork.Book.Update(book);
                Save();
                return true;
            }
            return false;
        }

        //add book with information book edit view model
        public bool AddBook(BookEditView bookEditView)
        {
            if (bookEditView == null)
                return false;

            Book book = MapEditToDataModel(bookEditView);

            if (book != null)
            {
                book.IsAlive = true;
                book.CreatedDate = DateTime.Now;
                _unitOfWork.Book.Add(book);
                Save();
                return true;
            }
            return false;
        }
        public Book MapToDataModel(BookView bookView)
        {
            return Mapper.Map<Book>(bookView);
        }

        public BookView MapToViewModel(Book book)
        {
            return Mapper.Map<BookView>(book);
        }

        //mapping Edit model to data view model
        public Book MapEditToDataModel(BookEditView bookEditView)
        {
            return Mapper.Map<Book>(bookEditView);
        }

        //mapping data model to edit view model
        public BookEditView MapDataToEditModel(Book book)
        {
            return Mapper.Map<BookEditView>(book);
        }
    }
}
