using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CartViewModels
{
    public class UpdateCartViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
