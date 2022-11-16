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

            builder.HasComment("Detail of customer orders");

            builder.HasIndex(e => e.ContactPersonId, "FK_Sales_Orders_ContactPersonID");

            builder.HasIndex(e => e.CustomerId, "FK_Sales_Orders_CustomerID");

            builder.HasIndex(e => e.PickedByPersonId, "FK_Sales_Orders_PickedByPersonID");

            builder.HasIndex(e => e.SalespersonPersonId, "FK_Sales_Orders_SalespersonPersonID");



            builder.Property(e => e.OrderId)
                .HasColumnName("OrderID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[OrderID])")
                .HasComment("Numeric ID used for reference to an order within the database");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasComment("Customer for this order");

            builder.Property(e => e.SalespersonPersonId)
                .HasColumnName("SalespersonPersonID")
                .HasComment("Salesperson for this order");

            builder.Property(e => e.PickedByPersonId)
                .HasColumnName("PickedByPersonID")
                .HasComment("Person who picked this shipment");

            builder.Property(e => e.ContactPersonId)
                .HasColumnName("ContactPersonID")
                .HasComment("Customer contact for this order");

            builder.Property(e => e.BackorderOrderId)
                .HasColumnName("BackorderOrderID")
                .HasComment("If this order is a backorder, this column holds the original order number");

            builder.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasComment("Date that this order was raised");

            builder.Property(e => e.ExpectedDeliveryDate)
                .HasColumnType("date")
                .HasComment("Expected delivery date");

            builder.Property(e => e.CustomerPurchaseOrderNumber)
                .HasMaxLength(20)
                .HasComment("Purchase Order Number received from customer");

            builder.Property(e => e.IsUndersupplyBackordered)
                .HasComment("If items cannot be supplied are they backordered?");

            builder.Property(e => e.Comments)
                .HasComment("Any comments related to this order (sent to customer)");

            builder.Property(e => e.DeliveryInstructions)
                .HasComment("\tAny comments related to order delivery (sent to customer)");

            builder.Property(e => e.InternalComments)
                .HasComment("Any internal comments related to this order (not sent to the customer)");

            builder.Property(e => e.PickingCompletedWhen)
                .HasComment("When was picking of the entire order completed?");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");
        }
    }
}
