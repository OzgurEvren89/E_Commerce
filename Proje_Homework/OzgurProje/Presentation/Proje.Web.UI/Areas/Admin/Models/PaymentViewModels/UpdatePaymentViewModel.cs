using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.PaymentViewModels
{
    public class UpdatePaymentViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Adınızı Girmeniz Gerekmaktedir..")]
        public string UserFirstname { get; set; }
        [Required(ErrorMessage = "Soyadınızı Girmeniz Gerekmaktedir..")]
        public string UserSurname { get; set; }
        [Required(ErrorMessage = "Email Adresinizi Girmeniz Gerekmaktedir..")]
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        [Required(ErrorMessage = "Ödeme Şeklinizi Seçmeniz Gerekmaktedir..")]
        public string PaymentTypeName { get; set; }  //ödeme tipi (Kredi Kartı, Hediye Çeki İle öde, Üye Puanı ile öde vb. ) 
        [Required(ErrorMessage = "Ödeme Kanal Adını Seçmeniz Gerekmaktedir..")]
        public string PaymentGatewayName { get; set; } // Banka Adı
        public string PaymentGatewayCode { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal SumOfGainedPoints { get; set; }
        public int Installment { get; set; }//taksit sayısı
        public decimal InstallmentRate { get; set; } // taksit oranı
        public string Currency { get; set; }
        public string UserNote { get; set; }
        public Guid PaymentStatusId { get; set; }

    }
}
