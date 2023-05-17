using System;
using System.Collections.Generic;

namespace StockControl.Models
{
    public partial class PurchaseRequest
    {
        public PurchaseRequest()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int RequestId { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? PurchaseRequestStatus { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual PurchaseRequestDetail? PurchaseRequestDetail { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
