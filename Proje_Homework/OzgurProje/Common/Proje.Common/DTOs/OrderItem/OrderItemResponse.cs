using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Order;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;

namespace Proje.Common.DTOs.OrderItem
{
    public class OrderItemResponse : BaseDto
    {
        public string ProductName { get; set; }
        public decimal ProductWeight { get; set; }
        public Guid OrderId { get; set; }
        public OrderResponse Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductResponse Product { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
