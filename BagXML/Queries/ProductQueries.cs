using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using BagXML.Models;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с продуктами</summary>
    public sealed class ProductQueries : Queries<Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductQueries(IProductRepository productRepository, IMapper mapper)
        {
            (_productRepository, _mapper) = (productRepository, mapper);    
        }

        public override int Create(Product model)
        {
            return _productRepository.Create(_mapper.Map<ProductEntity>(model));
        }
    }
}
