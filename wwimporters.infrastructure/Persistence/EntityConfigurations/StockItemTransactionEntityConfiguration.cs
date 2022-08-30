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
    public class StockItemTransactionEntityConfiguration : IEntityTypeConfiguration<StockItemTransaction>
    {
        public void Configure(EntityTypeBuilder<StockItemTransaction> builder)
        {
            builder.HasKey(e => e.StockItemTransactionId)
                .HasName("PK_Warehouse_StockItemTransactions")
                .IsClustered(false);

            builder.ToTable("StockItemTransactions", "Warehouse");

            builder.HasIndex(e => e.CustomerId, "FK_Warehouse_StockItemTransactions_CustomerID");

            builder.HasIndex(e => e.InvoiceId, "FK_Warehouse_StockItemTransactions_InvoiceID");

            builder.HasIndex(e => e.PurchaseOrderId, "FK_Warehouse_StockItemTransactions_PurchaseOrderID");

            builder.HasIndex(e => e.StockItemId, "FK_Warehouse_StockItemTransactions_StockItemID");

            builder.HasIndex(e => e.SupplierId, "FK_Warehouse_StockItemTransactions_SupplierID");

            builder.HasIndex(e => e.TransactionTypeId, "FK_Warehouse_StockItemTransactions_TransactionTypeID");

            builder.Property(e => e.StockItemTransactionId)
                .HasColumnName("StockItemTransactionID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])");

            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");

            builder.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");

            builder.Property(e => e.StockItemId).HasColumnName("StockItemID");

            builder.Property(e => e.SupplierId).HasColumnName("SupplierID");

            builder.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");
        }
    }
}
