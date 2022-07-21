using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwimporters.infrastructure.Persistence
{
    public class WideWorldImportersContext : DbContext
    {
        public WideWorldImportersContext()
        {

        }

        public WideWorldImportersContext(DbContextOptions<WideWorldImportersContext> options) 
            : base(options)
        {

        }

    }
}
