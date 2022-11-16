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

            builder.HasComment("Main entity tables for customers (organizations or individuals)");

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
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CustomerID])")
                .HasComment("Numeric ID used for reference to a customer within the database");

            builder.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .HasComment("Customer's full name (usually a trading name)");

            builder.Property(e => e.BillToCustomerId)
                .HasColumnName("BillToCustomerID")
                .HasComment("Customer that this is billed to (usually the same customer but can be another parent company)");

            builder.Property(e => e.CustomerCategoryId)
                .HasColumnName("CustomerCategoryID")
                .HasComment("Customer's category");

            builder.Property(e => e.BuyingGroupId)
                .HasColumnName("BuyingGroupID")
                .HasComment("Customer's buying group (optional)");

            builder.Property(e => e.PrimaryContactPersonId)
                .HasColumnName("PrimaryContactPersonID")
                .HasComment("Primary contact");

            builder.Property(e => e.AlternateContactPersonId)
                .HasColumnName("AlternateContactPersonID")
                .HasComment("Alternate contact");

            builder.Property(e => e.DeliveryMethodId)
                .HasColumnName("DeliveryMethodID")
                .HasComment("Standard delivery method for stock items sent to this customer");

            builder.Property(e => e.DeliveryCityId)
                .HasColumnName("DeliveryCityID")
                .HasComment("ID of the delivery city for this address");

            builder.Property(e => e.PostalCityId)
                .HasColumnName("PostalCityID")
                .HasComment("ID of the postal city for this address");

            builder.Property(e => e.CreditLimit)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Credit limit for this customer (NULL if unlimited)");

            builder.Property(e => e.AccountOpenedDate)
                .HasColumnType("date")
                .HasComment("Date this customer account was opened");

            builder.Property(e => e.StandardDiscountPercentage)
                .HasColumnType("decimal(18, 3)")
                .HasComment("Standard discount offered to this customer");

            builder.Property(e => e.IsStatementSent)
                .HasComment("Is a statement sent to this customer? (Or do they just pay on each invoice?)");

            builder.Property(e => e.IsOnCreditHold)
                .HasComment("Is this customer on credit hold? (Prevents further deliveries to this customer)");

            builder.Property(e => e.PaymentDays)
                .HasComment("Number of days for payment of an invoice (ie payment terms)");

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasComment("Phone number");

            builder.Property(e => e.FaxNumber)
                .HasMaxLength(20)
                .HasComment("Fax number");

            builder.Property(e => e.DeliveryRun)
                .HasMaxLength(5)
                .HasComment("Normal delivery run for this customer");

            builder.Property(e => e.RunPosition)
                .HasMaxLength(5)
                .HasComment("Normal position in the delivery run for this customer");

            builder.Property(e => e.WebsiteUrl)
                .HasMaxLength(256)
                .HasColumnName("WebsiteURL")
                .HasComment("URL for the website for this customer");

            builder.Property(e => e.DeliveryAddressLine1)
                .HasMaxLength(60)
                .HasComment("First delivery address line for the customer");

            builder.Property(e => e.DeliveryAddressLine2)
                .HasMaxLength(60)
                .HasComment("Second delivery address line for the customer");

            builder.Property(e => e.DeliveryPostalCode)
                .HasMaxLength(10)
                .HasComment("Delivery postal code for the customer");

            builder.Property(e => e.DeliveryLocation)
                .HasComment("Geographic location for the customer's office/warehouse");

            builder.Property(e => e.PostalAddressLine1)
                .HasMaxLength(60)
                .HasComment("First postal address line for the customer");

            builder.Property(e => e.PostalAddressLine2)
                .HasMaxLength(60)
                .HasComment("Second postal address line for the customer");

            builder.Property(e => e.PostalPostalCode)
                .HasMaxLength(10)
                .HasComment("Postal code for the customer when sending by mail");
        }
    }
}
