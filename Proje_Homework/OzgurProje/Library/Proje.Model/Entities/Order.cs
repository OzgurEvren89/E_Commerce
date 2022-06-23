using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderRefundDemands = new HashSet<OrderRefundDemand>();
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
        public MemberAddress ShippingAddress { get; set; }
        public Guid? BillingAddressId { get; set; }
        public MemberAddress BillingAddress { get; set; }    
        public User CreatedUserOrder { get; set; }
        public User ModifiedUserOrder { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<OrderRefundDemand> OrderRefundDemands { get; set; }

    }
}
