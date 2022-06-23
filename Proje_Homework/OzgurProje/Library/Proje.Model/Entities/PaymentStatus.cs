using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class PaymentStatus : CoreEntity
    {
        public PaymentStatus()
        {
            Payments = new HashSet<Payment>();
        }
        public string Name { get; set; }        
        public User CreatedUserPaymentStatus { get; set; }
        public User ModifiedUserPaymentStatus { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
