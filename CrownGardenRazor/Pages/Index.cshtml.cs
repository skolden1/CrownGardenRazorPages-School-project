using CrownGardenRazor.Areas.Identity.Data;
using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace CrownGardenRazor.Pages;

public class IndexModel : PageModel
{
   
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager; 
    private readonly IdentityUserContext _Icontext;
    private readonly ILogger<IndexModel> _logger;

    
    public string UserMessage { get; set; }
    public IndexModel(ILogger<IndexModel> logger, AppDbContext context, IdentityUserContext Icontext)
    {
        _Icontext = Icontext;
        _context = context;
        _logger = logger;
        //_userManager = userManager;
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
