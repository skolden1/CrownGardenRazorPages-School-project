namespace CrownGardenRazor.Model
{
    public class UndoEditCommentModel
    {
        public int Id { get; set; }
        public bool RegretEditComment { get; set; } = false;
        public int CommentId { get; set; }
    }
}
