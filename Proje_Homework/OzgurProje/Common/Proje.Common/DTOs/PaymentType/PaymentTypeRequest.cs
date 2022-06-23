using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.PaymentType
{
    public class PaymentTypeRequest : BaseDto
    {
        [Required]
        public string Name { get; set; }

    }
}
