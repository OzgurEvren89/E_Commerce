using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class DistributorToProductSeedData : IEntityTypeConfiguration<DistributorToProduct>
    {
        public void Configure(EntityTypeBuilder<DistributorToProduct> builder)
        {
            builder.HasData(

                new DistributorToProduct
                {
                    Id = Guid.Parse("4E99DC58-B8D1-4F5A-A1A8-914E1364351F"),
                    Status = Status.Active,
                    ProductId = Guid.Parse("1ACB9AF2-4983-45C8-9081-F6233A77F111"),
                    DistributorId = Guid.Parse("6CFC425A-CEA6-4079-B123-5B8116C55AD9")

                },
                new DistributorToProduct
                {
                    Id = Guid.Parse("3E165D70-E775-485D-BA89-CE7D22F6548C"),
                    Status = Status.Active,
                    ProductId = Guid.Parse("2ACB9AF2-4983-45C8-9081-F6233A77F222"),
                    DistributorId = Guid.Parse("D32FCF25-4D38-4D99-B1E5-C3CAB7606807")
                }
            
                );
        }
    }
}
