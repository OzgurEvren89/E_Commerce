using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.SeedData
{
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("1ACB9AF2-4983-45C8-9081-F6233A77F111"),
                    Status = Status.Active,
                    ProductName="Siyah Kazak",                   
                    BuyingPrice =100,
                    Price1= 200,
                    Warranty= 1,
                    StockAmount= 100,
                    ShortDetails= "SİYAH KIŞLIK KAZAK",
                    BrandId=  Guid.Parse("1D67D426-77D0-4359-9C8B-804C0D7890FF"),
                    CategoryId= Guid.Parse("220E9662-88CC-4B24-8C40-80D423553615"),
                    VolumetricWeight = Convert.ToDecimal("1,2")

                },
                new Product
                {
                    Id = Guid.Parse("2ACB9AF2-4983-45C8-9081-F6233A77F222"),
                    Status = Status.Active,
                    ProductName = "Beyaz Kazak",
                    BuyingPrice = 100,
                    Price1 = 200,
                    Warranty = 1,
                    StockAmount = 100,
                    ShortDetails = "BEYAZ KIŞLIK KAZAK",
                    BrandId = Guid.Parse("1D67D426-77D0-4359-9C8B-804C0D7890FF"),
                    CategoryId = Guid.Parse("220E9662-88CC-4B24-8C40-80D423553615"),
                    VolumetricWeight = Convert.ToDecimal("1,3")
                },
                 new Product
                 {
                     Id = Guid.Parse("3ACB9AF2-4983-45C8-9081-F6233A77F333"),
                     Status = Status.Active,
                     ProductName = "Kırmızı Kazak",
                     BuyingPrice = 100,
                     Price1 = 200,
                     Warranty = 1,
                     StockAmount = 100,
                     ShortDetails = "KIRMIZI KIŞLIK KAZAK",
                     BrandId = Guid.Parse("1D67D426-77D0-4359-9C8B-804C0D7890FF"),
                     CategoryId = Guid.Parse("220E9662-88CC-4B24-8C40-80D423553615"),
                     VolumetricWeight = Convert.ToDecimal("1,3")
                 },
                 new Product
                 {
                     Id = Guid.Parse("4ACB9AF2-4983-45C8-9081-F6233A77F444"),
                     Status = Status.Active,
                     ProductName = "Kot Pantolon",
                     BuyingPrice = 99,
                     Price1 = 200,
                     Warranty = 1,
                     StockAmount = 100,
                     ShortDetails = "KOT PANTOLON",
                     BrandId = Guid.Parse("70291557-C137-4C6F-BD73-874CCC8D2994"),
                     CategoryId = Guid.Parse("74368C62-C748-483E-8B38-9A4302D32922"),
                     VolumetricWeight = Convert.ToDecimal("1,2")
                 },
                 new Product
                 {
                     Id = Guid.Parse("5ACB9AF2-4983-45C8-9081-F6233A77F555"),
                     Status = Status.Active,
                     ProductName = "Kumaş Pantolon",
                     BuyingPrice = 199,
                     Price1 = 300,
                     Warranty = 1,
                     StockAmount = 100,
                     ShortDetails = "KUMAŞ PANTOLON",
                     BrandId = Guid.Parse("3ACB9AF2-4983-45C8-9081-F6233A77F537"),
                     CategoryId = Guid.Parse("74368C62-C748-483E-8B38-9A4302D32922"),
                     VolumetricWeight = Convert.ToDecimal("1")
                 }, 
                 new Product
                 {
                     Id = Guid.Parse("6ACB9AF2-4983-45C8-9081-F6233A77F666"),
                     Status = Status.Active,
                     ProductName = "Beyaz Gömlek",
                     BuyingPrice = 89,
                     Price1 = 200,
                     Warranty = 1,
                     StockAmount = 100,
                     ShortDetails = "BEYAZ KLASİK GÖMLEK",
                     BrandId = Guid.Parse("5819FD74-7AD3-4AC0-89E1-48F7A06E87E5"),
                     CategoryId = Guid.Parse("FF670E2D-C83C-4DEF-B5B7-35595A3C26CC"),
                     VolumetricWeight = Convert.ToDecimal("1")
                 },
                 new Product
                 {
                     Id = Guid.Parse("7ACB9AF2-4983-45C8-9081-F6233A77F777"),
                     Status = Status.Active,
                     ProductName = "Siyah Gömlek",
                     BuyingPrice = 89,
                     Price1 = 200,
                     Warranty = 1,
                     StockAmount = 100,
                     ShortDetails = "BEYAZ KLASİK GÖMLEK",
                     BrandId = Guid.Parse("5819FD74-7AD3-4AC0-89E1-48F7A06E87E5"),
                     CategoryId = Guid.Parse("FF670E2D-C83C-4DEF-B5B7-35595A3C26CC"),
                     VolumetricWeight = Convert.ToDecimal("1")
                 },
                 new Product
                 {
                     Id = Guid.Parse("8ACB9AF2-4983-45C8-9081-F6233A77F888"),
                     Status = Status.Active,
                     ProductName = "Mavi Gömlek",
                     BuyingPrice = 89,
                     Price1 = 200,
                     Warranty = 1,
                     StockAmount = 100,
                     ShortDetails = "MAVİ KLASİK GÖMLEK",
                     BrandId = Guid.Parse("5819FD74-7AD3-4AC0-89E1-48F7A06E87E5"),
                     CategoryId = Guid.Parse("FF670E2D-C83C-4DEF-B5B7-35595A3C26CC"),
                     VolumetricWeight = Convert.ToDecimal("1")

                 },
                 new Product
                 {
                     Id = Guid.Parse("C98B184B-0FA0-4633-BB5F-CFBCC7B0E45B"),
                     Status = Status.Active,
                     ProductName = "Kırmızı Gömlek",
                     BuyingPrice = 124,
                     Price1 = 250,
                     Warranty = 1,
                     StockAmount = 100,
                     ShortDetails = "MAVİ KLASİK GÖMLEK",
                     BrandId = Guid.Parse("5819FD74-7AD3-4AC0-89E1-48F7A06E87E5"),
                     CategoryId = Guid.Parse("FF670E2D-C83C-4DEF-B5B7-35595A3C26CC"),
                     VolumetricWeight = Convert.ToDecimal("1")

                 }




                );

        }
    }
}
