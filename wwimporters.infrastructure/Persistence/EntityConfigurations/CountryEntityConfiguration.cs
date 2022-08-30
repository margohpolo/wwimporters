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
    public class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries", "Application");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("Countries_Archive", "Application");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.CountryName, "UQ_Application_Countries_CountryName")
                .IsUnique();

            builder.HasIndex(e => e.FormalName, "UQ_Application_Countries_FormalName")
                .IsUnique();

            builder.Property(e => e.CountryId)
                .HasColumnName("CountryID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CountryID])");

            builder.Property(e => e.Continent).HasMaxLength(38);

            builder.Property(e => e.CountryName).HasMaxLength(68);

            builder.Property(e => e.CountryType).HasMaxLength(28);

            builder.Property(e => e.FormalName).HasMaxLength(68);

            builder.Property(e => e.IsoAlpha3Code).HasMaxLength(11);

            builder.Property(e => e.Region).HasMaxLength(38);

            builder.Property(e => e.Subregion).HasMaxLength(38);
        }
    }
}
