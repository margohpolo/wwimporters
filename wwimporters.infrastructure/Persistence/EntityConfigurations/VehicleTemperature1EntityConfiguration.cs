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
    public class VehicleTemperature1EntityConfiguration : IEntityTypeConfiguration<VehicleTemperature1>
    {
        public void Configure(EntityTypeBuilder<VehicleTemperature1> builder)
        {
            builder.HasNoKey();

            builder.ToView("VehicleTemperatures", "Website");

            builder.Property(e => e.FullSensorData).HasMaxLength(1008);

            builder.Property(e => e.Temperature).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.VehicleRegistration).HasMaxLength(28);

            builder.Property(e => e.VehicleTemperatureId)
                .ValueGeneratedOnAdd()
                .HasColumnName("VehicleTemperatureID");
        }
    }
}
