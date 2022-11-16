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

            builder.HasComment("Main entity table for stock items");

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
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockItemID])")
                .HasComment("Numeric ID used for reference to a stock item within the database");

            builder.Property(e => e.StockItemName)
                .HasMaxLength(100)
                .HasComment("Full name of a stock item (but not a full description)");

            builder.Property(e => e.SupplierId)
                .HasColumnName("SupplierID")
                .HasComment("Usual supplier for this stock item");

            builder.Property(e => e.ColorId)
                .HasColumnName("ColorID")
                .HasComment("Color (optional) for this stock item");

            builder.Property(e => e.UnitPackageId)
                .HasColumnName("UnitPackageID")
                .HasComment("Usual package for selling units of this stock item");

            builder.Property(e => e.OuterPackageId)
                .HasColumnName("OuterPackageID")
                .HasComment("Usual package for selling outers of this stock item (ie cartons, boxes, etc.)");

            builder.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasComment("Brand for the stock item (if the item is branded)");

            builder.Property(e => e.Size)
                .HasMaxLength(20)
                .HasComment("Size of this item (eg: 100mm)");

            builder.Property(e => e.LeadTimeDays)
                .HasComment("Number of days typically taken from order to receipt of this stock item");

            builder.Property(e => e.QuantityPerOuter)
                .HasComment("Quantity of the stock item in an outer package");

            builder.Property(e => e.IsChillerStock)
                .HasComment("Does this stock item need to be in a chiller?");

            builder.Property(e => e.Barcode)
                .HasMaxLength(50)
                .HasComment("Barcode for this stock item");

            builder.Property(e => e.TaxRate)
                .HasColumnType("decimal(18, 3)")
                .HasComment("Tax rate to be applied");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Selling price (ex-tax) for one unit of this product");

            builder.Property(e => e.RecommendedRetailPrice)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Recommended retail price for this stock item");

            builder.Property(e => e.TypicalWeightPerUnit)
                .HasColumnType("decimal(18, 3)")
                .HasComment("Typical weight for one unit of this product (packaged)");

            builder.Property(e => e.MarketingComments)
                .HasComment("Marketing comments for this stock item (shared outside the organization)");

            builder.Property(e => e.InternalComments)
                .HasComment("Internal comments (not exposed outside organization)");

            builder.Property(e => e.Photo)
                .HasComment("Photo of the product");

            builder.Property(e => e.CustomFields)
                .HasComment("Custom fields added by system users");

            builder.Property(e => e.Tags)
                .HasComputedColumnSql("(json_query([CustomFields],N'$.Tags'))", false)
                .HasComment("Advertising tags associated with this stock item (JSON array retrieved from CustomFields)");

            builder.Property(e => e.SearchDetails)
                .HasComputedColumnSql("(concat([StockItemName],N' ',[MarketingComments]))", false)
                .HasComment("Combination of columns used by full text search");
        }
    }
}
