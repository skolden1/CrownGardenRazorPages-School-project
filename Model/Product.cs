namespace CrownGardenRazorEmilLocal.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;
        public string ImageUrl { get; set; }
        //fk
        public int CategoryId { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
