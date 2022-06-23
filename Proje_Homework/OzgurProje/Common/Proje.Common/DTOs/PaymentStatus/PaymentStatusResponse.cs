using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Payment;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.PaymentStatus
{
    public class PaymentStatusResponse : BaseDto
    {
        public PaymentStatusResponse()
        {
            Payments = new HashSet<PaymentResponse>();
        }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<PaymentResponse> Payments { get; set; }
    }
}
