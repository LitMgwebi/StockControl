using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockControl.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Purchase_Order_Detail = new HashSet<Purchase_Order_Detail>();
            Purchase_Request_Detail = new HashSet<Purchase_Request_Detail>();
        }

        [Key]
        public int ProductID { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string ProductDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal? ProductPrice { get; set; }

        public int? SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Purchase_Order_Detail> Purchase_Order_Detail { get; set; }

        public virtual ICollection<Purchase_Request_Detail> Purchase_Request_Detail { get; set; }
    }
}
