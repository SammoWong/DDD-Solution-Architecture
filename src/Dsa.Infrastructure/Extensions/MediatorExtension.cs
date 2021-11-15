using Dsa.Domain.Core.Models;
using Dsa.Infrastructure.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsa.Domain.Core.Interfaces;

namespace Dsa.Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublishDomainEventsAsync(this IMediator mediator, DsaContext context)
        {
            
        }
    }
}
