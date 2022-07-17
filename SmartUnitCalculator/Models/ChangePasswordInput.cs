using System.ComponentModel.DataAnnotations;

namespace SmartUnitCalculator.Models
{
    public class ChangePasswordInput
    {
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string PasswordCheck { get; set; }
    }
}
