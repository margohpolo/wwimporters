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
    public class InvoiceLineEntityConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("InvoiceLines", "Sales");

            builder.HasIndex(e => e.InvoiceId, "FK_Sales_InvoiceLines_InvoiceID");

            builder.HasIndex(e => e.PackageTypeId, "FK_Sales_InvoiceLines_PackageTypeID");

            builder.HasIndex(e => e.StockItemId, "FK_Sales_InvoiceLines_StockItemID");

            builder.Property(e => e.InvoiceLineId)
                .HasColumnName("InvoiceLineID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[InvoiceLineID])");

            builder.Property(e => e.Description).HasMaxLength(107);

            builder.Property(e => e.ExtendedPrice).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.LineProfit).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");

            builder.Property(e => e.StockItemId).HasColumnName("StockItemID");

            builder.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.TaxRate).HasColumnType("decimal(18, 3)");

            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
        }
    }
}
