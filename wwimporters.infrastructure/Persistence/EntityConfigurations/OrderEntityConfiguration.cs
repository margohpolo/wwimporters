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
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Sales");

            builder.HasIndex(e => e.ContactPersonId, "FK_Sales_Orders_ContactPersonID");

            builder.HasIndex(e => e.CustomerId, "FK_Sales_Orders_CustomerID");

            builder.HasIndex(e => e.PickedByPersonId, "FK_Sales_Orders_PickedByPersonID");

            builder.HasIndex(e => e.SalespersonPersonId, "FK_Sales_Orders_SalespersonPersonID");

            builder.Property(e => e.OrderId)
                .HasColumnName("OrderID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[OrderID])");

            builder.Property(e => e.BackorderOrderId).HasColumnName("BackorderOrderID");

            builder.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");

            builder.Property(e => e.CustomerPurchaseOrderNumber).HasMaxLength(28);

            builder.Property(e => e.ExpectedDeliveryDate).HasColumnType("date");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.OrderDate).HasColumnType("date");

            builder.Property(e => e.PickedByPersonId).HasColumnName("PickedByPersonID");

            builder.Property(e => e.SalespersonPersonId).HasColumnName("SalespersonPersonID");
        }
    }
}
