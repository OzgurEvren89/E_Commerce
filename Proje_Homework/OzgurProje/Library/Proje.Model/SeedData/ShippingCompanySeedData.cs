using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class ShippingCompanySeedData : IEntityTypeConfiguration<ShippingCompany>
    {
        public void Configure(EntityTypeBuilder<ShippingCompany> builder)
        {
            builder.HasData(

                new ShippingCompany
                {
                    Id = Guid.Parse("DB5FB4AB-653A-4D26-8346-B067B6EF5D44"),
                    Status = Status.Active,
                    Name = "Aras Kargo",
                    ExtraPrice = Convert.ToDecimal("10"),
                    ExtraVolumetricWeightPrice = Convert.ToDecimal("1"),
                    FreeShipmentOrderPrice = Convert.ToDecimal("100")

                },
                new ShippingCompany
                {
                    Id = Guid.Parse("ED1F9D0A-87F4-4634-A9A6-40120A277BBF"),
                    Status = Status.Active,
                    Name = "PTT",
                    ExtraPrice = Convert.ToDecimal("11"),
                    ExtraVolumetricWeightPrice = Convert.ToDecimal("1"),
                    FreeShipmentOrderPrice = Convert.ToDecimal("100")

                }


                );
        }
    }
}
