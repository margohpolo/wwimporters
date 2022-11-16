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
    public class CustomerTransactionEntityConfiguration : IEntityTypeConfiguration<CustomerTransaction>
    {
        public void Configure(EntityTypeBuilder<CustomerTransaction> builder)
        {
            builder.HasKey(e => e.CustomerTransactionId)
                .HasName("PK_Sales_CustomerTransactions")
                .IsClustered(false);

            builder.ToTable("CustomerTransactions", "Sales");

            builder.HasComment("All financial transactions that are customer-related");

            builder.HasIndex(e => e.TransactionDate, "CX_Sales_CustomerTransactions")
                .IsClustered();

            builder.HasIndex(e => new { e.TransactionDate, e.CustomerId }, "FK_Sales_CustomerTransactions_CustomerID");

            builder.HasIndex(e => new { e.TransactionDate, e.InvoiceId }, "FK_Sales_CustomerTransactions_InvoiceID");

            builder.HasIndex(e => new { e.TransactionDate, e.PaymentMethodId }, "FK_Sales_CustomerTransactions_PaymentMethodID");

            builder.HasIndex(e => new { e.TransactionDate, e.TransactionTypeId }, "FK_Sales_CustomerTransactions_TransactionTypeID");

            builder.HasIndex(e => new { e.TransactionDate, e.IsFinalized }, "IX_Sales_CustomerTransactions_IsFinalized");



            builder.Property(e => e.CustomerTransactionId)
                .HasColumnName("CustomerTransactionID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])")
                .HasComment("Numeric ID used to refer to a customer transaction within the database");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasComment("Customer for this transaction");

            builder.Property(e => e.TransactionTypeId)
                .HasColumnName("TransactionTypeID")
                .HasComment("Type of transaction");

            builder.Property(e => e.InvoiceId)
                .HasColumnName("InvoiceID")
                .HasComment("ID of an invoice (for transactions associated with an invoice)");

            builder.Property(e => e.PaymentMethodId)
                .HasColumnName("PaymentMethodID")
                .HasComment("ID of a payment method (for transactions involving payments)");

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
