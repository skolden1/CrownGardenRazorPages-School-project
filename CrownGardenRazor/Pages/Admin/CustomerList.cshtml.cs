using CrownGardenRazor.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrownGardenRazor.Pages.Admin
{
   // [Authorize(Roles = "Admin")] 
    public class CustomerListModel : PageModel
    {
        private readonly UserManager<IdentityUserTable> _userManager;

        public CustomerListModel(UserManager<IdentityUserTable> userManager)
        {
            _userManager = userManager;
        }

        public List<IdentityUserTable> Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _userManager.Users.ToListAsync();
        }
    }
}
