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

            builder.HasComment("Non-temporal attributes for stock items");

            builder.Property(e => e.StockItemId)
                .ValueGeneratedNever()
                .HasColumnName("StockItemID")
                .HasComment("ID of the stock item that this holding relates to (this table holds non-temporal columns for stock)");

            builder.Property(e => e.QuantityOnHand)
                .HasComment("Quantity currently on hand (if tracked)");

            builder.Property(e => e.BinLocation)
                .HasMaxLength(20)
                .HasComment("Bin location (ie location of this stock item within the depot)");

            builder.Property(e => e.LastStocktakeQuantity)
                .HasComment("Quantity at last stocktake (if tracked)");

            builder.Property(e => e.LastCostPrice)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Unit cost price the last time this stock item was purchased");

            builder.Property(e => e.ReorderLevel)
                .HasComment("Quantity below which reordering should take place");

            builder.Property(e => e.TargetStockLevel)
                .HasComment("Typical quantity ordered");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");

        }
    }
}
