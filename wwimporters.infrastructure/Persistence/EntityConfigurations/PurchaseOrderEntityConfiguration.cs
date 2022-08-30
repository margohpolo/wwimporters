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

            builder.HasIndex(e => e.ContactPersonId, "FK_Purchasing_PurchaseOrders_ContactPersonID");

            builder.HasIndex(e => e.DeliveryMethodId, "FK_Purchasing_PurchaseOrders_DeliveryMethodID");

            builder.HasIndex(e => e.SupplierId, "FK_Purchasing_PurchaseOrders_SupplierID");

            builder.Property(e => e.PurchaseOrderId)
                .HasColumnName("PurchaseOrderID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PurchaseOrderID])");

            builder.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

            builder.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");

            builder.Property(e => e.ExpectedDeliveryDate).HasColumnType("date");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.OrderDate).HasColumnType("date");

            builder.Property(e => e.SupplierId).HasColumnName("SupplierID");

            builder.Property(e => e.SupplierReference).HasMaxLength(28);
        }
    }
}
