namespace CrownGardenRazorEmilLocal.Model
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public DateTime CommentPostDate { get; set; }
    }
}
