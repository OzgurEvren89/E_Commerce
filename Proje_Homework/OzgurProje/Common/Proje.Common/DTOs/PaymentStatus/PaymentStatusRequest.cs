using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.PaymentStatus
{
    public class PaymentStatusRequest : BaseDto
    {
        [Required]
        public string Name { get; set; }
    }
}
