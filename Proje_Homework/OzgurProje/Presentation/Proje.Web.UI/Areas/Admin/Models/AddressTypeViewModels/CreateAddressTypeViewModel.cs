using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.AddressTypeViewModels
{
    public class CreateAddressTypeViewModel
    {
       
        public Status Status { get; set; }
        [Required(ErrorMessage = "Adres Tipi Adı alanı zorunludur.")]
        public string TypeName { get; set; }

    }
}
