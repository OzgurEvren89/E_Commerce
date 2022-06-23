using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class PaymentGateway : CoreEntity
    {
        public PaymentGateway()
        {
            InstallmentRates = new HashSet<InstallmentRate>();
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public User CreatedUserPaymentGateway { get; set; }
        public User ModifiedUserPaymentGateway { get; set; }
        public ICollection<InstallmentRate> InstallmentRates { get; set; }
    }
}
