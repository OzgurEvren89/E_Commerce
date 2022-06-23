using Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proje.Web.UI.Areas.Admin.Models.DemandStatusViewModels
{
    public class CreateDemandStatusViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "İptal Talebi Statüsü Adı alanı zorunludur.")]
        public string Name { get; set; }
    }
}
