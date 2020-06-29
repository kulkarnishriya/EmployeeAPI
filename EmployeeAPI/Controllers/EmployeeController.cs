using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Domain;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _service;
        ILogger _logger;

        public EmployeeController(IEmployeeService service, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _service = service;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IList<Employee> Get()
        {
            _logger.LogInformation("Get all Employee called");
            try
            {
                var students = _service.GetAll().ToList();
                return students;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Get all Employee", ex.InnerException);
                return new List<Employee>();
            }
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            try
            {
                _logger.LogInformation("Get Employee by id called");
                return _service.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get Employee by id failed", ex.InnerException);
                return new Employee();
            }
            
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _logger.LogInformation("Add student called","Student object {student}", employee);
            try
            {
                _service.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError("Add student failed", ex.InnerException);
            }
           
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            _logger.LogInformation("Update employee called", "Student object {student}", employee);
            try
            {
                _service.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError("Update employee failed", ex.InnerException);
            }

            
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation("Delete employee called", "Student id {id}", id);
            try
            {
                _service.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Update employee failed", ex.InnerException);
            }
            
        }
    }
}
