using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class MemberAddress : CoreEntity
    {
        public MemberAddress()
        {
            ShippingAddresses = new HashSet<Order>();
            BillingAddresses = new HashSet<Order>();
        }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string TCLD { get; set; }
        public string TaxNumber { get; set; }//iş yeri adresleri için
        public string TaxOffice { get; set; }
        public string AddressName { get; set; }
        public Guid AddressTypeId { get; set; }
        public int CityCode { get; set; }
        public int CountyCode { get; set; }
        public string Address { get; set; }
        public User CreatedUserMemberAddress { get; set; }
        public User ModifiedUserMemberAddress { get; set; }
        public ICollection<Order> ShippingAddresses { get; set; }
        public ICollection<Order> BillingAddresses { get; set; }
    }
}
