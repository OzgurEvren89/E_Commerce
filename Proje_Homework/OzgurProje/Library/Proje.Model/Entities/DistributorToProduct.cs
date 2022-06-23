using Proje.Core.Entity;
using System;


namespace Proje.Model.Entities
{
    public class DistributorToProduct : CoreEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid DistributorId { get; set; }
        public Distributor Distributor { get; set; }
       
    }
}
