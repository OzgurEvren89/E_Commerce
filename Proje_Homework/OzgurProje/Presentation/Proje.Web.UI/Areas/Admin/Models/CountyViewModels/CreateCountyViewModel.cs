using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CountyViewModels
{
    public class CreateCountyViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "İlçe kodu alanı zorunludur.")]
        public int CountyCode { get; set; }
        [Required(ErrorMessage = "Şehir adı alanı zorunludur.")]
        public string CountyName { get; set; }
        [Required(ErrorMessage = "Şehir kodu alanı zorunludur.")]
        public int CityCode { get; set; }
    }
}
