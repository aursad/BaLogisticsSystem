using System;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Organization
{
    public interface IOrganizationRepository : IGenericRepository<OrganizationEntity>
    {
        OrganizationEntity GetSingle(Guid idOrganization);
    }
}
