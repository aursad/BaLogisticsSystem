using System;
using System.ComponentModel.DataAnnotations;

namespace BaLogisticsSystem.Models
{
    public class ShipmentViewModel
    {
        public Guid IdShipment { get; set; }
        public string Title { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Status { get; set; }

        //-- Responsible now person
        public Guid? IdPerson { get; set; }
        public Guid IdService { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdate { get; set; }
    }
}
