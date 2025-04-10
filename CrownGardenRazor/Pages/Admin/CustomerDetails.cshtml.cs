using CrownGardenRazor.Areas.Identity.Data;
using CrownGardenRazor.Datas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrownGardenRazor.Pages.Admin
{
    public class CustomerDetailsModel : PageModel
    {
        private readonly AppDbContext _Context;
        private readonly UserManager<IdentityUserTable> _userManager;

        public CustomerDetailsModel(AppDbContext context, UserManager<IdentityUserTable> userManager)
        {
            _Context = context;
            _userManager = userManager;
        }
    }
}
