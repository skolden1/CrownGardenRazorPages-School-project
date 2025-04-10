using Azure;
using CrownGardenRazor.Areas.Identity.Data;
using CrownGardenRazor.Datas;
using CrownGardenRazor.Model;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Claims;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace CrownGardenRazor.Pages
{
    public class ProductModel : PageModel
    {
        private readonly AppDbContext _context;
        //private readonly IdentityUserContext _identityUserContext;

        public ProductModel(AppDbContext context)
        {
            _context = context;

        }
        public List<Product> productList { get; set; } = new List<Product>();
        public string SearchWord { get; set; }
        
        public string ErrorMessage { get; set; }
        public bool Under300 { get; set; }
        public bool Over300Under800 { get; set; }
        public bool Over800Under2500 { get; set; }
        public bool Over2500 { get; set; }
        public string Category { get; set; }
        public bool Over300 { get; set; }
        public string AddToCartMsg { get; set; }

        public async Task<IActionResult> OnGetAsync(string SearchWord, string Category, bool Under300, bool Over300Under800, bool Over800Under2500, bool Over2500)
        {

            if (!await _context.Products.AnyAsync())
            {
                productList = new List<Product>
                {
                    //golfboll prod
                    new Product { ProductName = "Titleist - Pro v1", Description = "Här är det optimala valet för de flesta golfspelare och är även den mest spelade bollmodellen inom golf. Denna nyhet leverera ännu mer längd och bättre resultat, den flyger lägre och kan även spinna mindre i det långa spelet. Samtidigt ger den liknande spinn kring greenen och en mjukare känsla."
                    , Price = 599, ImageUrl = "product3.png" ,Quantity = 50, CategoryId = 1, CreatedDate = DateTime.Now.ToString()},
                    new Product { ProductName = "Wilson - Tour Velocity Women", Description = "Detta är ett utmärkt val av golfboll för dig som vill uppnå långa avstånd från tee till green. Dessa golfbollar har ett unikt hårt skal som är utformat för att generera en bra bollbana, distans samt rullning oavsett om du slår från pegg eller gräs. Deras dimplemönster är optimerat för aerodynamisk bollflykt både vid utslagen och approachslagen.", Price = 199, ImageUrl = "product4.png",  Quantity = 50, CategoryId = 1, CreatedDate = DateTime.Now.ToString()},
                    new Product { ProductName = "Wilson - Duo Soft Trk360", Description = "Wilson Duo Soft TRK360 är en 2-delad boll som Wilson själva benämner som ”Världens mjukaste golfboll”. Duo Soft har en mjuk träffkänsla både på långa slag och när du puttar och passar optimalt för spelare med en måttlig svinghastighet. Kompression: 37. Bollen har ett tydligt sikthjälpmedel som hjälper dig att linjera upp bollen enklare på greenerna.", Price = 349, ImageUrl = "product5.png", Quantity = 50, CategoryId = 1, CreatedDate = DateTime.Now.ToString()},

                    //golfbag
                    new Product { ProductName = "Lyle & Scott", Description = "Detta är en smidig och bekväm bärbag med dubbla axelremmar för jämn viktfördelning och extra stöd. Den har en 3-delad fullängdsavdelare som rymmer upp till 8 klubbor, vilket gör den perfekt för kortare rundor eller träning. En isolerad kylficka håller drycker kalla, medan en velourfodrad ficka skyddar värdesaker. Med sitt stabila och infällbara ställ får bagen ett säkert grepp på alla underlag.", Price = 2199, ImageUrl = "product2.png", Quantity = 50, CategoryId = 5, CreatedDate = DateTime.Now.ToString()},
                    new Product { ProductName = "Pemfold Heritage Sunday Bag Blå", Description = "Stig in i historien på golfbanan med Heritage Sunday Bag från Penfold. I över 60 år har Penfold skapat Sunday Bags med endast de finaste materialen.", Price = 2999, ImageUrl = "product1.png", Quantity = 50, CategoryId = 5, CreatedDate = DateTime.Now.ToString()},

                    //handske
                    new Product { ProductName = "FootJoy - Weathersof Men", Description = "Revolutionerande prestanda och slitstyrka har gjort denna till världens mest sålda golfhandske. Exklusivt FiberSof-material ger den mest avancerade kombinationen av konsekvent passform, mjuk känsla och ett säkert grepp. Ny FiberSof MicroTab säkerställer en mjuk känsla och greppprestanda i de mest utsatta områdena. Ett mjukt och ventilerande PowerNet-mesh över handen skapar optimal flexibilitet, ökad komfort och andningsförmåga.", Price = 179, ImageUrl = "product9.png", Quantity = 50, CategoryId = 2, CreatedDate = DateTime.Now.ToString()},

                    //Peg
                    new Product { ProductName = "Tour Tee Pro", Description = "Tour Tee är miljövänliga plastpeggar utvecklade för att generera längre slag med mindre spinn från tee. Enligt egna undersökningar uppges Tour Tee öka din längd med upp till tio meter. Tour Tee Pro innehåller fyra peggar som är 80 mm långa.", Price = 119, ImageUrl = "product14.png", Quantity = 50, CategoryId = 3, CreatedDate = DateTime.Now.ToString()},
                    new Product { ProductName = "Tour Tee Combo", Description = "Tour Tee är miljövänliga plastpeggar utvecklade för att generera längre slag med mindre spinn från tee. Enligt egna undersökningar uppges Tour Tee öka din längd med upp till tio meter. Tour Tee Combo innehåller fem peggar i förpackningen. Tre stycken som är 80 mm långa och två stycken som är 45 mm långa.", Price = 119, ImageUrl = "product15.png", Quantity = 50, CategoryId = 3, CreatedDate = DateTime.Now.ToString()},

                    //Skor
                    new Product { ProductName = "Adidas - S2G SI 24", Description = "Snöra på dig en avslappnad stil som passar lika bra på banan som under grillkvällen. Adidas S2G SL 24 har en löparskoinspirerad design som är lika snygg på greenen som utanför.", Price = 999, ImageUrl = "product19.png", Quantity = 50, CategoryId = 4, CreatedDate = DateTime.Now.ToString()},
                    new Product { ProductName = "Under Armour - Drive Pro Vit", Description = "Under Armour Drive Pro har Swing Support System som ger intelligent grepp, dubbel skumdämpning och låsning med snörning. Nya UA S3-spikar, utvecklade med Softspikes® och en golfbiomekaniker, ger banbrytande riktningsgrepp. Yttersulan har strategiska flexspår, sekundärt grepp och TPU upp på sidan för extra stöd vid påverkan.", Price = 2229, ImageUrl = "product18.png", Quantity = 50, CategoryId = 4, CreatedDate = DateTime.Now.ToString()},

                    //klocka o kikare
                    new Product { ProductName = "Garmin - Approch Z82 Svart", Description = "Garmin Approach Z82 är en golfkikare med GPS. Approach Z82 är Garmins flaggskepp när det kommer till kikare och den är fullmatad med det teknik som underlättar ditt beslutstagande på golfbanan.", Price = 6999, ImageUrl = "product17.png", Quantity = 50, CategoryId = 3, CreatedDate = DateTime.Now.ToString()},
                    new Product { ProductName = "Garmin - Approach S70 Svart", Description = "Den perfekta klockan för dig som vill använda den både på och utanför banan. Med en ljusstark AMOLED-skärm på 1.4 får du tillgång till över 43 000 förinstallerade banor i fullfärg direkt på handleden. Klockan har en lätt och stilren design med en keramisk infattning som ger en elegant och modern känsla. Med dess 47 mm storlek passar den bekvämt på handleden och är lätt att läsa i alla ljusförhållanden.", Price = 7999, ImageUrl = "product20.png", Quantity = 50, CategoryId = 3, CreatedDate = DateTime.Now.ToString()},
                };
                await _context.Products.AddRangeAsync(productList);
                await _context.SaveChangesAsync();
            }

            productList = await _context.Products.Include(p => p.Category).ToListAsync();

            if (!string.IsNullOrWhiteSpace(SearchWord))
            {
                productList = await _context.Products
                    .Include(p => p.Category)
                    .Where(p => p.ProductName.ToLower().Contains(SearchWord.ToLower()) || p.Category.CategoryName.ToLower().Contains(SearchWord.ToLower())).ToListAsync();

            }
            if (Under300)
            {
                productList = productList.Where(p => p.Price <= 300).ToList();
            }
            if (Over300Under800)
            {
                productList = productList.Where(p => p.Price > 300 && p.Price <= 800).ToList();
            }
            if (Over800Under2500)
            {
                productList = productList.Where(p => p.Price > 800 && p.Price <= 2500).ToList();
            }
            if (Over2500)
            {
                productList = productList.Where(p => p.Price > 2500).ToList();
            }

            if (!string.IsNullOrEmpty(Category))
            {
                productList = productList.Where(p => p.Category.CategoryName == Category).ToList();
            }
            if (!productList.Any())
            {
                ErrorMessage = "Produkten du sökte efter kunde ej hittas";
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
            return RedirectToPage();
        }
    }
}
