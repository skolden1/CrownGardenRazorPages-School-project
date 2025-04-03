using CrownGardenRazor.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace CrownGardenRazor.Pages;

public class IndexModel : PageModel
{
    //private readonly IdentityUserContext _identityContext;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<IndexModel> _logger;

    
    

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        //_userManager = userManager;
       //_identityContext = context;
    }

    public void OnGet()
    {
        
    }
}
