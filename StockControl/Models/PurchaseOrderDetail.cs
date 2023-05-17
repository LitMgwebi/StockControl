using System;
using System.Collections.Generic;

namespace StockControl.Models
{
    public partial class PurchaseOrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual PurchaseOrder Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
