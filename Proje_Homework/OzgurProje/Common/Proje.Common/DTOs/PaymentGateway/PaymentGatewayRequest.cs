using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.PaymentGateway
{
    public class PaymentGatewayRequest : BaseDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
