using System.Data.Entity;
using System.Linq;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository.User
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
