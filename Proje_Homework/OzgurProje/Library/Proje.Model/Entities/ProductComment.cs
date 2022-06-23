using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class ProductComment : CoreEntity
    {
        public string Content { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public User CreatedUserProductComment { get; set; }
        public User ModifiedUserProductComment { get; set; }
    }
}
