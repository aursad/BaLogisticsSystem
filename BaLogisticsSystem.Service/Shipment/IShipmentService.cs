using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.Service.Shipment
{
    public interface IShipmentService
    {
        ShipmentEntity GetSingle(Guid isShipment);
        IEnumerable<ShipmentEntity> GetList();
        ShipmentEntity CreateShipment(ShipmentEntity entity);

        IEnumerable<ShipmentEntity> GetServicesByService(Guid idService);
    }
}
