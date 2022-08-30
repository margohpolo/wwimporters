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
    public class StockGroupEntityConfiguration : IEntityTypeConfiguration<StockGroup>
    {
        public void Configure(EntityTypeBuilder<StockGroup> builder)
        {
            builder.ToTable("StockGroups", "Warehouse");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("StockGroups_Archive", "Warehouse");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.StockGroupName, "UQ_Warehouse_StockGroups_StockGroupName")
                .IsUnique();

            builder.Property(e => e.StockGroupId)
                .HasColumnName("StockGroupID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockGroupID])");

            builder.Property(e => e.StockGroupName).HasMaxLength(58);
        }
    }
}
