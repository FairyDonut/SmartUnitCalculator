using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUnitCalculator.Database;
using SmartUnitCalculator.Database.Models;
using SmartUnitCalculator.Helpers;
using SmartUnitCalculator.Models;

namespace SmartUnitCalculator.Pages
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        private readonly DatabaseContext _context;

        public string Information { get; private set; }

        [BindProperty]
        public ChangePasswordInput ChangePassword { get; set; }

        public ChangePasswordModel(DatabaseContext context)
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
            if (ChangePassword.Password != ChangePassword.PasswordCheck)
            {
                Information = "Given passwords must be the same.";
                return Page();
            }
            bool valid = ChangePasswordInDB();
            if (!valid)
                return Page();
            return RedirectToPage("/User");
        }

        private bool ChangePasswordInDB()
        {
            User user = _context.Users
                .FirstOrDefault(u => u.Login == User.Identity.Name);
            if (user is null)
            {
                Information = "Missing user in database.";
                return false;
            }
            string hash = Hasher.Hash(ChangePassword.Password);
            user.Password = hash;
            _context.SaveChanges();
            return true;
        }
    }
}
