using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.Payment
{
    public class PaymentRequest : BaseDto
    {
        [Required]
        public string UserFirstname { get; set; }
        [Required]
        public string UserSurname { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }       
        public string PaymentTypeName { get; set; }  //ödeme tipi (Kredi Kartı, Hediye Çeki İle öde, Üye Puanı ile öde vb. ) 
        [Required]
        public string PaymentGatewayName { get; set; } // Banka Adı seçecek Payment Getewaydan viewBagda getireceğiz
        [Required]
        public string PaymentGatewayCode { get; set; }
        [Required]
        public decimal FinalAmount { get; set; }
        [Required]
        public decimal SumOfGainedPoints { get; set; }//kazanılan puan fiyata göre ayarlanacak müşteri girmeyecek
        [Required]
        public int Installment { get; set; }//taksit sayısı 
        [Required]
        public int InstallmentRate { get; set; } // taksit oranı
        [Required]
        public string Currency { get; set; } 
        public string UserNote { get; set; }
        public Guid PaymentStatusId { get; set; }
    }
}
