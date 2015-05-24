using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Shipment
{
    public class ShipmentRepository : GenericRepository<ShipmentEntity>, IShipmentRepository
    {
        public ShipmentRepository(DbContext context)
            : base(context)
        {
        }

        public ShipmentEntity GetSingle(Guid idService)
        {
            return Dbset.FirstOrDefault(x => x.IdService == idService);
        }

        public IEnumerable<ShipmentEntity> GetServicesByService(Guid idService)
        {
            return Dbset.Where(x => x.IdService == idService);
        }
    }
}
