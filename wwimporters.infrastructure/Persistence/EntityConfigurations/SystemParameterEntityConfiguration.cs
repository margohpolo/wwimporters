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

            builder.HasComment("Any configurable parameters for the whole system");

            builder.HasIndex(e => e.DeliveryCityId, "FK_Application_SystemParameters_DeliveryCityID");

            builder.HasIndex(e => e.PostalCityId, "FK_Application_SystemParameters_PostalCityID");

            builder.Property(e => e.SystemParameterId)
                .HasColumnName("SystemParameterID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SystemParameterID])")
                .HasComment("Numeric ID used for row holding system parameters");

            builder.Property(e => e.DeliveryAddressLine1)
                .HasMaxLength(60)
                .HasComment("First address line for the company");

            builder.Property(e => e.DeliveryAddressLine2)
                .HasMaxLength(60)
                .HasComment("Second address line for the company");

            builder.Property(e => e.DeliveryCityId)
                .HasColumnName("DeliveryCityID")
                .HasComment("ID of the city for this address");

            builder.Property(e => e.DeliveryPostalCode)
                .HasMaxLength(10)
                .HasComment("Postal code for the company");

            builder.Property(e => e.DeliveryLocation)
                .HasComment("Geographic location for the company office");

            builder.Property(e => e.PostalAddressLine1)
                .HasMaxLength(60)
                .HasComment("First postal address line for the company");

            builder.Property(e => e.PostalAddressLine2)
                .HasMaxLength(60)
                .HasComment("Second postaladdress line for the company");

            builder.Property(e => e.PostalCityId)
                .HasColumnName("PostalCityID")
                .HasComment("ID of the city for this postaladdress");

            builder.Property(e => e.PostalPostalCode)
                .HasMaxLength(10)
                .HasComment("Postal code for the company when sending via mail");

            builder.Property(e => e.ApplicationSettings)
                .HasComment("JSON-structured application settings");

            builder.Property(e => e.LastEditedWhen)
                .HasDefaultValueSql("(sysdatetime())");
        }
    }
}
