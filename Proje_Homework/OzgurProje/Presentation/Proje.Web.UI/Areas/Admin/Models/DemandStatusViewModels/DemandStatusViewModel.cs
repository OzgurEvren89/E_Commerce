using Proje.Common.Enums;
using System;

namespace Proje.Web.UI.Areas.Admin.Models.DemandStatusViewModels
{
    public class DemandStatusViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
