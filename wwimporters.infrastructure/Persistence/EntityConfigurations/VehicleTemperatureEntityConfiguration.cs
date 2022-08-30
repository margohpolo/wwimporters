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
    public class VehicleTemperatureEntityConfiguration : IEntityTypeConfiguration<VehicleTemperature>
    {
        public void Configure(EntityTypeBuilder<VehicleTemperature> builder)
        {
            builder.HasKey(e => e.VehicleTemperatureId)
                .HasName("PK_Warehouse_VehicleTemperatures")
                .IsClustered(false);

            builder.ToTable("VehicleTemperatures", "Warehouse");

            builder.IsMemoryOptimized();

            builder.Property(e => e.VehicleTemperatureId).HasColumnName("VehicleTemperatureID");

            builder.Property(e => e.FullSensorData)
                .HasMaxLength(1008)
                .UseCollation("Latin1_General_CI_AS");

            builder.Property(e => e.Temperature).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.VehicleRegistration)
                .HasMaxLength(28)
                .UseCollation("Latin1_General_CI_AS");
        }
    }
}
