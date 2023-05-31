namespace StockControl.Models
{
    public class OrderRequestViewModel
    {
        public Purchase_Order Order { get; set; }
        public Purchase_Request Request { get; set; }
        public IEnumerable<Purchase_Request> Requests { get; set; }
    }
}
