using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
               
                new Category
                {
                    
                    Id = Guid.Parse("6E5250EF-CA5A-4C6C-9C24-03BD5F16E854"),
                    Status = Status.Active,
                    CategoryName ="Takım Elbise",
                    Description = "Klasik Giyim",                    
                    ImageUrl = "/"                  
                },
                new Category
                {
                    Id = Guid.Parse("6D66BD90-DABF-46A9-B75B-F206FBE5C7D9"),
                    Status = Status.Active,
                    CategoryName = "Spor Ayakkabı",
                    Description = "Spor Giyim",
                    ImageUrl = "/"
                },
                new Category
                {
                    Id = Guid.Parse("8678A844-6811-4018-821C-A499D7A7761C"),
                    Status = Status.Active,
                    CategoryName = "Eşofman",
                    Description = "Spor Giyim",
                    ImageUrl = "/"
                },
                new Category
                {
                    Id = Guid.Parse("220E9662-88CC-4B24-8C40-80D423553615"),
                    Status = Status.Active,
                    CategoryName = "Kazak",
                    Description = "Günlük Giyim",
                    ImageUrl = "/"
                },
                new Category
                {
                    Id = Guid.Parse("FF670E2D-C83C-4DEF-B5B7-35595A3C26CC"),
                    Status = Status.Active,
                    CategoryName = "Gömlek",
                    Description = "Günlük Giyim",
                    ImageUrl = "/"
                },
                new Category
                {
                    Id = Guid.Parse("74368C62-C748-483E-8B38-9A4302D32922"),
                    Status = Status.Active,
                    CategoryName = "Pantolon",
                    Description = "Günlük Giyim",
                    ImageUrl = "/"
                }

                );
        }
    }
}
