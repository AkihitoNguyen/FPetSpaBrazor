using FPetSpaBrazor.DAL.Repositories;
using FPetSpaBrazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPetSpaBrazor.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public GenericRepository<Product> ProductRepository { get; }
        Task<int> SaveChangesAsync();
        void SaveChanges();
    }
}
