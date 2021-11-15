using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Application.ViewModels.Orders
{
    public class CancelOrderInput
    {
        public long Id { get; set; }

        public string CancelReason { get; set; }
    }
}
