using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class OptionToProductSeedData : IEntityTypeConfiguration<OptionToProduct>
    {
        public void Configure(EntityTypeBuilder<OptionToProduct> builder)
        {
            builder.HasData(

                new OptionToProduct
                {
                    Id = Guid.Parse("EF12CEA5-7ADE-4F57-87F2-DADAC3112C0B"),
                    Status = Status.Active,
                    ParentProductId = Guid.Parse("8ACB9AF2-4983-45C8-9081-F6233A77F888"),//Müşterinin incelediği ürün 
                    ProductId = Guid.Parse("3ACB9AF2-4983-45C8-9081-F6233A77F333"),//Gideceği ürün(tüm özellikleri aynı fakat rengi farklı) 
                    OptionGroupId = Guid.Parse("3E8E39B5-8E99-46B4-88CC-B3126367B365"),
                    OptionId = Guid.Parse("EF12CEA5-7ADE-4F57-87F2-DADAC3112C0B")

                },
                new OptionToProduct
                {
                    Id = Guid.Parse("50A5F086-42C9-4EF3-9873-7021EEBE1017"),
                    Status = Status.Active,
                    ParentProductId = Guid.Parse("8ACB9AF2-4983-45C8-9081-F6233A77F888"),
                    ProductId = Guid.Parse("7ACB9AF2-4983-45C8-9081-F6233A77F777"),
                    OptionGroupId = Guid.Parse("3E8E39B5-8E99-46B4-88CC-B3126367B365"),
                    OptionId = Guid.Parse("D41B5341-0AD0-4E5F-9108-44A669CD7024")

                }

                );
        }
    }
}
