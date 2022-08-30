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
    public class PaymentMethodEntityConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods", "Application");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("PaymentMethods_Archive", "Application");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.PaymentMethodName, "UQ_Application_PaymentMethods_PaymentMethodName")
                .IsUnique();

            builder.Property(e => e.PaymentMethodId)
                .HasColumnName("PaymentMethodID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PaymentMethodID])");

            builder.Property(e => e.PaymentMethodName).HasMaxLength(58);
        }
    }
}
