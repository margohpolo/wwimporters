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

            builder.HasComment("Cities that are part of any address (including geographic location)");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("Cities_Archive", "Application");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.StateProvinceId, "FK_Application_Cities_StateProvinceID");

            builder.Property(e => e.CityId)
                .HasColumnName("CityID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CityID])")
                .HasComment("Numeric ID used for reference to a city within the database");

            builder.Property(e => e.CityName)
                .HasMaxLength(58)
                .HasComment("Formal name of the city");

            builder.Property(e => e.StateProvinceId)
                .HasColumnName("StateProvinceID")
                .HasComment("State or province for this city. Has a foreign key");

            builder.Property(e => e.Location)
                .HasComment("Geographic location of the city");

            builder.Property(e => e.LatestRecordedPopulation)
                .HasComment("Latest available population for the City");

        }
    }
}
