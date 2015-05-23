using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.Service.Organizations
{
    public interface IOrganizationService
    {
        OrganizationEntity GetSingle(Guid idOrganization);
        IEnumerable<OrganizationEntity> GetList();
        void CreateOrganization(OrganizationEntity personEntity);
    }
}
