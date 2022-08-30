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
    public class StockItemStockGroupEntityConfiguration : IEntityTypeConfiguration<StockItemStockGroup>
    {
        public void Configure(EntityTypeBuilder<StockItemStockGroup> builder)
        {
            builder.ToTable("StockItemStockGroups", "Warehouse");

            builder.HasIndex(e => new { e.StockGroupId, e.StockItemId }, "UQ_StockItemStockGroups_StockGroupID_Lookup")
                .IsUnique();

            builder.HasIndex(e => new { e.StockItemId, e.StockGroupId }, "UQ_StockItemStockGroups_StockItemID_Lookup")
                .IsUnique();

            builder.Property(e => e.StockItemStockGroupId)
                .HasColumnName("StockItemStockGroupID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockItemStockGroupID])");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.StockGroupId).HasColumnName("StockGroupID");

            builder.Property(e => e.StockItemId).HasColumnName("StockItemID");
        }
    }
}
