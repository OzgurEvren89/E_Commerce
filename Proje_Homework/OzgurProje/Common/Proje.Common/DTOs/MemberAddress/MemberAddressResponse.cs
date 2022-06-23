using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Order;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.MemberAddress
{
    public class MemberAddressResponse : BaseDto
    {
        public MemberAddressResponse()
        {
            ShippingAddressOrders = new HashSet<OrderResponse>();
            BillingAddressOrders = new HashSet<OrderResponse>();

        }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string TCLD { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string AddressName { get; set; }
        public Guid AddressTypeId { get; set; }
        public int CityCode { get; set; }
        public int CountyCode { get; set; }
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<OrderResponse> ShippingAddressOrders { get; set; }
        public ICollection<OrderResponse> BillingAddressOrders { get; set; }
    }
}
