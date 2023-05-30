namespace StockControl.Models
{
    public class OrderViewModel
    {
        public Purchase_Order Purchase_Order { get; set; }
        public Purchase_Order_Detail Purchase_Order_Detail { get; set; }
        public IEnumerable<Purchase_Order_Detail> Order_Details { get; set; }
    }
}
