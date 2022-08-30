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
    public class PackageTypeEntityConfiguration : IEntityTypeConfiguration<PackageType>
    {
        public void Configure(EntityTypeBuilder<PackageType> builder)
        {
            builder.ToTable("PackageTypes", "Warehouse");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("PackageTypes_Archive", "Warehouse");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.PackageTypeName, "UQ_Warehouse_PackageTypes_PackageTypeName")
                .IsUnique();

            builder.Property(e => e.PackageTypeId)
                .HasColumnName("PackageTypeID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PackageTypeID])");

            builder.Property(e => e.PackageTypeName).HasMaxLength(58);
        }
    }
}
