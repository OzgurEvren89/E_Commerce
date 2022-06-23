using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.BrandToCategoryViewModels
{
    public class UpdateBrandToCategoryViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
}
