using Dsa.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Domain.Models
{
    public class OrderItem : Entity<long>
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal SalePrice { get; set; }

        public decimal? MarketPrice { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
