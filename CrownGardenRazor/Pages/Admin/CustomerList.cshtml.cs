
using CrownGardenRazor.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CrownGardenRazor.Pages.Admin
{
     [Authorize(Roles = "Admin")] 
    public class CustomerListModel : PageModel
    {
        private readonly UserManager<IdentityUserTable> _userManager;

        public CustomerListModel(UserManager<IdentityUserTable> userManager)
        {
            _userManager = userManager;
        }

        public List<IdentityUserTable> Customers { get; set; }





        [BindProperty(SupportsGet = true)]
        public string Search { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SearchFilter { get; set; } = "name";

        public async Task OnGetAsync()
        {
            var users = _userManager.Users.AsQueryable();


            if (!string.IsNullOrEmpty(Search))
            {
                if (SearchFilter == "membership")
                {
                    users = users.Where(c => c.MembershipLevel != null && c.MembershipLevel.Contains(Search));
                }



                else
                {
                    users = users.Where(c =>
                    (c.FirstName != null && c.FirstName.Contains(Search)) ||
                    (c.LastName != null && c.LastName.Contains(Search)));
                }
            }
            Customers = await users.ToListAsync();

        }
    }

}
