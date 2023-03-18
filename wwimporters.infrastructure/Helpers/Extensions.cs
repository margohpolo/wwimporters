using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using wwimporters.infrastructure.Persistence;

namespace wwimporters.infrastructure.Helpers
{
    public static class Extensions
    {
        public static List<PropertyInfo> GetDbSetProperties(this WideWorldImportersContext context)
        {
            List<PropertyInfo> dbSetProperties = new List<PropertyInfo>();
            PropertyInfo[] properties = context.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Type setType = property.PropertyType;
                bool isDbSet = setType.IsGenericType && (typeof(DbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()) || setType.GetInterface(typeof(DbSet<>).FullName) != null);

                if (isDbSet)
                {
                    dbSetProperties.Add(property);
                }
            }
            return dbSetProperties;
        }
    }
}
