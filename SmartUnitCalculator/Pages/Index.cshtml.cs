using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartUnitCalculator.Database;
using SmartUnitCalculator.Database.Models;
using SmartUnitCalculator.Helpers;
using SmartUnitCalculator.Models;

namespace SmartUnitCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;
        private decimal? _baseValue;
        private decimal? _resultValue;

        public CalculatorLists Lists { get; set; }

        public string ResultValue => 
            _resultValue is null ? "NaN" :  ((decimal)_resultValue).ToString("G29");

        [BindProperty(SupportsGet = true)]
        public string? Type { get; set; }

        [BindProperty]
        public CalculatorInput Input { get; set; }

        public IndexModel(DatabaseContext context)
        {
            _context = context;
            Lists = new();
            Input = new();
        }

        public void OnGet()
        {
            InitializeTypeIfEmpty();
            GetUnitTypes();
            GetLastHistory();
            ConvertInputValueToNumber();
            CalculateResultValue();
            GetUnitsSelectLists();
        }

        private void InitializeTypeIfEmpty()
        {
            if (string.IsNullOrWhiteSpace(Type))
                Type = _context.UnitTypes!
                    .OrderBy(ut => ut.Priority)
                    .FirstOrDefault()?.Name;
        }

        private void GetUnitTypes() =>
            Lists.UnitTypes = _context.UnitTypes!
                .OrderBy(ut => ut.Priority);

        private void GetLastHistory() =>
            Lists.History = _context.History!
                .Where(h => h.User != null && h.User.Login == User.Identity.Name)
                .OrderByDescending(h => h.Created)
                .Take(5)
                .Select(h => h.ToStringValue());

        private void ConvertInputValueToNumber()
        {
            if (string.IsNullOrWhiteSpace(Input.BaseValue))
                _baseValue = null;
            else
            {
                decimal.TryParse(Input.BaseValue, out decimal result);
                _baseValue = result;
            }
        }

        private void CalculateResultValue()
        {
            Calculation calc = _context.Calculations!.FirstOrDefault(c =>
                c.BaseUnitId == Input.BaseUnitId && 
                c.ResultUnitId == Input.ResultUnitId);
            if (_baseValue is not null && calc is not null && calc.Multiplier is not null)
                _resultValue = CalculatAndValidateResultValue(calc);
            else
                _resultValue = _baseValue;
        }

        private decimal? CalculatAndValidateResultValue(Calculation calc)
        {
            try
            {
                decimal result = (decimal)_baseValue * (decimal)calc.Multiplier;
                if (result < -99999999999999.99999999999999m ||
                    result > 99999999999999.99999999999999m)
                    throw new Exception("Wartość poza zakresem.");
                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }

        private void GetUnitsSelectLists()
        {
            IEnumerable<Unit> allUnits = _context.Units!.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(Type))
                allUnits = allUnits.Where(u => u.TypeName == Type);
            if (allUnits.Count() < 2)
                throw new Exception("Za mała liczba jednostek do wyświetlenia.");
            Lists.BaseUnits = new(allUnits, nameof(Unit.Id), nameof(Unit.Name));
            Lists.ResultUnits = new(allUnits, nameof(Unit.Id), nameof(Unit.Name));
            if (allUnits.Any(au => au.Id != Input.BaseUnitId))
            {
                Input.BaseUnitId = allUnits.Last().Id;
                Input.ResultUnitId = allUnits.First().Id;
            }
        }

        public IActionResult OnPost()
        {
            GetUnitTypes();
            GetLastHistory();
            ConvertInputValueToNumber();
            CalculateResultValue();
            SaveCalculationifValid();
            GetUnitsSelectLists();
            return Page();
        }

        private void SaveCalculationifValid()
        {
            if (_baseValue is null || _resultValue is null)
                return;
            History his = new()
            {
                BaseUnitId = Input.BaseUnitId,
                ResultUnitId = Input.ResultUnitId,
                BaseValue = (decimal)_baseValue,
                ResultValue = (decimal)_resultValue
            };
            User user = _context.Users!.FirstOrDefault(u => u.Login == User.Identity.Name);
            if (user is not null)
                his.User = user;
            _context.History!.Add(his);
            _context.SaveChanges();
        }
    }
}