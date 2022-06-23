using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels
{
    public class CreateSpecValueViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ürün özelliği değeri adı zorunludur.")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage = "Ürün özelliği değeri  sırası zorunludur.")]
        public int SortOrder { get; set; }
        public Guid SpecNameId { get; set; }
        public Guid SpecGroupId { get; set; }
       
    }
}
