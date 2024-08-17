using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using BagXML.Models;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с продуктами-заказами</summary>
    public sealed class ProductOrderQueries : Queries<ProductOrder>
    {
        private readonly IProductOrderRepository _repository;
        private readonly IMapper _mapper;

        public ProductOrderQueries(IProductOrderRepository repository, IMapper mapper)
        {
            (_repository, _mapper) = (repository, mapper);
        }

        public override int Create(ProductOrder model)
        {
            return _repository.Create(_mapper.Map<ProductOrderEntity>(model));
        }
    }
}
