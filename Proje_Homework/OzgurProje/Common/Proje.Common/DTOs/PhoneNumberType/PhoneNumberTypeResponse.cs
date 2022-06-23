using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.PhoneNumberType
{
    public class PhoneNumberTypeResponse : BaseDto
    {
        public string Name { get; set; }       
        public DateTime? CreatedDate { get; set; }
    }
}
