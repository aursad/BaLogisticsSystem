using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Person
{
    public interface IPersonsRepository : IGenericRepository<PersonEntity>
    {
        PersonEntity GetSingle(Guid userId);
        PersonEntity GetSingle(string email);
        IEnumerable<PersonEntity> PersonsInOrganization(Guid idOrganization);
    }
}
