using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class CountySeedData : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.HasData(

                new County
                {
                    Id = Guid.Parse("FD9F5F98-B7EC-4F3C-B256-2B32C1156F3F"),
                    Status = Status.Active,
                    CountyCode = 1,
                    CountyName = "Kağıthane",
                    CityCode = 34

                },
                new County
                {
                    Id = Guid.Parse("09AA8046-8F90-4F92-BDFE-F27FE643FEF6"),
                    Status = Status.Active,
                    CountyCode = 2,
                    CountyName = "SarıYer",
                    CityCode = 34

                },
                new County
                {
                    Id = Guid.Parse("DA129D37-E7BE-4340-987C-46A7C20429E2"),
                    Status = Status.Active,
                    CountyCode = 3,
                    CountyName = "Esenler",
                    CityCode = 34

                },
                 new County
                 {
                     Id = Guid.Parse("4CF528CC-8F34-4534-9229-C1E0FB7E533F"),
                     Status = Status.Active,
                     CountyCode = 4,
                     CountyName = "Beşktaş",
                     CityCode = 34

                 },
                 new County
                 {
                     Id = Guid.Parse("0191008F-672F-4754-83DF-4330BAD1EB52"),
                     Status = Status.Active,
                     CountyCode = 5,
                     CountyName = "Şişli",
                     CityCode = 34

                 },
                  new County
                  {
                      Id = Guid.Parse("A65A4934-A7A6-4F62-8F50-01BE9B04D74B"),
                      Status = Status.Active,
                      CountyCode = 6,
                      CountyName = "Taksim",
                      CityCode = 34

                  },
                  new County
                  {
                      Id = Guid.Parse("C909881E-4437-407E-BC64-15F350B45B2C"),
                      Status = Status.Active,
                      CountyCode = 7,
                      CountyName = "Bakırköy",
                      CityCode = 34

                  },
                  new County
                  {
                      Id = Guid.Parse("20C3A4D8-42FA-42B9-A591-5CD12D52B94C"),
                      Status = Status.Active,
                      CountyCode = 8,
                      CountyName = "Fatih",
                      CityCode = 34

                  },
                  new County
                  {
                      Id = Guid.Parse("E0EC0E46-1DB0-4133-A1CF-6F98E28F6D5D"),
                      Status = Status.Active,
                      CountyCode = 9,
                      CountyName = "Kadıköy",
                      CityCode = 34

                  },
                  new County
                  {
                      Id = Guid.Parse("37073E80-CA18-4F49-B4B6-99EAEB67C9D8"),
                      Status = Status.Active,
                      CountyCode = 10,
                      CountyName = "Çankaya",
                      CityCode = 06

                  },
                  new County
                  {
                      Id = Guid.Parse("4C3E1B47-2216-4E50-A214-C32AE2EE40E9"),
                      Status = Status.Active,
                      CountyCode = 11,
                      CountyName = "Sıhhıye",
                      CityCode = 06


                  },
                  new County
                  {
                      Id = Guid.Parse("7D0137D0-BEFE-4EFA-84F9-1630A0217AF3"),
                      Status = Status.Active,
                      CountyCode = 12,
                      CountyName = "Yeni Mahalle",
                      CityCode = 06


                  },
                  new County
                  {
                      Id = Guid.Parse("{2AAE8F9F-3EA8-45A8-8BB2-10ABE0CBFD5F}"),
                      Status = Status.Active,
                      CountyCode = 13,
                      CountyName = "Demet Evler",
                      CityCode = 06


                  },
                  new County
                  {
                      Id = Guid.Parse("AE1AEBD8-C181-4464-8D96-808F4F47F196"),
                      Status = Status.Active,
                      CountyCode = 14,
                      CountyName = "Gölbaşı",
                      CityCode = 06


                  }



                );
        }
    }
}
