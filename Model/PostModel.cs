namespace CrownGardenRazorEmilLocal.Model
{
    public class PostModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? ProfileLink { get; set; }
        public string? PostTxt { get; set; }
        public string? PostPic { get; set; }
        public int LikeQuantity { get; set; }
        public int CategoryId { get; set; }
        public DateTime PostDate { get; set; }
    }
}
