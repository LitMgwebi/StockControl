using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockControl.Models
{
    [Table("Supplier")]
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
            Purchase_Order = new HashSet<Purchase_Order>();
        }

        public int SupplierID { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        [StringLength(50)]
        public string SupplierEmail { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Purchase_Order> Purchase_Order { get; set; }
    }
}
