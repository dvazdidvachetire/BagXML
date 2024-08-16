using BagXML.DAL.Entities;
using BagXML.DAL.Repositories.Interfaces;
using BagXML.Models;

namespace BagXML.Queries
{
    public sealed class OrderQueries : Queries<Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ProductQueries _productQueries;
        private readonly UserQueries _userQueries;
        private readonly ProductOrderQueries _productOrderQueries;

        public OrderQueries(IOrderRepository orderRepository, 
                            ProductQueries productQueries, 
                            UserQueries userQueries,
                            ProductOrderQueries productOrderQueries)
        {
            (_orderRepository, _productQueries, _userQueries, _productOrderQueries) 
            = (orderRepository, productQueries, userQueries, productOrderQueries);
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
                productId = _productQueries.Create(new Product 
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity
                });

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
