using CrownGardenRazorEmilLocal.Model;
using Microsoft.EntityFrameworkCore;

namespace CrownGardenRazorEmilLocal.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<PostCommentLinkModel> PostCommentLinks { get; set; }
        public DbSet<PostLikeModel> PostLikes { get; set; }
    }
}
