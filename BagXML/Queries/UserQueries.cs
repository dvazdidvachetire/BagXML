using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using BagXML.Models;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с пользователями</summary>
    public sealed class UserQueries : Queries<User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserQueries(IUserRepository userRepository, IMapper mapper)
        {
            (_userRepository, _mapper) = (userRepository, mapper);
        }

        public override int Create(User model)
        {
            return _userRepository.Create(_mapper.Map<UserEntity>(model));
        }
    }
}
