using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaLogisticsSystem.Models.Common;

namespace BaLogisticsSystem.Models
{
    [Table("Persons")]
    public class PersonEntity : AuditableEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdPerson{ get; set; }
        [Display(Name = "Vartotojo vardas")]
        public string UserName { get; set; }
        [Display(Name = "El. paštas")]
        public string Email { get; set; }
        [Display(Name = "Vardas")]
        public string Name { get; set; }
        [Display(Name = "Pavardė")]
        public string LastName { get; set; }
        [Display(Name = "Gimimo data")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Mobilusis tel. nr.")]
        public string MobilePhone { get; set; }
        [Display(Name = "Adresas")]
        public string Address { get; set; }
        [Display(Name = "Organizacija")]
        public Guid IdOrganization { get; set; }

        public bool IsBlocked { get; set; }
    }
}
