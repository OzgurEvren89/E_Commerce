using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.PaymentGatewayViewModels
{
    public class UpdatePaymentGatewayViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ödeme Kanalı Kodunu Girmeniz Zorunludur.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Ödeme Kanalı Adı Alanı Zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ödeme Kanalı  Sırası Alanı Zorunludur.")]
        public int SortOrder { get; set; }
    }
}
