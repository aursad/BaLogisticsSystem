using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaLogisticsSystem.Models
{
    public class OrganizationViewModel
    {
        public Guid IdOrganization { get; set; }
        [Required]
        [Display(Name = "Pavadinimas")]
        public string Name { get; set; }

        [Display(Name = "Adresas")]
        public string Address { get; set; }

        [Display(Name = "Organizacijos tipas")]
        public int OrganizationType { get; set; }
        public bool IsActive { get; set; }
    }

    public class OrganizationFullViewModel : OrganizationViewModel
    {
       public IEnumerable<PersonEntity> Persons { get; set; }
       public IEnumerable<ServiceEntity> Services { get; set; } 
    }
}