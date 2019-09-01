using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Atmi.Data
{
    public interface IBaseRepository : IDisposable
    {
        Task Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        Task Delete<T>(T entity) where T : class;

        Task<T[]> GetAll<T>() where T : class;

        Task<T[]> Get<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
            where T : class;

        Task SaveChanges();
    }
}
