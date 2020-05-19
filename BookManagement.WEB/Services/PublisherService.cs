using AutoMapper;
using BookManagement.DAL.Infrastructure.Interfaces;
using BookManagement.Entities.DataModels;
using BookManagement.Entities.ViewModels;
using BookManagement.WEB.Services.Interfaces;
using System.Collections.Generic;

namespace BookManagement.WEB.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PublisherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Add(PublisherView model)
        {
            if (model != null)
            {
                Publisher publisher = MapToDataModel(model);
                publisher.IsAlive = true;
                _unitOfWork.Publisher.Add(publisher);
                Save();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Publisher publisher = _unitOfWork.Publisher.Get(id);

            if (publisher != null)
            {
                publisher.IsAlive = false;
                _unitOfWork.Publisher.Update(publisher);
                Save();
                return true;
            }
            return false;
        }

        public PublisherView Get(int id)
        {
            Publisher publisher = _unitOfWork.Publisher.Get(id);
            PublisherView publisherView = MapToViewModel(publisher);
            return publisherView;
        }

        public IEnumerable<PublisherView> GetAll()
        {
            IEnumerable<Publisher> publishers = _unitOfWork.Publisher.GetAll();
            List<PublisherView> publisherViews = new List<PublisherView>();
            foreach (Publisher publisher in publishers)
            {
                if (publisher.IsAlive == true)
                {
                    PublisherView publisherView = MapToViewModel(publisher);
                    publisherViews.Add(publisherView);
                }
            }
            return publisherViews;
        }

        public bool Update(PublisherView model)
        {
            if (model == null)
                return false;

            Publisher publisher = _unitOfWork.Publisher.Get(model.PubId);
            Publisher publisherNew = MapToDataModel(model);

            if (publisherNew != null)
            {
                publisher.Name = publisherNew.Name;
                publisher.Description = publisher.Description;
            }

            if (publisher != null)
            {
                _unitOfWork.Publisher.Update(publisher);
                Save();
                return true;
            }
            return false;
        }

        public Publisher MapToDataModel(PublisherView publisherView)
        {
            return Mapper.Map<Publisher>(publisherView);
        }

        public PublisherView MapToViewModel(Publisher publisher)
        {
            return Mapper.Map<PublisherView>(publisher);
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
