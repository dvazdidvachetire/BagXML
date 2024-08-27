using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Data.SQLite;

namespace BagXML.DAL.Repositories.Implementations
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Create(OrderEntity entity, IDbTransaction? dbTransaction = null)
        {
            try
            {
                var insertQuery = $@"insert into `order`(no, reg_date, sum, userId) values(@{nameof(entity.No)}, @{nameof(entity.Reg_Date)}, @{nameof(entity.Sum)}, @{nameof(entity.UserId)}) returning id";

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
