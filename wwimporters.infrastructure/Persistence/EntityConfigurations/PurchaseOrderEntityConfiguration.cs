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
    public class PurchaseOrderEntityConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("PurchaseOrders", "Purchasing");

            builder.HasComment("Details of supplier purchase orders");

            builder.HasIndex(e => e.ContactPersonId, "FK_Purchasing_PurchaseOrders_ContactPersonID");

            builder.HasIndex(e => e.DeliveryMethodId, "FK_Purchasing_PurchaseOrders_DeliveryMethodID");

            builder.HasIndex(e => e.SupplierId, "FK_Purchasing_PurchaseOrders_SupplierID");



            builder.Property(e => e.PurchaseOrderId)
                .HasColumnName("PurchaseOrderID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PurchaseOrderID])")
                .HasComment("Numeric ID used for reference to a purchase order within the database");

            builder.Property(e => e.SupplierId)
                .HasColumnName("SupplierID")
                .HasComment("Supplier for this purchase order");

            builder.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasComment("Date that this purchase order was raised");

            builder.Property(e => e.DeliveryMethodId)
                .HasColumnName("DeliveryMethodID")
                .HasComment("How this purchase order should be delivered");

            builder.Property(e => e.ContactPersonId)
                .HasColumnName("ContactPersonID")
                .HasComment("The person who is the primary contact for this purchase order");

            builder.Property(e => e.ExpectedDeliveryDate)
                .HasColumnType("date")
                .HasComment("Expected delivery date for this purchase order");

            builder.Property(e => e.SupplierReference)
                .HasMaxLength(20)
                .HasComment("Supplier reference for our organization (might be our account number at the supplier)");

            builder.Property(e => e.IsOrderFinalized)
                .HasComment("Is this purchase order now considered finalized?");

            builder.Property(e => e.Comments)
                .HasComment("Any comments related this purchase order (comments sent to the supplier)");

            builder.Property(e => e.InternalComments)
                .HasComment("Any internal comments related this purchase order (comments for internal reference only and not sent to the supplier)");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");
        }
    }
}
