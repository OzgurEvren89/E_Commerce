using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.PaymentTypeViewModels
{
    public class CreatePaymentTypeViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ödeme Tipi Adı alanı zorunludur.")]
        public string Name { get; set; }
    }
}
