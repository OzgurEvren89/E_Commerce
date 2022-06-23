using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class OptionToProduct : CoreEntity
    {

        public Guid ParentProductId { get; set; }
        public Guid OptionGroupId { get; set; }
        public OptionGroup OptionGroup { get; set; }
        public Guid OptionId { get; set; }
        public Options Option { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public User CreatedUserOptionToProduct { get; set; }
        public User ModifiedUserOptionToProduct { get; set; }


    }
}
