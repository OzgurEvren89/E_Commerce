using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class Currency : CoreEntity
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
     
    }
}
