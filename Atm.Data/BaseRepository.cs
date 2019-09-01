using Atmi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atm.Data
{
    public class BaseRepository : IBaseRepository
    {
        protected AtmDbContext Context;

        public BaseRepository(AtmDbContext context)
        {
            Context = context;
        }

        public async Task Add<T>(T entity) where T : class
        {
            await Context.AddAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete<T>(T entity) where T : class
        {
            await Task.Run(() =>
            {
                Context.Remove(entity);
            });
        }

        public async Task<T[]> GetAll<T>() where T : class
        {
            return await Get<T>(x => x != null);
        }

        public async Task<T[]> Get<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class
        {
            var query = Context.DbSet<T>().AsNoTracking().AsQueryable();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var result = await query.ToArrayAsync();
            return result;
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                Context.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
