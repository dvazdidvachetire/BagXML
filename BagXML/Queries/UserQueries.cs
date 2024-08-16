using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using BagXML.Models;

namespace BagXML.Queries
{
    public sealed class UserQueries : Queries<User>
    {
        private readonly IUserRepository _userRepository;

        public UserQueries(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override int Create(User model)
        {
            return _userRepository.Create(new UserEntity
            {
                Email = model.Email,
                FIO = model.FIO
            });
        }
    }
}
