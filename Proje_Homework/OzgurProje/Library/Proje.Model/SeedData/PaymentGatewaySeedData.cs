using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class PaymentGatewaySeedData : IEntityTypeConfiguration<PaymentGateway>
    {
        public void Configure(EntityTypeBuilder<PaymentGateway> builder)
        {
            builder.HasData(

                new PaymentGateway
                {
                    Id = Guid.Parse("EB183C77-CC12-45E0-9792-57F2318DDF71"),
                    Status = Status.Active,
                    Code = "VkfBnk",
                    Name = "Vakıf Bank",
                    SortOrder = 1

                },
                new PaymentGateway
                {
                    Id = Guid.Parse("35AF2FF3-8B97-43F3-8176-59982291B012"),
                    Status = Status.Active,
                    Code = "FnsBnk",
                    Name = "Finans Bank",
                    SortOrder = 2
                }
              
                 
                );
        }
    }
}
