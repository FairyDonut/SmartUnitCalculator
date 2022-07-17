using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartUnitCalculator.Database;
using SmartUnitCalculator.Database.Models;
using SmartUnitCalculator.Helpers;
using SmartUnitCalculator.Models;

namespace SmartUnitCalculator.Pages.Shared
{
    [Authorize]
    public class UserModel : PageModel
    {
        private readonly DatabaseContext _context;
        private List<History> _allHistory;
        private float _historyRowsCount;

        public StatisiticLists Statistics { get; set; }

        public UserModel(DatabaseContext context)
        {
            _context = context;
            Statistics = new();
        }

        public void OnGetAsync()
        {
            GetAllHistory();
            CalculateRowsCountInHistoryTable();
            GetUserHistory();
            GetAllUsersUnitsSearch();
            GetLoginUserUnitTypesSearch();
        }

        private void GetAllHistory() =>
            _allHistory = _context.History!
            .Include(h => h.User)
            .Include(h => h.BaseUnit)
            .Include(h => h.ResultUnit)
            .Include(h => h.ResultUnit.Type)
            .ToList();

        private void CalculateRowsCountInHistoryTable() =>
            _historyRowsCount = _allHistory.Count();

        private void GetUserHistory()
        {
            Statistics.History = _allHistory
                .Where(h => h.User != null && h.User.Login == User.Identity.Name)
                .OrderByDescending(h => h.Created)
                .Select(h => h.ToStringValue()).ToList();
        }

        private void GetAllUsersUnitsSearch()
        {
            Statistics.AllUsersUnitTypesSearch = _allHistory
                .Where(h => h.ResultUnit is not null)
                .GroupBy(h => h.ResultUnit.Type)
                .ToDictionary(g => g.Key, g => Math.Round(g.Count() * 100 / _historyRowsCount, 2));
        }

        private void GetLoginUserUnitTypesSearch()
        {
            Statistics.LoginUserUnitTypesSearch = _allHistory
                .Where(h => h.ResultUnit != null && 
                h.User != null && h.User.Login == User.Identity.Name)
                .GroupBy(h => h.ResultUnit.Type)
                .ToDictionary(g => g.Key, g => Math.Round(g.Count() * 100 / _historyRowsCount, 2));
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync("SMC_Cookie");
            return RedirectToPage("/Index");
        }
    }
}
