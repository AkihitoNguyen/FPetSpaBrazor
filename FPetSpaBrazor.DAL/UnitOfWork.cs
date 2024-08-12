using FPetSpaBrazor.DAL.Repositories;
using FPetSpaBrazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPetSpaBrazor.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FpetSpaBrazorContext _context;
        private GenericRepository<Product> productRepository;

        public UnitOfWork(FpetSpaBrazorContext _context)
        {
            this._context = _context;
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(_context);
                }
                return this.productRepository;
            }
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
