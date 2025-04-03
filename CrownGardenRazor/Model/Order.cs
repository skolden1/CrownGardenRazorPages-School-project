using CrownGardenRazor.Areas.Identity.Data;

namespace CrownGardenRazor.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }  // This is the foreign key, because the Id property of identityUser is a string
        public IdentityUserTable User { get; set; }  // This is the navigation property for the foreign key
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
