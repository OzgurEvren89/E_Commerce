using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.AddressTypeViewModels
{
    public class AddressTypeViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string TypeName { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
