using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUnitCalculator.Database;
using SmartUnitCalculator.Database.Models;
using SmartUnitCalculator.Helpers;
using SmartUnitCalculator.Models;
using System.Security.Claims;

namespace SmartUnitCalculator.Pages
{
    public class LogInModel : PageModel
    {
        private readonly DatabaseContext _context;

        public string Information { get; set; }

        [BindProperty]
        public LoginInput Login { get; set; }

        public LogInModel(DatabaseContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            string hash = Hasher.Hash(Login.Password);
            User userDB = _context.Users!.FirstOrDefault(u => 
                u.Login == Login.Login && u.Password == hash);
            if (userDB is null)
            {
                Information = "Incorrect login or password.";
                return Page();
            }
            List<Claim> claims = new()
                {
                    new(ClaimTypes.Name, userDB.Login)
                };
            ClaimsIdentity identity = new(claims, "SMC_Cookie");
            ClaimsPrincipal claimsPrincipal = new(identity);
            await HttpContext.SignInAsync("SMC_Cookie", claimsPrincipal);
            return RedirectToPage("/User");
        }
    }
}
