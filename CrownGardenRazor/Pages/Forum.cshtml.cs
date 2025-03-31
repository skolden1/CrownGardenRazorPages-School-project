using CrownGardenRazor.Areas.Identity.Data;
using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrownGardenRazor.Pages
{
    public class ForumModel : PageModel
    {
        private readonly AppDbContext _appDbContext;
        private readonly IdentityUserContext _indentityContext;
        public List<PostModel> Posts { get; set; }
        public ForumModel(AppDbContext appDbContext, IdentityUserContext indentityContext)
        {
            _appDbContext = appDbContext;
            _indentityContext = indentityContext;
        }
        public void OnGet()
        {
            Posts = _appDbContext.Posts.ToList();
        }
        public List<(string, string)> GetCommentsForPost(PostModel post)
        {
            List<PostCommentLinkModel> relevantPostCommentLinks = _appDbContext.PostCommentLinks.Where(pl => pl.PostId == post.Id).ToList();

            List<(string, string)> output = new List<(string, string)>();

            foreach (PostCommentLinkModel postCommentLink in relevantPostCommentLinks)
            {
                (string, string) tuple = (_appDbContext.Comments.FirstOrDefault(comment => comment.Id == postCommentLink.CommentId).Comment, _appDbContext.Comments.FirstOrDefault(comment => comment.Id == postCommentLink.CommentId).UserId);
                output.Add();
            }

            return output;
        }

        public string GetEmailForPost(string UserId)
        {
            return _indentityContext.Users.FirstOrDefault(user => user.Id == UserId).Id;
        }
    }
}
