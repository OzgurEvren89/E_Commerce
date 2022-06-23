using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class SpecName : CoreEntity
    {
        public SpecName()
        {
            SpecValues = new HashSet<SpecValue>();
            SpecToProducts = new HashSet<SpecToProduct>();

        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ShortOrder { get; set; }
        public Guid SpecGroupId { get; set; }
        public SpecGroup SpecGroup { get; set; }
        public User CreatedUserSpecName { get; set; }
        public User ModifiedUserSpecName { get; set; }

        public ICollection<SpecValue> SpecValues { get; set; }
        public ICollection<SpecToProduct> SpecToProducts { get; set; }

    }
}
