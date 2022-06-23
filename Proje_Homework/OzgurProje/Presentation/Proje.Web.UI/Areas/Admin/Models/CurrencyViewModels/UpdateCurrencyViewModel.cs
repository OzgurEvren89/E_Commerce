using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CurrencyViewModels
{
    public class UpdateCurrencyViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Kurun Kısa Adı alanı zorunludur.")]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Kurun Uzun Adı alanı zorunludur.")]
        public string LongName { get; set; }
    }
}
