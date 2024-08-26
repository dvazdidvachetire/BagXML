using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Data.SQLite;

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
            using var transaction = _dbConnection.BeginTransaction();

            try
            {
                var insertQuery = $@"insert into product(quantity, name, price) values(@{nameof(entity.Quantity)}, @{nameof(entity.Name)}, @{nameof(entity.Price)}) returning id";

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
