namespace CrownGardenRazor.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool PaymentStatus { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
