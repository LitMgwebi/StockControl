using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace StockControl.Models
{
    [Table("Department")]
    public partial class Department: IdentityRole
    {
        [DisplayName("Name")]
        [StringLength(50)]
        public string? DepartmentName { get; set; }

        [DisplayName("Description")]
        [StringLength(100)]
        public string? DepartmentDescription { get; set; }

        //public virtual ICollection<Employee>? Employees { get; set; }
    }
}
