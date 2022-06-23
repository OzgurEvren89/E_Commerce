using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Order;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.OrderRefundDemand
{
    public class OrderRefundDemandResponse : BaseDto
    {
        public string Reason { get; set; }
        public string Details { get; set; }
        public string ResultStatus { get; set; }
        public decimal Fee { get; set; }
        public Guid OrderId { get; set; }
        public OrderResponse Order { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
