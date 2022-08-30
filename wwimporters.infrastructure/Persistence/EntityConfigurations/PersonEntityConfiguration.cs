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
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People", "Application");

            builder.ToTable(tb => tb.IsTemporal(ttb => {
                ttb.UseHistoryTable("People_Archive", "Application");
                ttb.HasPeriodStart("ValidFrom").HasColumnName("ValidFrom");
                ttb.HasPeriodEnd("ValidTo").HasColumnName("ValidTo");
            }));

            builder.HasIndex(e => e.FullName, "IX_Application_People_FullName");

            builder.HasIndex(e => e.IsEmployee, "IX_Application_People_IsEmployee");

            builder.HasIndex(e => e.IsSalesperson, "IX_Application_People_IsSalesperson");

            builder.HasIndex(e => new { e.IsPermittedToLogon, e.PersonId }, "IX_Application_People_Perf_20160301_05");

            builder.Property(e => e.PersonId)
                .HasColumnName("PersonID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PersonID])");

            builder.Property(e => e.EmailAddress).HasMaxLength(264);

            builder.Property(e => e.FaxNumber).HasMaxLength(28);

            builder.Property(e => e.FullName).HasMaxLength(58);

            builder.Property(e => e.LogonName).HasMaxLength(58);

            builder.Property(e => e.OtherLanguages).HasComputedColumnSql("(json_query([CustomFields],N'$.OtherLanguages'))", false);

            builder.Property(e => e.PhoneNumber).HasMaxLength(28);

            builder.Property(e => e.PreferredName).HasMaxLength(58);

            builder.Property(e => e.SearchName)
                .HasMaxLength(107)
                .HasComputedColumnSql("(concat([PreferredName],N' ',[FullName]))", true);
        }
    }
}
