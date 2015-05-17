using System;
using System.Data.Entity;
using System.Linq;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository
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
            return Dbset.FirstOrDefault(x => email != null && String.Equals(x.Email, email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
