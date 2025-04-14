using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrownGardenRazor.Pages.Admin
{

    [Authorize(Roles = "Admin")]
    public class OrderDetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        public OrderDetailsModel (AppDbContext context)
        {
            _context = context;
        }

        public List<Order> Orders { get; set; } = new List<Order>();

        [BindProperty(SupportsGet = true)]
        public string UserId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(UserId))
                return NotFound();
            Orders = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == UserId)
                .ToListAsync();

            return Page();
        }
    }
}
