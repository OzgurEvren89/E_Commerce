using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OrderViewModels
{
    public class UpdateOrderViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Müşteri Adı alanı zorunludur.")]
        public string CustomerFirstname { get; set; }
        [Required(ErrorMessage = "Müşteri Soyadı alanı zorunludur.")]
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "Ödeme tipi alanı zorunludur.")]
        public string PaymentTypeName { get; set; }
        [Required(ErrorMessage = "Ödeme kanalı alanı zorunludur.")]
        public string PaymentGatewayName { get; set; }
        [Required(ErrorMessage = "Ödeme Kanalı Kodu alanı zorunludur.")]
        public string PaymentGatewayCode { get; set; }
        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Sipariş durumu alanı zorunludur.")]
        public string OrderStatus { get; set; }
        public string ErrorMessage { get; set; }
        public string GiftNote { get; set; }
        public string ShippingCompanyName { get; set; }
        public string ShippingTrackingCode { get; set; }
        public Guid? ShippingAddressId { get; set; }
        public Guid? BillingAddressId { get; set; }
    }
}
