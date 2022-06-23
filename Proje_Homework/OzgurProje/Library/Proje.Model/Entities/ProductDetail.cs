using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class ProductDetail : CoreEntity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
       
    }
}
