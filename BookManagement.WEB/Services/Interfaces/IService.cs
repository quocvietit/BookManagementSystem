using System.Collections.Generic;

namespace BookManagement.WEB.Services.Interfaces
{
    public interface IService<TDataModel, TViewModel> 
        where TDataModel: class 
        where TViewModel : class
    {
        TViewModel Get(int id);
        IEnumerable<TViewModel> GetAll();
        bool Add(TViewModel model);
        bool Update(TViewModel model);
        bool Delete(int id);
        void Save();
        TDataModel MapToDataModel(TViewModel model);
        TViewModel MapToViewModel(TDataModel model);
    }
}
