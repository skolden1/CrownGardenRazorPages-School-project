using CrownGardenRazor.Areas.Identity.Data;

namespace CrownGardenRazor.Model
{
    public class ProductReview
    {
        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }  // This is the foreign key, because the Id property of identityUser is a string
        public IdentityUserTable User { get; set; }  // This is the navigation property for the foreign key
        public string Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
