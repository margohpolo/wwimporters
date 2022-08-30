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
    public class InvoiceEntityConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices", "Sales");

            builder.HasIndex(e => e.AccountsPersonId, "FK_Sales_Invoices_AccountsPersonID");

            builder.HasIndex(e => e.BillToCustomerId, "FK_Sales_Invoices_BillToCustomerID");

            builder.HasIndex(e => e.ContactPersonId, "FK_Sales_Invoices_ContactPersonID");

            builder.HasIndex(e => e.CustomerId, "FK_Sales_Invoices_CustomerID");

            builder.HasIndex(e => e.DeliveryMethodId, "FK_Sales_Invoices_DeliveryMethodID");

            builder.HasIndex(e => e.OrderId, "FK_Sales_Invoices_OrderID");

            builder.HasIndex(e => e.PackedByPersonId, "FK_Sales_Invoices_PackedByPersonID");

            builder.HasIndex(e => e.SalespersonPersonId, "FK_Sales_Invoices_SalespersonPersonID");

            builder.HasIndex(e => e.ConfirmedDeliveryTime, "IX_Sales_Invoices_ConfirmedDeliveryTime");

            builder.Property(e => e.InvoiceId)
                .HasColumnName("InvoiceID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[InvoiceID])");

            builder.Property(e => e.AccountsPersonId).HasColumnName("AccountsPersonID");

            builder.Property(e => e.BillToCustomerId).HasColumnName("BillToCustomerID");

            builder.Property(e => e.ConfirmedDeliveryTime).HasComputedColumnSql("(TRY_CONVERT([datetime2](7),json_value([ReturnedDeliveryData],N'$.DeliveredWhen'),(126)))", false);

            builder.Property(e => e.ConfirmedReceivedBy)
                .HasMaxLength(4000)
                .HasComputedColumnSql("(json_value([ReturnedDeliveryData],N'$.ReceivedBy'))", false);

            builder.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");

            builder.Property(e => e.CustomerPurchaseOrderNumber).HasMaxLength(28);

            builder.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");

            builder.Property(e => e.DeliveryRun).HasMaxLength(11);

            builder.Property(e => e.InvoiceDate).HasColumnType("date");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.PackedByPersonId).HasColumnName("PackedByPersonID");

            builder.Property(e => e.RunPosition).HasMaxLength(11);

            builder.Property(e => e.SalespersonPersonId).HasColumnName("SalespersonPersonID");
        }
    }
}
