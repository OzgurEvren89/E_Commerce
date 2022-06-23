using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.PaymentGateway;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.InstallmentRate
{
    public class InstallmentRateResponse : BaseDto
    {      
        public int Installment { get; set; }      
        public decimal Rate { get; set; }
        public Guid PaymentGatewayId { get; set; }
        public PaymentGatewayResponse PaymentGateway { get; set; }       
        public DateTime? CreatedDate { get; set; }
    }
}
