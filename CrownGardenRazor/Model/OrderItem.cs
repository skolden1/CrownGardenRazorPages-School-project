namespace CrownGardenRazor.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        //fk till order
        public int OrderId { get; set; }
        public Order Order { get; set; }

        //fk till produkt
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
