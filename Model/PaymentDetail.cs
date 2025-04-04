namespace CrownGardenRazorEmilLocal.Model
{
    public class PaymentDetail
    {
        public int PaymentDetailId { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public int AmountPaid { get; set; }
    }
}
