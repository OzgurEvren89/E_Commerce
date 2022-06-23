using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class OptionGroupSeedData : IEntityTypeConfiguration<OptionGroup>
    {
        public void Configure(EntityTypeBuilder<OptionGroup> builder)
        {
            builder.HasData(

                new OptionGroup
                {
                    Id = Guid.Parse("3E8E39B5-8E99-46B4-88CC-B3126367B365"),
                    Status = Status.Active,
                    Title = "Renk",
                    Slug = "Mevcut Diğer Renkler",
                    SortOrder = 1

                }
             
                );
        }
    }
}
