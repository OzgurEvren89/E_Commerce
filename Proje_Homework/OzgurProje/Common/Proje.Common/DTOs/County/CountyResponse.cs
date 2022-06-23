using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.County
{
    public class CountyResponse : BaseDto
    {
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
        public int CityCode { get; set; }      
        public DateTime? CreatedDate { get; set; }
    }
}
