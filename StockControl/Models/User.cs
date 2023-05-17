using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(50)]
        public string? Surname { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? UserType { get; set; }

        public bool? Active { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
