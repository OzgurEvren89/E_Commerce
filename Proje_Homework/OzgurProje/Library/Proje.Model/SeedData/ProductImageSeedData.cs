using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class ProductImageSeedData : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasData(
                //-------------Beyaz_Kazak---------------
                new ProductImage
                {
                    Id = Guid.Parse("8E99496E-665F-49EB-B9F5-DAF9EFDABD94"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Siyah_Kazak/1_org.jpg",
                    Revision = "Siyah Kazak_1",
                    SortOrder = 1,
                    ProductId = Guid.Parse("1ACB9AF2-4983-45C8-9081-F6233A77F111")
                },
                new ProductImage
                {
                    Id = Guid.Parse("86E49BA0-0D47-4BB4-85E5-014E5241E3E7"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Siyah_Kazak/2_org_zoom.jpg",
                    Revision = "Siyah Kazak_2",
                    SortOrder = 2,
                    ProductId = Guid.Parse("1ACB9AF2-4983-45C8-9081-F6233A77F111")
                },
                new ProductImage
                {
                    Id = Guid.Parse("3C405FB8-3355-4934-A1B5-8F0F9DBC2B4C"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Siyah_Kazak/4_org_zoom.jpg",
                    Revision = "Siyah Kazak_3",
                    SortOrder = 3,
                    ProductId = Guid.Parse("1ACB9AF2-4983-45C8-9081-F6233A77F111")
                },
                new ProductImage
                {
                    Id = Guid.Parse("CFB5B2A1-38E9-4E35-BA30-1AF9E5B7DEF5"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Siyah_Kazak/5_org_zoom.jpg",
                    Revision = "Siyah Kazak_4",
                    SortOrder = 4,
                    ProductId = Guid.Parse("1ACB9AF2-4983-45C8-9081-F6233A77F111")
                },
                //------------------Siyah_Kazak-------------------------
                new ProductImage
                {
                    Id = Guid.Parse("8195165C-5AFA-4165-AC79-6151ACBF771E"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Beyaz_Kazak/1_org_zoom.jpg",
                    Revision = "Beyaz Kazak_1",
                    SortOrder = 5,
                    ProductId = Guid.Parse("2ACB9AF2-4983-45C8-9081-F6233A77F222")
                },
                new ProductImage
                {
                    Id = Guid.Parse("466327BB-B102-4293-9435-02BB8D7A7D4E"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Beyaz_Kazak/2_org_zoom.jpg",
                    Revision = "Beyaz Kazak_2",
                    SortOrder = 6,
                    ProductId = Guid.Parse("2ACB9AF2-4983-45C8-9081-F6233A77F222")
                },
                new ProductImage
                {
                    Id = Guid.Parse("7D081144-3B3B-4DCC-B842-48CCF13F8CD3"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Beyaz_Kazak/5_org_zoom.jpg",
                    Revision = "Beyaz Kazak_3",
                    SortOrder = 7,
                    ProductId = Guid.Parse("2ACB9AF2-4983-45C8-9081-F6233A77F222")
                },
                new ProductImage
                {
                    Id = Guid.Parse("E5552FF1-0932-4D95-9E90-827D9F388C89"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Beyaz_Kazak/6_org_zoom.jpg",
                    Revision = "Beyaz Kazak_4",
                    SortOrder = 8,
                    ProductId = Guid.Parse("2ACB9AF2-4983-45C8-9081-F6233A77F222")
                },
                //------------------Kırmızı_Kazak-------------------
                new ProductImage
                {
                    Id = Guid.Parse("94CD44DC-C981-4688-8E0B-F65E5BA461E6"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kirmizi_Kazak/1_org_zoom (1).jpg",
                    Revision = "Kırmızı Kazak_1",
                    SortOrder = 1,
                    ProductId = Guid.Parse("3ACB9AF2-4983-45C8-9081-F6233A77F333")
                },
                new ProductImage
                {
                    Id = Guid.Parse("DBCCC3EF-931C-45FE-AE32-013CCFAB10CA"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kirmizi_Kazak/2_org_zoom.jpg",
                    Revision = "Kırmızı Kazak_2",
                    SortOrder = 2,
                    ProductId = Guid.Parse("3ACB9AF2-4983-45C8-9081-F6233A77F333")
                },
                new ProductImage
                {
                    Id = Guid.Parse("D44BDBFB-E792-46B1-B810-740D012CA9D8"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kirmizi_Kazak/5_org_zoom.jpg",
                    Revision = "Kırmızı Kazak_3",
                    SortOrder = 3,
                    ProductId = Guid.Parse("3ACB9AF2-4983-45C8-9081-F6233A77F333")
                },
                //-------------------Kot_Pantolon--------------
                new ProductImage
                {
                    Id = Guid.Parse("CA950A33-EFCD-422F-B32C-27620B69945D"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kot_Pantolon/0_org_zoom.jpg",
                    Revision = "Kot_Pantolon_1",
                    SortOrder = 1,
                    ProductId = Guid.Parse("4ACB9AF2-4983-45C8-9081-F6233A77F444")
                },
                new ProductImage
                {
                    Id = Guid.Parse("F88AF012-589F-4FBE-9B32-04DA771C58AD"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kot_Pantolon/1_org_zoom.jpg",
                    Revision = "Kot_Pantolon_2",
                    SortOrder = 2,
                    ProductId = Guid.Parse("4ACB9AF2-4983-45C8-9081-F6233A77F444")
                },
                new ProductImage
                {
                    Id = Guid.Parse("2FC7F2F0-401F-427D-B09E-4FA9E5F83BC8"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kot_Pantolon/4_org_zoom.jpg",
                    Revision = "Kot_Pantolon_3",
                    SortOrder = 3,
                    ProductId = Guid.Parse("4ACB9AF2-4983-45C8-9081-F6233A77F444")
                },
                //-------------------Kumaş Pantolon--------------
                new ProductImage
                {
                    Id = Guid.Parse("39DB4CC0-2C68-4E83-A691-3D8458C11437"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kumas_Pantolon/1_org_zoom (1).jpg",
                    Revision = "Kumas_Pantolon_1",
                    SortOrder = 1,
                    ProductId = Guid.Parse("5ACB9AF2-4983-45C8-9081-F6233A77F555")
                },
                new ProductImage
                {
                    Id = Guid.Parse("C9E17B8C-DD1E-427F-A977-248E15AEA3FD"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kumas_Pantolon/2_org_zoom.jpg",
                    Revision = "Kumas_Pantolon_2",
                    SortOrder = 2,
                    ProductId = Guid.Parse("5ACB9AF2-4983-45C8-9081-F6233A77F555")
                },
                new ProductImage
                {
                    Id = Guid.Parse("BDE1098D-04B6-44D8-9BF8-660BB95735F4"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kumas_Pantolon/3_org_zoom.jpg",
                    Revision = "Kumas_Pantolon_3",
                    SortOrder = 3,
                    ProductId = Guid.Parse("5ACB9AF2-4983-45C8-9081-F6233A77F555")
                },
                //----------------------Beyaz Gömlek---------
                new ProductImage
                {
                    Id = Guid.Parse("660EEDD2-F0A1-429C-8EC9-BEAA3964A183"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Beyaz_Gomlek/1_org_zoom.jpg",
                    Revision = "Beyaz_Gömlek_1",
                    SortOrder = 1,
                    ProductId = Guid.Parse("6ACB9AF2-4983-45C8-9081-F6233A77F666")
                },
                new ProductImage
                {
                    Id = Guid.Parse("960F4A34-422A-4846-9C83-882E9EC2DD0D"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Beyaz_Gomlek/3_org_zoom.jpg",
                    Revision = "Beyaz_Gömlek_2",
                    SortOrder = 2,
                    ProductId = Guid.Parse("6ACB9AF2-4983-45C8-9081-F6233A77F666")
                },
                new ProductImage
                {
                    Id = Guid.Parse("638DAE02-6D9D-4A46-838A-7E3E5F790F1E"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Beyaz_Gomlek/5_org_zoom.jpg",
                    Revision = "Beyaz_Gömlek_3",
                    SortOrder = 3,
                    ProductId = Guid.Parse("6ACB9AF2-4983-45C8-9081-F6233A77F666")
                },
                //-------------Siyah Gömlek-------------
                new ProductImage
                {
                    Id = Guid.Parse("43237839-639B-46F3-A314-F702A602C40D"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Siyah_Gomlek/2_org_zoom.jpg",
                    Revision = "Siyah_Gömlek_1",
                    SortOrder = 1,
                    ProductId = Guid.Parse("7ACB9AF2-4983-45C8-9081-F6233A77F777")
                },
                new ProductImage
                {
                    Id = Guid.Parse("98C93C9F-90BD-4867-AB12-2965DF684AED"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Siyah_Gomlek/90_org_zoom.jpg",
                    Revision = "Siyah_Gömlek_2",
                    SortOrder = 2,
                    ProductId = Guid.Parse("7ACB9AF2-4983-45C8-9081-F6233A77F777")
                },
                new ProductImage
                {
                    Id = Guid.Parse("969278CA-46BA-48D1-A0C3-F9A253A1E5FF"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Siyah_Gomlek/94_org_zoom.jpg",
                    Revision = "Siyah_Gömlek_3",
                    SortOrder = 3,
                    ProductId = Guid.Parse("7ACB9AF2-4983-45C8-9081-F6233A77F777")
                },
                 //-------------Mavi Gömlek-------------
                new ProductImage
                {
                    Id = Guid.Parse("1FC89776-7537-4348-9AFF-CBDC5776F002"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Mavi_Gomlek/1_org_zoom.jpg",
                    Revision = "Mavi_Gömlek_1",
                    SortOrder = 1,
                    ProductId = Guid.Parse("8ACB9AF2-4983-45C8-9081-F6233A77F888")
                },
                new ProductImage
                {
                    Id = Guid.Parse("B9EAF18A-E280-4D84-92DE-0E99BEE8AC89"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Mavi_Gomlek/2_org_zoom.jpg",
                    Revision = "Mavi_Gömlek_2",
                    SortOrder = 2,
                    ProductId = Guid.Parse("8ACB9AF2-4983-45C8-9081-F6233A77F888")
                },
                new ProductImage
                {
                    Id = Guid.Parse("D9DAEA35-F288-425A-8D75-A1D14F2A510B"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Mavi_Gomlek/3_org_zoom.jpg",
                    Revision = "Mavi_Gömlek_3",
                    SortOrder = 3,
                    ProductId = Guid.Parse("8ACB9AF2-4983-45C8-9081-F6233A77F888")
                },
                //-------------Kırmızı Gömlek-------------
                new ProductImage
                {
                    Id = Guid.Parse("5C7E932B-358B-493B-9545-534BD8A86270"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kirmizi_Gomlek/1_org_zoom (1).jpg",
                    Revision = "Kırmızı_Gömlek_1",
                    SortOrder = 1,
                    ProductId = Guid.Parse("C98B184B-0FA0-4633-BB5F-CFBCC7B0E45B")
                },
                new ProductImage
                {
                    Id = Guid.Parse("CA83F04E-45FB-4C5B-8FB7-F56FDE1F58D0"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kirmizi_Gomlek/1_org_zoom.jpg",
                    Revision = "Kırmızı_Gömlek_2",
                    SortOrder = 2,
                    ProductId = Guid.Parse("C98B184B-0FA0-4633-BB5F-CFBCC7B0E45B")
                },
                new ProductImage
                {
                    Id = Guid.Parse("E8885FB6-9E94-4ED9-A73B-EB1581970D53"),
                    Status = Status.Active,
                    FileName = "/blog/images/product_images/Kirmizi_Gomlek/3_org_zoom.jpg",
                    Revision = "Kırmızı_Gömlek_3",
                    SortOrder = 3,
                    ProductId = Guid.Parse("C98B184B-0FA0-4633-BB5F-CFBCC7B0E45B")
                }

                );
        }
    }
}
