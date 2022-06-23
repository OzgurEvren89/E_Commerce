using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class BrandToCategorySeedData : IEntityTypeConfiguration<BrandToCategory>
    {
        public void Configure(EntityTypeBuilder<BrandToCategory> builder)
        {
            builder.HasData(

                new BrandToCategory
                {

                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId= Guid.Parse("1D67D426-77D0-4359-9C8B-804C0D7890FF"),
                    BrandName = "Altın Yıldız",
                    CategoryId= Guid.Parse("6E5250EF-CA5A-4C6C-9C24-03BD5F16E854"),
                    CategoryName = "Takım Elbise"

                },
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("3ACB9AF2-4983-45C8-9081-F6233A77F537"),
                    BrandName = "Pierre Cardin",
                    CategoryId = Guid.Parse("6E5250EF-CA5A-4C6C-9C24-03BD5F16E854"),
                    CategoryName = "Takım Elbise"
                },
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("5819FD74-7AD3-4AC0-89E1-48F7A06E87E5"),
                    BrandName = "Kiğılı",
                    CategoryId = Guid.Parse("6E5250EF-CA5A-4C6C-9C24-03BD5F16E854"),
                    CategoryName = "Takım Elbise"
                },
                //--------------------------------------------------
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("2656565C-B55C-4996-8216-9AB2DAA41792"),
                    BrandName = "Puma",
                    CategoryId = Guid.Parse("6D66BD90-DABF-46A9-B75B-F206FBE5C7D9"),
                    CategoryName = "Spor Ayakkabı"
                },
                 new BrandToCategory
                 {
                     Id = Guid.NewGuid(),
                     Status = Status.Active,
                     BrandId = Guid.Parse("D9913B9A-6D9F-4ECC-8562-E3FD687B7485"),
                     BrandName = "Adidas",
                     CategoryId = Guid.Parse("6D66BD90-DABF-46A9-B75B-F206FBE5C7D9"),
                     CategoryName = "Spor Ayakkabı"
                 },
                  new BrandToCategory
                  {
                      Id = Guid.NewGuid(),
                      Status = Status.Active,
                      BrandId = Guid.Parse("91C05F73-4A1B-4256-84A0-3D6FE6EE46D3"),
                      BrandName = "Nike",
                      CategoryId = Guid.Parse("6D66BD90-DABF-46A9-B75B-F206FBE5C7D9"),
                      CategoryName = "Spor Ayakkabı"
                  },
               //------------------------------------------
               new BrandToCategory
               {
                   Id = Guid.NewGuid(),
                   Status = Status.Active,
                   BrandId = Guid.Parse("2656565C-B55C-4996-8216-9AB2DAA41792"),
                   BrandName = "Puma",
                   CategoryId = Guid.Parse("8678A844-6811-4018-821C-A499D7A7761C"),
                   CategoryName = "Eşofman"
               },
                 new BrandToCategory
                 {
                     Id = Guid.NewGuid(),
                     Status = Status.Active,
                     BrandId = Guid.Parse("D9913B9A-6D9F-4ECC-8562-E3FD687B7485"),
                     BrandName = "Adidas",
                     CategoryId = Guid.Parse("8678A844-6811-4018-821C-A499D7A7761C"),
                     CategoryName = "Eşofman"
                 },
                  new BrandToCategory
                  {
                      Id = Guid.NewGuid(),
                      Status = Status.Active,
                      BrandId = Guid.Parse("91C05F73-4A1B-4256-84A0-3D6FE6EE46D3"),
                      BrandName = "Nike",
                      CategoryId = Guid.Parse("8678A844-6811-4018-821C-A499D7A7761C"),
                      CategoryName = "Eşofman"
                  },
                //-----------------------------------------
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("781A5242-96F5-463B-823E-EC601FDCD591"),
                    BrandName = "Koton",
                    CategoryId = Guid.Parse("220E9662-88CC-4B24-8C40-80D423553615"),
                    CategoryName = "Kazak"
                },
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("70291557-C137-4C6F-BD73-874CCC8D2994"),
                    BrandName = "Mavi",
                    CategoryId = Guid.Parse("220E9662-88CC-4B24-8C40-80D423553615"),
                    CategoryName = "Kazak"
                },
                //------------------------------------------------------
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("70291557-C137-4C6F-BD73-874CCC8D2994"),
                    BrandName = "Mavi",
                    CategoryId = Guid.Parse("FF670E2D-C83C-4DEF-B5B7-35595A3C26CC"),
                    CategoryName = "Kazak"
                },
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("781A5242-96F5-463B-823E-EC601FDCD591"),
                    BrandName = "Koton",
                    CategoryId = Guid.Parse("FF670E2D-C83C-4DEF-B5B7-35595A3C26CC"),
                    CategoryName = "Kazak"
                },
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("5819FD74-7AD3-4AC0-89E1-48F7A06E87E5"),
                    BrandName = "Kiğılı",
                    CategoryId = Guid.Parse("FF670E2D-C83C-4DEF-B5B7-35595A3C26CC"),
                    CategoryName = "Kazak"
                },
                  //------------------------------------------
                  new BrandToCategory
                  {
                      Id = Guid.NewGuid(),
                      Status = Status.Active,
                      BrandId = Guid.Parse("70291557-C137-4C6F-BD73-874CCC8D2994"),
                      BrandName = "Mavi",
                      CategoryId = Guid.Parse("74368C62-C748-483E-8B38-9A4302D32922"),
                      CategoryName = "Pantolon"
                  },
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("781A5242-96F5-463B-823E-EC601FDCD591"),
                    BrandName = "Koton",
                    CategoryId = Guid.Parse("74368C62-C748-483E-8B38-9A4302D32922"),
                    CategoryName = "Pantolon"
                },
                new BrandToCategory
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    BrandId = Guid.Parse("5819FD74-7AD3-4AC0-89E1-48F7A06E87E5"),
                    BrandName = "Kiğılı",
                    CategoryId = Guid.Parse("74368C62-C748-483E-8B38-9A4302D32922"),
                    CategoryName = "Pantolon"
                }
                );
        }
    }
}
