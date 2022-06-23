using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class DemandStatusSeedData : IEntityTypeConfiguration<DemandStatus>
    {
        public void Configure(EntityTypeBuilder<DemandStatus> builder)
        {
            builder.HasData(

                new DemandStatus
                {
                    Id = Guid.Parse("1D4A24EA-6CF0-4836-8777-94C8BBA7E7DA"),
                    Status = Status.Active,
                    Name = "Onay Bekliyor"                   

                },
                new DemandStatus
                {
                    Id = Guid.Parse("9C6DFB14-2D90-4F14-A0CE-C3B0E4C0F778"),
                    Status = Status.Active,
                    Name = "Onaylandı"

                },
                new DemandStatus
                {
                    Id = Guid.Parse("8A138711-7A9C-46BC-8FF4-B7FE87C86DA3"),
                    Status = Status.Active,
                    Name = "İptal Edildi"

                }

                );
        }
    }
}
