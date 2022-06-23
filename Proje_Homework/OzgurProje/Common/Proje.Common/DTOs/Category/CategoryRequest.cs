using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Category
{
    public class CategoryRequest : BaseDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
