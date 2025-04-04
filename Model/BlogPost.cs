namespace CrownGardenRazorEmilLocal.Model
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public string PublishDate { get; set; }
    }
}
