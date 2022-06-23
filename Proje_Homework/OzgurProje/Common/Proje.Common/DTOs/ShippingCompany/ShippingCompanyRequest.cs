using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.ShippingCompany
{
    public class ShippingCompanyRequest : BaseDto
    {
        public string Name { get; set; }
        public decimal ExtraPrice { get; set; }
        public decimal ExtraVolumetricWeightPrice { get; set; }
        public decimal FreeShipmentOrderPrice { get; set; }
    }
}
