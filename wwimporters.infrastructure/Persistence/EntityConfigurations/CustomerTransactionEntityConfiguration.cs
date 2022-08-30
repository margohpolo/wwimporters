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

            builder.HasIndex(e => e.TransactionDate, "CX_Sales_CustomerTransactions")
                .IsClustered();

            builder.HasIndex(e => new { e.TransactionDate, e.CustomerId }, "FK_Sales_CustomerTransactions_CustomerID");

            builder.HasIndex(e => new { e.TransactionDate, e.InvoiceId }, "FK_Sales_CustomerTransactions_InvoiceID");

            builder.HasIndex(e => new { e.TransactionDate, e.PaymentMethodId }, "FK_Sales_CustomerTransactions_PaymentMethodID");

            builder.HasIndex(e => new { e.TransactionDate, e.TransactionTypeId }, "FK_Sales_CustomerTransactions_TransactionTypeID");

            builder.HasIndex(e => new { e.TransactionDate, e.IsFinalized }, "IX_Sales_CustomerTransactions_IsFinalized");

            builder.Property(e => e.CustomerTransactionId)
                .HasColumnName("CustomerTransactionID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])");

            builder.Property(e => e.AmountExcludingTax).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");

            builder.Property(e => e.FinalizationDate).HasColumnType("date");

            builder.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

            builder.Property(e => e.IsFinalized).HasComputedColumnSql("(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", true);

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.OutstandingBalance).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

            builder.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.TransactionAmount).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.TransactionDate).HasColumnType("date");

            builder.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");
        }
    }
}
