using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaLogisticsSystem.Models
{
    public class ServiceViewModel
    {
        public Guid IdService { get; set; }
        [Required]
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Display(Name = "Organizacija")]
        public Guid IdOrganization { get; set; }
        public OrganizationViewModel Organization { get; set; }
        public IEnumerable<ShipmentViewModel> Shipments { get; set; } 
    }
}