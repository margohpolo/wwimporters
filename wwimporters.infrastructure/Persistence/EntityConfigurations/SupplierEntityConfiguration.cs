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
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SupplierID])");

            builder.Property(e => e.AlternateContactPersonId).HasColumnName("AlternateContactPersonID");

            builder.Property(e => e.BankAccountBranch).HasMaxLength(58);

            builder.Property(e => e.BankAccountCode).HasMaxLength(28);

            builder.Property(e => e.BankAccountName).HasMaxLength(58);

            builder.Property(e => e.BankAccountNumber).HasMaxLength(28);

            builder.Property(e => e.BankInternationalCode).HasMaxLength(28);

            builder.Property(e => e.DeliveryAddressLine1).HasMaxLength(68);

            builder.Property(e => e.DeliveryAddressLine2).HasMaxLength(68);

            builder.Property(e => e.DeliveryCityId).HasColumnName("DeliveryCityID");

            builder.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");

            builder.Property(e => e.DeliveryPostalCode).HasMaxLength(18);

            builder.Property(e => e.FaxNumber).HasMaxLength(28);

            builder.Property(e => e.PhoneNumber).HasMaxLength(28);

            builder.Property(e => e.PostalAddressLine1).HasMaxLength(68);

            builder.Property(e => e.PostalAddressLine2).HasMaxLength(68);

            builder.Property(e => e.PostalCityId).HasColumnName("PostalCityID");

            builder.Property(e => e.PostalPostalCode).HasMaxLength(18);

            builder.Property(e => e.PrimaryContactPersonId).HasColumnName("PrimaryContactPersonID");

            builder.Property(e => e.SupplierCategoryId).HasColumnName("SupplierCategoryID");

            builder.Property(e => e.SupplierName).HasMaxLength(107);

            builder.Property(e => e.SupplierReference).HasMaxLength(28);

            builder.Property(e => e.WebsiteUrl)
                .HasMaxLength(264)
                .HasColumnName("WebsiteURL");
        }
    }
}
