using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;


namespace Proje.Model.Maps
{
    public class PaymentMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.HasExtended();

                entity.Property(x => x.UserFirstname).HasMaxLength(250).IsRequired(true);
                entity.Property(x => x.UserSurname).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.UserEmail).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.UserPhone).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.PaymentTypeName).HasMaxLength(255).IsRequired(false);//çevirecem tablo oluşunca true
                entity.Property(x => x.PaymentGatewayName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.PaymentGatewayCode).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.FinalAmount).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.SumOfGainedPoints).IsRequired(true);
                entity.Property(x => x.Installment).IsRequired(true);
                entity.Property(x => x.InstallmentRate).IsRequired(true);
                entity.Property(x => x.Currency).IsRequired(true);
                entity.Property(x => x.UserNote).HasMaxLength(255).IsRequired(false);

                entity
                     .HasOne(c => c.PaymentStatus)
                     .WithMany(u => u.Payments)
                     .HasForeignKey(c => c.PaymentStatusId);
                entity
                    .HasOne(c => c.CreatedUserPayment)
                    .WithMany(u => u.CreatedUserPayments)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserPayment)
                   .WithMany(u => u.ModifiedUserPayments)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
