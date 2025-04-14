namespace CrownGardenRazor.Model
{
    public class ShouldEditCommentModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CommentId { get; set; }
        public int PostId { get; set; }
    }
}