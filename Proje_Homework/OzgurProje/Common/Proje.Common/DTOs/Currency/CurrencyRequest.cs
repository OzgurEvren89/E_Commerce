using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.Currency
{
    public class CurrencyRequest : BaseDto
    {
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string LongName { get; set; }
    }
}
