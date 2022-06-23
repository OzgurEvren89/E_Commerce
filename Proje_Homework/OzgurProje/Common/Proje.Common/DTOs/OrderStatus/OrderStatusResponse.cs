using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.OrderStatus
{
    public class OrderStatusResponse : BaseDto
    {
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
