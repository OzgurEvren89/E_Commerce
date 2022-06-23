using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.InstallmentRateViewModels
{
    public class CreateInstallmentRateViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "Taksit Sayısını Girmeniz Gerekmaktedir..")]
        public int Installment { get; set; }
        [Required(ErrorMessage = "Taksit Oranını Girmeniz Gerekmaktedir..")]
        public decimal Rate { get; set; }
        public Guid PaymentGatewayId { get; set; }
    
    }
}
