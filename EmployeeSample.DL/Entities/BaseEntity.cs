using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSample.DL.Entities
{
    public  class BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Version { get; set; }
        public bool IsDeleted { get; set; }

    }
}
