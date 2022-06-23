using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.PhoneNumber
{
    public class PhoneNumberRequest : BaseDto
    {
        public string Number { get; set; }
        public string PhoneNumberType { get; set; }
        public Guid UserId { get; set; }    
    }
}
