using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using BagXML.Models;

namespace BagXML.Queries
{
    public sealed class ProductOrderQueries : Queries<ProductOrder>
    {
        private readonly IProductOrderRepository _repository;

        public ProductOrderQueries(IProductOrderRepository repository)
        {
            _repository = repository;
        }

        public override int Create(ProductOrder model)
        {
            return _repository.Create(new ProductOrderEntity 
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId
            });
        }
    }
}
