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
    public class DeliveryMethodEntityConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods", "Application");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("DeliveryMethods_Archive", "Application");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.DeliveryMethodName, "UQ_Application_DeliveryMethods_DeliveryMethodName")
                .IsUnique();

            builder.Property(e => e.DeliveryMethodId)
                .HasColumnName("DeliveryMethodID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[DeliveryMethodID])");

            builder.Property(e => e.DeliveryMethodName).HasMaxLength(58);
        }
    }
}
