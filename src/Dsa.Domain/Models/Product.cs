using Dsa.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Domain.Models
{
    public class Product : Entity<long>
    {
        public string Name { get; set; }

        public string UniqueCode { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int Inventory { get; set; }

        public decimal SalePrice { get; set; }

        public decimal? MarketPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTime? SpecialPriceStart { get; set; }

        public DateTime? SpecialPriceEnd { get; set; }

        public bool IsPublished { get; set; }

    }
}
