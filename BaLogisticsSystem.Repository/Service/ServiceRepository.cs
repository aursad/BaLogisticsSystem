using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Service
{
    public class ServiceRepository : GenericRepository<ServiceEntity>, IServiceRepository
    {
        public ServiceRepository(DbContext context)
            : base(context)
        {
        }

        public ServiceEntity GetSingle(Guid idService)
        {
            return Dbset.FirstOrDefault(x => x.IdService == idService);
        }


        public IEnumerable<ServiceEntity> GetServicesByOrganization(Guid idOrganization)
        {
            return Dbset.Where(x => x.IdOrganization == idOrganization);
        }
    }
}
