using Dsa.Domain.Core.Models;
using System.Collections.Generic;

namespace Dsa.Domain.Models
{
    public class Cart : Entity<long>
    {
        public long CustomerId { get; set; }

        public string Remark { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }
    }
}
