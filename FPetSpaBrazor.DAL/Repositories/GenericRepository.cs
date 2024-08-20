using FPetSpaBrazor.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPetSpaBrazor.DAL.Repositories
{
    public class GenericRepository<T> where T : class
    {
        private readonly FpetSpaBrazorContext _context;

        private DbSet<T> dbSet;

        public GenericRepository(FpetSpaBrazorContext context)
        {
            this._context = context;
            this.dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
           return dbSet.ToList();
        }
        

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }


        public void Update(T entity)
        {
            var tracker = dbSet.Attach(entity);
            tracker.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
           dbSet.Remove(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

    }
}
