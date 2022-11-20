using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

#nullable disable

namespace wwimporters.efmigrations.Migrations
{
    public partial class CreateStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string scriptsDir = @"../wwimporters.infrastructure/Persistence/StoredProcedures/Scripts/";
            foreach ( string fileName in Directory.GetFiles(scriptsDir) )
            {
                migrationBuilder.Sql(File.ReadAllText(fileName));
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string[] spNames =
            {
                "Configuration_ApplyPartitioning",
                "Configuration_ApplyFullTextIndexing"
            };

            foreach ( string name in spNames )
            {
                migrationBuilder.Sql($"DROP PROCEDURE [Application].{name};");
            }
        }
    }
}
