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
    public class Supplier1EntityConfiguration : IEntityTypeConfiguration<Supplier1>
    {
        public void Configure(EntityTypeBuilder<Supplier1> builder)
        {
            builder.HasNoKey();

            builder.ToView("Suppliers", "Website");

            builder.Property(e => e.AlternateContact).HasMaxLength(58);

            builder.Property(e => e.CityName).HasMaxLength(58);

            builder.Property(e => e.DeliveryMethod).HasMaxLength(58);

            builder.Property(e => e.FaxNumber).HasMaxLength(28);

            builder.Property(e => e.PhoneNumber).HasMaxLength(28);

            builder.Property(e => e.PrimaryContact).HasMaxLength(58);

            builder.Property(e => e.SupplierCategoryName).HasMaxLength(58);

            builder.Property(e => e.SupplierId).HasColumnName("SupplierID");

            builder.Property(e => e.SupplierName).HasMaxLength(107);

            builder.Property(e => e.SupplierReference).HasMaxLength(28);

            builder.Property(e => e.WebsiteUrl)
                .HasMaxLength(264)
                .HasColumnName("WebsiteURL");
        }
    }
}
