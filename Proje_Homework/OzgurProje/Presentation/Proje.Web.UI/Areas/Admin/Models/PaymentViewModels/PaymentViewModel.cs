using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.PaymentStatusViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.PaymentViewModels
{
    public class PaymentViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
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
        public Guid PaymentStatusId { get; set; }
        public PaymentStatusViewModel PaymentStatus { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
