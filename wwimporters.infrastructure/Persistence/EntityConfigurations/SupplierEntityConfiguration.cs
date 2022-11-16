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
    public class SupplierEntityConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers", "Purchasing");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("Suppliers_Archive", "Purchasing");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasComment("Main entity table for suppliers (organizations)");

            builder.HasIndex(e => e.AlternateContactPersonId, "FK_Purchasing_Suppliers_AlternateContactPersonID");

            builder.HasIndex(e => e.DeliveryCityId, "FK_Purchasing_Suppliers_DeliveryCityID");

            builder.HasIndex(e => e.DeliveryMethodId, "FK_Purchasing_Suppliers_DeliveryMethodID");

            builder.HasIndex(e => e.PostalCityId, "FK_Purchasing_Suppliers_PostalCityID");

            builder.HasIndex(e => e.PrimaryContactPersonId, "FK_Purchasing_Suppliers_PrimaryContactPersonID");

            builder.HasIndex(e => e.SupplierCategoryId, "FK_Purchasing_Suppliers_SupplierCategoryID");

            builder.HasIndex(e => e.SupplierName, "UQ_Purchasing_Suppliers_SupplierName")
                .IsUnique();


            builder.Property(e => e.SupplierId)
                .HasColumnName("SupplierID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SupplierID])")
                .HasComment("Numeric ID used for reference to a supplier within the database");

            builder.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasComment("Supplier's full name (usually a trading name)");

            builder.Property(e => e.SupplierCategoryId)
                .HasColumnName("SupplierCategoryID")
                .HasComment("Supplier's category");

            builder.Property(e => e.PrimaryContactPersonId)
                .HasColumnName("PrimaryContactPersonID")
                .HasComment("Primary contact");

            builder.Property(e => e.AlternateContactPersonId)
                .HasColumnName("AlternateContactPersonID")
                .HasComment("Alternate contact");

            builder.Property(e => e.DeliveryMethodId)
                .HasColumnName("DeliveryMethodID")
                .HasComment("Standard delivery method for stock items received from this supplier");

            builder.Property(e => e.DeliveryCityId)
                .HasColumnName("DeliveryCityID")
                .HasComment("ID of the delivery city for this address");

            builder.Property(e => e.PostalCityId)
                .HasColumnName("PostalCityID")
                .HasComment("ID of the mailing city for this address");

            builder.Property(e => e.SupplierReference)
                .HasMaxLength(20)
                .HasComment("Supplier reference for our organization (might be our account number at the supplier)");

            builder.Property(e => e.BankAccountName)
                .HasMaxLength(50)
                .HasComment("Supplier's bank account name (ie name on the account)");

            builder.Property(e => e.BankAccountBranch)
                .HasMaxLength(50)
                .HasComment("Supplier's bank branch");

            builder.Property(e => e.BankAccountCode)
                .HasMaxLength(20)
                .HasComment("Supplier's bank account code (usually a numeric reference for the bank branch)");

            builder.Property(e => e.BankAccountNumber)
                .HasMaxLength(20)
                .HasComment("Supplier's bank account number");

            builder.Property(e => e.BankInternationalCode)
                .HasMaxLength(20)
                .HasComment("Supplier's bank's international code (such as a SWIFT code)");

            builder.Property(e => e.PaymentDays)
                .HasComment("Number of days for payment of an invoice (ie payment terms)");

            builder.Property(e => e.InternalComments)
                .HasComment("Internal comments (not exposed outside organization)");

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasComment("Phone number");

            builder.Property(e => e.FaxNumber)
                .HasMaxLength(20)
                .HasComment("Fax number");

            builder.Property(e => e.WebsiteUrl)
                .HasMaxLength(256)
                .HasColumnName("WebsiteURL")
                .HasComment("URL for the website for this supplier");

            builder.Property(e => e.DeliveryAddressLine1)
                .HasMaxLength(60)
                .HasComment("First delivery address line for the supplier");

            builder.Property(e => e.DeliveryAddressLine2)
                .HasMaxLength(60)
                .HasComment("Second delivery address line for the supplier");

            builder.Property(e => e.DeliveryPostalCode)
                .HasMaxLength(10)
                .HasComment("Delivery postal code for the supplier");

            builder.Property(e => e.DeliveryLocation)
                .HasComment("Geographic location for the supplier's office/warehouse");

            builder.Property(e => e.PostalAddressLine1)
                .HasMaxLength(60)
                .HasComment("First postal address line for the supplier");

            builder.Property(e => e.PostalAddressLine2)
                .HasMaxLength(60)
                .HasComment("Second postal address line for the supplier");

            builder.Property(e => e.PostalPostalCode)
                .HasMaxLength(10)
                .HasComment("Postal code for the supplier when sending by mail");
        }
    }
}
