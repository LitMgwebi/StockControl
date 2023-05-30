using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        [DisplayName("Date of Request")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? RequestDate { get; set; }

        [DisplayName("Employee")]
        public string? EmployeeID { get; set; }

        [DisplayName("Status")]
        [StringLength(50)]//InComplete, Complete, In Progress
        public string PurchaseRequestStatus { get; set; }

        [DisplayName("Total")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "R {0:c}")]
        public decimal? PurchaseRequestTotal { get; set; }

        [DisplayName("Subtotal")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "R {0:c}")]
        public decimal? PurchaseRequestSubtotal { get; set; }

        public bool IsDeleted { get; set; } = false;



        [ForeignKey("EmployeeID")]
        public virtual User User { get; set; }

        public virtual ICollection<Purchase_Order> Purchase_Order { get; set; }

        public virtual Purchase_Request_Detail Purchase_Request_Detail { get; set; }
    }
}
