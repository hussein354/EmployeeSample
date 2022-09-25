using EmployeeSample.DL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSample.DL.Contexts
{
  
        public class EmployeeDbContext : DbContext
        {
            public EmployeeDbContext(DbContextOptions options) : base(options)
            {
            }

            DbSet<Employee> Employees { get; set; }
            DbSet<Department> departments { get; set; }
        }
    
}
