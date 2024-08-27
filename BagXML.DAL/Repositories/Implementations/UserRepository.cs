using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Data.SQLite;

namespace BagXML.DAL.Repositories.Implementations
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Create(UserEntity entity, IDbTransaction? dbTransaction = null)
        {
            try
            {
                var insertQuery = $@"insert into user(fio, email) values(@{nameof(entity.FIO)}, @{nameof(entity.Email)}) returning id";

                var id = _dbConnection.QueryFirstOrDefault<int>(insertQuery, entity, dbTransaction);

                return id;
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine(ex.Message);

                throw;
            }
        }
    }
}
