using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CrownGardenRazor.Areas.Identity.Data;
using CrownGardenRazor.Datas;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityUserContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityUserContextConnection' not found.");;

//Appdbcontext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<IdentityUserContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUserTable>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<IdentityUserContext>()
//    .AddDefaultUI()
//    .AddDefaultTokenProviders();



// Add Identity services to pass two types of identity
builder.Services.AddIdentity<IdentityUserTable, IdentityRole>(options =>
{
options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<IdentityUserContext>()
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


using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUserTable>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // Admin user info
    var adminEmail = "admin@crowngarden.se";
    var adminPassword = "Admin123!";

    // Create "Admin" role if not exists
    await roleManager.CreateAsync(new IdentityRole("Admin"));

   
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var user = new IdentityUserTable
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = "Admin",
            LastName = "User",
            EmailConfirmed = true,
            MembershipLevel = "Gold",
            ProfilePicture = "/ProfilePictures/DefaultProfileImage.png"
        };

        await userManager.CreateAsync(user, adminPassword);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}


app.Run();
