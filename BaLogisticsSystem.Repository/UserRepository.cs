using System;
using System.Data.Entity;
using System.Linq;
using BaLogisticsSystem.Repository.Common;
using Models;

namespace BaLogisticsSystem.Repository
{
    public class UserRepository : GenericRepository<UserProfileEntity>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public UserProfileEntity GetSingle(int userId)
        {
            return Dbset.FirstOrDefault(x => x.UserId == userId);
        }

        public UserProfileEntity GetSingle(string email)
        {
            return Dbset.FirstOrDefault(x => x.UserName.ToLower() == email.ToLower());
        }
    }
}
