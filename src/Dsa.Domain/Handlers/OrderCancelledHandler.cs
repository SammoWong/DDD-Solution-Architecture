using Dsa.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dsa.Domain.Handlers
{
    public class OrderCancelledHandler : INotificationHandler<OrderCancelledEvent>
    {
        public Task Handle(OrderCancelledEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
