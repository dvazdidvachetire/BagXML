using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using BagXML.Models;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с продуктами</summary>
    public sealed class ProductQueries : Queries<Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductQueries(IProductRepository productRepository)
        {
            _productRepository = productRepository;    
        }

        public override int Create(Product model)
        {
            return _productRepository.Create(new ProductEntity
            {
                Name = model.Name,
                Price = decimal.Parse(model.Price.Replace('.', ',')),
                Quantity = int.Parse(model.Quantity)
            });
        }
    }
}
