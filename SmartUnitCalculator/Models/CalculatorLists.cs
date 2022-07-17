using Microsoft.AspNetCore.Mvc.Rendering;
using SmartUnitCalculator.Database.Models;

namespace SmartUnitCalculator.Models
{
    public class CalculatorLists
    {
        public IEnumerable<UnitType>? UnitTypes { get; set; }
        public SelectList? BaseUnits { get; set; }
        public SelectList? ResultUnits { get; set; }
        public IEnumerable<HistoryStringValue>? History { get; set; }
    }
}
