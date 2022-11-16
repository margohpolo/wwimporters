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
    public class SpecialDealEntityConfiguration : IEntityTypeConfiguration<SpecialDeal>
    {
        public void Configure(EntityTypeBuilder<SpecialDeal> builder)
        {
            builder.ToTable("SpecialDeals", "Sales");

            builder.HasComment("Special pricing (can include fixed prices, discount $ or discount %)");

            builder.HasIndex(e => e.BuyingGroupId, "FK_Sales_SpecialDeals_BuyingGroupID");

            builder.HasIndex(e => e.CustomerCategoryId, "FK_Sales_SpecialDeals_CustomerCategoryID");

            builder.HasIndex(e => e.CustomerId, "FK_Sales_SpecialDeals_CustomerID");

            builder.HasIndex(e => e.StockGroupId, "FK_Sales_SpecialDeals_StockGroupID");

            builder.HasIndex(e => e.StockItemId, "FK_Sales_SpecialDeals_StockItemID");



            builder.Property(e => e.SpecialDealId)
                .HasColumnName("SpecialDealID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SpecialDealID])")
                .HasComment("ID (sequence based) for a special deal");

            builder.Property(e => e.StockItemId)
                .HasColumnName("StockItemID")
                .HasComment("Stock item that the deal applies to (if NULL, then only discounts are permitted not unit prices)");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasComment("ID of the customer that the special pricing applies to (if NULL then all customers)");

            builder.Property(e => e.BuyingGroupId)
                .HasColumnName("BuyingGroupID")
                .HasComment("ID of the buying group that the special pricing applies to (optional)");

            builder.Property(e => e.CustomerCategoryId)
                .HasColumnName("CustomerCategoryID")
                .HasComment("ID of the customer category that the special pricing applies to (optional)");

            builder.Property(e => e.StockGroupId)
                .HasColumnName("StockGroupID")
                .HasComment("ID of the stock group that the special pricing applies to (optional)");

            builder.Property(e => e.DealDescription)
                .HasMaxLength(30)
                .HasComment("Description of the special deal");

            builder.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasComment("Date that the special pricing starts from");

            builder.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasComment("Date that the special pricing ends on");

            builder.Property(e => e.DiscountAmount)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Discount per unit to be applied to sale price (optional)");

            builder.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(18, 3)")
                .HasComment("\tDiscount percentage per unit to be applied to sale price (optional)");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Special price per unit to be applied instead of sale price (optional)");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");
        }
    }
}
