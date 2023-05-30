namespace StockControl.Models
{
    public class RequestViewModel
    {
        public Purchase_Request Purchase_Request { get; set; }
        public Purchase_Request_Detail Purchase_Request_Detail { get; set; }
        public IEnumerable<Purchase_Request_Detail> Request_Details { get; set; }
    }
}
