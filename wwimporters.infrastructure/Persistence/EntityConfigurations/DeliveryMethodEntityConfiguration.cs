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

            builder.HasComment("Ways that stock items can be delivered (ie: truck/van, post, pickup, courier, etc.");

            builder.HasIndex(e => e.DeliveryMethodName, "UQ_Application_DeliveryMethods_DeliveryMethodName")
                .IsUnique();

            builder.Property(e => e.DeliveryMethodId)
                .HasColumnName("DeliveryMethodID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[DeliveryMethodID])")
                .HasComment("Numeric ID used for reference to a delivery method within the database");

            builder.Property(e => e.DeliveryMethodName)
                .HasMaxLength(58)
                .HasComment("Full name of methods that can be used for delivery of customer orders");
        }
    }
}
