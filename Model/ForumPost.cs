namespace CrownGardenRazorEmilLocal.Model
{
    public class ForumPost
    {
        public int ForumPostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
