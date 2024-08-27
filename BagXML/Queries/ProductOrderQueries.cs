using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Implementations;
using BagXML.DAL.UnitOfWork;
using BagXML.Models;
using System.Data;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с продуктами-заказами</summary>
    public sealed class ProductOrderQueries : Queries<ProductOrder>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductOrderQueries(UnitOfWork unitOfWork, IMapper mapper)
        {
            (_unitOfWork, _mapper) = (unitOfWork, mapper);
        }

        public override int Create(ProductOrder model, IDbTransaction? dbTransaction = null)
            => _unitOfWork.GetRepository(new ProductOrderRepository(_unitOfWork.DBConnection))
                          .Create(_mapper.Map<ProductOrderEntity>(model), dbTransaction);
    }
}
