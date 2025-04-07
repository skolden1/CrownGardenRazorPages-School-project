using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CrownGardenRazor.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly AppDbContext _context;
        public CheckoutModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Cart> CartItemList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            return Page();
        }
    }
}
