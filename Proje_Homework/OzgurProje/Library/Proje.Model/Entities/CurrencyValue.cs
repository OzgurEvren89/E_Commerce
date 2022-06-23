using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class CurrencyValue : CoreEntity
    {
        public Guid CurrencyId { get; set; }
        public string ShortName { get; set; }
        public DateTime Date { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SalePrice { get; set; }
        public User CreatedUserCurrencyValue { get; set; }
        public User ModifiedUserCurrencyValue { get; set; }
    }
}
