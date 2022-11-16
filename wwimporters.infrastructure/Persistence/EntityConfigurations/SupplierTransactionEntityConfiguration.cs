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
    public class SupplierTransactionEntityConfiguration : IEntityTypeConfiguration<SupplierTransaction>
    {
        public void Configure(EntityTypeBuilder<SupplierTransaction> builder)
        {
            builder.HasKey(e => e.SupplierTransactionId)
                .HasName("PK_Purchasing_SupplierTransactions")
                .IsClustered(false);

            builder.ToTable("SupplierTransactions", "Purchasing");

            builder.HasComment("All financial transactions that are supplier-related");

            builder.HasIndex(e => e.TransactionDate, "CX_Purchasing_SupplierTransactions")
                .IsClustered();

            builder.HasIndex(e => new { e.TransactionDate, e.PaymentMethodId }, "FK_Purchasing_SupplierTransactions_PaymentMethodID");

            builder.HasIndex(e => new { e.TransactionDate, e.PurchaseOrderId }, "FK_Purchasing_SupplierTransactions_PurchaseOrderID");

            builder.HasIndex(e => new { e.TransactionDate, e.SupplierId }, "FK_Purchasing_SupplierTransactions_SupplierID");

            builder.HasIndex(e => new { e.TransactionDate, e.TransactionTypeId }, "FK_Purchasing_SupplierTransactions_TransactionTypeID");

            builder.HasIndex(e => new { e.TransactionDate, e.IsFinalized }, "IX_Purchasing_SupplierTransactions_IsFinalized");



            builder.Property(e => e.SupplierTransactionId)
                .HasColumnName("SupplierTransactionID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])")
                .HasComment("Numeric ID used to refer to a supplier transaction within the database");

            builder.Property(e => e.SupplierId)
                .HasColumnName("SupplierID")
                .HasComment("Supplier for this transaction");

            builder.Property(e => e.TransactionTypeId)
                .HasColumnName("TransactionTypeID")
                .HasComment("Type of transaction");

            builder.Property(e => e.PurchaseOrderId)
                .HasColumnName("PurchaseOrderID")
                .HasComment("ID of an purchase order (for transactions associated with a purchase order)");

            builder.Property(e => e.PaymentMethodId)
                .HasColumnName("PaymentMethodID")
                .HasComment("ID of a payment method (for transactions involving payments)");

            builder.Property(e => e.SupplierInvoiceNumber)
                .HasMaxLength(20)
                .HasComment("Invoice number for an invoice received from the supplier");

            builder.Property(e => e.TransactionDate)
                .HasColumnType("date")
                .HasComment("Date for the transaction");

            builder.Property(e => e.AmountExcludingTax)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Transaction amount (excluding tax)");

            builder.Property(e => e.TaxAmount)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Tax amount calculated");

            builder.Property(e => e.TransactionAmount)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Transaction amount (including tax)");

            builder.Property(e => e.OutstandingBalance)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Amount still outstanding for this transaction");

            builder.Property(e => e.FinalizationDate)
                .HasColumnType("date")
                .HasComment("Date that this transaction was finalized (if it has been)");

            builder.Property(e => e.IsFinalized)
                .HasComputedColumnSql("(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", true)
                .HasComment("Is this transaction finalized (invoices, credits and payments have been matched)");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");
        }
    }
}
