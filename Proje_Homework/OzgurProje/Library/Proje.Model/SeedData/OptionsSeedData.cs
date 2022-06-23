using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class OptionsSeedData : IEntityTypeConfiguration<Options>
    {
        public void Configure(EntityTypeBuilder<Options> builder)
        {
            builder.HasData(

                new Options
                {
                    Id = Guid.Parse("EF12CEA5-7ADE-4F57-87F2-DADAC3112C0B"),
                    Status = Status.Active,
                    Title = "Kırmızı",
                    Slug = "",
                    SortOrder = 1,
                    OptionGroupId = Guid.Parse("3E8E39B5-8E99-46B4-88CC-B3126367B365")

                },

                new Options
                {
                    Id = Guid.Parse("D41B5341-0AD0-4E5F-9108-44A669CD7024"),
                    Status = Status.Active,
                    Title = "Beyaz",
                    Slug = "",
                    SortOrder = 2,
                    OptionGroupId = Guid.Parse("3E8E39B5-8E99-46B4-88CC-B3126367B365")

                },

                new Options
                {
                    Id = Guid.Parse("42C7BEBC-E7DF-4DE2-9CE4-9227451A2F5C"),
                    Status = Status.Active,
                    Title = "Mavi",
                    Slug = "",
                    SortOrder = 3,
                    OptionGroupId = Guid.Parse("3E8E39B5-8E99-46B4-88CC-B3126367B365")

                },
                new Options
                {
                    Id = Guid.Parse("{AC5EA607-20E2-4CED-889C-D229814D55AA}"),
                    Status = Status.Active,
                    Title = "Yeşil",
                    Slug = "",
                    SortOrder = 4,
                    OptionGroupId = Guid.Parse("3E8E39B5-8E99-46B4-88CC-B3126367B365")

                }

                );
        }
    }
}
