using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Options
{
    public class OptionsRequest : BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Guid OptionGroupId { get; set; }
      
    }
}
