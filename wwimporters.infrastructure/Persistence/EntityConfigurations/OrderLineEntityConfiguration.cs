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

            builder.HasComment("Detail lines from customer orders");

            builder.HasIndex(e => e.OrderId, "FK_Sales_OrderLines_OrderID");

            builder.HasIndex(e => e.PackageTypeId, "FK_Sales_OrderLines_PackageTypeID");

            builder.HasIndex(e => e.StockItemId, "IX_Sales_OrderLines_AllocatedStockItems");

            builder.HasIndex(e => new { e.PickingCompletedWhen, e.OrderId, e.OrderLineId }, "IX_Sales_OrderLines_Perf_20160301_01");

            builder.HasIndex(e => new { e.StockItemId, e.PickingCompletedWhen }, "IX_Sales_OrderLines_Perf_20160301_02");



            builder.Property(e => e.OrderLineId)
                .HasColumnName("OrderLineID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[OrderLineID])")
                .HasComment("Numeric ID used for reference to a line on an Order within the database");

            builder.Property(e => e.OrderId)
                .HasColumnName("OrderID")
                .HasComment("Order that this line is associated with");

            builder.Property(e => e.StockItemId)
                .HasColumnName("StockItemID")
                .HasComment("Stock item for this order line (FK not indexed as separate index exists)");

            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .HasComment("Description of the item supplied (Usually the stock item name but can be overridden)");

            builder.Property(e => e.PackageTypeId)
                .HasColumnName("PackageTypeID")
                .HasComment("Type of package to be supplied");

            builder.Property(e => e.Quantity)
                .HasComment("Quantity to be supplied");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Unit price to be charged");

            builder.Property(e => e.TaxRate)
                .HasColumnType("decimal(18, 3)")
                .HasComment("Tax rate to be applied");

            builder.Property(e => e.PickedQuantity)
                .HasComment("Quantity picked from stock");

            builder.Property(e => e.PickingCompletedWhen)
                .HasComment("When was picking of this line completed?");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");
        }
    }
}
