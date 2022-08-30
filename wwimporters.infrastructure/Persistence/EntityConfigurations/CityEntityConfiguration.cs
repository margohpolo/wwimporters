using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wwimporters.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwimporters.infrastructure.Persistence.EntityConfigurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities", "Application");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("Cities_Archive", "Application");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.StateProvinceId, "FK_Application_Cities_StateProvinceID");

            builder.Property(e => e.CityId)
                .HasColumnName("CityID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CityID])");

            builder.Property(e => e.CityName).HasMaxLength(58);

            builder.Property(e => e.StateProvinceId).HasColumnName("StateProvinceID");
        }
    }
}
