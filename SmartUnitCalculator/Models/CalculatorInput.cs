using System.ComponentModel.DataAnnotations;

namespace SmartUnitCalculator.Models
{
    public class CalculatorInput
    {
        public int BaseUnitId { get; set; }
        public int ResultUnitId { get; set; }
        [Required]
        [StringLength(29)]
        public string BaseValue { get; set; }
    }
}
