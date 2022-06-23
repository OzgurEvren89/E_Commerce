using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels
{
    public class UpdateSpecGroupViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Özellik grubu adı  zorunludur.")]
        public string SpecGroupName { get; set; }        
        [Required(ErrorMessage = "Özellik grubu sırası  zorunludur.")]
        public int ShortOrder { get; set; }
    }
}
