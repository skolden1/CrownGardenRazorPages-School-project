using CrownGardenRazor.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrownGardenRazor.Pages.Admin
{
    public class EditCustomerModel : PageModel
    {
        private readonly UserManager<IdentityUserTable> _userManager;

        public EditCustomerModel(UserManager<IdentityUserTable> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public IdentityUserTable Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
                return NotFound();

            Customer = await _userManager.FindByIdAsync(id);

            if (Customer == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.FindByIdAsync(Customer.Id);
            if (user == null)
                return NotFound();

            user.FirstName = Customer.FirstName;
            user.LastName = Customer.LastName;
            user.MembershipLevel = Customer.MembershipLevel;

            await _userManager.UpdateAsync(user);
            return RedirectToPage("CustomerList");
        }
    }
}
