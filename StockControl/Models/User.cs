using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace StockControl.Models
{
    [Table("User")]
    public partial class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string? UserName { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50)]
        public string? LastName { get; set; }

        [DisplayName("First Name")]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? UserType { get; set; }

        [DisplayName("Contact Number")]
        [Phone]
        public int ContactNumber { get; set; }

        [DisplayName("Date of Birth")]
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public bool? Active { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
