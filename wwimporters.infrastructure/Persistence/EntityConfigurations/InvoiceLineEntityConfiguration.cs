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

            builder.HasComment("Detail lines from customer invoices");

            builder.HasIndex(e => e.InvoiceId, "FK_Sales_InvoiceLines_InvoiceID");

            builder.HasIndex(e => e.PackageTypeId, "FK_Sales_InvoiceLines_PackageTypeID");

            builder.HasIndex(e => e.StockItemId, "FK_Sales_InvoiceLines_StockItemID");



            builder.Property(e => e.InvoiceLineId)
                .HasColumnName("InvoiceLineID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[InvoiceLineID])")
                .HasComment("Numeric ID used for reference to a line on an invoice within the database");

            builder.Property(e => e.InvoiceId)
                .HasColumnName("InvoiceID")
                .HasComment("Invoice that this line is associated with");

            builder.Property(e => e.StockItemId)
                .HasColumnName("StockItemID")
                .HasComment("Stock item for this invoice line");

            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .HasComment("Description of the item supplied (Usually the stock item name but can be overridden)");

            builder.Property(e => e.PackageTypeId)
                .HasColumnName("PackageTypeID")
                .HasComment("Type of package supplied");

            builder.Property(e => e.Quantity)
                .HasComment("Quantity supplied");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Unit price charged");

            builder.Property(e => e.TaxRate)
                .HasColumnType("decimal(18, 3)")
                .HasComment("Tax rate to be applied");

            builder.Property(e => e.TaxAmount)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Tax amount calculated");

            builder.Property(e => e.LineProfit)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Profit made on this line item at current cost price");

            builder.Property(e => e.ExtendedPrice)
                .HasColumnType("decimal(18, 2)")
                .HasComment("Extended line price charged");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");
        }
    }
}
