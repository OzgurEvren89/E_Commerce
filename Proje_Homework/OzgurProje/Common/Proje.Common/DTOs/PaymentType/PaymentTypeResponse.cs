using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.PaymentType
{
    public class PaymentTypeResponse : BaseDto
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
