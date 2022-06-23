using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CurrencyValueViewModels
{
    public class CreateCurrencyValueViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "Kur Id alanı zorunludur.")]
        public Guid CurrencyId { get; set; }
        [Required(ErrorMessage = "Kurun Kısa Adı alanı zorunludur.")]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Kur Tarihi alanı zorunludur.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Kurun  Alış Fiyatı Alanı Zorunludur.")]
        public decimal BuyingPrice { get; set; }
        [Required(ErrorMessage = "Kurun Satış Fiyatı Alanı Zorunludur.")]
        public decimal SalePrice { get; set; }
    }
}
