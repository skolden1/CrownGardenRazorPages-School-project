using Microsoft.AspNetCore.Antiforgery;

namespace CrownGardenRazor.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; } //för o koppla till identity då den är string

        //lägg till nav prop så det blir fk
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
