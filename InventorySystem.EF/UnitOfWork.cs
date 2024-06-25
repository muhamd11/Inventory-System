using App.Core;
using App.Core.Repositories;
using App.EF.Repositories;
using InventorySystem.EF.Data;
using InvetorySystem.Core.Models.UnitModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBaseRepository<Unit> Units { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Units = new BaseRepository<Unit>(_context);
        }



        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
