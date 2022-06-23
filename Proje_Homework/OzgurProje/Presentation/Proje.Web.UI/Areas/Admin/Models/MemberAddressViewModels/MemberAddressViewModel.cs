using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.MemberAddressViewModels
{
    public class MemberAddressViewModel
    {
        public MemberAddressViewModel()
        {
            ShippingAddressOrders = new HashSet<OrderViewModel>();
            BillingAddressOrders = new HashSet<OrderViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
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
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<OrderViewModel> ShippingAddressOrders { get; set; }
        public ICollection<OrderViewModel> BillingAddressOrders { get; set; }
    }
}
