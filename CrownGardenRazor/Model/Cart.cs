using Microsoft.AspNetCore.Antiforgery;

namespace CrownGardenRazor.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; } //för o koppla till identity då den är string

       
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
