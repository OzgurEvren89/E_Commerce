using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.DemandStatusViewModels
{
    public class UpdateDemandStatusViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "İptal Talebi Statüsü Adı alanı zorunludur.")]
        public string Name { get; set; }
    }
}
