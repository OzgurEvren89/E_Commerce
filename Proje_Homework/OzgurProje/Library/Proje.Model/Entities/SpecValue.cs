using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class SpecValue : CoreEntity
    {
        public SpecValue()
        {
            SpecToProducts = new HashSet<SpecToProduct>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }    

        public Guid SpecNameId { get; set; }
        public SpecName SpecName { get; set; }

        public Guid SpecGroupId { get; set; }
        public SpecGroup SpecGroup { get; set; }

        public User CreatedUserSpecValue { get; set; }
        public User ModifiedUserSpecValue { get; set; }

        public ICollection<SpecToProduct> SpecToProducts { get; set; }
    }
}
