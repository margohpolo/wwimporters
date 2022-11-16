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

            builder.HasComment("Detail lines from supplier purchase orders");

            builder.HasIndex(e => e.PackageTypeId, "FK_Purchasing_PurchaseOrderLines_PackageTypeID");

            builder.HasIndex(e => e.PurchaseOrderId, "FK_Purchasing_PurchaseOrderLines_PurchaseOrderID");

            builder.HasIndex(e => e.StockItemId, "FK_Purchasing_PurchaseOrderLines_StockItemID");

            builder.HasIndex(e => new { e.IsOrderLineFinalized, e.StockItemId }, "IX_Purchasing_PurchaseOrderLines_Perf_20160301_4");

            builder.Property(e => e.PurchaseOrderLineId)
                .HasColumnName("PurchaseOrderLineID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PurchaseOrderLineID])")
                .HasComment("Numeric ID used for reference to a line on a purchase order within the database");

            builder.Property(e => e.PurchaseOrderId)
                .HasColumnName("PurchaseOrderID")
                .HasComment("Purchase order that this line is associated with");

            builder.Property(e => e.StockItemId)
                .HasColumnName("StockItemID")
                .HasComment("Stock item for this purchase order line");

            builder.Property(e => e.OrderedOuters)
                .HasComment("Quantity of the stock item that is ordered");

            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .HasComment("Description of the item to be supplied (Often the stock item name but could be supplier description)");

            builder.Property(e => e.ReceivedOuters)
                .HasComment("Total quantity of the stock item that has been received so far");

            builder.Property(e => e.PackageTypeId)
                .HasColumnName("PackageTypeID")
                .HasComment("Type of package received");

            builder.Property(e => e.ExpectedUnitPricePerOuter)
                .HasColumnType("decimal(18, 2)")
                .HasComment("The unit price that we expect to be charged");

            builder.Property(e => e.LastReceiptDate)
                .HasColumnType("date")
                .HasComment("The last date on which this stock item was received for this purchase order");

            builder.Property(e => e.IsOrderLineFinalized)
                .HasComment("Is this purchase order line now considered finalized? (Receipted quantities and weights are often not precise)");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");
        }
    }
}
