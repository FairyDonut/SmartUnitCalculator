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
    public class RegisterModel : PageModel
    {
        private readonly DatabaseContext _context;

        public string Information{ get; private set; } 

        [BindProperty]
        public RegisterInput Register { get; set; }

        public RegisterModel(DatabaseContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            if (Register.Password != Register.PasswordCheck)
            {
                Information = "Given passwords must be the same.";
                return Page();
            }
            if (_context.Users.Any(u => u.Login == Register.Login))
            {
                Information = $"User with login {Register.Login} alredy exist.";
                return Page();
            }
            CreateUser();
            Login();
            return RedirectToPage("/User");
        }

        private void CreateUser()
        {
            string hash = Hasher.Hash(Register.Password);
            User user = new()
            {
                Login = Register.Login,
                Password = hash
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private async void Login()
        {
            List<Claim> claims = new()
            {
                new(ClaimTypes.Name, Register.Login)
            };
            ClaimsIdentity identity = new(claims, "SMC_Cookie");
            ClaimsPrincipal claimsPrincipal = new(identity);
            await HttpContext.SignInAsync("SMC_Cookie", claimsPrincipal);
        }
    }
}
