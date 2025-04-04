namespace CrownGardenRazor.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
