using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace CrownGardenRazor.Pages
{
    public class OrderHistoryModel : PageModel
    {

        private readonly AppDbContext _context;

        public OrderHistoryModel(AppDbContext context)
        {
            _context = context;
        }

        public string ErrorMsg { get; set; }
        public List<Order> OrderHistoryList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                ErrorMsg = "Du måste logga in för att se din orderhistorik";
                return Page();
            }

            OrderHistoryList = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(p => p.Product)
                .Where(u => u.UserId == userId)
                .ToListAsync();

            if (!OrderHistoryList.Any())
            {
                ErrorMsg = "Du har inga tidigare ordrar";
                return Page();
            }

            return Page();
        }


    }
}
