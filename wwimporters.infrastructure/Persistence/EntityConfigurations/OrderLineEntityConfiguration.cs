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
    public class OrderLineEntityConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("OrderLines", "Sales");

            builder.HasIndex(e => e.OrderId, "FK_Sales_OrderLines_OrderID");

            builder.HasIndex(e => e.PackageTypeId, "FK_Sales_OrderLines_PackageTypeID");

            builder.HasIndex(e => e.StockItemId, "IX_Sales_OrderLines_AllocatedStockItems");

            builder.HasIndex(e => new { e.PickingCompletedWhen, e.OrderId, e.OrderLineId }, "IX_Sales_OrderLines_Perf_20160301_01");

            builder.HasIndex(e => new { e.StockItemId, e.PickingCompletedWhen }, "IX_Sales_OrderLines_Perf_20160301_02");

            builder.Property(e => e.OrderLineId)
                .HasColumnName("OrderLineID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[OrderLineID])");

            builder.Property(e => e.Description).HasMaxLength(107);

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");

            builder.Property(e => e.StockItemId).HasColumnName("StockItemID");

            builder.Property(e => e.TaxRate).HasColumnType("decimal(18, 3)");

            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
        }
    }
}
