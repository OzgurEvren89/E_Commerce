using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.City
{
    public class CityResponse : BaseDto
    {
        public int CityCode { get; set; }
        public string CityName { get; set; }    
        public DateTime? CreatedDate { get; set; }
    }
}
