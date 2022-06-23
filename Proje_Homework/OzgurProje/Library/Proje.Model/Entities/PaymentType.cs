using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class PaymentType : CoreEntity
    {
        public string Name { get; set; }
        public User CreatedUserPaymentType { get; set; }
        public User ModifiedUserPaymentType { get; set; }
    }
}
