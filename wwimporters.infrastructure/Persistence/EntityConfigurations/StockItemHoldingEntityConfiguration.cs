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
    public class StockItemHoldingEntityConfiguration : IEntityTypeConfiguration<StockItemHolding>
    {
        public void Configure(EntityTypeBuilder<StockItemHolding> builder)
        {
            builder.HasKey(e => e.StockItemId)
                .HasName("PK_Warehouse_StockItemHoldings");

            builder.ToTable("StockItemHoldings", "Warehouse");

            builder.Property(e => e.StockItemId)
                .ValueGeneratedNever()
                .HasColumnName("StockItemID");

            builder.Property(e => e.BinLocation).HasMaxLength(28);

            builder.Property(e => e.LastCostPrice).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

        }
    }
}
