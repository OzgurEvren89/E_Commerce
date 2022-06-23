using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.InstallmentRate
{
    public class InstallmentRateRequest : BaseDto
    {
        [Required]
        public int Installment { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public Guid PaymentGatewayId { get; set; }      
        public DateTime? CreatedDate { get; set; }
    }
}
