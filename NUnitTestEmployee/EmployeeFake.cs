using EmployeeAPI.Domain;
using EmployeeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestEmployee
{
   public class EmployeeFake : IEmployeeService
    {
        public List<Employee> _employee;

        public EmployeeFake()
        {
            _employee = new List<Employee>()
            {
                new Employee(){ Id=1, Name="ABC", Address="Mumbai" },
                new Employee(){ Id=2, Name="Twinkle", Address="Pune" },
                new Employee(){ Id=3, Name="John", Address="Delhi" },
                new Employee(){ Id=4, Name="Mike", Address="Mumbai" }
            };
           
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employee;
        }

        public void AddEmployee(Employee newEmployee)
        {
          newEmployee.Id = _employee.OrderBy(x=> x.Id).LastOrDefault().Id + 1;
          _employee.Add(newEmployee);
        }

        public Employee GetEmployeeById(int id)
        {
            return _employee.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void DeleteEmployee(int id)
        {
            var existing = _employee.First(a => a.Id == id);
            _employee.Remove(existing);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existing = _employee.First(a => a.Id == employee.Id);
            existing.Name = employee.Name;
            existing.Address = employee.Name;
            _employee.RemoveAll(x => x.Id == employee.Id);
            _employee.Add(existing);
        }
    }
}
