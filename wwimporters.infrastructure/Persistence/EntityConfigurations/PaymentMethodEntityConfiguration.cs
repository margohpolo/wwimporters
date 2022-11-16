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

            builder.HasComment("Ways that payments can be made (ie: cash, check, EFT, etc.");

            builder.HasIndex(e => e.PaymentMethodName, "UQ_Application_PaymentMethods_PaymentMethodName")
                .IsUnique();

            builder.Property(e => e.PaymentMethodId)
                .HasColumnName("PaymentMethodID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PaymentMethodID])")
                .HasComment("Numeric ID used for reference to a payment type within the database");

            builder.Property(e => e.PaymentMethodName)
                .HasMaxLength(58)
                .HasComment("Full name of ways that customers can make payments or that suppliers can be paid");
        }
    }
}
