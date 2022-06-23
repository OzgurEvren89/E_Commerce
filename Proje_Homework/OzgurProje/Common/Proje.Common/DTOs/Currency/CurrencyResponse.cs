using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Currency
{
    public class CurrencyResponse : BaseDto
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }   
        public DateTime? CreatedDate { get; set; }
    }
}
