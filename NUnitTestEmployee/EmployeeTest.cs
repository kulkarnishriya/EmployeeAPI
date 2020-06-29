using EmployeeAPI.Controllers;
using EmployeeAPI.Domain;
using EmployeeAPI.Services;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace NUnitTestEmployee
{
    public class EmployeeTest
    {
        IEmployeeService _service;
        static LoggerFactory factory = new LoggerFactory();

        ILogger<EmployeeController> logger = factory.CreateLogger<EmployeeController>();
        EmployeeController controller;

        [SetUp]
        public void Setup()
        {
            _service = new EmployeeFake();
            controller = new EmployeeController(_service, logger);
        }

        [Test]
        public void GetAllEmployees()
        {
            var Result = controller.Get();

            Assert.AreEqual(_service.GetAll(), Result);
        }

        [Test]
        public void GetEmployeeById()
        {
            var Result = controller.Get(2);

            Assert.AreEqual(_service.GetEmployeeById(2), Result);
        }

        [Test]
        public void AddEmployee()
        {
            Employee emp = new Employee()
            {
                Name = "Mary",
                Address = "Banglore",
            };
            controller.Post(emp);
            var Result = controller.Get(emp.Id);

            //Object of that Rollnumber is created.
            Assert.AreEqual(emp.Id, Result.Id);
        }

        [Test]
        public void UpdateEmployee()
        {
            var employee = controller.Get(1);
            employee.Name = "Snipper";
            controller.Put(1, employee);
            var Result = controller.Get(employee.Id);

            Assert.AreEqual(employee.Name, Result.Name);
        }

        [Test]
        public void DeleteEmployee()
        {
            controller.Delete(3);
            var Result = controller.Get(3);

            Assert.Null(Result);
        }

    }
}