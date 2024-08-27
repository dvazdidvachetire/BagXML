using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Implementations;
using BagXML.DAL.UnitOfWork;
using BagXML.Models;
using System.Data;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с продуктами</summary>
    public sealed class ProductQueries : Queries<Product>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductQueries(UnitOfWork unitOfWork, IMapper mapper)
        {
            (_unitOfWork, _mapper) = (unitOfWork, mapper);    
        }

        public override int Create(Product model, IDbTransaction? dbTransaction = null)
            => _unitOfWork.GetRepository(new ProductRepository(_unitOfWork.DBConnection))
                          .Create(_mapper.Map<ProductEntity>(model), dbTransaction);
    }
}
