using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class PaymentTypeSeedData : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasData(

                new PaymentType
                {
                    Id = Guid.Parse("0D051727-896B-4C86-BFB5-980AF28CDBC4"),
                    Status = Status.Active,
                    Name = "Kredi Kartı"

                },
                new PaymentType
                {
                    Id = Guid.Parse("43D849A2-FEBA-4A79-AA14-6ADCFDB19916"),
                    Status = Status.Active,
                    Name = "Hediye Çeki"
                }
               
                );
        }
    }
}
