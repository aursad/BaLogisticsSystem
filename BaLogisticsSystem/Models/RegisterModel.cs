using System.ComponentModel.DataAnnotations;

namespace BaLogisticsSystem.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Vartotojo vardas")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Slaptažodį turi sudaryti bent {2} simboliai.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Patvirtinti slaptažodį")]
        [Compare("Password", ErrorMessage = "Slaptažodžiai nesutampa.")]
        public string ConfirmPassword { get; set; }
    }
}