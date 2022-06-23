using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CountyViewModels
{
    public class CountyViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
        public int CityCode { get; set; }       
        public DateTime? CreatedDate { get; set; }
    }
}
