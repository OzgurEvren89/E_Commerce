using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class PhoneNumberTypeSeedData : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.HasData(

                new PhoneNumberType
                {
                    Id = Guid.Parse("4726A3AA-3A0C-4FF3-B684-9B2C6766329E"),
                    Status = Status.Active,
                    Name = "Ev Telefonu"

                },
                new PhoneNumberType
                {
                    Id = Guid.Parse("FB820515-4FE0-45FB-8F52-501478DDE166"),
                    Status = Status.Active,
                    Name = "İş Telefonu"

                },
                new PhoneNumberType
                {
                    Id = Guid.Parse("73738DA4-B457-48CB-B35D-3F2F469614E4"),
                    Status = Status.Active,
                    Name = "Cep Telefonu"
                },
                new PhoneNumberType
                {
                    Id = Guid.Parse("58FAD403-9C67-481B-A722-8BA260391E52"),
                    Status = Status.Active,
                    Name = "Fax"
                },
                new PhoneNumberType
                {
                    Id = Guid.Parse("69649C24-512C-463B-ADD1-25EC970D3D9E"),
                    Status = Status.Active,
                    Name = "Diğer"
                }

                );
        }
    }
}
