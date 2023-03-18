using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace wwimporters.infrastructure.Helpers
{
    public static class GenericExtensions<TEntity> where TEntity : class
    {
        //public static DbSet<TEntity> GetDbSet(DbContext dbContext, string name)
        //{
        //    Type type = Assembly.GetExecutingAssembly()
        //        .GetTypes()
        //        .FirstOrDefault(t => t.Name == name);

        //    if (type is null)
        //    {
        //        Console.WriteLine("type not found");
        //    }
        //    else
        //    {

        //    }

        //    return dbContext.Set<type>(type.Name);

        //    //return dbContext.Set<TEntity>().Where(typeof(TEntity) == Assembly.GetExecutingAssembly()
        //    //    .GetTypes()
        //    //    .FirstOrDefault(t => t.Name == name));
        //}

    }
}
