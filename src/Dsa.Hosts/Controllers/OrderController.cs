using Dsa.Application.Interfaces;
using Dsa.Application.ViewModels.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dsa.Hosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateOrderInput input)
        {
            await _orderAppService.CreateAsync(input);
            return Ok();
        }

        [HttpPost(nameof(Cancel))]
        public async Task<IActionResult> Cancel([FromBody] CancelOrderInput input)
        {
            await _orderAppService.CancelAsync(input);
            return Ok();
        }

        [HttpGet("Detail/{id}")]
        public async Task<OrderDto> GetDetail(long id)
        {
            return await _orderAppService.GetDetailAsync(id);
        }
    }
}
