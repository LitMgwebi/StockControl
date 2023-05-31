using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        [Display(Name ="Barcode", Prompt ="Please enter the barcode of the product")]
        [StringLength(50)]
        public string Barcode { get; set; }

        [Display(Name ="Name", Prompt ="Please enter the name of the product")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Display(Name ="Description", Prompt ="Please enter a description of this product")]
        [StringLength(100)]
        public string ProductDescription { get; set; }

        [DisplayName("Price")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal ProductPrice { get; set; }

        [DisplayName("Supplier")]
        public int SupplierID { get; set; }

        public bool IsDeleted { get; set; } = false;



        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Purchase_Order_Detail> Purchase_Order_Detail { get; set; }

        public virtual ICollection<Purchase_Request_Detail> Purchase_Request_Detail { get; set; }
    }
}
