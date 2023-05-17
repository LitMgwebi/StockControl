using System;
using System.Collections.Generic;

namespace StockControl.Models
{
    public partial class Product
    {
        public Product()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            PurchaseRequestDetails = new HashSet<PurchaseRequestDetail>();
        }

        public int ProductId { get; set; }
        public string? Barcode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<PurchaseRequestDetail> PurchaseRequestDetails { get; set; }
    }
}
