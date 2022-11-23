using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

#nullable disable

namespace wwimporters.infrastructure.Persistence.StoredProcedures.CustomMigrations
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

        //Down() may not be necessary
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            foreach ( string name in new StoredProcedureNames().AllStoredProcedures )
            {
                migrationBuilder.Sql($"DROP PROCEDURE [Application].{name};");
            }
        }
    }
}
