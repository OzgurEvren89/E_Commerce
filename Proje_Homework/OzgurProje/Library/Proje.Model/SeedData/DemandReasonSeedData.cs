using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class DemandReasonSeedData : IEntityTypeConfiguration<DemandReason>
    {
        public void Configure(EntityTypeBuilder<DemandReason> builder)
        {
            builder.HasData(

                new DemandReason
                {
                    Id = Guid.Parse("F2B1DAB9-D45D-4763-8970-48034A2D5F44"),
                    Status = Status.Active,
                    Reason = "Ürünü İade Etmek İstiyorum"

                },
                new DemandReason
                {
                    Id = Guid.Parse("21545434-6B7A-4235-B731-2CA45C187A24"),
                    Status = Status.Active,
                    Reason = "Ürünü Değiştirmek İstiyorum"

                },
                new DemandReason
                {
                    Id = Guid.Parse("9002B034-2862-4024-A2A2-12E287FB2C7C"),
                    Status = Status.Active,
                    Reason = "Faturadaki Ürünler İle Gelen Ürünler Farklı"

                },
                new DemandReason
                {
                    Id = Guid.Parse("665F138D-3E77-495E-B2C7-3847F91545E2"),
                    Status = Status.Active,
                    Reason = "Siparişimdeki Ürünler İle Gelen Ürünler Farklı"

                },
                new DemandReason
                {
                    Id = Guid.Parse("BB16690B-9345-4FDB-BD45-F5F965CD3731"),
                    Status = Status.Active,
                    Reason = "Diğer"
                
                }

                );
        }
    }
}
