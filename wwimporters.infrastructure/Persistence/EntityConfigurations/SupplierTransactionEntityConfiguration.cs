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

            builder.HasIndex(e => e.TransactionDate, "CX_Purchasing_SupplierTransactions")
                .IsClustered();

            builder.HasIndex(e => new { e.TransactionDate, e.PaymentMethodId }, "FK_Purchasing_SupplierTransactions_PaymentMethodID");

            builder.HasIndex(e => new { e.TransactionDate, e.PurchaseOrderId }, "FK_Purchasing_SupplierTransactions_PurchaseOrderID");

            builder.HasIndex(e => new { e.TransactionDate, e.SupplierId }, "FK_Purchasing_SupplierTransactions_SupplierID");

            builder.HasIndex(e => new { e.TransactionDate, e.TransactionTypeId }, "FK_Purchasing_SupplierTransactions_TransactionTypeID");

            builder.HasIndex(e => new { e.TransactionDate, e.IsFinalized }, "IX_Purchasing_SupplierTransactions_IsFinalized");

            builder.Property(e => e.SupplierTransactionId)
                .HasColumnName("SupplierTransactionID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])");

            builder.Property(e => e.AmountExcludingTax).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.FinalizationDate).HasColumnType("date");

            builder.Property(e => e.IsFinalized).HasComputedColumnSql("(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", true);

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.OutstandingBalance).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

            builder.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

            builder.Property(e => e.SupplierId).HasColumnName("SupplierID");

            builder.Property(e => e.SupplierInvoiceNumber).HasMaxLength(28);

            builder.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.TransactionAmount).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.TransactionDate).HasColumnType("date");

            builder.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");
        }
    }
}
