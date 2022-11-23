using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Xml.Linq;
using wwimporters.infrastructure.Persistence.StoredProcedures;

namespace wwimporters.infrastructure.Persistence
{
    public class WideWorldImportersContextInitialiser
    {
        private readonly WideWorldImportersContext _context;

        public WideWorldImportersContextInitialiser(WideWorldImportersContext context)
        {
            _context = context;
        }

        public void Initialise()
        {
            if (_context.Database.IsSqlServer())
            {
                _context.Database.Migrate();
                //CreateStoredProcedures();
                RunStartupStoredProcedures();
            }
            else
            {
                _context.Database.EnsureCreated();
            }
        }

        private void RunStartupStoredProcedures()
        {
            //TODO: Refactor
            //Add USERDATA FileGroup to DB
            _context.Database.ExecuteSqlRaw("IF NOT EXISTS (SELECT 1 FROM sys.filegroups WHERE name = 'USERDATA')\r\nALTER DATABASE WWImporters_CodeFirst\r\nADD FILEGROUP [USERDATA]");


            //TODO: Review the other DB scripts from WWI
            foreach ( string name in new StoredProcedureNames().SetupStoredProcedures )
            {
                _context.Database.ExecuteSqlRaw($@"EXECUTE [Application].{name};");
            }

        }

        ////Maybe the query parsed by ExecuteSqlRaw is not compatible?
        //private void CreateStoredProcedures()
        //{
        //    string scriptsDir = @"../wwimporters.infrastructure/Persistence/StoredProcedures/Scripts/";
        //    foreach (string fileName in Directory.GetFiles(scriptsDir))
        //    {
        //        Console.WriteLine(fileName);
        //        _context.Database.ExecuteSqlRaw(sql:File.ReadAllText(fileName));
        //    }
        //}

        private void DeleteStoredProcedures()
        {
            string[] spNames =
            {
                "Configuration_ApplyPartitioning",
                "Configuration_ApplyFullTextIndexing"
            };

            foreach (string name in spNames)
            {
                _context.Database.ExecuteSqlRaw($"DROP PROCEDURE [Application].{name};");
            }
        }

        public void Seed()
        {

        }

    }
}
