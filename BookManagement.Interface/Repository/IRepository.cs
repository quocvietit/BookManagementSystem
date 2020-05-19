using System.Collections.Generic;

namespace BookManagement.Interface.Repository
{
    /// <summary>
    /// Base repository interface for interaction with DB model
    /// </summary>
    /// <typeparam name="TModel">Entity type</typeparam>
    public interface IRepository<TModel> where TModel : class
    {
        /// <summary>
        /// Gets the count
        /// </summary>
        /// <value>Total rows count</value>
        int Count();

        //add entity
        void Add(TModel model);

        //Update model
        void Update(TModel model);

        //Delete model
        void Remove(TModel model);

        //Get model by id
        TModel Get(int id);

        //Get All model
        IEnumerable<TModel> GetAll();
    }
}
