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

            builder.HasComment("Categories for customers (ie restaurants, cafes, supermarkets, etc.)");

            builder.HasIndex(e => e.CustomerCategoryName, "UQ_Sales_CustomerCategories_CustomerCategoryName")
                .IsUnique();

            builder.Property(e => e.CustomerCategoryId)
                .HasColumnName("CustomerCategoryID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CustomerCategoryID])")
                .HasComment("Numeric ID used for reference to a customer category within the database");

            builder.Property(e => e.CustomerCategoryName)
                .HasMaxLength(50)
                .HasComment("Full name of the category that customers can be assigned to");
        }
    }
}
