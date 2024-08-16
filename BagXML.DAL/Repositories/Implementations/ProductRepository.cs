using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
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

        public void Create(Product entity)
        {
            
        }
    }
}
