namespace SmartUnitCalculator.Database.Models;
public class Calculation
{
    public int Id { get; set; }
    public int BaseUnitId { get; set; }
    public Unit? BaseUnit { get; set; }
    public int ResultUnitId { get; set; }
    public Unit? ResultUnit { get; set; }
    public decimal? Multiplier { get; set; }
}
