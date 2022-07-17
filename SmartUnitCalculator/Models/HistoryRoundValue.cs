using SmartUnitCalculator.Database.Models;

namespace SmartUnitCalculator.Models
{
    public class HistoryStringValue
    {
        public int Id { get; set; }
        public int BaseUnitId { get; set; }
        public Unit? BaseUnit { get; set; }
        public string BaseValue { get; set; }
        public int ResultUnitId { get; set; }
        public Unit? ResultUnit { get; set; }
        public string ResultValue { get; set; }
        public DateTime Created { get; set; }
    }
}
