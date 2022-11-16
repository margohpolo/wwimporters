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

            builder.HasComment("Details of customer invoices");

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
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[InvoiceID])")
                .HasComment("Numeric ID used for reference to an invoice within the database");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasComment("Customer for this invoice");

            builder.Property(e => e.BillToCustomerId)
                .HasColumnName("BillToCustomerID")
                .HasComment("Bill to customer for this invoice (invoices might be billed to a head office)");

            builder.Property(e => e.OrderId)
                .HasColumnName("OrderID")
                .HasComment("Sales order (if any) for this invoice");

            builder.Property(e => e.DeliveryMethodId)
                .HasColumnName("DeliveryMethodID")
                .HasComment("How these stock items are beign delivered");

            builder.Property(e => e.ContactPersonId)
                .HasColumnName("ContactPersonID")
                .HasComment("Customer contact for this invoice");

            builder.Property(e => e.AccountsPersonId)
                .HasColumnName("AccountsPersonID")
                .HasComment("Customer accounts contact for this invoice");

            builder.Property(e => e.SalespersonPersonId)
                .HasColumnName("SalespersonPersonID")
                .HasComment("Salesperson for this invoice");

            builder.Property(e => e.PackedByPersonId)
                .HasColumnName("PackedByPersonID")
                .HasComment("Person who packed this shipment (or checked the packing)");

            builder.Property(e => e.InvoiceDate)
                .HasColumnType("date")
                .HasComment("Date that this invoice was raised");

            builder.Property(e => e.CustomerPurchaseOrderNumber)
                .HasMaxLength(20)
                .HasComment("Purchase Order Number received from customer");

            builder.Property(e => e.IsCreditNote)
                .HasComment("Is this a credit note (rather than an invoice)");

            builder.Property(e => e.CreditNoteReason)
                .HasComment("Reason that this credit note needed to be generated (if applicable)");

            builder.Property(e => e.Comments)
                .HasComment("Any comments related to this invoice (sent to customer)");

            builder.Property(e => e.DeliveryInstructions)
                .HasComment("Any comments related to delivery (sent to customer)");

            builder.Property(e => e.InternalComments)
                .HasComment("Any internal comments related to this invoice (not sent to the customer)");

            builder.Property(e => e.TotalDryItems)
                .HasComment("Total number of dry packages (information for the delivery driver)");

            builder.Property(e => e.TotalChillerItems)
                .HasComment("Total number of chiller packages (information for the delivery driver)");

            builder.Property(e => e.DeliveryRun)
                .HasMaxLength(5)
                .HasComment("Delivery run for this shipment");

            builder.Property(e => e.RunPosition)
                .HasMaxLength(5)
                .HasComment("Position in the delivery run for this shipment");

            builder.Property(e => e.ReturnedDeliveryData)
                .HasMaxLength(5)
                .HasComment("JSON-structured data returned from delivery devices for deliveries made directly by the organization");

            builder.Property(e => e.ConfirmedDeliveryTime)
                .HasComputedColumnSql("(TRY_CONVERT([datetime2](7),json_value([ReturnedDeliveryData],N'$.DeliveredWhen'),(126)))", false)
                .HasComment("Confirmed delivery date and time promoted from JSON delivery data");

            builder.Property(e => e.ConfirmedReceivedBy)
                .HasMaxLength(4000)
                .HasComputedColumnSql("(json_value([ReturnedDeliveryData],N'$.ReceivedBy'))", false)
                .HasComment("Confirmed receiver promoted from JSON delivery data");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");
        }
    }
}
