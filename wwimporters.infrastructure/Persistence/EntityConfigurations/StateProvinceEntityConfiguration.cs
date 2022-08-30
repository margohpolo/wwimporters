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

            builder.HasIndex(e => e.CountryId, "FK_Application_StateProvinces_CountryID");

            builder.HasIndex(e => e.SalesTerritory, "IX_Application_StateProvinces_SalesTerritory");

            builder.HasIndex(e => e.StateProvinceName, "UQ_Application_StateProvinces_StateProvinceName")
                .IsUnique();

            builder.Property(e => e.StateProvinceId)
                .HasColumnName("StateProvinceID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StateProvinceID])");

            builder.Property(e => e.CountryId).HasColumnName("CountryID");

            builder.Property(e => e.SalesTerritory).HasMaxLength(58);

            builder.Property(e => e.StateProvinceCode).HasMaxLength(11);

            builder.Property(e => e.StateProvinceName).HasMaxLength(58);
        }
    }
}
