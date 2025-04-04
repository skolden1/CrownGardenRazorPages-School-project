namespace CrownGardenRazorEmilLocal.Model
{
    public class PostLikeModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public bool? HasLiked { get; set; }
    }
}
