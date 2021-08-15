using AutoMapper;
using Dsa.Application.Interfaces;
using Dsa.Application.ViewModels.Orders;
using Dsa.Domain.Core.Interfaces;
using Dsa.Domain.Models;
using Dsa.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Application.Services
{
    /// <summary>
    /// 应用服务：用例，服务编排
    /// </summary>
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderAppService(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateOrderInput input)
        {
            var customerId = default(long);
            await _orderService.CreateAsync(customerId, input.ProductId, input.Quantity);
            //发送短信/邮件通知
        }

        public async Task CancelAsync(CancelOrderInput input)
        {
            await _orderService.CancelAsync(input.Id, input.CancelReason);
        }

        public async Task<OrderDto> GetDetailAsync(long id)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(a => a.Id == id);
            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }
}
