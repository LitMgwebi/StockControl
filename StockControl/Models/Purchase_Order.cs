using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockControl.Models
{
    [Table("Purchase_Order")]
    public partial class Purchase_Order
    {
        [Key]
        public int OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public int? RequestID { get; set; }

        [Column(TypeName = "money")]
        public decimal? PurchaseOrderTotal { get; set; }

        public int? SupplierID { get; set; }

        [StringLength(50)]
        public string? PurchaseOrderProgress { get; set; }


        public virtual Purchase_Order_Detail Purchase_Order_Detail { get; set; }

        [ForeignKey("RequestID")]
        public virtual Purchase_Request Purchase_Request { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }
    }

}
