using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.Service.Persons
{
    public interface IPersonsService
    {
        PersonEntity GetSingle(Guid userId);
        PersonEntity GetSingle(string email);
        IEnumerable<PersonEntity> GetList();
        IEnumerable<PersonEntity> PersonsInOrganization(Guid idOrganization);
        void CreatePerson(PersonEntity personEntity);
        bool BlockUser(Guid idPerson);
    }
}
