using CrownGardenRazor.Areas.Identity.Data;
using CrownGardenRazor.Datas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace CrownGardenRazor.Pages;

public class IndexModel : PageModel
{
    //private readonly IdentityUserContext _identityContext;
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string Id { get; set; } = "hej"; 

    public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
    {
        _context = context;
        _logger = logger;
        //_userManager = userManager;
       //_identityContext = context;
    }

    public void OnGet()
    {
        int hej = 12;
    }
}
