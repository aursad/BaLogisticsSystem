using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.Person
{
    public class PersonsRepository : GenericRepository<PersonEntity>, IPersonsRepository
    {
        public PersonsRepository(DbContext context)
            : base(context)
        {
        }

        public PersonEntity GetSingle(Guid userId)
        {
            return Dbset.FirstOrDefault(x => x.IdPerson == userId);
        }

        public PersonEntity GetSingle(string email)
        {
            var personEntity = Dbset.FirstOrDefault(q => q.UserName.ToLower().Equals(email.ToLower()));
            return personEntity;
        }


        public IEnumerable<PersonEntity> PersonsInOrganization(Guid idOrganization)
        {
            var personsEntities = Dbset.Where(q => q.IdOrganization == idOrganization).ToList();
            return personsEntities;
        }
    }
}
