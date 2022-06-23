using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OptionsViewModels
{
    public class UpdateOptionsViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage = "Sıralama alanı zorunludur.")]
        public int SortOrder { get; set; }
        public Guid OptionGroupId { get; set; }
    }
}
