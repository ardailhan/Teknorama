using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TeknoramaBackOffice.Core.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //Verileri Getirme

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);

        //Verileri Düzenleme
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
