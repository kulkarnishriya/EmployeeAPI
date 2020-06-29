using EmployeeAPI.DataAccess;
using EmployeeAPI.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork _unitOfWork;
        IRepository<Employee> _employeeRepository;
        ILogger _logger;

        public EmployeeService(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = _unitOfWork.Repository<Employee>();
            _logger = logger;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Insert(employee);
            _unitOfWork.Save();
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
            _unitOfWork.Save();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
                _unitOfWork.Save();
            }
        }
    }
}
