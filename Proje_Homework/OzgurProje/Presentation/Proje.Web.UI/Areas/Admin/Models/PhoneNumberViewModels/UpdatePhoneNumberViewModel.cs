using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.PhoneNumberViewModels
{
    public class UpdatePhoneNumberViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Telefon numarası alanı zorunludur.")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Telefon numarası tipi alanı zorunludur.")]
        public string PhoneNumberType { get; set; }
        [Required(ErrorMessage = "Kullanıcı alanı zorunludur.")]
        public Guid UserId { get; set; }

    }
}
