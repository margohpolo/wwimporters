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
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Sales");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("Customers_Archive", "Sales");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.AlternateContactPersonId, "FK_Sales_Customers_AlternateContactPersonID");

            builder.HasIndex(e => e.BuyingGroupId, "FK_Sales_Customers_BuyingGroupID");

            builder.HasIndex(e => e.CustomerCategoryId, "FK_Sales_Customers_CustomerCategoryID");

            builder.HasIndex(e => e.DeliveryCityId, "FK_Sales_Customers_DeliveryCityID");

            builder.HasIndex(e => e.DeliveryMethodId, "FK_Sales_Customers_DeliveryMethodID");

            builder.HasIndex(e => e.PostalCityId, "FK_Sales_Customers_PostalCityID");

            builder.HasIndex(e => e.PrimaryContactPersonId, "FK_Sales_Customers_PrimaryContactPersonID");

            builder.HasIndex(e => new { e.IsOnCreditHold, e.CustomerId, e.BillToCustomerId }, "IX_Sales_Customers_Perf_20160301_06");

            builder.HasIndex(e => e.CustomerName, "UQ_Sales_Customers_CustomerName")
                .IsUnique();

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CustomerID])");

            builder.Property(e => e.AccountOpenedDate).HasColumnType("date");

            builder.Property(e => e.AlternateContactPersonId).HasColumnName("AlternateContactPersonID");

            builder.Property(e => e.BillToCustomerId).HasColumnName("BillToCustomerID");

            builder.Property(e => e.BuyingGroupId).HasColumnName("BuyingGroupID");

            builder.Property(e => e.CreditLimit).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.CustomerCategoryId).HasColumnName("CustomerCategoryID");

            builder.Property(e => e.CustomerName).HasMaxLength(107);

            builder.Property(e => e.DeliveryAddressLine1).HasMaxLength(68);

            builder.Property(e => e.DeliveryAddressLine2).HasMaxLength(68);

            builder.Property(e => e.DeliveryCityId).HasColumnName("DeliveryCityID");

            builder.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");

            builder.Property(e => e.DeliveryPostalCode).HasMaxLength(18);

            builder.Property(e => e.DeliveryRun).HasMaxLength(11);

            builder.Property(e => e.FaxNumber).HasMaxLength(28);

            builder.Property(e => e.PhoneNumber).HasMaxLength(28);

            builder.Property(e => e.PostalAddressLine1).HasMaxLength(68);

            builder.Property(e => e.PostalAddressLine2).HasMaxLength(68);

            builder.Property(e => e.PostalCityId).HasColumnName("PostalCityID");

            builder.Property(e => e.PostalPostalCode).HasMaxLength(18);

            builder.Property(e => e.PrimaryContactPersonId).HasColumnName("PrimaryContactPersonID");

            builder.Property(e => e.RunPosition).HasMaxLength(11);

            builder.Property(e => e.StandardDiscountPercentage).HasColumnType("decimal(18, 3)");

            builder.Property(e => e.WebsiteUrl)
                .HasMaxLength(264)
                .HasColumnName("WebsiteURL");
        }
    }
}
