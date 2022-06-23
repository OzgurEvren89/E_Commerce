using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class SpecToProduct : CoreEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid SpecGroupId { get; set; }
        public SpecGroup SpecGroup { get; set; }
        public Guid SpecNameId { get; set; }
        public SpecName SpecName { get; set; }
        public Guid SpecValueId { get; set; }
        public SpecValue SpecValue { get; set; }
        public User CreatedUserSpecToProduct { get; set; }
        public User ModifiedUserSpecToProduct { get; set; }

    }
}
