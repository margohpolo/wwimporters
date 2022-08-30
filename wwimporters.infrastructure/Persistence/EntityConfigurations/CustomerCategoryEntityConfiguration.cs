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
    public class CustomerCategoryEntityConfiguration : IEntityTypeConfiguration<CustomerCategory>
    {
        public void Configure(EntityTypeBuilder<CustomerCategory> builder)
        {
            builder.ToTable("CustomerCategories", "Sales");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("CustomerCategories_Archive", "Sales");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.CustomerCategoryName, "UQ_Sales_CustomerCategories_CustomerCategoryName")
                .IsUnique();

            builder.Property(e => e.CustomerCategoryId)
                .HasColumnName("CustomerCategoryID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CustomerCategoryID])");

            builder.Property(e => e.CustomerCategoryName).HasMaxLength(58);
        }
    }
}
