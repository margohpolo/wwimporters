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
    public class ColdRoomTemperatureEntityConfiguration : IEntityTypeConfiguration<ColdRoomTemperature>
    {
        public void Configure(EntityTypeBuilder<ColdRoomTemperature> builder)
        {
            builder.HasKey(e => e.ColdRoomTemperatureId)
                .HasName("PK_Warehouse_ColdRoomTemperatures")
                .IsClustered(false);

            builder.ToTable("ColdRoomTemperatures", "Warehouse");

            //TODO: Implement Workaround for the below issue
            builder
                //.IsMemoryOptimized()
                .ToTable(tb => tb.IsTemporal(ttb => {
                    ttb.UseHistoryTable("ColdRoomTemperatures_Archive", "Warehouse");
                    ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                    ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
                }));

            builder.HasIndex(e => e.ColdRoomSensorNumber, "IX_Warehouse_ColdRoomTemperatures_ColdRoomSensorNumber");

            builder.Property(e => e.ColdRoomTemperatureId).HasColumnName("ColdRoomTemperatureID");

            builder.Property(e => e.Temperature).HasColumnType("decimal(10, 2)");
        }
    }
}
