using App.Core.Repositories;
using InventorySystem.EF.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T item)
        {
            var result = await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;

        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }


        public async Task<T> RemoveAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(result);
            return result;
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = _context.Set<T>().Update(item);
            return result.Entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
            return items;
        }

        public async Task<int> Count()
        {
            return await _context.Set<T>().CountAsync();
        }

    }
}

