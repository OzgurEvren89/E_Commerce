using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.InstallmentRate;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.PaymentGateway
{
    public class PaymentGatewayResponse : BaseDto
    {
        public PaymentGatewayResponse()
        {
            InstallmentRates = new HashSet<InstallmentRateResponse>();

        }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<InstallmentRateResponse> InstallmentRates { get; set; }

    }
}
