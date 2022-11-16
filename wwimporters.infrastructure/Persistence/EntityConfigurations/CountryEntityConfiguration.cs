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

            builder.HasComment("Countries that contain the states or provinces (including geographic boundaries)");

            builder.HasIndex(e => e.CountryName, "UQ_Application_Countries_CountryName")
                .IsUnique();

            builder.HasIndex(e => e.FormalName, "UQ_Application_Countries_FormalName")
                .IsUnique();

            builder.Property(e => e.CountryId)
                .HasColumnName("CountryID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CountryID])")
                .HasComment("Numeric ID used for reference to a country within the database");

            builder.Property(e => e.CountryName)
                .HasComment("Name of the country")
                .HasMaxLength(60);

            builder.Property(e => e.FormalName)
                .HasComment("Full formal name of the country as agreed by United Nations")
                .HasMaxLength(60);

            builder.Property(e => e.IsoAlpha3Code)
                .HasComment("3 letter alphabetic code assigned to the country by ISO")
                .HasMaxLength(3);

            builder.Property(e => e.IsoNumericCode)
                .HasComment("Numeric code assigned to the country by ISO");

            builder.Property(e => e.CountryType)
                .HasComment("Type of country or administrative region")
                .HasMaxLength(20);

            builder.Property(e => e.LatestRecordedPopulation)
                .HasComment("Latest available population for the country");

            builder.Property(e => e.Continent)
                .HasComment("Name of the continent")
                .HasMaxLength(30);

            builder.Property(e => e.Region)
                .HasComment("Name of the region")
                .HasMaxLength(30);

            builder.Property(e => e.Subregion)
                .HasComment("Name of the subregion")
                .HasMaxLength(30);

            builder.Property(e => e.Border)
                .HasComment("Geographic border of the country as described by the United Nations");
        }
    }
}
