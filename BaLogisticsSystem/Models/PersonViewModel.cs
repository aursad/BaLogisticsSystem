using System;
using System.ComponentModel.DataAnnotations;

namespace BaLogisticsSystem.Models
{
    public class PersonViewModel
    {
        public Guid IdPerson { get; set; }
        [Display(Name = "Vartotojo vardas")]
        public string UserName { get; set; }
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

        [Display(Name = "Organizacijos pavadinimas")]
        public OrganizationViewModel Organization { get; set; }

        public bool IsBlocked { get; set; }
    }
}