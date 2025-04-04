using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CrownGardenRazorEmilLocal.Areas.Identity.Data;
using CrownGardenRazorEmilLocal.Datas;
namespace CrownGardenRazorEmilLocal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("IdentityUserContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityUserContextConnection' not found.");;

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<IdentityUserContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUserTable>(options => options.SignIn.RequireConfirmedAccount = true).
                AddEntityFrameworkStores<IdentityUserContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
