using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.PaymentStatus;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Payment
{
    public class PaymentResponse : BaseDto
    {
        public string UserFirstname { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string PaymentTypeName { get; set; }  //ödeme tipi (Kredi Kartı, Hediye Çeki İle öde, Üye Puanı ile öde vb. ) 
        public string PaymentGatewayName { get; set; } // Banka Adı
        public string PaymentGatewayCode { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal SumOfGainedPoints { get; set; }
        public int Installment { get; set; }//taksit sayısı
        public decimal InstallmentRate { get; set; } // taksit oranı
        public string Currency { get; set; }
        public string UserNote { get; set; }
        public Guid? PaymentStatusId { get; set; }
        public PaymentStatusResponse PaymentStatus { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
