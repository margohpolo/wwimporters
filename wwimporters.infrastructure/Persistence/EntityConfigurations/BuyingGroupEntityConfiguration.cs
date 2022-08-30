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
    public class BuyingGroupEntityConfiguration : IEntityTypeConfiguration<BuyingGroup>
    {
        public void Configure(EntityTypeBuilder<BuyingGroup> builder)
        {
            builder.ToTable("BuyingGroups", "Sales");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("BuyingGroups_Archive", "Sales");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.BuyingGroupName, "UQ_Sales_BuyingGroups_BuyingGroupName")
                    .IsUnique();

            builder.Property(e => e.BuyingGroupId)
                .HasColumnName("BuyingGroupID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[BuyingGroupID])");

            builder.Property(e => e.BuyingGroupName).HasMaxLength(58);


        }
    }
}
