using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StockControl.Models
{
    [Table("Purchase_Order")]
    public partial class Purchase_Order
    {
        [Key]
        public int OrderID { get; set; }

        [DisplayName("Date of Order")]
        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [DisplayName("Purchase Request")]
        public int? RequestID { get; set; }

        [DisplayName("Total")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? PurchaseOrderTotal { get; set; }

        [DisplayName("Subtotal")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? PurchaseOrderSubtotal { get; set; }

        [DisplayName("Supplier")]
        public int? SupplierID { get; set; }

        [DisplayName("Progress")]
        [StringLength(50)]
        public string? PurchaseOrderProgress { get; set; }

        [Display(Name ="Comment", Prompt ="Please enter a comment for this Purchase Order")]
        public string? Comment { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual Purchase_Order_Detail Purchase_Order_Detail { get; set; }

        [ForeignKey("RequestID")]
        public virtual Purchase_Request Purchase_Request { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }
    }

}
