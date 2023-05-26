using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace StockControl.Models
{
    [Table("Employee")]
    public partial class Employee: IdentityUserRole<string>
    {
        public Employee()
        {
            Purchase_Request = new HashSet<Purchase_Request>();
        }
        /*
        [DisplayName("Employee")]
        public string EmployeeID { get; set; }

        [DisplayName("Department")]
        public int? DepartmentID { get; set; }*/

        [DisplayName("Grade Level")]
        [StringLength(10)]
        public string? GradeLevel { get; set; }

        /*
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual User User { get; set; }*/

        public virtual ICollection<Purchase_Request> Purchase_Request { get; set; }
    }
}
