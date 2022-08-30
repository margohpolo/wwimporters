using Microsoft.EntityFrameworkCore;

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
            }
            else
            {
                _context.Database.EnsureCreated();
            }
        }

        public void Seed()
        {

        }

    }
}
