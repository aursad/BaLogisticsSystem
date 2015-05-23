using System;
using System.Data.Entity;
using System.Linq;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Organization
{
    public class OrganizationRepository : GenericRepository<OrganizationEntity>, IOrganizationRepository
    {
        public OrganizationRepository(DbContext context)
            : base(context)
        {
        }

        public OrganizationEntity GetSingle(Guid idOrganization)
        {
            return Dbset.FirstOrDefault(x => x.IdOrganization == idOrganization);
        }
    }
}
