using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.SpecName
{
    public class SpecNameRequest : BaseDto
    {
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required]
        public int ShortOrder { get; set; }
        public Guid SpecGroupId { get; set; }
    }
}
