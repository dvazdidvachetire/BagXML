using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using Dapper;
using System.Data;

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
            var insertQuery = $@"insert into product_order(productId, orderId) values(@{nameof(entity.ProductId)}, @{nameof(entity.OrderId)}) returning id";

            return _dbConnection.QueryFirstOrDefault<int>(insertQuery, entity);
        }
    }
}
