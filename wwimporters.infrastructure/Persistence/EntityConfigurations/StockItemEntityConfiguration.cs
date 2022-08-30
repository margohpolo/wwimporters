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
    public class StockItemEntityConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.ToTable("StockItems", "Warehouse");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("StockItems_Archive", "Warehouse");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.ColorId, "FK_Warehouse_StockItems_ColorID");

            builder.HasIndex(e => e.OuterPackageId, "FK_Warehouse_StockItems_OuterPackageID");

            builder.HasIndex(e => e.SupplierId, "FK_Warehouse_StockItems_SupplierID");

            builder.HasIndex(e => e.UnitPackageId, "FK_Warehouse_StockItems_UnitPackageID");

            builder.HasIndex(e => e.StockItemName, "UQ_Warehouse_StockItems_StockItemName")
                .IsUnique();

            builder.Property(e => e.StockItemId)
                .HasColumnName("StockItemID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockItemID])");

            builder.Property(e => e.Barcode).HasMaxLength(58);

            builder.Property(e => e.Brand).HasMaxLength(58);

            builder.Property(e => e.ColorId).HasColumnName("ColorID");

            builder.Property(e => e.OuterPackageId).HasColumnName("OuterPackageID");

            builder.Property(e => e.RecommendedRetailPrice).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.SearchDetails).HasComputedColumnSql("(concat([StockItemName],N' ',[MarketingComments]))", false);

            builder.Property(e => e.Size).HasMaxLength(28);

            builder.Property(e => e.StockItemName).HasMaxLength(107);

            builder.Property(e => e.SupplierId).HasColumnName("SupplierID");

            builder.Property(e => e.Tags).HasComputedColumnSql("(json_query([CustomFields],N'$.Tags'))", false);

            builder.Property(e => e.TaxRate).HasColumnType("decimal(18, 3)");

            builder.Property(e => e.TypicalWeightPerUnit).HasColumnType("decimal(18, 3)");

            builder.Property(e => e.UnitPackageId).HasColumnName("UnitPackageID");

            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
        }
    }
}
