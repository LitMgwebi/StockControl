using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StockControl.Models
{
    [Table("Purchase_Order_Detail")]
    public partial class Purchase_Order_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [DisplayName("Product")]
        public int ProductID { get; set; }

        [Display(Name ="Quantity", Prompt ="Please enter the quantity")]
        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? Price { get; set; }

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderID")]
        public virtual Purchase_Order Purchase_Order { get; set; }
    }
}
