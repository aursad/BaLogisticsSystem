using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaLogisticsSystem.Models.Common;

namespace BaLogisticsSystem.Models
{
    [Table("Organizations")]
    public class OrganizationEntity : AuditableEntity<int>
    {
        [Key]
        public Guid IdOrganization { get; set; }
        [Display(Name = "Pavadinimas")]
        public string Name { get; set; }
        [Display(Name = "Adresas")]
        public string Address { get; set; }
        [Display(Name = "Organizacijos tipas")]
        public int OrganizationType { get; set; }

        public bool IsActive { get; set; }
    }
}
