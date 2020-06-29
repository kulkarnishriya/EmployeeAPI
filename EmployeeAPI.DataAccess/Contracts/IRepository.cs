using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.DataAccess
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        void Update(T entity);

        void Insert(T entity);

        void Delete(T entity);
    }
}
