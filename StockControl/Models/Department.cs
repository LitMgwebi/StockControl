using System;
using System.Collections.Generic;

namespace StockControl.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
