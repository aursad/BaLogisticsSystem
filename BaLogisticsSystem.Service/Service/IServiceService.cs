using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.Service.Service
{
    public interface IServiceService
    {
        ServiceEntity GetSingle(Guid idService);
        IEnumerable<ServiceEntity> GetList();
        void CreateService(ServiceEntity entity);

        IEnumerable<ServiceEntity> GetServicesByOrganization(Guid idOrganization);
    }
}
