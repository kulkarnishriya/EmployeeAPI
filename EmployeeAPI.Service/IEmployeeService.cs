using EmployeeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public interface IEmployeeService
    {
         IEnumerable<Employee> GetAll();

         Employee GetEmployeeById(int id);

         void AddEmployee(Employee employee);

         void UpdateEmployee(Employee employee);

         void DeleteEmployee(int id);

    }
}
