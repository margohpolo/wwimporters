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

            builder.HasIndex(e => e.TransactionTypeName, "UQ_Application_TransactionTypes_TransactionTypeName")
                .IsUnique();

            builder.Property(e => e.TransactionTypeId)
                .HasColumnName("TransactionTypeID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionTypeID])");

            builder.Property(e => e.TransactionTypeName).HasMaxLength(58);
        }
    }
}
