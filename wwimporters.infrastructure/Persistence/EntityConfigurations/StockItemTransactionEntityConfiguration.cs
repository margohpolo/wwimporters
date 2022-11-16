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

            builder.HasComment("Transactions covering all movements of all stock items");

            builder.HasIndex(e => e.CustomerId, "FK_Warehouse_StockItemTransactions_CustomerID");

            builder.HasIndex(e => e.InvoiceId, "FK_Warehouse_StockItemTransactions_InvoiceID");

            builder.HasIndex(e => e.PurchaseOrderId, "FK_Warehouse_StockItemTransactions_PurchaseOrderID");

            builder.HasIndex(e => e.StockItemId, "FK_Warehouse_StockItemTransactions_StockItemID");

            builder.HasIndex(e => e.SupplierId, "FK_Warehouse_StockItemTransactions_SupplierID");

            builder.HasIndex(e => e.TransactionTypeId, "FK_Warehouse_StockItemTransactions_TransactionTypeID");



            builder.Property(e => e.StockItemTransactionId)
                .HasColumnName("StockItemTransactionID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])")
                .HasComment("Numeric ID used to refer to a stock item transaction within the database");

            builder.Property(e => e.StockItemId)
                .HasColumnName("StockItemID")
                .HasComment("StockItem for this transaction");

            builder.Property(e => e.TransactionTypeId)
                .HasColumnName("TransactionTypeID")
                .HasComment("Type of transaction");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasComment("Customer for this transaction (if applicable)");

            builder.Property(e => e.InvoiceId)
                .HasColumnName("InvoiceID")
                .HasComment("ID of an invoice (for transactions associated with an invoice)");

            builder.Property(e => e.SupplierId)
                .HasColumnName("SupplierID")
                .HasComment("Supplier for this stock transaction (if applicable)");

            builder.Property(e => e.PurchaseOrderId)
                .HasColumnName("PurchaseOrderID")
                .HasComment("ID of an purchase order (for transactions associated with a purchase order)");

            builder.Property(e => e.TransactionOccurredWhen)
                .HasComment("Date and time when the transaction occurred");

            builder.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 3)")
                .HasComment("Quantity of stock movement (positive is incoming stock, negative is outgoing)");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");
        }
    }
}
