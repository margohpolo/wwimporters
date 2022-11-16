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
    public class TransactionTypeEntityConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("TransactionTypes", "Application");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("TransactionTypes_Archive", "Application");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasComment("Types of customer, supplier, or stock transactions (ie: invoice, credit note, etc.)");

            builder.HasIndex(e => e.TransactionTypeName, "UQ_Application_TransactionTypes_TransactionTypeName")
                .IsUnique();

            builder.Property(e => e.TransactionTypeId)
                .HasColumnName("TransactionTypeID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionTypeID])")
                .HasComment("Numeric ID used for reference to a transaction type within the database");

            builder.Property(e => e.TransactionTypeName)
                .HasMaxLength(50)
                .HasComment("Full name of the transaction type");
        }
    }
}
