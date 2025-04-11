using CrownGardenRazor.Areas.Identity.Data;
using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrownGardenRazor.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly IdentityUserContext _Icontext;
    private readonly ILogger<IndexModel> _logger;

    public string UserMessage { get; set; }

    public List<Product> productList { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger, AppDbContext context, IdentityUserContext Icontext)
    {
        _Icontext = Icontext;
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {

            productList = await _context.Products
                .OrderBy(p => Guid.NewGuid())
                .Take(9)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching products for the index page.");
            productList = new List<Product>();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostDelete()
    {
        var name = "admin";
        var user = await _Icontext.Users.FirstOrDefaultAsync(u => u.UserName == name);

        if (user != null)
        {
            _Icontext.Users.Remove(user);
            await _Icontext.SaveChangesAsync();
            return Page();
        }

        return Page();
    }
}
