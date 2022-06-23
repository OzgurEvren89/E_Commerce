using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class PhoneNumberTypeMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<PhoneNumberType>(entity =>
            {
                entity.ToTable("PhoneNumberTypes");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);

           
            });
        }
    }
}
