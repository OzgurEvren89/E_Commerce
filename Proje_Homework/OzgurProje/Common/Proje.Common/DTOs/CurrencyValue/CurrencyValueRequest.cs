using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.CurrencyValue
{
    public class CurrencyValueRequest : BaseDto
    {
        [Required]
        public Guid CurrencyId { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal BuyingPrice { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
    }
}
