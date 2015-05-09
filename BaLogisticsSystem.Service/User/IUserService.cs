using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.Service.User
{
    public interface IUserService
    {
        UserProfileEntity GetSingle(int userId);
        UserProfileEntity GetSingle(string email);
    }
}
