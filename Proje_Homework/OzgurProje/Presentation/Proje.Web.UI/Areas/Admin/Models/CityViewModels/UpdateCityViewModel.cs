using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CityViewModels
{
    public class UpdateCityViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Sehir Kodu alanı zorunludur.")]
        public int CityCode { get; set; }
        [Required(ErrorMessage = "Şehir Adı alanı zorunludur.")]
        public string CityName { get; set; }
    }
}
