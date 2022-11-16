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

            builder.HasComment("People known to the application (staff, customer contacts, supplier contacts)");

            builder.HasIndex(e => e.FullName, "IX_Application_People_FullName");

            builder.HasIndex(e => e.IsEmployee, "IX_Application_People_IsEmployee");

            builder.HasIndex(e => e.IsSalesperson, "IX_Application_People_IsSalesperson");

            builder.HasIndex(e => new { e.IsPermittedToLogon, e.PersonId }, "IX_Application_People_Perf_20160301_05");

            builder.Property(e => e.PersonId)
                .HasColumnName("PersonID")
                .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PersonID])")
                .HasComment("Numeric ID used for reference to a person within the database");

            builder.Property(e => e.FullName)
                .HasMaxLength(58)
                .HasComment("Full name for this person");

            builder.Property(e => e.PreferredName)
                .HasMaxLength(58)
                .HasComment("Name that this person prefers to be called");

            builder.Property(e => e.SearchName)
                .HasMaxLength(107)
                .HasComputedColumnSql("(concat([PreferredName],N' ',[FullName]))", true)
                .HasComment("Name to build full text search on (computed column)");

            builder.Property(e => e.IsPermittedToLogon)
                .HasComment("Is this person permitted to log on?");

            builder.Property(e => e.LogonName)
                .HasMaxLength(58)
                .HasComment("Person's system logon name");

            builder.Property(e => e.IsExternalLogonProvider)
                .HasComment("Is logon token provided by an external system?");

            builder.Property(e => e.HashedPassword)
                .HasComment("Hash of password for users without external logon tokens");

            builder.Property(e => e.IsSystemUser)
                .HasComment("Is the currently permitted to make online access?");

            builder.Property(e => e.IsEmployee)
                .HasComment("Is this person an employee?");

            builder.Property(e => e.IsSalesperson)
                .HasComment("Is this person a staff salesperson?");

            builder.Property(e => e.UserPreferences)
                .HasComment("User preferences related to the website (holds JSON data)");

            builder.Property(e => e.PhoneNumber).HasMaxLength(28)
                .HasComment("Phone number");

            builder.Property(e => e.FaxNumber).HasMaxLength(28)
                .HasComment("Fax number");

            builder.Property(e => e.EmailAddress).HasMaxLength(264)
                .HasComment("Email address for this person");

            builder.Property(e => e.Photo)
                .HasComment("Photo of this person");

            builder.Property(e => e.CustomFields)
                .HasComment("Custom fields for employees and salespeople");

            builder.Property(e => e.OtherLanguages)
                .HasComputedColumnSql("(json_query([CustomFields],N'$.OtherLanguages'))", false)
                .HasComment("Other languages spoken (computed column from custom fields)");

        }
    }
}
