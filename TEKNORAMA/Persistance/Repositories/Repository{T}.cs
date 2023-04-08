using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using TeknoramaBackOffice.Core.Application.Interfaces;
using TeknoramaBackOffice.Persistance.Context;

namespace TeknoramaBackOffice.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly TEKNORAMAContext _teknoContext;


        public Repository(TEKNORAMAContext teknoContext)
        {
            _teknoContext = teknoContext;
        }

        public async Task CreateAsync(T entity)
        {
            
            await _teknoContext.Set<T>().AddAsync(entity);
            await _teknoContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _teknoContext.Set<T>().Update(entity);
            await _teknoContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _teknoContext.Set<T>().Remove(entity);
            await _teknoContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _teknoContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _teknoContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _teknoContext.Set<T>().FindAsync(id);
        }
        

    }
}
