using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.MemberAddress;
using Proje.Common.DTOs.OrderItem;
using Proje.Common.DTOs.OrderRefundDemand;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Order
{
    public class OrderResponse : BaseDto
    {
        public OrderResponse()
        {
            OrderItems = new HashSet<OrderItemResponse>();
            OrderRefundDemands = new HashSet<OrderRefundDemandResponse>();
        }
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
        public MemberAddressResponse ShippingAddress { get; set; }
        public Guid? BillingAddressId { get; set; }
        public MemberAddressResponse BillingAddress { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<OrderItemResponse> OrderItems { get; set; }
        public ICollection<OrderRefundDemandResponse> OrderRefundDemands { get; set; }

    }
}
