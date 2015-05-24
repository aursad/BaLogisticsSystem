using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaLogisticsSystem.Models.Common;

namespace BaLogisticsSystem.Models
{
    [Table("Transactions")]
    public class TransactionEntity : AuditableEntity<int>
    {
        [Key]
        public Guid IdTransaction { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Status { get; set; }

        //-- Responsible now person
        public Guid? IdPerson { get; set; }
        public Guid IdShipment { get; set; }
    }
}
