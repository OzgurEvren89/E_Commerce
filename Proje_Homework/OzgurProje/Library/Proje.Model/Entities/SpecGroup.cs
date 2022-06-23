using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class SpecGroup : CoreEntity
    {
        public SpecGroup()
        {
            SpecNames = new HashSet<SpecName>();
            SpecValues = new HashSet<SpecValue>();
            SpecToProducts = new HashSet<SpecToProduct>();
        }

        public string SpecGroupName { get; set; }
        public int ShortOrder { get; set; }
        public User CreatedUserSpecGroup { get; set; }
        public User ModifiedUserSpecGroup { get; set; }
        public ICollection<SpecName> SpecNames { get; set; }
        public ICollection<SpecValue> SpecValues { get; set; }
        public ICollection<SpecToProduct> SpecToProducts { get; set; }

    }
}
