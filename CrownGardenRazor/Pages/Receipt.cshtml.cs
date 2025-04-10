using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CrownGardenRazor.Pages
{
    public class ReceiptModel : PageModel
    {
        private readonly AppDbContext _context;
        public ReceiptModel(AppDbContext context)
        {
            _context = context;
        }
        public Order Orders { get; set; }
       
        public async Task<IActionResult> OnGet()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToPage("/Index");    
            }
            Orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();

            if (Orders == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
