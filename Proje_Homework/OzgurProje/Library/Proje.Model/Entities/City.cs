using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class City : CoreEntity
    {
        public int CityCode { get; set; }
        public string CityName { get; set; }
       
    }
}
