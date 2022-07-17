using System.ComponentModel.DataAnnotations;

namespace SmartUnitCalculator.Models
{
    public class LoginInput
    {
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
