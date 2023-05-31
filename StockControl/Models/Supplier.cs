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

        [Display(Name ="Name", Prompt ="Please enter the Name of the Supplier")]
        [StringLength(50)]
        public string SupplierName { get; set; }

        [Display(Name ="Email", Prompt ="Please enter the Supplier's email address")]
        [EmailAddress(ErrorMessage = "Please enter an email address")]
        public string SupplierEmail { get; set; }

        [Display(Name="Contact Number", Prompt ="Please enter the Supplier's Contact Number")]
        public string SupplierContactNumber { get; set; }

        [Display(Name="Address", Prompt =$"Please enter the Supplier's physical address ")]
        public string SupplierAddress { get; set; }

        [Display(Name ="Url", Prompt ="Please enter the Supplier's URL")]
        [Url(ErrorMessage = "Please enter a proper URL.")]
        public string SupplierUrl { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Purchase_Order> Purchase_Order { get; set; }
    }
}
