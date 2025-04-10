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

        public string ErrorMsg { get; set; }
        public List<Cart> CartItemList { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        public decimal TotalAmounT { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                ErrorMsg = "Du måste logga in för att se din varukorg";
                return Page();
            }

            CartItemList = await _context.Carts.Where(u => u.UserId == userId)
                .Include(p => p.Product)
                .ToListAsync();

            if (CartItemList == null || CartItemList.Count == 0)
            {
                ErrorMsg = "Varukorgen är tom";
            }

            TotalAmounT = CartItemList.Sum(item => item.Product.Price * item.Quantity);         

            return Page();
        }

        public async Task<IActionResult> OnPostCheckoutOrderAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                ErrorMsg = "Du måste logga in för att göra en beställning";
                return Page();
            }

            CartItemList = await _context.Carts.Where(u => u.UserId == userId)
                .Include(p => p.Product)
                .ToListAsync();



            if (CartItemList == null || !CartItemList.Any())
            {
                ErrorMsg = "Din varukorg är tom";
                return Page();
            }
            TotalAmounT = CartItemList.Sum(item => item.Product.Price * item.Quantity);
            List<OrderItem> orderItems = new List<OrderItem>();
            

            foreach(var item in CartItemList)
            {
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                };
                orderItems.Add(orderItem);

                
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                PaymentStatus = true,
                OrderItems = orderItems,
                TotalAmount = TotalAmounT
            };

            

            await _context.Orders.AddAsync(order);

            _context.Carts.RemoveRange(CartItemList);

            await _context.SaveChangesAsync();

            return RedirectToPage("Receipt");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int cartItemId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var cartItemToRemove = await _context.Carts.FindAsync(cartItemId);
            

            if (cartItemToRemove != null && cartItemToRemove.UserId == userId)
            {
                if (cartItemToRemove.Quantity > 1)
                {
                    cartItemToRemove.Quantity--;
                }
                else
                {
                    _context.Carts.Remove(cartItemToRemove);
                }
                    
                await _context.SaveChangesAsync();
            }

           
            return RedirectToPage("Checkout");
        }
    }
}
