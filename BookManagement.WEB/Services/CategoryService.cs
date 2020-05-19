using AutoMapper;
using BookManagement.DAL.Infrastructure.Interfaces;
using BookManagement.Entities.DataModels;
using BookManagement.Entities.ViewModels;
using BookManagement.WEB.Services.Interfaces;
using System.Collections.Generic;

namespace BookManagement.WEB.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Add(CategoryView model)
        {
            if (model != null)
            {
                Category category = MapToDataModel(model);
                category.IsAlive = true;
                _unitOfWork.Category.Add(category);
                Save();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Category category = _unitOfWork.Category.Get(id);

            if (category != null)
            {
                category.IsAlive = false;
                _unitOfWork.Category.Update(category);
                Save();
                return true;
            }
            return false;
        }

        public CategoryView Get(int id)
        {
            Category category = _unitOfWork.Category.Get(id);
            CategoryView categoryView = MapToViewModel(category);
            return categoryView;
        }

        public IEnumerable<CategoryView> GetAll()
        {
            IEnumerable<Category> categories = _unitOfWork.Category.GetAll();
            List<CategoryView> categoryViews = new List<CategoryView>();
            foreach(Category category in categories)
            {
                if (category.IsAlive == true)
                {
                    CategoryView categoryView = MapToViewModel(category);
                    categoryViews.Add(categoryView);
                }
            }
            return categoryViews;
        }

        public bool Update( CategoryView model)
        {
            if (model==null)
                return false;

            Category category = _unitOfWork.Category.Get(model.CateId);
            Category categoryNew = MapToDataModel(model);
            
            if(categoryNew != null)
            {
                category.CateName = categoryNew.CateName;
                category.Description = category.Description;
            }

            if (category != null)
            {
                _unitOfWork.Category.Update(category);
                Save();
                return true;
            }
            return false;
        }

        public Category MapToDataModel(CategoryView categoryView)
        {
            return Mapper.Map<Category>(categoryView);
        }

        public CategoryView MapToViewModel(Category category)
        {
            return Mapper.Map<CategoryView>(category);
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
