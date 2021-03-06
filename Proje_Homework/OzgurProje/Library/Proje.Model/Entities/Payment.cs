using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class Payment : CoreEntity
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
        public PaymentStatus PaymentStatus { get; set; }
        public User CreatedUserPayment { get; set; }
        public User ModifiedUserPayment { get; set; }


    }
}
