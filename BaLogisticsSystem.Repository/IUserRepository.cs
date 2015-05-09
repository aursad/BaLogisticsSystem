using System;
using BaLogisticsSystem.Repository.Common;
using Models;

namespace BaLogisticsSystem.Repository
{
    public interface IUserRepository : IGenericRepository<UserProfileEntity>
    {
        UserProfileEntity GetSingle(int userId);
        UserProfileEntity GetSingle(string email);
    }
}
