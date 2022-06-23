using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels
{
    public class CreateSpecToProductViewModel
    {
        public Status Status { get; set; }
        public Guid ProductId { get; set; }
        public Guid SpecGroupId { get; set; }
        public Guid SpecNameId { get; set; }
        public Guid SpecValueId { get; set; }
    }
}
