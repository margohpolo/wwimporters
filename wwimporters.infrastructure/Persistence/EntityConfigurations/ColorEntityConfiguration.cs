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
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors", "Warehouse");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("Colors_Archive", "Warehouse");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasComment("Stock items can (optionally) have colors");

            builder.HasIndex(e => e.ColorName, "UQ_Warehouse_Colors_ColorName")
                .IsUnique();

            builder.Property(e => e.ColorId)
                .HasColumnName("ColorID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[ColorID])")
                .HasComment("Numeric ID used for reference to a color within the database");

            builder.Property(e => e.ColorName)
                .HasMaxLength(20)
                .HasComment("Full name of a color that can be used to describe stock items");
        }
    }
}
