using System;
using System.Collections.Generic;

namespace StockControl.Models
{
    public partial class Employee
    {
        public Employee()
        {
            PurchaseRequests = new HashSet<PurchaseRequest>();
        }

        public int EmployeeId { get; set; }
        public string? Gender { get; set; }
        public string? GradeLevel { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual User EmployeeNavigation { get; set; } = null!;
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; }
    }
}
