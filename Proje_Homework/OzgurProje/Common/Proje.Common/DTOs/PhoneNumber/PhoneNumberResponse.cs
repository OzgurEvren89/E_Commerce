using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.PhoneNumber
{
    public class PhoneNumberResponse : BaseDto
    {
        public string Number { get; set; }
        public string PhoneNumberType { get; set; }      
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
