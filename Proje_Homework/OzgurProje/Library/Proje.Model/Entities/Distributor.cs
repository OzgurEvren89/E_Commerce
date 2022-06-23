using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class Distributor : CoreEntity
    {
        public Distributor()
        {
            DistributorToProducts = new HashSet<DistributorToProduct>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }   
        public ICollection<DistributorToProduct> DistributorToProducts { get; set; }

    }
}
