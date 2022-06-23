using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class InstallmentRateSeedData : IEntityTypeConfiguration<InstallmentRate>
    {
        public void Configure(EntityTypeBuilder<InstallmentRate> builder)
        {
            builder.HasData(

                new InstallmentRate
                {
                    Id = Guid.Parse("C86C8CB4-4A3F-478A-9375-6EFE790AE864"),
                    Status = Status.Active,
                    Installment = 3,
                    Rate = Convert.ToDecimal("0,18"),
                    PaymentGatewayId = Guid.Parse("EB183C77-CC12-45E0-9792-57F2318DDF71"),

                },
                new InstallmentRate
                {
                    Id = Guid.Parse("DF5846FA-84D6-4D4B-B47E-60B847CC1C3A"),
                    Status = Status.Active,
                    Installment = 6,
                    Rate = Convert.ToDecimal("0,20"),
                    PaymentGatewayId = Guid.Parse("EB183C77-CC12-45E0-9792-57F2318DDF71"),

                },
                new InstallmentRate
                {
                    Id = Guid.Parse("FADAAC3D-A3AE-42CD-94A1-D980917518BA"),
                    Status = Status.Active,
                    Installment = 9,
                    Rate = Convert.ToDecimal("0,23"),
                    PaymentGatewayId = Guid.Parse("EB183C77-CC12-45E0-9792-57F2318DDF71"),

                },
                new InstallmentRate
                {
                    Id = Guid.Parse("6A23D070-9303-445C-87AD-92624CAE21DF"),
                    Status = Status.Active,
                    Installment = 12,
                    Rate = Convert.ToDecimal("0,25"),
                    PaymentGatewayId = Guid.Parse("EB183C77-CC12-45E0-9792-57F2318DDF71"),

                },
                new InstallmentRate
                {
                    Id = Guid.Parse("918D7196-EC1D-4FE0-A8D4-72DF98ECF433"),
                    Status = Status.Active,
                    Installment = 15,
                    Rate = Convert.ToDecimal("0,30"),
                    PaymentGatewayId = Guid.Parse("EB183C77-CC12-45E0-9792-57F2318DDF71"),

                },
                //---------------------
                new InstallmentRate
                {
                    Id = Guid.Parse("BCBB2945-7340-4C66-9FE5-54D4DA5465FC"),
                    Status = Status.Active,
                    Installment = 3,
                    Rate = Convert.ToDecimal("0,15"),
                    PaymentGatewayId = Guid.Parse("35AF2FF3-8B97-43F3-8176-59982291B012"),
                },
                new InstallmentRate
                {
                    Id = Guid.Parse("415DD76E-8D3D-4AC8-A9BD-C4E24E7BA45F"),
                    Status = Status.Active,
                    Installment = 6,
                    Rate = Convert.ToDecimal("0,18"),
                    PaymentGatewayId = Guid.Parse("35AF2FF3-8B97-43F3-8176-59982291B012"),
                },
                new InstallmentRate
                {
                    Id = Guid.Parse("41EFFD73-3624-4185-A8EB-A37CD830585C"),
                    Status = Status.Active,
                    Installment = 10,
                    Rate = Convert.ToDecimal("0,22"),
                    PaymentGatewayId = Guid.Parse("35AF2FF3-8B97-43F3-8176-59982291B012"),
                },
                new InstallmentRate
                {
                    Id = Guid.Parse("89D4E81C-7632-4C90-8E12-9B265B9BAAEE"),
                    Status = Status.Active,
                    Installment = 15,
                    Rate = Convert.ToDecimal("0,32"),
                    PaymentGatewayId = Guid.Parse("35AF2FF3-8B97-43F3-8176-59982291B012"),
                }

                );
        }
    }
}
