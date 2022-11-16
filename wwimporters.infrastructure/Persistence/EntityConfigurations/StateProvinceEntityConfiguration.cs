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
    public class StateProvinceEntityConfiguration : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.ToTable("StateProvinces", "Application");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("StateProvinces_Archive", "Application");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasComment("States or provinces that contain cities (including geographic location)");

            builder.HasIndex(e => e.CountryId, "FK_Application_StateProvinces_CountryID");

            builder.HasIndex(e => e.SalesTerritory, "IX_Application_StateProvinces_SalesTerritory");

            builder.HasIndex(e => e.StateProvinceName, "UQ_Application_StateProvinces_StateProvinceName")
                .IsUnique();

            builder.Property(e => e.StateProvinceId)
                .HasColumnName("StateProvinceID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StateProvinceID])")
                .HasComment("Numeric ID used for reference to a state or province within the database");

            builder.Property(e => e.StateProvinceCode)
                .HasMaxLength(5)
                .HasComment("Common code for this state or province (such as WA - Washington for the USA)");

            builder.Property(e => e.StateProvinceName)
                .HasMaxLength(50)
                .HasComment("Formal name of the state or province");

            builder.Property(e => e.CountryId)
                .HasColumnName("CountryID")
                .HasComment("Country for this StateProvince");

            builder.Property(e => e.SalesTerritory)
                .HasMaxLength(50)
                .HasComment("Sales territory for this StateProvince");

            builder.Property(e => e.Border)
                .HasComment("Geographic boundary of the state or province");

            builder.Property(e => e.LatestRecordedPopulation)
                .HasComment("Latest available population for the StateProvince");


        }
    }
}
