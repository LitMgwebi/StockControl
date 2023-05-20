using StockControl.Models;

namespace StockControl.Services
{
    public class PurchaseRequestViewModel
    {
        public Purchase_Request Purchase_Request { get; set; }
        public Purchase_Request_Detail Request_Detail { get; set; }
    }
}
