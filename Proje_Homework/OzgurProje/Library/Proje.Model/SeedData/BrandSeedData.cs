using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class BrandSeedData : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(

                new Brand
                {
                    Id = Guid.Parse("1D67D426-77D0-4359-9C8B-804C0D7890FF"),
                    Status = Status.Active,
                    BrandName = "Altın Yıldız",
                    Description = "Klasik Giyim",
                    
                },
                new Brand
                {
                    Id = Guid.Parse("3ACB9AF2-4983-45C8-9081-F6233A77F537"),
                    Status = Status.Active,
                    BrandName = "Pierre Cardin",
                    Description = "Klasik Giyim",

                },
                new Brand
                {
                    Id = Guid.Parse("5819FD74-7AD3-4AC0-89E1-48F7A06E87E5"),
                    Status = Status.Active,
                    BrandName = "Kiğılı",
                    Description = "Klasik Giyim",

                },
                //--------------------------------------------
                 new Brand
                 {
                     Id = Guid.Parse("2656565C-B55C-4996-8216-9AB2DAA41792"),
                     Status = Status.Active,
                     BrandName = "Puma",
                     Description = "Spor Giyim",

                 },
                 new Brand
                 {
                     Id = Guid.Parse("D9913B9A-6D9F-4ECC-8562-E3FD687B7485"),
                     Status = Status.Active,
                     BrandName = "Adidas",
                     Description = "Spor Giyim",

                 },
                  new Brand
                  {
                      Id = Guid.Parse("91C05F73-4A1B-4256-84A0-3D6FE6EE46D3"),
                      Status = Status.Active,
                      BrandName = "Nike",
                      Description = "Spor Giyim",

                  },
                  new Brand
                  {
                      Id = Guid.Parse("ECB44058-2977-47B0-B143-ABADDDAA2E77"),
                      Status = Status.Active,
                      BrandName = "Polo",
                      Description = "Spor Giyim",

                  },
                  new Brand
                  {
                      Id = Guid.Parse("781A5242-96F5-463B-823E-EC601FDCD591"),
                      Status = Status.Active,
                      BrandName = "Koton",
                      Description = "Günlük Giyim",

                  },
                  new Brand
                  {
                      Id = Guid.Parse("70291557-C137-4C6F-BD73-874CCC8D2994"),
                      Status = Status.Active,
                      BrandName = "Mavi",
                      Description = "Spor Giyim",

                  }


                );
        }
    }
}
