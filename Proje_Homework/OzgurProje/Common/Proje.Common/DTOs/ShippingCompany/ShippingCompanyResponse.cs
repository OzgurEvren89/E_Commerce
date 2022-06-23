using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.ShippingCompany
{
    public class ShippingCompanyResponse : BaseDto
    {
        public string Name { get; set; }
        public decimal ExtraPrice { get; set; }
        public decimal ExtraVolumetricWeightPrice { get; set; }
        public decimal FreeShipmentOrderPrice { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
