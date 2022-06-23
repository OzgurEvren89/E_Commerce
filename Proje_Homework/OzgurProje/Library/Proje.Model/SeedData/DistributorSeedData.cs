using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class DistributorSeedData : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.HasData(

                new Distributor
                {
                    Id = Guid.Parse("6CFC425A-CEA6-4079-B123-5B8116C55AD9"),
                    Status = Status.Active,
                    Name = "Altın Yıldız İstanbul Şube",
                    Phone = "0555 555-55-55",
                    Email = "altınyıldız@altınyıldız.com",
                    ContactPerson = "Burak YEŞİL"

                },
                new Distributor
                {
                    Id = Guid.Parse("D32FCF25-4D38-4D99-B1E5-C3CAB7606807"),
                    Status = Status.Active,
                    Name = "Coton İstanbul Şube",
                    Phone = "0555 555-55-56",
                    Email = "coton@coton.com",
                    ContactPerson = "Burak KARA"

                },
                new Distributor
                {
                    Id = Guid.Parse("8DB88A18-19AD-4648-A62A-9FF6C7080311"),
                    Status = Status.Active,
                    Name = "Kiğılı İstanbul Şube",
                    Phone = "0555 555-55-57",
                    Email = "kigili@kigili.com",
                    ContactPerson = "Burak SARI"

                },
                 new Distributor
                 {
                     Id = Guid.Parse("263FA307-8B12-414F-8F7B-C5F359545150"),
                     Status = Status.Active,
                     Name = "Nike İstanbul Şube",
                     Phone = "0555 555-55-58",
                     Email = "nike@nike.com",
                     ContactPerson = "Burak MAVİ"

                 },
                  new Distributor
                  {
                      Id = Guid.Parse("1852023F-2032-4954-AF86-11FE9A21F609"),
                      Status = Status.Active,
                      Name = "Samsung İstanbul Şube",
                      Phone = "0555 555-55-59",
                      Email = "samsung@samsung.com",
                      ContactPerson = "Burak KIRMIZI"

                  }

                );
        }
    }
}
