using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Repository
{
    public interface IUserRepository : IGenericRepository<UserProfileEntity>
    {
        UserProfileEntity GetSingle(int userId);
        UserProfileEntity GetSingle(string email);
    }
}
