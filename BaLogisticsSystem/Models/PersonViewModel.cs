using System;
using System.ComponentModel.DataAnnotations;

namespace BaLogisticsSystem.Models
{
    public class PersonViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "El. paštas")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Vardas")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pavardė")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Gimimo data")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Tel. nr")]
        [DataType(DataType.Text)]
        public string MobilePhone { get; set; }

        [Display(Name = "Adresas")]
        public string Address { get; set; }
    }
}