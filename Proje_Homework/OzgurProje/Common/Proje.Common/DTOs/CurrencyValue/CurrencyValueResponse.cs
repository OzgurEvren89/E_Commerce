using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.CurrencyValue
{
    public class CurrencyValueResponse : BaseDto
    {
        public Guid CurrencyId { get; set; }
        public string ShortName { get; set; }
        public DateTime Date { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SalePrice { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
