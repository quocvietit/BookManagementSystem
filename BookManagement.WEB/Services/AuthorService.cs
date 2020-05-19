using AutoMapper;
using BookManagement.DAL.Infrastructure.Interfaces;
using BookManagement.Entities.DataModels;
using BookManagement.Entities.ViewModels;
using BookManagement.WEB.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BookManagement.WEB.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public bool Add(AuthorView model)
        {
            if (model != null)
            {
                Author author = MapToDataModel(model);
                author.IsAlive = true;
                _unitOfWork.Author.Add(author);
                Save();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Author author = _unitOfWork.Author.Get(id);
            if (author != null)
            {
                author.IsAlive = false;
                _unitOfWork.Author.Update(author);
                Save();
                return true;
            }
            return false;
        }

        public AuthorView Get(int id)
        {
            Author author = _unitOfWork.Author.Get(id);
            AuthorView authorView = MapToViewModel(author);
            return authorView;
        }

        public IEnumerable<AuthorView> GetAll()
        {
            IEnumerable<Author> authors = _unitOfWork.Author.GetAll();
            List<AuthorView> authorViews = new List<AuthorView>();
            foreach (Author author in authors)
            {
                if (author.IsAlive == true)
                {
                    AuthorView authorView = MapToViewModel(author);
                    authorViews.Add(authorView);
                }
            }
            return authorViews;
        }

        public bool Update(AuthorView model)
        {
            if (model == null)
                return false;

            Author author = _unitOfWork.Author.Get(model.AuthorId);
            Author authorNew = MapToDataModel(model);

            if (authorNew != null)
            {
                author.AuthorName = authorNew.AuthorName;
                author.History = author.History;
            }

            if (author != null)
            {
                _unitOfWork.Author.Update(author);
                Save();
                return true;
            }
            return false;
        }

        public Author MapToDataModel(AuthorView authorView)
        {
            return Mapper.Map<Author>(authorView);
        }

        public AuthorView MapToViewModel(Author author)
        {
            return Mapper.Map<AuthorView>(author);
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
