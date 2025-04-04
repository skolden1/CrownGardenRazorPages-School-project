using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrownGardenRazor.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        public ProductDetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _context.Products.FirstOrDefaultAsync(u => u.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
