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
    public class PurchaseOrderLineEntityConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
        {
            builder.ToTable("PurchaseOrderLines", "Purchasing");

            builder.HasIndex(e => e.PackageTypeId, "FK_Purchasing_PurchaseOrderLines_PackageTypeID");

            builder.HasIndex(e => e.PurchaseOrderId, "FK_Purchasing_PurchaseOrderLines_PurchaseOrderID");

            builder.HasIndex(e => e.StockItemId, "FK_Purchasing_PurchaseOrderLines_StockItemID");

            builder.HasIndex(e => new { e.IsOrderLineFinalized, e.StockItemId }, "IX_Purchasing_PurchaseOrderLines_Perf_20160301_4");

            builder.Property(e => e.PurchaseOrderLineId)
                .HasColumnName("PurchaseOrderLineID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PurchaseOrderLineID])");

            builder.Property(e => e.Description).HasMaxLength(107);

            builder.Property(e => e.ExpectedUnitPricePerOuter).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.LastReceiptDate).HasColumnType("date");

            builder.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");

            builder.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

            builder.Property(e => e.StockItemId).HasColumnName("StockItemID");
        }
    }
}
