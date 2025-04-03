using CrownGardenRazor.Areas.Identity.Data;

namespace CrownGardenRazor.Model
{
    public class ForumPost
    {
        public int ForumPostId { get; set; }
        public string UserId { get; set; }  // This is the foreign key, because the Id property of identityUser is a string
        public IdentityUserTable User { get; set; }  // This is the navigation property for the foreign key
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
