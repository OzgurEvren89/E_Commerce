using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.OrderItem
{
    public class OrderItemRequest : BaseDto
    {
        public string ProductName { get; set; }
        public decimal ProductWeight { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }


    }
}
