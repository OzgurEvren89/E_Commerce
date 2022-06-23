using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.AddressType
{
    public class AddressTypeRequest : BaseDto
    {
        [Required]
        public string TypeName { get; set; }
    }
}
