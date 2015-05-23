using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaLogisticsSystem.Models.Common;

namespace BaLogisticsSystem.Models
{
    [Table("ServiceItems")]
    public class ServiceItemEntity : AuditableEntity<int>
    {
        [Key]
        public Guid IdServiceItem { get; set; }
        public string Title { get; set; }
        public bool Latitude { get; set; }
        public bool Longitude { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Status { get; set; }

        //-- Responsible now person
        public Guid? IdPerson { get; set; }
        public Guid IdService { get; set; }
    }
}