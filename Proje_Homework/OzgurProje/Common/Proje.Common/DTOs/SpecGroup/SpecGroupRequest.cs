using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.SpecGroup
{
    public class SpecGroupRequest : BaseDto
    {
        [Required]
        public string SpecGroupName { get; set; }
        public int ShortOrder { get; set; }
    }
}
