using EmployeeSample.DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSample.BL.Abstract
{
    public interface IEmployeeService
    {
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(long employeeId);
        Employee GetById(int id);
    }
}
