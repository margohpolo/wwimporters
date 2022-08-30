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

            builder.HasIndex(e => e.BuyingGroupId, "FK_Sales_SpecialDeals_BuyingGroupID");

            builder.HasIndex(e => e.CustomerCategoryId, "FK_Sales_SpecialDeals_CustomerCategoryID");

            builder.HasIndex(e => e.CustomerId, "FK_Sales_SpecialDeals_CustomerID");

            builder.HasIndex(e => e.StockGroupId, "FK_Sales_SpecialDeals_StockGroupID");

            builder.HasIndex(e => e.StockItemId, "FK_Sales_SpecialDeals_StockItemID");

            builder.Property(e => e.SpecialDealId)
                .HasColumnName("SpecialDealID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SpecialDealID])");

            builder.Property(e => e.BuyingGroupId).HasColumnName("BuyingGroupID");

            builder.Property(e => e.CustomerCategoryId).HasColumnName("CustomerCategoryID");

            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");

            builder.Property(e => e.DealDescription).HasMaxLength(38);

            builder.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 3)");

            builder.Property(e => e.EndDate).HasColumnType("date");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.StartDate).HasColumnType("date");

            builder.Property(e => e.StockGroupId).HasColumnName("StockGroupID");

            builder.Property(e => e.StockItemId).HasColumnName("StockItemID");

            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
        }
    }
}
