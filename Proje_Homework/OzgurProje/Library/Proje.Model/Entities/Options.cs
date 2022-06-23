using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class Options : CoreEntity
    {
        public Options()
        {
            OptionToProducts = new HashSet<OptionToProduct>();
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Guid OptionGroupId { get; set; }
        public OptionGroup OptionGroup { get; set; }
        public User CreatedUserOptions { get; set; }
        public User ModifiedUserOptions { get; set; }

        public ICollection<OptionToProduct> OptionToProducts { get; set; }

    }
}
