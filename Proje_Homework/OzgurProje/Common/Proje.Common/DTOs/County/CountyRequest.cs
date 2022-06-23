using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.County
{
    public class CountyRequest : BaseDto
    {
        [Required]
        public int CountyCode { get; set; }
        [Required]
        public string CountyName { get; set; }
        [Required]
        public int CityCode { get; set; }//var olan şehirlerimi çekip seçtireceğim.
    }
}
