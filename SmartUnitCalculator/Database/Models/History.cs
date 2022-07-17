namespace SmartUnitCalculator.Database.Models;
public class History
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public int BaseUnitId { get; set; }
    public Unit? BaseUnit { get; set; }
    public decimal BaseValue { get; set; }
    public int ResultUnitId { get; set; }
    public Unit? ResultUnit { get; set; }
    public decimal ResultValue { get; set; }
    public DateTime Created { get; set; }
}
