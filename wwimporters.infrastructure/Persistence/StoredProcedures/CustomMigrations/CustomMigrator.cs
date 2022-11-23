using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwimporters.infrastructure.Persistence.StoredProcedures.CustomMigrations
{
    //TODO: fully understand why this - https://github.com/dotnet/efcore/issues/24710
    internal class CustomMigrator : Migrator
    {
        public CustomMigrator(
            IMigrationsAssembly migrationsAssembly, 
            IHistoryRepository historyRepository, 
            IDatabaseCreator databaseCreator, 
            IMigrationsSqlGenerator migrationsSqlGenerator, 
            IRawSqlCommandBuilder rawSqlCommandBuilder, 
            IMigrationCommandExecutor migrationCommandExecutor, 
            IRelationalConnection connection, 
            ISqlGenerationHelper sqlGenerationHelper, 
            ICurrentDbContext currentContext, 
            IModelRuntimeInitializer modelRuntimeInitializer, 
            IDiagnosticsLogger<DbLoggerCategory.Migrations> logger, 
            IRelationalCommandDiagnosticsLogger commandLogger, 
            IDatabaseProvider databaseProvider) 
            : base(migrationsAssembly, 
                historyRepository, 
                databaseCreator, 
                migrationsSqlGenerator, 
                rawSqlCommandBuilder, 
                migrationCommandExecutor, 
                connection, 
                sqlGenerationHelper, 
                currentContext, 
                modelRuntimeInitializer, 
                logger, 
                commandLogger, 
                databaseProvider
                )
        {
        }

        protected override IReadOnlyList<MigrationCommand> GenerateUpSql(
            Migration migration,
            MigrationsSqlGenerationOptions options = MigrationsSqlGenerationOptions.Default
            )
        {
            if (migration is not CreateStoredProcedures)
            {
                return base.GenerateUpSql(migration, options);
            }

            IReadOnlyList<MigrationCommand> migrationCollection = base.GenerateUpSql(migration, options);

            return migrationCollection.Take(migrationCollection.Count - 1).ToList();
        }

        protected override void PopulateMigrations(
            IEnumerable<string> appliedMigrationEntries, 
            string? targetMigration, 
            out IReadOnlyList<Migration> migrationsToApply, 
            out IReadOnlyList<Migration> migrationsToRevert, 
            out Migration? actualTargetMigration
            )
        {
            base.PopulateMigrations(appliedMigrationEntries, 
                targetMigration, 
                out IReadOnlyList<Migration>? baseMigrationsToApply, 
                out migrationsToRevert, 
                out actualTargetMigration
                );

            migrationsToApply = baseMigrationsToApply
                .Append(new CreateStoredProcedures())
                .ToList();

        }

    }
}
