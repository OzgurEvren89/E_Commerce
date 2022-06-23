using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.OptionGroup
{
    public class OptionGroupRequest : BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
    }
}
