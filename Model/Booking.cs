namespace CrownGardenRazorEmilLocal.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime GolfTime { get; set; }
        public int Duration { get; set; } //minuter
    }
}
