using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class OptionGroup : CoreEntity
    {
        public OptionGroup()
        {
            Options = new HashSet<Options>();
            OptionToProducts = new HashSet<OptionToProduct>();
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public User CreatedUserOptionGroup { get; set; }
        public User ModifiedUserOptionGroup { get; set; }
        public ICollection<Options> Options { get; set; }
        public ICollection<OptionToProduct> OptionToProducts { get; set; }


    }
}
