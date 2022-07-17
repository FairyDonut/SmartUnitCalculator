namespace SmartUnitCalculator.Database.Models;
public class UnitType
{
    public string? Name { get; set; }
    public int Priority { get; set; }

    public override string ToString()
        => Name;
}
