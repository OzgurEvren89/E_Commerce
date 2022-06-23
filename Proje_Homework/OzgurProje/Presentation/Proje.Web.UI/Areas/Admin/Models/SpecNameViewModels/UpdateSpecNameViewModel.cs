using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels
{
    public class UpdateSpecNameViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ürün özelliği adı hanesi zorunludur.")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage = "Ürün özelliği adı sırası zorunludur.")]
        public int ShortOrder { get; set; }
        public Guid SpecGroupId { get; set; }
    }
}
