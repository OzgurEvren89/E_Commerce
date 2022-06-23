using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.PhoneNumberTypeViewModels
{
    public class CreatePhoneNumberTypeViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "Telefon numarası tipi alanı zorunludur.")]
        public string Name { get; set; }
    }
}
