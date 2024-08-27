using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Implementations;
using BagXML.DAL.UnitOfWork;
using BagXML.Models;
using System.Data;
using System.Data.SQLite;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с заказами</summary>
    public sealed class OrderQueries : Queries<Order>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductQueries _productQueries;
        private readonly UserQueries _userQueries;
        private readonly ProductOrderQueries _productOrderQueries;
        private readonly IMapper _mapper;

        public OrderQueries(UnitOfWork unitOfWork, 
                            ProductQueries productQueries, 
                            UserQueries userQueries,
                            ProductOrderQueries productOrderQueries,
                            IMapper mapper)
        {
            (_unitOfWork, _productQueries, _userQueries, _productOrderQueries, _mapper) 
            = (unitOfWork, productQueries, userQueries, productOrderQueries, mapper);
        }

        public override int Create(Order model, IDbTransaction? dbTransaction = null)
        {
            dbTransaction = _unitOfWork.DBConnection.BeginTransaction();

            try
            {
                var productId = 0;
                var userId = _userQueries.Create(model.User, dbTransaction);
                var orderRepo = _unitOfWork.GetRepository(new OrderRepository(_unitOfWork.DBConnection));
                var orderId = orderRepo.Create(new OrderEntity
                {
                    No = int.Parse(model.No),
                    Reg_Date = model.Reg_Date,
                    Sum = double.Parse(model.Sum.Replace('.', ',')),
                    UserId = userId,
                }, dbTransaction);

                foreach (var product in model.Products)
                {
                    productId = _productQueries.Create(_mapper.Map<Product>(product), dbTransaction);

                    _productOrderQueries.Create(new ProductOrder
                    {
                        OrderId = orderId,
                        ProductId = productId
                    }, dbTransaction);
                }

                dbTransaction.Commit();

                return orderId;
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine(ex.Message);

                dbTransaction.Rollback();

                throw;
            }
        }
    }
}
