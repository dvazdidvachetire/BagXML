using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace BagXML.DAL.Repositories.Implementations
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Create(ProductEntity entity)
        {
            var insertQuery = $@"insert into product(quantity, name, price) values(@{nameof(entity.Quantity)}, @{nameof(entity.Name)}, @{nameof(entity.Price)}) returning id";

            return _dbConnection.QueryFirstOrDefault<int>(insertQuery, entity);
        }
    }
}
