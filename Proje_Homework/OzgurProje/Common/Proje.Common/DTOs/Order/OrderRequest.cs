using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Order
{
    public class OrderRequest : BaseDto
    {
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
        public Guid? BillingAddressId { get; set; }

    }
}
