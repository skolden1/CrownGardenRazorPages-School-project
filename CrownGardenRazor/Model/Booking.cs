using CrownGardenRazor.Areas.Identity.Data;

namespace CrownGardenRazor.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }  // This is the foreign key, because the Id property of identityUser is a string GUID
        public IdentityUserTable User { get; set; }  // This is the navigation property for the foreign key
        public DateTime BookingDate { get; set; }
        public DateTime GolfTime { get; set; }
        public int Duration { get; set; } //minuter

    }
}
