using Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proje.Web.UI.Areas.Admin.Models.OptionGroupViewModels
{
    public class CreateOptionGroupViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage = "Sıralama alanı zorunludur.")]
        public int SortOrder { get; set; }
    }
}
