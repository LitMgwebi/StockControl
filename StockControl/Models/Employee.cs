using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StockControl.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Purchase_Request = new HashSet<Purchase_Request>();
        }

        [Key]
        public string EmployeeID { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [DisplayName("Grade Level")]
        [StringLength(10)]
        public string? GradeLevel { get; set; }

        [DisplayName("Department")]
        public int? DepartmentID { get; set; }


        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }


        [ForeignKey("EmployeeID")]
        public virtual User User { get; set; }

        public virtual ICollection<Purchase_Request> Purchase_Request { get; set; }
    }
}
