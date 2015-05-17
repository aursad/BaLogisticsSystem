using System.ComponentModel.DataAnnotations;

namespace BaLogisticsSystem.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Vartotojo vardas")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [Display(Name = "Prisiminti mane?")]
        public bool RememberMe { get; set; }
    }
}