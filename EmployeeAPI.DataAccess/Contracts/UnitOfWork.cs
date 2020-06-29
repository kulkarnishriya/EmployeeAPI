using EmployeeAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed;
        private Dictionary<string, object> repositories;
        private ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if(repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;
            if(!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance =
                    Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
