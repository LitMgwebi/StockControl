using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        [DisplayName("Name")]
        [StringLength(50)]
        public string SupplierName { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Please enter an email address")]
        public string SupplierEmail { get; set; }

        [DisplayName("Contact Number")]
        public string SupplierContactNumber { get; set; }

        [DisplayName("Address")]
        public string SupplierAddress { get; set; }

        [DisplayName("Url")]
        [Url(ErrorMessage = "Please enter a proper URL.")]
        public string SupplierUrl { get; set; }


        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Purchase_Order> Purchase_Order { get; set; }
    }
}
