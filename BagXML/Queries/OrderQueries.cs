using AutoMapper;
using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using BagXML.Models;

namespace BagXML.Queries
{
    /// <summary>представляет запросы к бд к таблице с заказами</summary>
    public sealed class OrderQueries : Queries<Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ProductQueries _productQueries;
        private readonly UserQueries _userQueries;
        private readonly ProductOrderQueries _productOrderQueries;
        private readonly IMapper _mapper;

        public OrderQueries(IOrderRepository orderRepository, 
                            ProductQueries productQueries, 
                            UserQueries userQueries,
                            ProductOrderQueries productOrderQueries,
                            IMapper mapper)
        {
            (_orderRepository, _productQueries, _userQueries, _productOrderQueries, _mapper) 
            = (orderRepository, productQueries, userQueries, productOrderQueries, mapper);
        }

        public override int Create(Order model)
        {
            var productId = 0;
            var userId = _userQueries.Create(model.User);
            var orderId = _orderRepository.Create(new OrderEntity
            {
                No = int.Parse(model.No),
                Reg_Date = model.Reg_Date,
                Sum = double.Parse(model.Sum.Replace('.', ',')),
                UserId = userId,
            });

            foreach (var product in model.Products)
            {
                productId = _productQueries.Create(_mapper.Map<Product>(product));

                _productOrderQueries.Create(new ProductOrder 
                {
                    OrderId = orderId,
                    ProductId = productId
                });
            }

            return orderId;
        }
    }
}
