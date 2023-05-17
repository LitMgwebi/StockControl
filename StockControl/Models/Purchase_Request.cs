using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockControl.Models
{
    [Table("Purchase_Request")]
    public partial class Purchase_Request
    {
        public Purchase_Request()
        {
            Purchase_Order = new HashSet<Purchase_Order>();
        }

        [Key]
        public int RequestID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestDate { get; set; }

        public int? EmployeeID { get; set; }

        [StringLength(50)]
        public string PurchaseRequestStatus { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Purchase_Order> Purchase_Order { get; set; }

        public virtual Purchase_Request_Detail Purchase_Request_Detail { get; set; }
    }
}
