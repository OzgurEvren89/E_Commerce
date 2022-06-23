using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class CurrencySeedData : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(

                new Currency
                {
                    Id = Guid.Parse("7B4FBA26-C678-4B08-A43C-38CCDBE594EE"),
                    Status = Status.Active,
                    LongName = "TÜRK LİRASI",
                    ShortName = "TL"

                },
                new Currency
                {
                    Id = Guid.Parse("ACF0F314-3B7D-4D2C-BCA7-7B0A195CE8A2"),
                    Status = Status.Active,
                    LongName = "EURO",
                    ShortName = "EUR"

                },
                new Currency
                {
                    Id = Guid.Parse("DC2DC16F-529A-4276-AA00-436BF2CA5B7F"),
                    Status = Status.Active,
                    LongName = "DOLAR",
                    ShortName = "USD"

                }
              
                );
        }
    }
}
