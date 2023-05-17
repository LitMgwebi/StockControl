using System;
using System.Collections.Generic;

namespace StockControl.Models
{
    public partial class PurchaseOrder
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? RequestId { get; set; }
        public decimal? PurchaseOrderTotal { get; set; }
        public int? SupplierId { get; set; }
        public string? PurchaseOrderProgress { get; set; }

        public virtual PurchaseRequest? Request { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual PurchaseOrderDetail? PurchaseOrderDetail { get; set; }
    }
}
