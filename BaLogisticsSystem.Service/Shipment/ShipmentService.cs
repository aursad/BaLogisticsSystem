using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;
using BaLogisticsSystem.Repository.Service;
using BaLogisticsSystem.Repository.Shipment;
using BaLogisticsSystem.Service.Common;

namespace BaLogisticsSystem.Service.Shipment
{
    public class ShipmentService : EntityService<ShipmentEntity>, IShipmentService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IUnitOfWork unitOfWork, IShipmentRepository shipmentRepository)
            : base(unitOfWork, shipmentRepository)
        {
            _unitOfWork = unitOfWork;
            _shipmentRepository = shipmentRepository;
        }

        public ShipmentEntity GetSingle(Guid userId)
        {
            return _shipmentRepository.GetSingle(userId);
        }

        public IEnumerable<ShipmentEntity> GetList()
        {
            return _shipmentRepository.GetAll();
        }

        public ShipmentEntity CreateShipment(ShipmentEntity entity)
        {
            entity.IdShipment = Guid.NewGuid();
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            _shipmentRepository.Add(entity);

            return entity;
        }

        public IEnumerable<ShipmentEntity> GetServicesByService(Guid idService)
        {
            return _shipmentRepository.GetServicesByService(idService);
        }

        public override void Update(ShipmentEntity shipmentEntity)
        {
            shipmentEntity.UpdatedDate = DateTime.Now;
            _shipmentRepository.Update(shipmentEntity);
        }
    }
}
