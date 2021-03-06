using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CurrencyViewModels
{
    public class CurrencyViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }        
        public DateTime? CreatedDate { get; set; }
    }
}
