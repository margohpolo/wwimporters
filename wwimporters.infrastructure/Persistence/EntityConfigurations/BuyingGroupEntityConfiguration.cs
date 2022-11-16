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

            builder.HasComment("Customer organizations can be part of groups that exert greater buying power");

            builder.HasIndex(e => e.BuyingGroupName, "UQ_Sales_BuyingGroups_BuyingGroupName")
                    .IsUnique();

            builder.Property(e => e.BuyingGroupId)
                .HasColumnName("BuyingGroupID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[BuyingGroupID])")
                .HasComment("Numeric ID used for reference to a buying group within the database");

            builder.Property(e => e.BuyingGroupName)
                .HasMaxLength(50)
                .HasComment("Full name of a buying group that customers can be members of");


        }
    }
}
