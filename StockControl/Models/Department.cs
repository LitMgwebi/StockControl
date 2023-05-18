using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StockControl.Models
{
    [Table("Department")]
    public partial class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [DisplayName("Name")]
        [StringLength(50)]
        public string? DepartmentName { get; set; }

        [DisplayName("Description")]
        [StringLength(50)]
        public string? DepartmentDescription { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
