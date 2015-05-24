using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Shipment
{
    public interface IShipmentRepository : IGenericRepository<ShipmentEntity>
    {
        ShipmentEntity GetSingle(Guid idShipment);
        IEnumerable<ShipmentEntity> GetServicesByService(Guid idService);
    }
}
