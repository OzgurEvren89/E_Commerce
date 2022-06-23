using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.DemandReasonViewModels
{
    public class DemandReasonViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Reason { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
