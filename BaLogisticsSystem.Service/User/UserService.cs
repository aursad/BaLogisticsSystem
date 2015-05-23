using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository;
using BaLogisticsSystem.Repository.Common;
using BaLogisticsSystem.Repository.User;
using BaLogisticsSystem.Service.Common;

namespace BaLogisticsSystem.Service.User
{
    public class UserService : EntityService<UserProfileEntity>, IUserService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
            : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public UserProfileEntity GetSingle(int userId)
        {
            return _userRepository.GetSingle(userId);
        }
        
        public UserProfileEntity GetSingle(string email)
        {
            return _userRepository.GetSingle(email);
        }
    }
}
