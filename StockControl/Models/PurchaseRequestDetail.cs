using System;
using System.Collections.Generic;

namespace StockControl.Models
{
    public partial class PurchaseRequestDetail
    {
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual PurchaseRequest Request { get; set; } = null!;
    }
}
