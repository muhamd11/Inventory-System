using App.Core.Repositories;
using InvetorySystem.Core.Models.UnitModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Unit> Units { get; } 

        Task<int> CommitAsync();
    }
}
