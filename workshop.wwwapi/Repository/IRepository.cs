using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace workshop.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(object id);
        Task Save();


    }
}
