using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class AddressTypeSeedData : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.HasData(

                new AddressType
                {
                    Id = Guid.Parse("6278FE0E-4E04-4DBE-B2D8-D6D2DF22694D"),
                    Status = Status.Active,
                    TypeName = "Ev Adresi",

                },
                new AddressType
                {
                    Id = Guid.Parse("EF7428EB-9C56-49CE-907C-209EA650AC38"),
                    Status = Status.Active,
                    TypeName = "İş Adresi",

                }
               

                );
        }
    }
}
