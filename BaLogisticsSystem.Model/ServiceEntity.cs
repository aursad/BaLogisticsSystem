using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaLogisticsSystem.Models.Common;

namespace BaLogisticsSystem.Models
{
    [Table("Services")]
    public class ServiceEntity : AuditableEntity<int>
    {
        [Key]
        public Guid IdService { get; set; }
        public string Title { get; set; }

        public Guid IdOrganization { get; set; }
    }
}
