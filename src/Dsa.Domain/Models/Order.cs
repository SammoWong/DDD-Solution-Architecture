using Dsa.Domain.Core.Models;
using Dsa.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Domain.Models
{
    public class Order : Entity<long>
    {
        private Order() { }

        public Order(long customerId)
        {
            No = DateTime.Now.ToString("yyyyMMddHHmmss");
            CustomerId = customerId;
            OrderStatus = OrderStatus.Unpaid;
            CreatedTime = DateTime.Now;
        }

        public string No { get; set; }

        public long CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaymentAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public DateTime? PaymentTime { get; set; }

        /// <summary>
        /// 发货地址
        /// </summary>
        public Address ShippingAddress { get; set; }

        public string CancelReason { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

        public void AddOrderItem(OrderItem item)
        {
            if (Items == null)
            {
                Items = new List<OrderItem>();
            }
            item.Order = this;
            TotalAmount += item.SalePrice * item.Quantity;
            PaymentAmount += item.SalePrice * item.Quantity;
            Items.Add(item);
        }

        public void Cancel(string cancelReason)
        {
            OrderStatus = OrderStatus.Cancelled;
            CancelReason = cancelReason;
        }

        public void Pay(PaymentMethod PaymentMethod, decimal paymentAmount)
        {
            if (OrderStatus == OrderStatus.Unpaid)
            {
                PaymentAmount += paymentAmount;
                if(PaymentAmount >= TotalAmount)
                {
                    OrderStatus = OrderStatus.Paid;
                    PaymentTime = DateTime.Now;
                }
            }
        }
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 未付款
        /// </summary>
        Unpaid = 1,

        /// <summary>
        /// 已付款
        /// </summary>
        Paid = 2,

        /// <summary>
        /// 已完成
        /// </summary>
        Completed = 4,

        /// <summary>
        /// 已取消
        /// </summary>
        Cancelled = 8,
    }

    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        Alipay = 0,
        /// <summary>
        /// 微信
        /// </summary>
        WeChat = 1
    }
}
