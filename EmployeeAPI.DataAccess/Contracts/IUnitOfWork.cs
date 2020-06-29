using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.DataAccess
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;

        void Save();
    }
}
