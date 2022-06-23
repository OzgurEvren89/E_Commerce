using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.Common.Enums;
using Proje.Model.Entities;
using System;

namespace Proje.Model.SeedData
{
    public class UserSeedData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    Email = "admin@admin.com",
                    Password = "123",
                    FirstName = "Admin",
                    LastName = "ADMIN",
                    Title = "Admin",
                    ImageUrl = "/",
                    LastIPAdress = "127.0.0.1",
                    LastLogin = DateTime.Now
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Status = Status.Active,
                    Email = "ozgur@ozgur.com",
                    Password = "123",
                    FirstName = "Ozgur",
                    LastName = "EVREN",
                    Title = "Normal",
                    ImageUrl = "/",
                    LastIPAdress = "127.0.0.1",
                    LastLogin = DateTime.Now
                }

                );

        }
    }
}
