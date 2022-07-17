using SmartUnitCalculator.Database.Models;

namespace SmartUnitCalculator.Models
{
    public class StatisiticLists
    {
        public List<HistoryStringValue> History { get; set; }
        public Dictionary<UnitType, double> AllUsersUnitTypesSearch { get; set; }
        public Dictionary<UnitType, double> LoginUserUnitTypesSearch { get; set; }
    }
}
