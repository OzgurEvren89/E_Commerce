using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.City
{
    public class CityRequest : BaseDto
    {
        [Required]
        public int CityCode { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
