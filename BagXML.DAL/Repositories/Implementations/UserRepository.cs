using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace BagXML.DAL.Repositories.Implementations
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Create(UserEntity entity)
        {
            var insertQuery = $@"insert into user(fio, email) values(@{nameof(entity.FIO)}, @{nameof(entity.Email)}) returning id";

            return _dbConnection.QueryFirstOrDefault<int>(insertQuery, entity);
        }
    }
}
