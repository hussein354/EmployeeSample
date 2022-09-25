using EmployeeSample.BL.Abstract;
using EmployeeSample.DL.Entities;
using EmployeeSample.DL.Repos;
using EmployeeSample.DL.Repos.Abstraction.GR.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmployeeSample.BL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _emoloyeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _emoloyeeRepository = employeeRepository;

        }
        public bool Add(Employee employee)
        {
            return _emoloyeeRepository.Insert(employee);
        }

        public bool Delete(long employeeId)
        {
            var entity = _emoloyeeRepository.Get().FirstOrDefault(e => e.Id == employeeId);
            if (entity == null)
                throw new NullReferenceException();
            if (_emoloyeeRepository.Delete(entity))
                return true;
            return false;
        }

        public Employee GetById(int id)
        {
            var emoloyee = _emoloyeeRepository.Get()
                                    .Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            return emoloyee;
        }

        public bool Update(Employee employee)
        {
            var entity = _emoloyeeRepository.Get().FirstOrDefault(e => e.Id == employee.Id);
            if (entity == null)
                throw new NullReferenceException();
            entity.Name = employee.Name;
            if (_emoloyeeRepository.Update(entity))
                return true;

            return false;

        }
    }
}
