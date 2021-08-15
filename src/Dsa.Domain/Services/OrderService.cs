using Dsa.Domain.Core.Interfaces;
using Dsa.Domain.Events;
using Dsa.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Domain.Services
{
    public interface IOrderService
    {
        Task CreateAsync(long customerId, long productId, int quantity);

        Task CancelAsync(long id, string cancelReason);
    }

    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IMediator _mediator;

        public OrderService(IRepository<Order> orderRepository, IRepository<Product> productRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public async Task CreateAsync(long customerId, long productId, int quantity)
        {
            var product = await _productRepository.FirstOrDefaultAsync(a => a.Id == productId);
            var order = new Order(customerId);
            order.AddOrderItem(new OrderItem
            {
                Product = product,
                Quantity = quantity,
                ProductName = product.Name,
                SalePrice = product.SalePrice,
                MarketPrice = product.MarketPrice,
                Order = order,
            });
            await _orderRepository.InsertAsync(order);

            //中介者模式：扣减库存，添加订单历史等后续动作（解耦，异步）
            await _mediator.Publish(new OrderCreatedEvent());
        }

        public async Task CancelAsync(long id, string cancelReason)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(a => a.Id == id);
            order.Cancel(cancelReason);
            await _orderRepository.UpdateAsync(order);

            //取消订单后续操作
            await _mediator.Publish(new OrderCancelledEvent());
        }
    }
}
