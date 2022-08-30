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
    public class Customer1EntityConfiguration : IEntityTypeConfiguration<Customer1>
    {
        public void Configure(EntityTypeBuilder<Customer1> builder)
        {
            builder.HasNoKey();

            builder.ToView("Customers", "Website");

            builder.Property(e => e.AlternateContact).HasMaxLength(58);

            builder.Property(e => e.BuyingGroupName).HasMaxLength(58);

            builder.Property(e => e.CityName).HasMaxLength(58);

            builder.Property(e => e.CustomerCategoryName).HasMaxLength(58);

            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");

            builder.Property(e => e.CustomerName).HasMaxLength(107);

            builder.Property(e => e.DeliveryMethod).HasMaxLength(58);

            builder.Property(e => e.DeliveryRun).HasMaxLength(11);

            builder.Property(e => e.FaxNumber).HasMaxLength(28);

            builder.Property(e => e.PhoneNumber).HasMaxLength(28);

            builder.Property(e => e.PrimaryContact).HasMaxLength(58);

            builder.Property(e => e.RunPosition).HasMaxLength(11);

            builder.Property(e => e.WebsiteUrl)
                .HasMaxLength(264)
                .HasColumnName("WebsiteURL");
        }
    }
}
