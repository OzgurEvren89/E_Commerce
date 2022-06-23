using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class BrandToCategory : CoreEntity
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public User CreatedUserBrandToCategory { get; set; }
        public User ModifiedUserBrandToCategory { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }

    }
}
