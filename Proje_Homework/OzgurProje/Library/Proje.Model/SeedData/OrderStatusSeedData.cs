using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    class OrderStatusSeedData : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasData(

               new OrderStatus
               {
                   Id = Guid.Parse("1E2C06A2-188A-4EC9-948F-955966C1CD6D"),
                   Status = Status.None,
                   Name = "Onay Bekliyor"
               },
               new OrderStatus
               {
                   Id = Guid.Parse("8F6C05A4-A7AD-4D74-B264-5514BAADEF13"),
                   Status = Status.None,
                   Name = "Silindi"

               },
               new OrderStatus
               {
                   Id = Guid.Parse("BE10F111-F4F6-4D58-9807-EC8C433D6B22"),
                   Status = Status.None,
                   Name = "Siparişiniz Hazırlanıyor"

               },
                new OrderStatus
                {
                    Id = Guid.Parse("F00AD7DC-F3FE-4951-BDA3-B90A6E29259D"),
                    Status = Status.None,
                    Name = "İptal Edildi"

                },
                new OrderStatus
                {
                    Id = Guid.Parse("1D8C4AEB-EE04-4F5D-90B7-AEE14B783B88"),
                    Status = Status.None,
                    Name = "İade Edildi"

                },
                new OrderStatus
                {
                    Id = Guid.Parse("719D6E39-AEE9-49F9-BFCF-DBA7E28C0293"),
                    Status = Status.None,
                    Name = "Kargoya Verildi"

                }

               );
        }
    }
}
