using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class ShippingCompany : CoreEntity
    {
        public string Name { get; set; }
        public decimal ExtraPrice { get; set; }//kargo firması sabit ücreti
        public decimal ExtraVolumetricWeightPrice { get; set; }//kilo üzerinden anlaşırsa buraya onu girecek.
        public decimal FreeShipmentOrderPrice { get; set; }//Hangi fiyattan sonra ücretsiz kargo olacağını belirleyeck admin, isterse değiştirir.
        public User CreatedUserShippingCompany { get; set; }
        public User ModifiedUserShippingCompany { get; set; }
    }
}
