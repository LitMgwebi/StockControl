using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StockControl.Models
{
    [Table("Purchase_Request_Detail")]
    public partial class Purchase_Request_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestID { get; set; }

        [DisplayName("Product")]
        public int ProductID { get; set; }

        [Display(Name = "Quantity", Prompt = "Please enter the quantity")]
        public int Quantity { get; set; }

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("RequestID")]
        public virtual Purchase_Request Purchase_Request { get; set; }
    }
}
