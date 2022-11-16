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
    public class StockGroupEntityConfiguration : IEntityTypeConfiguration<StockGroup>
    {
        public void Configure(EntityTypeBuilder<StockGroup> builder)
        {
            builder.ToTable("StockGroups", "Warehouse");

            builder.HasComment("Groups for categorizing stock items (ie: novelties, toys, edible novelties, etc.)");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("StockGroups_Archive", "Warehouse");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.StockGroupName, "UQ_Warehouse_StockGroups_StockGroupName")
                .IsUnique();

            builder.Property(e => e.StockGroupId)
                .HasColumnName("StockGroupID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockGroupID])")
                .HasComment("Numeric ID used for reference to a stock group within the database");

            builder.Property(e => e.StockGroupName)
                .HasMaxLength(50)
                .HasComment("Full name of groups used to categorize stock items");
        }
    }
}
