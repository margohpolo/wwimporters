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
    public class SupplierCategoryEntityConfiguration : IEntityTypeConfiguration<SupplierCategory>
    {
        public void Configure(EntityTypeBuilder<SupplierCategory> builder)
        {
            builder.ToTable("SupplierCategories", "Purchasing");

            builder.HasComment("Categories for suppliers (ie novelties, toys, clothing, packaging, etc.)");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("SupplierCategories_Archive", "Purchasing");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.SupplierCategoryName, "UQ_Purchasing_SupplierCategories_SupplierCategoryName")
                .IsUnique();

            builder.Property(e => e.SupplierCategoryId)
                .HasColumnName("SupplierCategoryID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SupplierCategoryID])")
                .HasComment("Numeric ID used for reference to a supplier category within the database");

            builder.Property(e => e.SupplierCategoryName)
                .HasMaxLength(50)
                .HasComment("Full name of the category that suppliers can be assigned to");
        }
    }
}
