using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class County : CoreEntity
    {
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
        public int CityCode { get; set; }     
    }
}
