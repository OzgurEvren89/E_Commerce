using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class CitySeedData : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(

                new City
                {
                    Id = Guid.Parse("F1646E31-CAE1-41C7-B7FA-5900651C5E69"),
                    Status = Status.Active,
                    CityCode = 34,
                    CityName = "İstanbul"

                },
                new City
                {
                    Id = Guid.Parse("EE05E832-798F-4EF3-9E75-CEC81A015103"),
                    Status = Status.Active,
                    CityCode = 06,
                    CityName = "Ankara"

                }
              
                );
        }
    }
}
