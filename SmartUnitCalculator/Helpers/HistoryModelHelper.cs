using SmartUnitCalculator.Database.Models;
using SmartUnitCalculator.Models;

namespace SmartUnitCalculator.Helpers
{
    public static class HistoryModelHelper
    {
        public static HistoryStringValue ToStringValue(this History row) =>
            new()
            {
                Id = row.Id,
                BaseUnitId = row.BaseUnitId,
                BaseUnit = row.BaseUnit,
                BaseValue = row.BaseValue.ToString("G29"),
                ResultUnitId = row.ResultUnitId,
                ResultUnit = row.ResultUnit,
                ResultValue = row.ResultValue.ToString("G29"),
                Created = row.Created
            };
    }
}
