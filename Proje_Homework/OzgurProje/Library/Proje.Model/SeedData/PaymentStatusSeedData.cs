using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    class PaymentStatusSeedData : IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.HasData(

               new PaymentStatus
               {
                   Id = Guid.Parse("922F400A-9743-4508-80CF-C6C3BBB385C0"),
                   Status = Status.None,
                   Name = "Onay Bekliyor"
               },
               new PaymentStatus
               {
                   Id = Guid.Parse("06CBD5DC-B443-46C7-B984-1AF819AC8453"),
                   Status = Status.None,
                   Name = "Silindi"

               },
               new PaymentStatus
               {
                   Id = Guid.Parse("294543A1-B385-4768-BEDA-CABCD5862364"),
                   Status = Status.None,
                   Name = "Onaylandı"

               },
                new PaymentStatus
                {
                    Id = Guid.Parse("5ADE7DBA-64EA-4DE5-B624-3D599C29C066"),
                    Status = Status.None,
                    Name = "İptal Edildi"

                },
                new PaymentStatus
                {
                    Id = Guid.Parse("138679AF-6368-4097-94A7-6C944F79CC24"),
                    Status = Status.None,
                    Name = "İade Edildi"

                },
                new PaymentStatus
                {
                    Id = Guid.Parse("C5273B25-59EA-4964-A4ED-099AEF91A706"),
                    Status = Status.None,
                    Name = "Hatalı Ödeme"

                }

               );
        }
    }
}
