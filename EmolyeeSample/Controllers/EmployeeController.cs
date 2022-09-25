using EmolyeeSample.Dtos;
using EmployeeSample.BL;
using EmployeeSample.BL.Abstract;
using EmployeeSample.DL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmolyeeSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public Employee GetEmployee(int employeeId)
        {
            return _employeeService.GetById(employeeId);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public bool AddEmployee(InsertEmployeeDto insertEmployeeDto)
        {
            Employee employee = new()
            {
                Name = insertEmployeeDto.Name,
                DepartmentId =  insertEmployeeDto.DepartmentId
            };
            return _employeeService.Add(employee);
        }
        [HttpPost]
        [Route("UpdateEmployee")]
        public bool UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            Employee employee = new()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
            };
            return _employeeService.Update(employee);
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public bool DeleteEmployee(int employeeId)
        {
            return _employeeService.Delete(employeeId);
        }
    }
}
