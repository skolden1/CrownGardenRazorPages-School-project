namespace CrownGardenRazorEmilLocal.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
