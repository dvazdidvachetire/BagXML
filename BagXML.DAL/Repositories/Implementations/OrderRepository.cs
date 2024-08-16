using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using System.Data;

namespace BagXML.DAL.Repositories.Implementations
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Create(Order entity)
        {
            
        }
    }
}
