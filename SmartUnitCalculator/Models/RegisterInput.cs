using System.ComponentModel.DataAnnotations;

namespace SmartUnitCalculator.Models
{
    public class RegisterInput : LoginInput
    {
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string PasswordCheck { get; set; }
    }
}
