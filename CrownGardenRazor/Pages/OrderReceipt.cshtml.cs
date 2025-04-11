using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CrownGardenRazor.Pages
{
    public class OrderReceiptModel : PageModel
    {
        private readonly AppDbContext _context;
        public OrderReceiptModel(AppDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Page();
            }

               Order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (Order == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
