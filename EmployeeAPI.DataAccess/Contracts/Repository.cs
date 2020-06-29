using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext dbContext;

        public DbSet<T> dbset;

        public Repository(DbContext context)
        {
            this.dbContext = context;
            dbset = context.Set<T>();
        }
        public void Delete(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> GetAll()
        {
            return dbset;
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
