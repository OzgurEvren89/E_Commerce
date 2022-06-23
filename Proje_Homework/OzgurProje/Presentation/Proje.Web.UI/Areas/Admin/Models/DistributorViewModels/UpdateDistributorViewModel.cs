using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.DistributorViewModels
{
    public class UpdateDistributorViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Distribütör Adı alanı zorunludur.")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Distribütör Telefonu alanı zorunludur.")]
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
    }
}
