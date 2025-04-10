using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public List<Product> productList { get; set; } = new List<Product>();
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _context.Products.FirstOrDefaultAsync(u => u.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var productById = await _context.Products.FindAsync(productId);


            if (userId == null)
            {
                ErrorMessage = "Du måste vara inloggad för att lägga till i kundvagnen";
                productList = await _context.Products.Include(p => p.Category).ToListAsync();
                return Page();
            }

            if (productById != null)
            {
                var cartItem = await _context.Carts.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    cartItem = new Cart
                    {
                        UserId = userId,
                        ProductId = productId,
                        Quantity = 1
                    };
                    await _context.Carts.AddAsync(cartItem);
                }
                await _context.SaveChangesAsync();
                TempData["AddToCartMsg"] = "Produkten lades till i kundvagnen";
            }
            return RedirectToPage("Checkout");
        }
    }
}
