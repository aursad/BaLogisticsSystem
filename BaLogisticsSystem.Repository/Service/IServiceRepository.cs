using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Service
{
    public interface IServiceRepository : IGenericRepository<ServiceEntity>
    {
        ServiceEntity GetSingle(Guid idService);
        IEnumerable<ServiceEntity> GetServicesByOrganization(Guid idOrganization);
    }
}
