using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class InstallmentRate : CoreEntity
    {
        public int Installment { get; set; }
        public decimal Rate { get; set; }
        public Guid PaymentGatewayId { get; set; }
        public PaymentGateway PaymentGateway { get; set; }
       
    }
}
