using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Data.SQLite;

namespace BagXML.DAL.Repositories.Implementations
{
    public sealed class ProductOrderRepository : IProductOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductOrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;    
        }

        public int Create(ProductOrderEntity entity)
        {
            using var transaction = _dbConnection.BeginTransaction();

            try
            {
                var insertQuery = $@"insert into product_order(productId, orderId) values(@{nameof(entity.ProductId)}, @{nameof(entity.OrderId)}) returning id";

                var id = _dbConnection.QueryFirstOrDefault<int>(insertQuery, entity, transaction);

                transaction.Commit();

                return id;
            }
            catch (SQLiteException ex)
            {
                Console.Out.WriteLine(ex.Message);

                transaction.Rollback();

                throw;
            }
        }
    }
}
