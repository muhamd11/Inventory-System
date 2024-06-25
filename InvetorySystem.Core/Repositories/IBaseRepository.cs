using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<T> AddAsync(T item);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> items);
        Task<T> RemoveAsync(int id);
        Task<T> UpdateAsync(T item);
        Task<int> Count();
        
    }
}
