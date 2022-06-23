using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.OrderRefundDemand
{
    public class OrderRefundDemandRequest : BaseDto
    {
        public string Reason { get; set; }
        public string Details { get; set; }
        public string ResultStatus { get; set; }
        public decimal Fee { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
    }
}
