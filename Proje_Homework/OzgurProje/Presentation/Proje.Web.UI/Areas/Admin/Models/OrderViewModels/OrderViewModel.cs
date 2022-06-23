using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.MemberAddressViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderRefundDemandViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OrderViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderItems = new HashSet<OrderItemViewModel>();
            OrderRefundDemands = new HashSet<OrderRefundDemandViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string CustomerFirstname { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string PaymentTypeName { get; set; }
        public string PaymentGatewayName { get; set; }
        public string PaymentGatewayCode { get; set; }
        public decimal Amount { get; set; }
        public string OrderStatus { get; set; }
        public string ErrorMessage { get; set; }
        public string GiftNote { get; set; }
        public string ShippingCompanyName { get; set; }
        public string ShippingTrackingCode { get; set; }
        public Guid? ShippingAddressId { get; set; }
        public MemberAddressViewModel ShippingAddress { get; set; }
        public Guid? BillingAddressId { get; set; }
        public MemberAddressViewModel BillingAddress { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<OrderItemViewModel> OrderItems { get; set; }
        public ICollection<OrderRefundDemandViewModel> OrderRefundDemands { get; set; }


    }
}
