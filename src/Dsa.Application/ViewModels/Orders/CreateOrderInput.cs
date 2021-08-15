using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Application.ViewModels.Orders
{
    public class CreateOrderInput
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
