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
    public class SystemParameterEntityConfiguration : IEntityTypeConfiguration<SystemParameter>
    {
        public void Configure(EntityTypeBuilder<SystemParameter> builder)
        {
            builder.ToTable("SystemParameters", "Application");

            builder.HasIndex(e => e.DeliveryCityId, "FK_Application_SystemParameters_DeliveryCityID");

            builder.HasIndex(e => e.PostalCityId, "FK_Application_SystemParameters_PostalCityID");

            builder.Property(e => e.SystemParameterId)
                .HasColumnName("SystemParameterID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SystemParameterID])");

            builder.Property(e => e.DeliveryAddressLine1).HasMaxLength(68);

            builder.Property(e => e.DeliveryAddressLine2).HasMaxLength(68);

            builder.Property(e => e.DeliveryCityId).HasColumnName("DeliveryCityID");

            builder.Property(e => e.DeliveryPostalCode).HasMaxLength(18);

            builder.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.PostalAddressLine1).HasMaxLength(68);

            builder.Property(e => e.PostalAddressLine2).HasMaxLength(68);

            builder.Property(e => e.PostalCityId).HasColumnName("PostalCityID");

            builder.Property(e => e.PostalPostalCode).HasMaxLength(18);
        }
    }
}
