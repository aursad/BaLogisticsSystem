using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;
using BaLogisticsSystem.Repository.Service;
using BaLogisticsSystem.Service.Common;

namespace BaLogisticsSystem.Service.Service
{
    public class ServiceService : EntityService<ServiceEntity>, IServiceService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IServiceRepository _serviceRepository;

        public ServiceService(IUnitOfWork unitOfWork, IServiceRepository serviceRepository)
            : base(unitOfWork, serviceRepository)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
        }

        public ServiceEntity GetSingle(Guid userId)
        {
            return _serviceRepository.GetSingle(userId);
        }

        public IEnumerable<ServiceEntity> GetList()
        {
            return _serviceRepository.GetAll();
        }

        public void CreateService(ServiceEntity entity)
        {
            entity.IdOrganization = Guid.NewGuid();
            entity.IdService = Guid.NewGuid();
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            _serviceRepository.Add(entity);
            _serviceRepository.Save();
        }


        public IEnumerable<ServiceEntity> GetServicesByOrganization(Guid idOrganization)
        {
            return _serviceRepository.GetServicesByOrganization(idOrganization);
        }
    }
}
