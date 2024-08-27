using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Implementations;
using BagXML.DAL.UnitOfWork;
using BagXML.Models;
using System.Data;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с пользователями</summary>
    public sealed class UserQueries : Queries<User>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserQueries(UnitOfWork unitOfWork, IMapper mapper)
        {
            (_unitOfWork, _mapper) = (unitOfWork, mapper);
        }

        public override int Create(User model, IDbTransaction? dbTransaction = null)
        {
            var id = _unitOfWork.GetRepository(new UserRepository(_unitOfWork.DBConnection))
                                 .Create(_mapper.Map<UserEntity>(model), dbTransaction);

            return id;
        } 
    }
}
