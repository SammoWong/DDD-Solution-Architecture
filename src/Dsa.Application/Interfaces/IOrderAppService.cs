using Dsa.Application.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task CreateAsync(CreateOrderInput input);

        Task CancelAsync(CancelOrderInput input);

        Task<OrderDto> GetDetailAsync(long id);
    }
}
